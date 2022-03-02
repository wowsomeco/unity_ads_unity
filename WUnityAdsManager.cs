using UnityEngine;
using UnityEngine.Advertisements;

namespace Wowsome.Ads {
  public class WUnityAdsManager : WAdsProviderBase, IUnityAdsInitializationListener {
    public UnityGameModel model;

    public override void InitAdsProvider(WAdSystem adSystem) {
      base.InitAdsProvider(adSystem);

      if (adSystem.IsDisabled.Value) return;

      bool testMode = true;

#if UNITY_EDITOR
      testMode = true;
#endif

      Advertisement.Initialize(model.GameId, testMode, this);
    }

    public void OnInitializationComplete() {
      InitAds();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message) {
      Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
  }
}