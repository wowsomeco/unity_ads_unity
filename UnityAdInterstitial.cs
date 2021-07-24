using UnityEngine;
using UnityEngine.Advertisements;

namespace Wowsome.Ads {
  public class UnityAdInterstitial : MonoBehaviour, IInterstitial {
    public int Order => data.showOrder;

    public Model data;

    public void InitInterstitial() {
      if (!Advertisement.isInitialized) {
        Advertisement.Initialize(data.GameId, false, true);
      } else {
        Advertisement.Load(data.PlacementId);
      }
    }

    public void UpdateInterstitial(float dt) { }

    public bool ShowInterstitial() {
      if (Advertisement.IsReady(data.PlacementId)) {
        Advertisement.Show();
        return true;
      }

      return false;
    }
  }
}
