using Oxygen.Backend;
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
    internal class Tagging
    {
        public static float TagAllCooldown;
        public static void TagAll()
        {
            if (PhotonNetwork.InRoom && RoomHelper.GetCurrentGameMode() == 2 && WristMenu.triggerDownR && Time.time > TagAllCooldown + 0.1f)
            {
                TagAllCooldown = Time.time + 0.01f;
                foreach (Player player in PhotonNetwork.PlayerListOthers)
                {
                    if (!RigManager.isTagged(RigManager.GetVRRigFromPlayer(player)))
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = RigManager.GetVRRigFromPlayer(player).transform.position + Vector3.up;
                        GorillaTagger.Instance.offlineVRRig.rightHandTransform.position = RigManager.GetVRRigFromPlayer(player).transform.position;
                        GorillaLocomotion.Player.Instance.rightControllerTransform.position = RigManager.GetVRRigFromPlayer(player).transform.position;
                        GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
{
                        player

});
                        GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
{
                        player
});

                        GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
{
                        player
});
                        GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
{
                        player
});
                        GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
{
                        player
});
                        GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
{
                        player
});
                        GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
{
                        player
});
                        GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
                        {
                        player
                        });
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                        Saftey.MaunelRpcFlush();

                    }
                }
            }
        }
        public static void TagAura()
        {
            if (PhotonNetwork.InRoom && RoomHelper.GetCurrentGameMode() == 2)
            {
                foreach(Player player in PhotonNetwork.PlayerListOthers)
                {
                    if (player != null)
                    {
                        if (Vector3.Distance(RigManager.GetVRRigFromPlayer(player).transform.position, GorillaTagger.Instance.offlineVRRig.transform.position) > GorillaGameManager.instance.tagDistanceThreshold)
                        {
                            GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
{
                        player

});
                            GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
    {
                        player
    });

                            GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
    {
                        player
    });
                            GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
    {
                        player
    });
                            GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
    {
                        player
    });
                            GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
    {
                        player
    });
                            GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
    {
                        player
    });
                            GorillaTagger.Instance.myVRRig.RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
                            {
                        player
                            });
                            Saftey.MaunelRpcFlush();
                        }
                    }
                }
            }
        }
        public static void AntiTagFreeze()
        {
            GorillaLocomotion.Player.Instance.disableMovement = false;
        }


        public static void UnTagAll()
        {
            if (PhotonNetwork.IsMasterClient && RoomHelper.GetCurrentGameMode() == 2 && ControllerInputPoller.TriggerFloat(UnityEngine.XR.XRNode.RightHand) == 1f)
            {
                foreach(GorillaTagManager gorillaTagManager in GameObject.FindObjectsOfType<GorillaTagManager>())
                {
                    if (gorillaTagManager != null)
                    {
                        foreach(Player py in PhotonNetwork.PlayerList)
                        {
                            gorillaTagManager.currentInfected.Remove(py);
                            gorillaTagManager.ClearInfectionState();
                        }
                    }
                }
            }
        }
        public static void UnTagAura()
        {
            if (PhotonNetwork.IsMasterClient && RoomHelper.GetCurrentGameMode() == 2)
            {
                foreach (GorillaTagManager gorillaTagManager in GameObject.FindObjectsOfType<GorillaTagManager>())
                {
                    if (gorillaTagManager != null)
                    {
                        foreach (Player py in PhotonNetwork.PlayerList)
                        {
                            if (Vector3.Distance(RigManager.GetVRRigFromPlayer(py).transform.position, GorillaTagger.Instance.offlineVRRig.transform.position) > GorillaGameManager.instance.tagDistanceThreshold)
                            {
                                gorillaTagManager.currentInfected.Remove(py);
                                gorillaTagManager.ClearInfectionState();
                            }
                        }
                    }
                }
            }
        }
        public static void MatAll()
        {
            if (RoomHelper.GetCurrentGameMode() == 2)
            {
                if (PhotonNetwork.IsMasterClient && ControllerInputPoller.TriggerFloat(UnityEngine.XR.XRNode.RightHand) == 1f)
                {
                    foreach (GorillaTagManager gorillaTagManager in GameObject.FindObjectsOfType<GorillaTagManager>())
                    {
                        if (gorillaTagManager != null)
                        {
                            foreach (Player py in PhotonNetwork.PlayerList)
                            {
                                if (RigManager.isTagged(RigManager.GetVRRigFromPlayer(py)))
                                {
                                    gorillaTagManager.AddInfectedPlayer(py);
                                    gorillaTagManager.currentInfected.Add(py);
                                }
                                else
                                {
                                    gorillaTagManager.currentInfected.Remove(py);
                                    gorillaTagManager.ClearInfectionState();
                                    gorillaTagManager.UpdateInfectionState();
                                }
                            }
                        }
                    }
                }
            }
            else if (RoomHelper.GetCurrentGameMode() == 3)
            {
                if (PhotonNetwork.IsMasterClient && ControllerInputPoller.TriggerFloat(UnityEngine.XR.XRNode.RightHand) == 1f)
                {
                    foreach (GorillaHuntManager gorillaHuntManager in GameObject.FindObjectsOfType<GorillaHuntManager>())
                    {
                        if (gorillaHuntManager != null)
                        {
                            foreach (Player py in PhotonNetwork.PlayerList)
                            {
                                gorillaHuntManager.currentHunted.Add(py);
                                gorillaHuntManager.currentTarget.Add(py);
                                gorillaHuntManager.countDownTime = int.MaxValue;
                                gorillaHuntManager.HuntEnd();
                                gorillaHuntManager.CleanUpHunt();
                            }
                        }
                    }
                }
            }else if (RoomHelper.GetCurrentGameMode() == 4)
            {
                if (PhotonNetwork.IsMasterClient && ControllerInputPoller.TriggerFloat(UnityEngine.XR.XRNode.RightHand) == 1f)
                {
                    foreach (GorillaBattleManager gorillaBattleManager in GameObject.FindObjectsOfType<GorillaBattleManager>())
                    {
                        if (gorillaBattleManager != null)
                        {
                            foreach (Player py in PhotonNetwork.PlayerList)
                            {
                                gorillaBattleManager.playerLives[py.ActorNumber] = int.MaxValue;
                                gorillaBattleManager.playerHitTimes[py.ActorNumber] = -2147483648;
                                gorillaBattleManager.playerStunTimes[py.ActorNumber] = -2147483648;
                                gorillaBattleManager.playerHitTimes[py.ActorNumber] = int.MaxValue;
                                gorillaBattleManager.playerLives[py.ActorNumber] = -2147483648;
                                gorillaBattleManager.playerLivesArray[py.ActorNumber] = -2147483648;
                                gorillaBattleManager.BattleEnd();
                            }
                        }
                    }
                }
            }
        }
    }
}
