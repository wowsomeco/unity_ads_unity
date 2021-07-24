using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Wowsome.Ads {
  public class UnityAdReward : MonoBehaviour, IReward, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener {
    public Action OnRewarded { get; set; }
    public int Order => data.showOrder;

    public Model data;

    public void InitReward() {
      if (!Advertisement.isInitialized) {
        Advertisement.Initialize(data.GameId, true, true, this);
      } else {
        Load();
      }
    }

    public bool ShowReward() {
      if (!Advertisement.IsReady(data.PlacementId)) return false;

      Advertisement.Show(data.PlacementId, this);
      return true;
    }

    public void OnInitializationComplete() {
      Load();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message) { }

    public void OnUnityAdsAdLoaded(string placementId) { }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) {
      Load();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) {
      Load();
    }

    public void OnUnityAdsShowStart(string placementId) { }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) {
      if (placementId.CompareStandard(data.PlacementId) && showCompletionState == UnityAdsShowCompletionState.COMPLETED) {
        OnRewarded?.Invoke();
      }

      Load();
    }

    void Load() {
      Advertisement.Load(data.PlacementId, this);
    }
  }
}

