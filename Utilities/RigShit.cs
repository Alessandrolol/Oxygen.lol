using Photon.Pun;
using System;
using UnityEngine;
using Photon.Realtime;
using Oxygen.UI;
using GorillaLocomotion.Gameplay;
using HarmonyLib;

namespace dark.efijiPOIWikjek
{
    internal class RigShit : MonoBehaviour
    {
        public static PhotonView GetViewFromPlayer(Player p)
        {
            return WristMenu.rig2view(GorillaGameManager.instance.FindPlayerVRRig(p));
        }
        public static Player GetPlayerFromNetPlayer(NetPlayer p)
        {
            Player result = null;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.UserId == p.UserId)
                {
                    result = player;
                    break;
                }
            }
            return result;
        }
        public static VRRig GetVRRigFromPlayer(Player p)
        {
            return GorillaGameManager.instance.FindPlayerVRRig(p);
        }
        public static Player GetPlayerFromVRRig(VRRig p)
        {
            return RigShit.GetPhotonViewFromVRRig(p).Owner;
        }
        public static PhotonView GetPhotonViewFromVRRig(VRRig p)
        {
            return (PhotonView)Traverse.Create(p).Field("photonView").GetValue();
        }
        public static VRRig GetOwnVRRig()
        {
            return GorillaTagger.Instance.offlineVRRig;
        }
        public static VRRig GetRigFromPlayer(Player p)
        {
            return GorillaGameManager.instance.FindPlayerVRRig(p);
        }
        public static PhotonView GetViewFromRig(VRRig rig)
        {
            return WristMenu.rig2view(rig);
        }
        public static Player GetPlayerFromRig(VRRig rig)
        {
            return WristMenu.rig2view(rig).Owner;
        }
        public static GorillaRopeSwing GetPlayersRope(VRRig rig)
        {
            return (GorillaRopeSwing)Traverse.Create(rig).Field("currentRopeSwing").GetValue();
        }
        public static bool battleIsOnCooldown(VRRig rig)
        {
            return rig.mainSkin.material.name.Contains("hit");
        }
        public static Player GetRandomPlayer(bool includeSelf)
        {
            Player result;
            if (includeSelf)
            {
                result = PhotonNetwork.PlayerList[UnityEngine.Random.Range(0, PhotonNetwork.PlayerList.Length - 1)];
            }
            else
            {
                result = PhotonNetwork.PlayerListOthers[UnityEngine.Random.Range(0, PhotonNetwork.PlayerListOthers.Length - 1)];
            }
            return result;
        }
        internal static object GetViewFromRig(object value)
        {
            throw new NotImplementedException();
        }
    }
}
