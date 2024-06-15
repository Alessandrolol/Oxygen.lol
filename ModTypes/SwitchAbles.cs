using GTAG_NotificationLib;
using Oxygen.Backend;
using Oxygen.ModTypes.Helpers;
using Oxygen.UI;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oxygen.ModTypes
{
    internal class SwitchAbles
    {
        public static int OrbType = 0; // Default is zero 0 is Orb 1 is Linear 2 is Orb A & Linear
        public static int SkeletonEspType = 0;
        public static int EspType = 0;
        public static void ESPColorChanger(string ButtonName)
        {
            EspType++;
            if (EspType > 4)
            {
                EspType = 0;
            }
            if (EspType == 0)
            {
                NotifiLib.SendNotification("Changed Esp Color Set To Tag");
            }
            else if (EspType == 1)
            {
                NotifiLib.SendNotification("Changed Esp Color Set To Hunt ESP");
            }
            else if (EspType == 2)
            {
                NotifiLib.SendNotification("Changed Esp Color Set To Battle");
            }
            else if (EspType == 3)
            {
                NotifiLib.SendNotification("Changed Esp Color Set To Menu Theme");
            }
            else if (EspType == 4)
            {
                NotifiLib.SendNotification("Changed Esp Color Set To Player Color");
            }
            Mods.GetButton(ButtonName).enabled = new bool?(false);
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void SkeletonEspTypeChanger(string ButtonName)
        {
            SkeletonEspType++;
            if (SkeletonEspType > 4)
            {
                SkeletonEspType = 0;
            }
            if (SkeletonEspType == 0)
            {
                NotifiLib.SendNotification("Changed Skeleton Color Set To Tag");
            }
            else if (SkeletonEspType == 1)
            {
                NotifiLib.SendNotification("Changed Skeleton Color Set To Hunt ESP");
            }else if (SkeletonEspType == 2)
            {
                NotifiLib.SendNotification("Changed Skeleton Color Set To Battle");
            }
            else if (SkeletonEspType == 3)
            {
                NotifiLib.SendNotification("Changed Skeleton Color Set To Menu Theme");
            }else if (SkeletonEspType == 4)
            {
                NotifiLib.SendNotification("Changed Skeleton Color Set To Player Color");
            }
            Mods.GetButton(ButtonName).enabled = new bool?(false);
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void OrbTypeChanger(string ButtonName)
        {
            OrbType++;
            if (OrbType > 2)
            {
                OrbType = 0;
            }
            if (OrbType == 0)
            {
                GTAG_NotificationLib.NotifiLib.SendNotification("Changed orb Type to Orb");
            }else if (OrbType == 1)
            {
                NotifiLib.SendNotification("Changed orb Type to Linear");
            }else if (OrbType == 2)
            {
                NotifiLib.SendNotification("Changed orb Type to Orb & Linear");
            }
            Mods.GetButton(ButtonName).enabled = new bool?(false);
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

    }
}
