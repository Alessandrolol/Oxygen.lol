using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oxygen.ModTypes.Helpers
{
    internal class RigManager
    {
        public static PhotonView GetPhotonViewFromPlayer(Player py)
        {
            return GorillaGameManager.instance.FindVRRigForPlayer(py);
        }
        public static VRRig GetVRRigFromPlayer(Player py)
        {
            return GorillaGameManager.instance.FindPlayerVRRig(py);
        }
        public static bool isTagged(VRRig vr)
        {
            if (vr.mainSkin.material.color.ToString().Contains("fected"))
            {
                return true;
            }
            return false;
        }
        public static bool isDead(VRRig vr)
        {
            if (vr.mainSkin.material.color.ToString().Contains("Dead"))
            {
                return true;
            }
            return false;
        }
        public static bool IsHit(VRRig vr)
        {
            if (vr.mainSkin.material.color.ToString().Contains("hit"))
            {
                return true;
            }
            return false;
        }
    }
}
