using UnityEngine;
using UnityEngine.Advertisements;

namespace Wowsome.Ads {
  public class WUnityAdsManager : WAdsProviderBase, IUnityAdsInitializationListener {
    public UnityGameModel model;

    public override void InitAdsProvider(WAdSystem adSystem) {
      base.InitAdsProvider(adSystem);

      if (adSystem.IsDisabled.Value || isDisabled) return;

      MetaData metaData = new MetaData("privacy");
      // This app is directed at children; no users will receive personalized ads.
      metaData.Set("mode", "app");
      Advertisement.SetMetaData(metaData);
      // init
      Advertisement.Initialize(model.GameId, isTestMode, this);
    }

    public void OnInitializationComplete() {
      InitAds();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message) {
      Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
  }
}