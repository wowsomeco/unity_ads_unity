using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Wowsome.Ads {
  public class UnityAdInterstitial : MonoBehaviour, IInterstitial {
    [Serializable]
    public struct Model {
      public string gameIdIOS;
      public string gameIdAndroid;
      public int showOrder;

      public string GameId {
        get {
          string gameId = Application.platform == RuntimePlatform.Android ? gameIdAndroid : gameIdIOS;
          return gameId.Trim();
        }
      }
    }

    public Model data;

    #region IInterstitial
    public int Order => data.showOrder;

    public void InitInterstitial() {
      Advertisement.Initialize(data.GameId);
    }

    public void UpdateInterstitial(float dt) { }

    public bool ShowInterstitial() {
      if (Advertisement.IsReady()) {
        Advertisement.Show();
        return true;
      }
      return false;
    }
    #endregion
  }
}
