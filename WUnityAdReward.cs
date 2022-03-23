using System;
using UnityEngine;
using UnityEngine.Advertisements;
using Wowsome.Generic;

namespace Wowsome.Ads {
  public class WUnityAdReward : MonoBehaviour, IAd, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener {
    public int Priority => priority;
    public WObservable<bool> IsLoaded { get; private set; } = new WObservable<bool>(false);
    public AdType Type => AdType.Rewarded;

    public UnityPlacementModel data;
    public int priority;

    Action _onDone = null;

    public void InitAd(IAdsProvider provider) {
      Load();
    }

    public bool ShowAd(Action onDone = null) {
      if (!IsLoaded.Value) {
        Load();

        return false;
      }

      _onDone = onDone;

      Advertisement.Show(data.PlacementId, this);

      return true;
    }

    public void OnDisabled() { }

    #region Unity Ad Listeners

    public void OnInitializationComplete() {
      Load();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message) { }

    public void OnUnityAdsAdLoaded(string placementId) {
      IsLoaded.Next(true);
    }

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
        _onDone?.Invoke();
        _onDone = null;
      }

      Load();
    }

    #endregion

    void Load() {
      IsLoaded.Next(false);

      Advertisement.Load(data.PlacementId, this);
    }
  }
}

