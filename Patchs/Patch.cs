using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Oxygen.Patchs
{
    internal class Patch
    {
        [HarmonyPatch(typeof(GorillaNot), "SendReport")]
        internal class AntiCheat : MonoBehaviour
        {
            private static bool Prefix(string susReason, string susId, string susNick)
            {
                if (susId == PhotonNetwork.LocalPlayer.UserId)
                {
                    NotifiLib.SendNotification("<color=red>GorillaNot</color>" + " Reported You Reason: " + susReason);
                    susNick.Remove(PhotonNetwork.LocalPlayer.NickName.Length);
                    susId.Remove(PhotonNetwork.LocalPlayer.UserId.Length);
                    PhotonNetwork.Disconnect();
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(GorillaNot), "LogErrorCount")]
        public class NoLogErrorCount : MonoBehaviour
        {
            private static bool Prefix(string logString, string stackTrace, LogType type)
            {
                return false;
            }
        }

        [HarmonyPatch(typeof(GorillaNot), "CloseInvalidRoom")]
        public class NoCloseInvalidRoom : MonoBehaviour
        {
            private static bool Prefix()
            {
                return false;
            }
        }

        [HarmonyPatch(typeof(GorillaNot), "CheckReports", MethodType.Enumerator)]
        public class NoCheckReports : MonoBehaviour
        {
            private static bool Prefix()
            {
                return false;
            }
        }

        [HarmonyPatch(typeof(GorillaNot), "QuitDelay", MethodType.Enumerator)]
        public class NoQuitDelay : MonoBehaviour
        {
            private static bool Prefix()
            {
                return false;
            }
        }

        [HarmonyPatch(typeof(GorillaNot), "IncrementRPCCallLocal")]
        public class NoIncrementRPCCallLocal : MonoBehaviour
        {
            private static bool Prefix(PhotonMessageInfo infoWrapped, string rpcFunction)
            {
                // Debug.Log(info.Sender.NickName + " sent rpc: " + rpcFunction);
                return false;
            }
        }

        [HarmonyPatch(typeof(GorillaNot), "GetRPCCallTracker")]
        internal class NoGetRPCCallTracker : MonoBehaviour
        {
            private static bool Prefix()
            {
                return false;
            }
        }

        [HarmonyPatch(typeof(GorillaNot), "IncrementRPCCall", new Type[] { typeof(PhotonMessageInfo), typeof(string) })]
        public class NoIncrementRPCCall : MonoBehaviour
        {
            private static bool Prefix(PhotonMessageInfo info, string callingMethod = "")
            {
                return false;
            }
        }

        [HarmonyPatch(typeof(VRRig), "IncrementRPC", new Type[] { typeof(PhotonMessageInfo), typeof(string) })]
        public class NoIncrementRPC : MonoBehaviour
        {
            private static bool Prefix(PhotonMessageInfo info, string sourceCall)
            {
                return false;
            }
        }



        [HarmonyPatch(typeof(GorillaNetworkPublicTestsJoin))]
        [HarmonyPatch("GracePeriod", MethodType.Normal)]
        public class GracePeriod
        {
            static void Prefix()
            {
                return;
            }
        }
        [HarmonyPatch(typeof(GorillaNetworkPublicTestJoin2))]
        [HarmonyPatch("GracePeriod", MethodType.Normal)]
        public class GracePeriod2
        {
            static void Prefix()
            {
                return;
            }
        }
        [HarmonyPatch(typeof(GorillaNetworkPublicTestsJoin))]
        [HarmonyPatch("GracePeriod", MethodType.Enumerator)]
        public class GracePeriod3
        {
            static void Prefix()
            {
                return;
            }
        }
        [HarmonyPatch(typeof(GorillaNetworkPublicTestJoin2))]
        [HarmonyPatch("GracePeriod", MethodType.Enumerator)]
        public class GracePeriod4
        {
            static void Prefix()
            {
                return;
            }
        }
        [HarmonyPatch(typeof(GorillaNot))]
        [HarmonyPatch("DispatchReport", MethodType.Normal)]
        public class AntiDispatchReport
        {
            static void Prefix()
            {
                return;
            }
        }
        [HarmonyPatch(typeof(PlayFabClientInstanceAPI), "ReportPlayer", MethodType.Normal)]
        public class NoReportPlayer : MonoBehaviour
        {
            static bool Prefix(ReportPlayerClientRequest request, Action<ReportPlayerClientResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
            {
                return false;
            }
        }
        [HarmonyPatch(typeof(VRRig), "OnDisable")]
        internal class GhostPatch : MonoBehaviour
        {
            public static bool Prefix(VRRig __instance)
            {
                if (__instance == GorillaTagger.Instance.offlineVRRig)
                {
                    
                    return false;
                }
                return true;
            }
        }
    }
}
