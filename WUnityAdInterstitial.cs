using System;
using UnityEngine;
using UnityEngine.Advertisements;
using Wowsome.Generic;

namespace Wowsome.Ads {
  public class WUnityAdInterstitial : MonoBehaviour, IAd, IUnityAdsLoadListener, IUnityAdsShowListener {
    public int Priority => priority;
    public WObservable<bool> IsLoaded { get; private set; } = new WObservable<bool>(false);
    public AdType Type => AdType.Interstitial;

    public UnityPlacementModel data;
    public int priority;

    public void InitAd(IAdsProvider provider) {
      LoadAd();
    }

    public bool ShowAd(Action onDone = null) {
      if (IsLoaded.Value) {
        Advertisement.Show(data.PlacementId, this);

        return true;
      }

      LoadAd();

      return false;
    }

    public void OnDisabled() { }

    #region Unity Ad Listeners

    public void OnUnityAdsAdLoaded(string placementId) {
      IsLoaded.Next(true);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) {

    }

    public void OnUnityAdsShowStart(string placementId) {

    }

    public void OnUnityAdsShowClick(string placementId) {

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) {

    }

    #endregion

    void LoadAd() {
      Advertisement.Load(data.PlacementId, this);
    }
  }
}
