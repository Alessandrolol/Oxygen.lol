using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace Oxygen.Backend
{
    [HarmonyPatch(typeof(GorillaNot), "SendReport")]
    internal class anticheatnotif : MonoBehaviour
    {
        private static bool Prefix(string susReason, string susId, string susNick)
        {
            if (susId == PhotonNetwork.LocalPlayer.UserId)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=red>ANTICHEAT</color><color=white>] REPORTED FOR: " + susReason + "</color>");
            }
            return false;
        }
    }
}
