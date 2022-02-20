using UnityEngine;
using UnityEngine.Advertisements;

namespace Wowsome.Ads {
  public class UnityAdInterstitial : MonoBehaviour, IInterstitial, IUnityAdsLoadListener {
    public int Order => data.showOrder;

    public Model data;

    bool _isLoaded = false;

    public void InitInterstitial() {
      if (!Advertisement.isInitialized) {
        bool testMode = false;

#if UNITY_EDITOR
        testMode = true;
#endif

        Advertisement.Initialize(data.GameId, testMode);
      } else {
        Advertisement.Load(data.PlacementId, this);
      }
    }

    public void UpdateInterstitial(float dt) { }

    public bool ShowInterstitial() {
      if (_isLoaded) {
        Advertisement.Show(data.PlacementId);

        return true;
      }

      return false;
    }

    public void OnUnityAdsAdLoaded(string placementId) {
      _isLoaded = true;
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) {

    }
  }
}
