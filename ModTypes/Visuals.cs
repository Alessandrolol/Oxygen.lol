using GorillaNetworking;
using GTAG_NotificationLib;
using Oxygen.Backend;
using Oxygen.ModTypes.Helpers;
using Oxygen.UI;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Oxygen.ModTypes
{
    internal class Visuals
    {
        public static int[] bones = new int[] {
            4, 3, 5, 4, 19, 18, 20, 19, 3, 18, 21, 20, 22, 21, 25, 21, 29, 21, 31, 29, 27, 25, 24, 22, 6, 5, 7, 6, 10, 6, 14, 6, 16, 14, 12, 10, 9, 7
        };
        public static int TracerType = 0;
        public static void Beacons()
        {
            foreach (VRRig vRRig in GorillaParent.instance.vrrigs)
            {
                LineRenderer BeaconLine = vRRig.head.rigTarget.GetComponent<LineRenderer>();
                BeaconLine.startWidth = 0.025f;  
                GradientColorKey[] array = new GradientColorKey[7];
                array[0].color = Color.cyan;
                array[0].time = 0f;
                array[1].color = Color.black;
                array[1].time = 0.5f;
                array[2].color = Color.cyan;
                array[2].time = 1f;
                Gradient gradient = new Gradient();
                gradient.colorKeys = array;
                float num = Mathf.PingPong(Time.time / 2f, 1f);
                Color color = gradient.Evaluate(num);
                BeaconLine.material.color = color;
                BeaconLine.material.shader = Shader.Find("GUI/Text Shader");
                BeaconLine.SetPosition(0, vRRig.transform.position - new Vector3(0f, 9999f, 0f));
                BeaconLine.SetPosition(1, vRRig.transform.position + new Vector3(0, 9999f, 0));
                BeaconLine.material.color = color;
                BeaconLine.material.shader = Shader.Find("GUI/Text Shader");
                GameObject.Destroy(BeaconLine,Time.deltaTime);
            }
        }
        public static void Tracers()
        {
            if (TracerType == 0)
            {
                foreach (VRRig vRRig in GorillaParent.instance.vrrigs)
                {
                    GameObject tracerobj = new GameObject("Tracer");
                    LineRenderer TracerLine = tracerobj.AddComponent<LineRenderer>();
                    GradientColorKey[] array = new GradientColorKey[7];
                    array[0].color = Color.cyan;
                    array[0].time = 0f;
                    array[1].color = Color.black;
                    array[1].time = 0.5f;
                    array[2].color = Color.cyan;
                    array[2].time = 1f;
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = array;
                    float num = Mathf.PingPong(Time.time / 2f, 1f);
                    Color color = gradient.Evaluate(num);
                    TracerLine.startColor = color;
                    TracerLine.endColor = color;
                    TracerLine.startWidth = 0.2f;
                    TracerLine.endWidth = 0.2f;
                    TracerLine.SetPosition(0, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                    TracerLine.SetPosition(1, vRRig.transform.position);
                }
            }
            else if (TracerType == 1) {
                foreach (VRRig vRRig in GorillaParent.instance.vrrigs)
                {
                    GameObject tracerobj = new GameObject("Tracer");
                    LineRenderer TracerLine = tracerobj.AddComponent<LineRenderer>();
                    GradientColorKey[] array = new GradientColorKey[7];
                    array[0].color = Color.cyan;
                    array[0].time = 0f;
                    array[1].color = Color.black;
                    array[1].time = 0.5f;
                    array[2].color = Color.cyan;
                    array[2].time = 1f;
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = array;
                    float num = Mathf.PingPong(Time.time / 2f, 1f);
                    Color color = gradient.Evaluate(num);
                    TracerLine.startColor = color;
                    TracerLine.endColor = color;
                    TracerLine.startWidth = 0.2f;
                    TracerLine.endWidth = 0.2f;
                    TracerLine.SetPosition(0, GorillaLocomotion.Player.Instance.leftControllerTransform.position);
                    TracerLine.SetPosition(1, vRRig.transform.position);
                }
            }
            else if (TracerType == 2)
            {
                foreach (VRRig vRRig in GorillaParent.instance.vrrigs)
                {
                    GameObject tracerobj = new GameObject("Tracer");
                    LineRenderer TracerLine = tracerobj.AddComponent<LineRenderer>();
                    GradientColorKey[] array = new GradientColorKey[7];
                    array[0].color = Color.cyan;
                    array[0].time = 0f;
                    array[1].color = Color.black;
                    array[1].time = 0.5f;
                    array[2].color = Color.cyan;
                    array[2].time = 1f;
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = array;
                    float num = Mathf.PingPong(Time.time / 2f, 1f);
                    Color color = gradient.Evaluate(num);
                    TracerLine.startColor = color;
                    TracerLine.endColor = color;
                    TracerLine.startWidth = 0.2f;
                    TracerLine.endWidth = 0.2f;
                    TracerLine.SetPosition(0, GorillaLocomotion.Player.Instance.transform.position);
                    TracerLine.SetPosition(1, vRRig.transform.position);
                }
            }
        }
        public static void BoneEsp()
        {
            if (PhotonNetwork.InRoom)
            {
                if (SwitchAbles.SkeletonEspType == 0)
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            LineRenderer liner = vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
                            liner.startWidth = 0.025f;
                            liner.endWidth = 0.025f;

                            if (RigManager.isTagged(vrrig))
                            {
                                liner.startColor = Color.red;
                                liner.endColor = Color.red;
                            }
                            else
                            {
                                liner.startColor = Color.green;
                                liner.endColor = Color.green;
                            }

                            liner.material.shader = Shader.Find("GUI/Text Shader");

                            liner.SetPosition(0, vrrig.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f));
                            liner.SetPosition(1, vrrig.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f));

                            UnityEngine.Object.Destroy(liner, Time.deltaTime);
                            for (int i = 0; i < bones.Count<int>(); i += 2)
                            {
                                liner = vrrig.mainSkin.bones[bones[i]].gameObject.AddComponent<LineRenderer>();

                                liner.startWidth = 0.025f;
                                liner.endWidth = 0.025f;

                                if (RigManager.isTagged(vrrig))
                                {
                                    liner.startColor = Color.red;
                                    liner.endColor = Color.red;
                                }
                                else
                                {
                                    liner.startColor = Color.green;
                                    liner.endColor = Color.green;
                                }

                                liner.material.shader = Shader.Find("GUI/Text Shader");

                                liner.SetPosition(0, vrrig.mainSkin.bones[bones[i]].position);
                                liner.SetPosition(1, vrrig.mainSkin.bones[bones[i + 1]].position);

                                UnityEngine.Object.Destroy(liner, Time.deltaTime);
                            }
                        }
                    }
                }
                else if (SwitchAbles.SkeletonEspType == 1)
                {
                    foreach (Player player in PhotonNetwork.PlayerListOthers)
                    {
                        GorillaHuntManager ghm = GorillaGameManager.instance.gameObject.GetComponent<GorillaHuntManager>();
                        VRRig vrrig = RigManager.GetVRRigFromPlayer(player);
                        LineRenderer liner = vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
                        liner.startWidth = 0.025f;
                        liner.endWidth = 0.025f;

                        if (RigManager.isDead(vrrig))
                        {
                            liner.startColor = Color.blue;
                            liner.endColor = Color.blue;
                        }
                        if (ghm.GetTargetOf(player) == PhotonNetwork.LocalPlayer)
                        {
                            liner.startColor = Color.red;
                            liner.endColor = Color.red;
                        }
                        if (ghm.GetTargetOf(PhotonNetwork.LocalPlayer) == player)
                        {
                            liner.startColor = Color.green;
                            liner.endColor = Color.green;
                        }

                        liner.material.shader = Shader.Find("GUI/Text Shader");

                        liner.SetPosition(0, vrrig.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f));
                        liner.SetPosition(1, vrrig.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f));

                        UnityEngine.Object.Destroy(liner, Time.deltaTime);
                        for (int i = 0; i < bones.Count<int>(); i += 2)
                        {
                            liner = vrrig.mainSkin.bones[bones[i]].gameObject.AddComponent<LineRenderer>();

                            liner.startWidth = 0.025f;
                            liner.endWidth = 0.025f;
                            if (RigManager.isDead(vrrig))
                            {
                                liner.startColor = Color.blue;
                                liner.endColor = Color.blue;
                            }
                            if (ghm.GetTargetOf(player) == PhotonNetwork.LocalPlayer)
                            {
                                liner.startColor = Color.red;
                                liner.endColor = Color.red;
                            }
                            if (ghm.GetTargetOf(PhotonNetwork.LocalPlayer) == player)
                            {
                                liner.startColor = Color.green;
                                liner.endColor = Color.green;
                            }
                            liner.material.shader = Shader.Find("GUI/Text Shader");

                            liner.SetPosition(0, vrrig.mainSkin.bones[bones[i]].position);
                            liner.SetPosition(1, vrrig.mainSkin.bones[bones[i + 1]].position);

                            UnityEngine.Object.Destroy(liner, Time.deltaTime);
                        }
                    }
                }
                else if (SwitchAbles.SkeletonEspType == 2)
                {
                    foreach (Player player in PhotonNetwork.PlayerListOthers)
                    {
                        GorillaBattleManager gbm = GorillaGameManager.instance.gameObject.GetComponent<GorillaBattleManager>();
                        VRRig vrrig = RigManager.GetVRRigFromPlayer(player);
                        if (vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            LineRenderer liner = vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
                            liner.startWidth = 0.025f;
                            liner.endWidth = 0.025f;

                            if (RigManager.IsHit(vrrig))
                            {
                                liner.startColor = Color.red;
                                liner.endColor = Color.red;
                            }
                            if (gbm.OnBlueTeam(player))
                            {
                                liner.startColor = Color.blue;
                                liner.endColor = Color.blue;
                            }
                            if (gbm.OnRedTeam(player))
                            {
                                liner.startColor = Color.red;
                                liner.endColor = Color.red;
                            }


                            liner.material.shader = Shader.Find("GUI/Text Shader");

                            liner.SetPosition(0, vrrig.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f));
                            liner.SetPosition(1, vrrig.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f));

                            UnityEngine.Object.Destroy(liner, Time.deltaTime);
                            for (int i = 0; i < bones.Count<int>(); i += 2)
                            {
                                liner = vrrig.mainSkin.bones[bones[i]].gameObject.AddComponent<LineRenderer>();

                                liner.startWidth = 0.025f;
                                liner.endWidth = 0.025f;

                                if (RigManager.IsHit(vrrig))
                                {
                                    liner.startColor = Color.yellow;
                                    liner.endColor = Color.yellow;
                                }
                                if (gbm.OnBlueTeam(player))
                                {
                                    liner.startColor = Color.blue;
                                    liner.endColor = Color.blue;
                                }
                                if (gbm.OnRedTeam(player))
                                {
                                    liner.startColor = Color.red;
                                    liner.endColor = Color.red;
                                }

                                liner.material.shader = Shader.Find("GUI/Text Shader");

                                liner.SetPosition(0, vrrig.mainSkin.bones[bones[i]].position);
                                liner.SetPosition(1, vrrig.mainSkin.bones[bones[i + 1]].position);

                                UnityEngine.Object.Destroy(liner, Time.deltaTime);
                            }
                        }
                    }
                }
                else if (SwitchAbles.SkeletonEspType == 3)
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            LineRenderer liner = vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
                            liner.startWidth = 0.025f;
                            liner.endWidth = 0.025f;

                            GradientColorKey[] array = new GradientColorKey[7];
                            array[0].color = Color.cyan;
                            array[0].time = 0f;
                            array[1].color = Color.black;
                            array[1].time = 0.5f;
                            array[2].color = Color.cyan;
                            array[2].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = array;
                            float num = Mathf.PingPong(Time.time / 2f, 1f);
                            Color color = gradient.Evaluate(num);

                            liner.startColor = color;
                            liner.endColor = color;

                            liner.material.shader = Shader.Find("GUI/Text Shader");

                            liner.SetPosition(0, vrrig.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f));
                            liner.SetPosition(1, vrrig.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f));

                            UnityEngine.Object.Destroy(liner, Time.deltaTime);
                            for (int i = 0; i < bones.Count<int>(); i += 2)
                            {
                                liner = vrrig.mainSkin.bones[bones[i]].gameObject.AddComponent<LineRenderer>();

                                liner.startWidth = 0.025f;
                                liner.endWidth = 0.025f;

                                liner.startColor = color;
                                liner.endColor = color;

                                liner.material.shader = Shader.Find("GUI/Text Shader");

                                liner.SetPosition(0, vrrig.mainSkin.bones[bones[i]].position);
                                liner.SetPosition(1, vrrig.mainSkin.bones[bones[i + 1]].position);

                                UnityEngine.Object.Destroy(liner, Time.deltaTime);
                            }
                        }
                    }
                }
                else if (SwitchAbles.SkeletonEspType == 4)
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            LineRenderer liner = vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
                            liner.startWidth = 0.025f;
                            liner.endWidth = 0.025f;

                            Color color = vrrig.mainSkin.material.color;

                            liner.startColor = color;
                            liner.endColor = color;

                            liner.material.shader = Shader.Find("GUI/Text Shader");

                            liner.SetPosition(0, vrrig.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f));
                            liner.SetPosition(1, vrrig.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f));

                            UnityEngine.Object.Destroy(liner, Time.deltaTime);
                            for (int i = 0; i < bones.Count<int>(); i += 2)
                            {
                                liner = vrrig.mainSkin.bones[bones[i]].gameObject.AddComponent<LineRenderer>();

                                liner.startWidth = 0.025f;
                                liner.endWidth = 0.025f;

                                liner.startColor = color;
                                liner.endColor = color;

                                liner.material.shader = Shader.Find("GUI/Text Shader");

                                liner.SetPosition(0, vrrig.mainSkin.bones[bones[i]].position);
                                liner.SetPosition(1, vrrig.mainSkin.bones[bones[i + 1]].position);

                                UnityEngine.Object.Destroy(liner, Time.deltaTime);
                            }
                        }
                    }
                }
            }
        }
        public static void TracersChanger(string ButtonName)
        {
            TracerType++;
            if (TracerType > 2)
            {
                TracerType = 0;
            }
            if (TracerType == 0)
            {
                NotifiLib.SendNotification("Change Tracer Position To Right Hand");
            }
            else if (TracerType == 1)
            {
                NotifiLib.SendNotification("Change Tracer Position To Left Hand");
            }
            else if (TracerType == 2)
            {
                NotifiLib.SendNotification("Change Tracer Position To Body Position");
            }
            Mods.GetButton(ButtonName).enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void ESP()
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                VRRig vrrig = RigManager.GetVRRigFromPlayer(player);
                if (vrrig != null)
                {
                    if (SwitchAbles.EspType == 0)
                    {
                        if (RigManager.isTagged(vrrig))
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = Color.red;
                        }
                        else
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = Color.green;
                        }
                    }else if (SwitchAbles.EspType == 1)
                    {
                        GorillaHuntManager ghm = GorillaComputer.instance.gameObject.GetComponent<GorillaHuntManager>();
                        if (RigManager.isDead(vrrig))
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = Color.blue;
                        }
                        if (ghm.GetTargetOf(player) == PhotonNetwork.LocalPlayer)
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = Color.red;
                        }
                        if (ghm.GetTargetOf(PhotonNetwork.LocalPlayer) == player)
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = Color.green;
                        }
                    }else if (SwitchAbles.EspType == 2)
                    {
                        GorillaBattleManager gbm = GorillaComputer.instance.gameObject.GetComponent<GorillaBattleManager>();
                        if (RigManager.IsHit(vrrig))
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = Color.red;
                        }
                        if (gbm.OnBlueTeam(player))
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = Color.blue;
                        }
                        if (gbm.OnRedTeam(player))
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = Color.red;
                        }
                    }else if (SwitchAbles.EspType == 3)
                    {

                        GradientColorKey[] array = new GradientColorKey[7];
                        array[0].color = Color.cyan;
                        array[0].time = 0f;
                        array[1].color = Color.black;
                        array[1].time = 0.5f;
                        array[2].color = Color.cyan;
                        array[2].time = 1f;
                        Gradient gradient = new Gradient();
                        gradient.colorKeys = array;
                        float num = Mathf.PingPong(Time.time / 2f, 1f);
                        Color color = gradient.Evaluate(num);
                        vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                        vrrig.mainSkin.material.color = color;
                    }else if (SwitchAbles.EspType == 4)
                    {
                        vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    }
                }
            }
        }
        public static void BoxESP()
        {
            foreach (VRRig vRRig in GorillaParent.instance.vrrigs) 
            {
                GradientColorKey[] array = new GradientColorKey[7];
                array[0].color = Color.cyan;
                array[0].time = 0f;
                array[1].color = Color.black;
                array[1].time = 0.5f;
                array[2].color = Color.cyan;
                array[2].time = 1f;
                Gradient gradient = new Gradient();
                gradient.colorKeys = array;
                float num = Mathf.PingPong(Time.time / 2f, 1f);
                Color color = gradient.Evaluate(num);
                GameObject BoxEsp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                BoxEsp.transform.rotation = GorillaLocomotion.Player.Instance.transform.rotation;
                BoxEsp.transform.position = vRRig.transform.position;
                BoxEsp.GetComponent<Renderer>().material.color = color;
                GameObject.Destroy(BoxEsp.GetComponent<Collider>());
                GameObject.Destroy(BoxEsp, Time.deltaTime);
            }
        }
        public static void NameTags()
        {
            foreach (VRRig vRRig in GorillaParent.instance.vrrigs)
            {
            }
        }
    }
}
