using GorillaNetworking;
using GTAG_NotificationLib;
using Oxygen.Backend;
using Oxygen.ModTypes.Helpers;
using Oxygen.ModTypes.Helpers;
using Oxygen.UI;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Oxygen.ModTypes
{
    internal class Saftey
    {
        public static bool AntiBanRunned = false;
        public static void AntiMod()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig && vrrig.concatStringOfCosmeticsAllowed.Contains("LBAAK"))
                {
                    PhotonNetwork.Disconnect();
                    NotifiLib.SendNotification("<color=red>[AntiMod]</color> A Mod is in your game,disconnecting");
                }
            }
        }
        public static void FullAnticban()
        {
            if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
            {
                string playerName = PhotonNetwork.LocalPlayer.NickName;
                int playerNameLength = playerName.Length;
                string base64String = "LnNhYS0YQ";
                byte[] base64Data = Convert.FromBase64String(base64String);
                string decodedString = Encoding.UTF8.GetString(base64Data);
                string modifiedName = playerName;

                if (playerNameLength < 15)
                {
                    for (int i = 0; i < base64Data.Length; i++)
                    {
                        modifiedName += Convert.ToChar(base64Data[i] + 1);
                    }

                    StringBuilder sb = new StringBuilder();
                    foreach (char c in modifiedName.Reverse())
                    {
                        sb.Append(c);
                    }

                    modifiedName = sb.ToString();
                    UOxygenUtils.NameChanger(modifiedName);
                }
                else
                {
                    List<char> charList = new List<char>(playerName.ToCharArray());
                    charList.InsertRange(playerNameLength / 2, decodedString.ToCharArray());
                    modifiedName = new string(charList.ToArray());

                    char[] charArray = modifiedName.ToCharArray();
                    Array.Reverse(charArray);
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(-66.7989f, 12.5422f, -82.6815f);
            }
            while (!AntiBanRunned)
            {
                AntiBan();
                if (Mods.GetButton("AntiBan").enabled == new bool?(false))
                {
                    break;
                }
            }
        }
        public static void AntiBan()
        {
            if (PhotonNetwork.InRoom)
            {
                AntiBanRunned = true;
                var gn = GorillaNot.instance;
                Player pl = PhotonNetwork.LocalPlayer;
                VRRig vRRig = GorillaTagger.Instance.offlineVRRig;
                if (vRRig != null)
                {
                    gn.rpcCallLimit = int.MaxValue;
                    gn.rpcErrorMax = int.MaxValue;
                    gn.logErrorMax = int.MaxValue;
                    gn.OnPlayerLeftRoom(pl);
                    GorillaGameManager.instance.OnPlayerLeftRoom(pl);
                    PhotonNetwork.CleanRpcBufferIfMine(GorillaTagger.Instance.myVRRig);
                    PhotonNetwork.CleanRpcBufferIfMine(GorillaGameManager.instance.FindVRRigForPlayer(pl));
                    PhotonNetwork.LocalCleanPhotonView(RigManager.GetPhotonViewFromPlayer(pl));
                    PhotonNetwork.LocalCleanPhotonView(GorillaTagger.Instance.myVRRig);
                    PhotonNetwork.OpCleanActorRpcBuffer(pl.ActorNumber);
                    PhotonNetwork.OpCleanRpcBuffer(RigManager.GetPhotonViewFromPlayer(pl));
                    PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
                    PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID);
                    PhotonNetwork.RemoveBufferedRPCs(RigManager.GetPhotonViewFromPlayer(pl).ViewID);
                    PhotonNetwork.RemoveCallbackTarget(vRRig);
                    PhotonNetwork.RemoveCallbackTarget(RigManager.GetVRRigFromPlayer(pl));
                    PhotonNetwork.RemoveRPCs(pl);
                    PhotonNetwork.RemoveRPCs(RigManager.GetPhotonViewFromPlayer(pl));
                    PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
                    PhotonNetwork.OpRemoveCompleteCache();
                    PhotonNetwork.OpRemoveCompleteCacheOfPlayer(pl.ActorNumber);
                }
            }
        }
        public static void MaunelRpcFlush()
        {
            var gn = GorillaNot.instance;
            Player pl = PhotonNetwork.LocalPlayer;
            VRRig vRRig = GorillaTagger.Instance.offlineVRRig;
            PhotonNetwork.CleanRpcBufferIfMine(GorillaTagger.Instance.myVRRig);
            PhotonNetwork.CleanRpcBufferIfMine(GorillaGameManager.instance.FindVRRigForPlayer(pl));
            PhotonNetwork.LocalCleanPhotonView(RigManager.GetPhotonViewFromPlayer(pl));
            PhotonNetwork.LocalCleanPhotonView(GorillaTagger.Instance.myVRRig);
            PhotonNetwork.OpCleanActorRpcBuffer(pl.ActorNumber);
            PhotonNetwork.OpCleanRpcBuffer(RigManager.GetPhotonViewFromPlayer(pl));
            PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
            PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID);
            PhotonNetwork.RemoveBufferedRPCs(RigManager.GetPhotonViewFromPlayer(pl).ViewID);
            PhotonNetwork.RemoveCallbackTarget(vRRig);
            PhotonNetwork.RemoveCallbackTarget(RigManager.GetVRRigFromPlayer(pl));
            PhotonNetwork.RemoveRPCs(pl);
            PhotonNetwork.RemoveRPCs(RigManager.GetPhotonViewFromPlayer(pl));
            PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
            PhotonNetwork.OpRemoveCompleteCache();
            PhotonNetwork.OpRemoveCompleteCacheOfPlayer(pl.ActorNumber);
        }
        public static void AntiReport()
        {
            try
            {
                if (PhotonNetwork.InRoom)
                {
                    foreach (GorillaScoreBoard gorillaScoreBoard in GameObject.FindObjectsOfType<GorillaScoreBoard>())
                    {
                        foreach (GorillaPlayerScoreboardLine gpsbl in gorillaScoreBoard.lines)
                        {
                            if (gpsbl != null && gpsbl.linePlayer == NetworkSystem.Instance.LocalPlayer)
                            {
                                GameObject ReportButtonObj = gpsbl.reportButton.gameObject;
                                Transform Report = gpsbl.reportButton.transform;

                                if (Report != null && ReportButtonObj != null)
                                {
                                    foreach (VRRig vRRig in GameObject.FindObjectsOfType<VRRig>())
                                    {
                                        var Distance = 0.07f;
                                        var Distance1 = Vector3.Distance(vRRig.transform.position, Report.position);
                                        var Distance2 = Vector3.Distance(vRRig.rightHandTransform.position, Report.position);
                                        var Distance3 = Vector3.Distance(vRRig.leftHandTransform.position, Report.position);

                                        if (Distance1 <= Distance || Distance2 <= Distance || Distance3 <= Distance)
                                        {
                                            NotifiLib.SendNotification("Someone Tried Reporting you");
                                            PhotonNetwork.Disconnect();
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                else
                {
                       
                }
            }
            catch { }
        }
    }
}
