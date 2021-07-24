using System;
using UnityEngine;

namespace Wowsome.Ads {
  [Serializable]
  public struct Model {
    public string GameId {
      get {
        string gameId = Application.platform == RuntimePlatform.Android ? gameIdAndroid : gameIdIOS;
        return gameId.Trim();
      }
    }

    public string PlacementId {
      get {
        string placementId = Application.platform == RuntimePlatform.Android ? placementIdAndroid : placementIdIOS;
        return placementId.Trim();
      }
    }

    public string gameIdIOS;
    public string gameIdAndroid;
    public string placementIdIOS;
    public string placementIdAndroid;
    public int showOrder;
  }
}