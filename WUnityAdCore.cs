using System;
using UnityEngine;

namespace Wowsome.Ads {
  [Serializable]
  public struct UnityGameModel {
    public string GameId {
      get {
        string gameId = Application.platform == RuntimePlatform.Android ? gameIdAndroid : gameIdIOS;
        return gameId.Trim();
      }
    }

    public string gameIdIOS;
    public string gameIdAndroid;
  }

  [Serializable]
  public struct UnityPlacementModel {
    public string PlacementId {
      get {
        string placementId = Application.platform == RuntimePlatform.Android ? placementIdAndroid : placementIdIOS;
        return placementId.Trim();
      }
    }

    public string placementIdIOS;
    public string placementIdAndroid;
  }
}