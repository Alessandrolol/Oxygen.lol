using Oxygen.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Oxygen.ModTypes
{
    internal class projectiles
    {
        public static GameObject ProjectileObj;
        public static void lp(Vector3 Pos, Vector3 Velocity, Color ProjColor, int Surface, string ProjectileName, string ProjectileID, bool UseRGB)
        {
            try
            {
                SnowballThrowable component = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/" + ProjectileName + "LeftAnchor").transform.Find(ProjectileID).GetComponent<SnowballThrowable>();
                component.randomizeColor = true;
                component.transform.position = Pos;
                if (ProjectileName == "FishFood")
                {
                    component.projectilePrefab = GameObject.Find("Environment Objects/05Maze_PersistentObjects/GlobalObjectPools/FishFoodProjectile(PoolIndex=16)");
                }
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Velocity;
                if (!UseRGB)
                {
                    GorillaTagger.Instance.offlineVRRig.SetThrowableProjectileColor(true, ProjColor);
                    component.randomizeColor = false;
                }
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/EquipmentInteractor").GetComponent<EquipmentInteractor>().ReleaseLeftHand();
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = GorillaTagger.Instance.GetComponent<Rigidbody>().velocity;
                if (UseRGB)
                {
                    component.randomizeColor = true;
                }
            }
            catch
            {
            }
        }
        public static void LaunchProjectile(Vector3 Pos, Vector3 Velocity, Color ProjColor, int Surface, string ProjectileName, string ProjectileID, bool UseRGB)
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 1f;
            ProjectileObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject.Destroy(ProjectileObj, 0.1f);
            ProjectileObj.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
            ProjectileObj.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
            ProjectileObj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            ProjectileObj.GetComponent<Renderer>().enabled = false;
            ProjectileObj.AddComponent<GorillaSurfaceOverride>().overrideIndex = Surface;
            if (true)
            {
                try
                {
                    SnowballThrowable component = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/" + ProjectileName + "LeftAnchor").transform.Find(ProjectileID).GetComponent<SnowballThrowable>();
                    component.randomizeColor = true;
                    component.transform.position = Pos;
                    if (ProjectileName == "FishFood")
                    {
                        component.projectilePrefab = GameObject.Find("Environment Objects/05Maze_PersistentObjects/GlobalObjectPools/FishFoodProjectile(PoolIndex=16)");
                    }
                    GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Velocity;
                    if (!UseRGB)
                    {
                        GorillaTagger.Instance.offlineVRRig.SetThrowableProjectileColor(true, ProjColor);
                        component.randomizeColor = false;
                    }
                    GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/EquipmentInteractor").GetComponent<EquipmentInteractor>().ReleaseLeftHand();
                    GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = GorillaTagger.Instance.GetComponent<Rigidbody>().velocity;
                    if (UseRGB)
                    {
                        component.randomizeColor = true;
                    }
                }
                catch
                {
                }
            }
        }
    }
}
