using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oxygen.ModTypes.Helpers
{
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnJoinedRoom")]
    public class RoomJoinPatch
    {
        public static void Postfix(MonoBehaviourPunCallbacks __instance)
        {
            Saftey.AntiBanRunned = false;
            if (RoomHelper.Ismodded())
            {
                RoomHelper.IsClientInModded = true;
            }
            else
            {
                RoomHelper.IsClientInModded = false;
            }
        }
    }

    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnLeftRoom")]
    public class RoomLeftPatch
    {
        public static void Postfix(MonoBehaviourPunCallbacks __instance)
        {
            //Debug.Log(__instance.gameObject.name);
            RoomHelper.IsClientInModded = false;
        }
    }
    internal class RoomHelper
    {
        public static bool IsClientInModded = false;
        public static bool Ismodded()
        {
            return (PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED"));
        }
        public static int GetCurrentGameMode()
        {
            string photonroomgamemode = PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString(); ;
            if (photonroomgamemode.Contains("CASUAL"))
            {
                return 1;
            }
            if (photonroomgamemode.Contains("INFECTION"))
            {
                return 2;
            }
            if (photonroomgamemode.Contains("HUNT"))
            {
                return 3;
            }
            if (photonroomgamemode.Contains("BATTLE"))
            {
                return 4;
            }
            if (photonroomgamemode.Contains("ERROR") && GorillaGameManager.instance == null)
            {
                return 5;
            }

            return 10; // 10 == unknown
        }
        public static int GetIdfromGameMode(string GameMode)
        {
            string photonroomgamemode = GameMode;
            if (photonroomgamemode.Contains("CASUAL"))
            {
                return 1;
            }
            if (photonroomgamemode.Contains("INFECTION"))
            {
                return 2;
            }
            if (photonroomgamemode.Contains("HUNT"))
            {
                return 3;
            }
            if (photonroomgamemode.Contains("BATTLE"))
            {
                return 4;
            }
            if (photonroomgamemode.Contains("ERROR") && GorillaGameManager.instance == null)
            {
                return 5;
            }

            return 10; // 10 == unknown
        }
        public static string GetGameModefromid(int id)
        {
            if (id == 1)
            {
                return "CASUAL";
            }
            if (id == 2)
            {
                return "INFECTION";
            }
            if (id == 3)
            {
                return "HUNT";
            }
            if (id == 4)
            {
                return "BATTLE";
            }
            if (id == 5 && GorillaGameManager.instance == null)
            {
                return "ERROR";
            }
            return "Invailed";
        }
    }
}
