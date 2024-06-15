using GorillaNetworking;
using Photon.Pun;
using UnityEngine;

namespace Oxygen.ModTypes.Helpers
{
    internal class UOxygenUtils
    {
        public static void NameChanger(string newName)
        {
            GorillaComputer.instance.name = newName;
            GorillaComputer.instance.currentName = newName;
            PlayerPrefs.SetString("playerName", newName);
            GorillaComputer.instance.savedName = newName;
            PhotonNetwork.LocalPlayer.NickName = newName;
            PlayerPrefs.Save();
        }
    }
}
