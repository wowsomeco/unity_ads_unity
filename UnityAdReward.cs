using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Wowsome.Ads {
  public class UnityAdReward : MonoBehaviour, IReward, IUnityAdsLoadListener, IUnityAdsShowListener {
    [Serializable]
    public struct Model {
      public string GameId {
        get {
          string gameId = Application.platform == RuntimePlatform.Android ? gameIdAndroid : gameIdIOS;
          return gameId.Trim();
        }
      }

      public string gameIdIOS;
      public string gameIdAndroid;
      public string placementId;
      public int showOrder;
    }

    public Action OnRewarded { get; set; }

    public int Order => data.showOrder;

    public Model data;

    public void InitReward() {
      if (!Advertisement.isInitialized) {
        Advertisement.Initialize(data.GameId, this);
      }

      Advertisement.Load(data.placementId, this);
    }

    public bool ShowReward() {
      if (!Advertisement.IsReady()) {
        return false;
      }

      Advertisement.Show(data.placementId);
      return true;
    }

    public void OnUnityAdsAdLoaded(string placementId) { }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) {
      Advertisement.Load(data.placementId, this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) {
      Advertisement.Load(data.placementId, this);
    }

    public void OnUnityAdsShowStart(string placementId) { }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) {
      if (data.placementId.CompareStandard(placementId)) {
        OnRewarded?.Invoke();
      }
    }
  }
}

