using BepInEx;
using dark.efijiPOIWikjek;
using ExitGames.Client.Photon;
using GorillaNetworking;
using GTAG_NotificationLib;
using Photon.Pun;
using Photon.Realtime;
using Oxygen.UI;
using Oxygen.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Application = UnityEngine.Application;
using Object = UnityEngine.Object;
using Text = UnityEngine.UI.Text;
using Oxygen.ModTypes;


namespace Oxygen.Backend
{
    internal class Mods : MonoBehaviour
    {
        public static void HeadSpin()
        {
            Head1 = true;
            if (Head1)
            {
                VRMap head = RigShit.GetOwnVRRig().head;
                head.trackingRotationOffset.y = head.trackingRotationOffset.y + 15f;
            }
        }
        public static void HeadSpinV2()
        {
            head2 = true;
            if (head2)
            {
                VRMap head = RigShit.GetOwnVRRig().head;
                head.trackingRotationOffset.z = head.trackingRotationOffset.z + 15f;
            }
        }
        public static void HeadSpinV3()
        {
            head3 = true;
            if (head3)
            {
                VRMap head = RigShit.GetOwnVRRig().head;
                head.trackingRotationOffset.x = head.trackingRotationOffset.x + 15f;
            }
        }
        public static void fix1()
        {
            if (Head1)
            {
                RigShit.GetOwnVRRig().head.trackingRotationOffset.y = 0f;
                Head1 = false;
            }
        }
        public static void fix2()
        {
            if (head2)
            {
                RigShit.GetOwnVRRig().head.trackingRotationOffset.z = 0f;
                head2 = false;
            }
        }
        public static void fix3()
        {
            if (head3)
            {
                RigShit.GetOwnVRRig().head.trackingRotationOffset.x = 0f;
                head3 = false;
            }
        }
        public static void fix4()
        {
            if (headback)
            {
                RigShit.GetOwnVRRig().head.trackingRotationOffset.y = 0f;
                headback = false;
            }
        }
        public static void fix5()
        {
            if (downhead)
            {
                RigShit.GetOwnVRRig().head.trackingRotationOffset.z = 0f;
                downhead = false;
            }
        }
        public static void backhead()
        {
            headback = true;
            if (headback)
            {
                GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 180f;
            }
        }
        public static void upsidedownhead()
        {
            downhead = true;
            if (downhead)
            {
                GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 180f;
            }
        }
        public static void WASD()
        {
            Transform cam = Camera.main.transform;
            GorillaTagger.Instance.rigidbody.useGravity = false;
            GorillaTagger.Instance.rigidbody.velocity = Vector3.zero;
            float NSpeed = FCMovmentSpeed * Time.deltaTime;
            if (UnityInput.Current.GetKey(KeyCode.LeftShift) || UnityInput.Current.GetKey(KeyCode.RightShift))
            {
                NSpeed *= 10f;
            }
            if (UnityInput.Current.GetKey(KeyCode.LeftArrow) || UnityInput.Current.GetKey(KeyCode.A))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.right * -1f * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.RightArrow) || UnityInput.Current.GetKey(KeyCode.D))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.right * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.UpArrow) || UnityInput.Current.GetKey(KeyCode.W))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.forward * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.DownArrow) || UnityInput.Current.GetKey(KeyCode.S))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.forward * -1f * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.Space) || UnityInput.Current.GetKey(KeyCode.PageUp))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.up * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.LeftControl) || UnityInput.Current.GetKey(KeyCode.PageDown))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.up * -1f * NSpeed;
            }
            if (UnityInput.Current.GetMouseButton(1))
            {
                Vector3 val = UnityInput.Current.mousePosition - previousMousePosition;
                float num2 = GorillaLocomotion.Player.Instance.transform.localEulerAngles.y + val.x * 0.3f;
                float num3 = GorillaLocomotion.Player.Instance.transform.localEulerAngles.x - val.y * 0.3f;
                cam.localEulerAngles = new Vector3(num3, num2, 0f);
            }
            previousMousePosition = UnityInput.Current.mousePosition;
        }
        public static void Platforms()
        {
            PlatformsThing(invisplat, stickyplatforms);
        }
        public static void Invisableplatforms()
        {
            PlatformsThing(true, false);
        }
        public static void Stickyplats()
        {
            PlatformsThing(false, true);
        }
        public static void invisstickyplats()
        {
            PlatformsThing(true, true);
        }
        public static void Noclip()
        {
            if (WristMenu.triggerDownR)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }
        public static void quit()
        {
            Application.Quit();
        }
        public static void LongArms()
        {
            longArms = true;
            if (longArms)
            {
                GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            }
        }
        public static void resetarms()
        {
            if (longArms)
            {
                GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
                longArms = false;
            }
        }
        public static void CustomBoards()
        {
            //GameObject.Find("motdtext").GetComponent<Text>().text = "Oxygen.lol"; // this is the text on the motd
            GameObject.Find("motd").GetComponent<Text>().text = "<color=white>" + WristMenu.MenuTitle + " </color>"; // this is the text at the top of the motd
            GameObject.Find("CodeOfConduct").GetComponent<Text>().text = "<color=white>Oxygen.lol</color>"; // this is the text at the top of the coc
            GameObject.Find("COC Text").GetComponent<Text>().text = "<color=white> uh plase </color>"; // this is the text on the coc
        }
        public static void Fly()
        {
            if (WristMenu.abuttonDown)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void fastFly()
        {
            if (WristMenu.abuttonDown)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 30f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void hellafastFly()
        {
            if (WristMenu.abuttonDown)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 60f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void slowFly()
        {
            if (WristMenu.abuttonDown)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 7f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void Ghostmonke()
        {
            if (right)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = !ghostMonke;
                if (ghostMonke)
                {
                    orb = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Object.Destroy(orb.GetComponent<Rigidbody>());
                    Object.Destroy(orb.GetComponent<SphereCollider>());
                    orb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    orb.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    orb2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Object.Destroy(orb2.GetComponent<Rigidbody>());
                    Object.Destroy(orb2.GetComponent<SphereCollider>());
                    orb2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    orb2.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    if (change8 == 1)
                    {
                        orb.GetComponent<Renderer>().material.color = Color.cyan;
                        orb2.GetComponent<Renderer>().material.color = Color.cyan;
                    }
                    if (change8 == 2)
                    {
                        orb.GetComponent<Renderer>().material.color = Color.red;
                        orb2.GetComponent<Renderer>().material.color = Color.red;
                    }
                    if (change8 == 3)
                    {
                        orb.GetComponent<Renderer>().material.color = Color.white;
                        orb2.GetComponent<Renderer>().material.color = Color.white;
                    }
                    if (change8 == 4)
                    {
                        orb.GetComponent<Renderer>().material.color = Color.green;
                        orb2.GetComponent<Renderer>().material.color = Color.green;
                    }
                    if (change8 == 5)
                    {
                        orb.GetComponent<Renderer>().material.color = Color.magenta;
                        orb2.GetComponent<Renderer>().material.color = Color.magenta;
                    }
                    if (change8 == 6)
                    {
                        orb.GetComponent<Renderer>().material.color = Color.cyan;
                        orb2.GetComponent<Renderer>().material.color = Color.cyan;
                    }
                    if (change8 == 7)
                    {
                        orb.GetComponent<Renderer>().material.color = Color.yellow;
                        orb2.GetComponent<Renderer>().material.color = Color.yellow;
                    }
                    if (change8 == 8)
                    {
                        orb.GetComponent<Renderer>().material.color = Color.black;
                        orb2.GetComponent<Renderer>().material.color = Color.black;
                    }
                    if (change8 == 9)
                    {
                        orb.GetComponent<Renderer>().material.color = Color.grey;
                        orb2.GetComponent<Renderer>().material.color = Color.grey;
                    }
                    if (change8 == 10)
                    {
                        GradientColorKey[] array = new GradientColorKey[7];
                        array[0].color = Color.red;
                        array[0].time = 0f;
                        array[1].color = Color.yellow;
                        array[1].time = 0.2f;
                        array[2].color = Color.green;
                        array[2].time = 0.3f;
                        array[3].color = Color.cyan;
                        array[3].time = 0.5f;
                        array[4].color = Color.cyan;
                        array[4].time = 0.6f;
                        array[5].color = Color.magenta;
                        array[5].time = 0.8f;
                        array[6].color = Color.red;
                        array[6].time = 1f;
                        Gradient gradient = new Gradient();
                        gradient.colorKeys = array;
                        float num = Mathf.PingPong(Time.time / 2f, 1f);
                        Color color = gradient.Evaluate(num);
                        orb.GetComponent<Renderer>().material.color = color;
                        orb2.GetComponent<Renderer>().material.color = color;
                    }
                    Object.Destroy(orb, Time.deltaTime);
                    Object.Destroy(orb2, Time.deltaTime);
                }
                if (WristMenu.ybuttonDown && !lastHit)
                {
                    ghostMonke = !ghostMonke;
                }
                lastHit = WristMenu.ybuttonDown;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = !Mods.ghostMonke;
                if (Mods.ghostMonke)
                {
                    Mods.orb = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Object.Destroy(Mods.orb.GetComponent<Rigidbody>());
                    Object.Destroy(Mods.orb.GetComponent<SphereCollider>());
                    Mods.orb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    Mods.orb.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    Mods.orb2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Object.Destroy(Mods.orb2.GetComponent<Rigidbody>());
                    Object.Destroy(Mods.orb2.GetComponent<SphereCollider>());
                    Mods.orb2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    Mods.orb2.transform.position = GorillaTagger.Instance.rightHandTransform.position;
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
                    Mods.orb.GetComponent<Renderer>().material.color = color;
                    Mods.orb2.GetComponent<Renderer>().material.color = color;
                    Object.Destroy(Mods.orb, Time.deltaTime);
                    Object.Destroy(Mods.orb2, Time.deltaTime);
                }
                if (WristMenu.bbuttonDown && !Mods.lastHit)
                {
                    Mods.ghostMonke = !Mods.ghostMonke;
                }
                Mods.lastHit = WristMenu.bbuttonDown;
            }
        }
        public static void GhostMonkeGUI()
        {
            Mods.GhostMonk();
            if (Mods.GhostMonkGUI)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                Mods.orb = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Object.Destroy(Mods.orb.GetComponent<Rigidbody>());
                Object.Destroy(Mods.orb.GetComponent<SphereCollider>());
                Mods.orb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                Mods.orb.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                Mods.orb2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Object.Destroy(Mods.orb2.GetComponent<Rigidbody>());
                Object.Destroy(Mods.orb2.GetComponent<SphereCollider>());
                Mods.orb2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                Mods.orb2.transform.position = GorillaTagger.Instance.rightHandTransform.position;
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
                Mods.orb.GetComponent<Renderer>().material.color = color;
                Mods.orb2.GetComponent<Renderer>().material.color = color;
                Object.Destroy(Mods.orb, Time.deltaTime);
                Object.Destroy(Mods.orb2, Time.deltaTime);
            }
        }
        public static void OffGhostMonkeGUI()
        {
            if (Mods.GhostMonkGUI)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                Mods.GhostMonkGUI = false;
            }
        }
        public static void Invis()
        {
            if (Mods.right)
            {
                if (Mods.invisMonke)
                {
                    GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(9999f, 9999f, 9999f);
                    Mods.orb = GameObject.CreatePrimitive(0);
                    Object.Destroy(Mods.orb.GetComponent<Rigidbody>());
                    Object.Destroy(Mods.orb.GetComponent<SphereCollider>());
                    Mods.orb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    Mods.orb.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Mods.orb2 = GameObject.CreatePrimitive(0);
                    Object.Destroy(Mods.orb2.GetComponent<Rigidbody>());
                    Object.Destroy(Mods.orb2.GetComponent<SphereCollider>());
                    Mods.orb2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    Mods.orb2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
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
                    Mods.orb.GetComponent<Renderer>().material.color = color;
                    Mods.orb2.GetComponent<Renderer>().material.color = color;
                    Object.Destroy(Mods.orb, Time.deltaTime);
                    Object.Destroy(Mods.orb2, Time.deltaTime);
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.headBodyOffset = (GorillaTagger.Instance.offlineVRRig.headBodyOffset = Vector3.zero);
                }
                if (WristMenu.ybuttonDown && !Mods.lastHit2)
                {
                    Mods.invisMonke = !Mods.invisMonke;
                }
                Mods.lastHit2 = WristMenu.ybuttonDown;
            }
            else
            {
                if (Mods.invisMonke)
                {
                    GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(9999f, 9999f, 9999f);
                    Mods.orb = GameObject.CreatePrimitive(0);
                    Object.Destroy(Mods.orb.GetComponent<Rigidbody>());
                    Object.Destroy(Mods.orb.GetComponent<SphereCollider>());
                    Mods.orb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    Mods.orb.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Mods.orb2 = GameObject.CreatePrimitive(0);
                    Object.Destroy(Mods.orb2.GetComponent<Rigidbody>());
                    Object.Destroy(Mods.orb2.GetComponent<SphereCollider>());
                    Mods.orb2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    Mods.orb2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
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
                    Mods.orb.GetComponent<Renderer>().material.color = color;
                    Mods.orb2.GetComponent<Renderer>().material.color = color;
                    Object.Destroy(Mods.orb, Time.deltaTime);
                    Object.Destroy(Mods.orb2, Time.deltaTime);
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.headBodyOffset = (GorillaTagger.Instance.offlineVRRig.headBodyOffset = Vector3.zero);
                }
                if (WristMenu.bbuttonDown && !Mods.lastHit2)
                {
                    Mods.invisMonke = !Mods.invisMonke;
                }
                Mods.lastHit2 = WristMenu.bbuttonDown;
            }
        }
        public static void InvisMonkeGUI()
        {
            Mods.InvisMonk();
            if (Mods.InvisMonkGUI)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(9999f, 9999f, 9999f);
                Mods.orb = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Object.Destroy(Mods.orb.GetComponent<Rigidbody>());
                Object.Destroy(Mods.orb.GetComponent<SphereCollider>());
                Mods.orb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                Mods.orb.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                Mods.orb2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Object.Destroy(Mods.orb2.GetComponent<Rigidbody>());
                Object.Destroy(Mods.orb2.GetComponent<SphereCollider>());
                Mods.orb2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                Mods.orb2.transform.position = GorillaTagger.Instance.rightHandTransform.position;
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
                Mods.orb.GetComponent<Renderer>().material.color = color;
                Mods.orb2.GetComponent<Renderer>().material.color = color;
                Object.Destroy(Mods.orb, Time.deltaTime);
                Object.Destroy(Mods.orb2, Time.deltaTime);
            }
        }
        public static void OffInvisMonkeGUI()
        {
            if (Mods.InvisMonkGUI)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = (GorillaTagger.Instance.offlineVRRig.headBodyOffset = Vector3.zero);
                Mods.InvisMonkGUI = false;
            }
        }
        public static void Tracers()
        {
            foreach (Player player in PhotonNetwork.PlayerListOthers)
            {
                PhotonView photonView = GorillaGameManager.instance.FindVRRigForPlayer(player);
                VRRig vrrig = GorillaGameManager.instance.FindPlayerVRRig(player);
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer && !photonView.IsMine && !vrrig.mainSkin.name.Contains("fected"))
                {
                    GameObject gameObject = new GameObject("Line");
                    LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
                    lineRenderer.startWidth = 0.01f;
                    lineRenderer.endWidth = 0.01f;
                    lineRenderer.positionCount = 2;
                    lineRenderer.useWorldSpace = true;
                    lineRenderer.SetPosition(0, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                    lineRenderer.SetPosition(1, vrrig.transform.position);
                    lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
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
                    lineRenderer.startColor = color;
                    lineRenderer.endColor = color;
                    Object.Destroy(gameObject, Time.deltaTime);
                }
            }
        }
        public static void Save()
        {
            GetButton("Save Config").enabled = new bool?(false);
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
            List<string> list = new List<string>();
            foreach (ButtonInfo buttonInfo in WristMenu.settingsbuttons)
            {
                bool? enabled = buttonInfo.enabled;
                bool flag = true;
                if (enabled.GetValueOrDefault() == true & enabled != null)
                {
                    list.Add(buttonInfo.buttonText);
                }
            }
            foreach (ButtonInfo button in WristMenu.buttons)
            {
                bool? enabled = button.enabled;
                bool flag = true;
                if (enabled.GetValueOrDefault() == true & enabled != null)
                {
                    list.Add(button.buttonText);
                }
            }
            Directory.CreateDirectory("Oxygen.Saves");
            File.WriteAllLines("Oxygen.Saves\\Saved_Settings.txt", list);
            string text4 = string.Concat(new string[]
            {
               Mods.change1.ToString(),
               "\n",
               Mods.change17.ToString(),
               "\n",
               SwitchAbles.OrbType.ToString(),
               "\n",
               SwitchAbles.EspType.ToString(),
               "\n",
               SwitchAbles.SkeletonEspType.ToString()
            });
            File.WriteAllText("Oxygen.Saves/Saved_Settings2.txt", text4.ToString());
            NotifiLib.SendNotification("<color=white>[</color><color=blue>SAVE</color><color=white>]</color> <color=white>Saved settings successfully!</color>");
        }
        public static void Load()
        {
            string[] array = File.ReadAllLines("Oxygen.Saves\\Saved_Settings.txt");
            foreach (string b in array)
            {
                foreach (ButtonInfo button in WristMenu.buttons)
                {
                    if (button.buttonText == b)
                    {
                        button.enabled = new bool?(true);
                    }
                }
                foreach (ButtonInfo buttonInfo in WristMenu.settingsbuttons)
                {
                    if (buttonInfo.buttonText == b)
                    {
                        buttonInfo.enabled = new bool?(true);
                    }
                }
            }
            try
            {
                string text3 = File.ReadAllText("Oxygen.Saves/Saved_Settings2.txt");
                string[] array4 = text3.Split(new string[] { "\n" }, StringSplitOptions.None);
                Mods.change1 = int.Parse(array4[0]) - 1;
                Mods.Changeplat();
                Mods.change17 = int.Parse(array4[1]) - 1;
                SwitchAbles.OrbType = int.Parse(array4[2]) - 1;
                SwitchAbles.EspType = int.Parse(array4[3]) - 1;
                SwitchAbles.SkeletonEspType = int.Parse(array4[4]) - 1;

            }
            catch
            {
            }
            Mods.GetButton("Load Config").enabled = new bool?(false);
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        private static void PlatformsThing(bool invis, bool sticky)
        {
            if (Mods.change1 == 1)
            {
                bool gripDownR2 = WristMenu.gripDownR;
                bool gripDownL2 = WristMenu.gripDownL;
                if (gripDownR2)
                {
                    if (!Mods.once_right && Mods.jump_right_local == null)
                    {
                        if (sticky)
                        {
                            Mods.jump_right_local = GameObject.CreatePrimitive(0);
                        }
                        else
                        {
                            Mods.jump_right_local = GameObject.CreatePrimitive((PrimitiveType)3);
                        }
                        if (invis)
                        {
                            Object.Destroy(Mods.jump_right_local.GetComponent<Renderer>());
                        }
                        Mods.jump_right_local.transform.localScale = Mods.scale;
                        Mods.jump_right_local.transform.position = new Vector3(0f, -0.01f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                        Mods.jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                        object[] array1 = new object[]
                        {
                        new Vector3(0f, -0.01f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
                        GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
                        };
                        RaiseEventOptions raiseEventOptions1 = new RaiseEventOptions
                        {
                            Receivers = 0
                        };
                        PhotonNetwork.RaiseEvent(70, array1, raiseEventOptions1, SendOptions.SendReliable);
                        Mods.once_right = true;
                        Mods.once_right_false = false;
                        ColorChanger colorChanger1 = Mods.jump_right_local.AddComponent<ColorChanger>();
                        colorChanger1.colors = new Gradient
                        {
                            colorKeys = Mods.colorKeysPlatformMonke
                        };
                        colorChanger1.Start();
                    }
                }
                else
                {
                    if (!Mods.once_right_false && Mods.jump_right_local != null)
                    {
                        GameObject.Destroy(Mods.jump_right_local.GetComponent<Collider>());
                        Rigidbody platr = Mods.jump_right_local.AddComponent(typeof(Rigidbody)) as Rigidbody;
                        platr.velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 5);
                        Object.Destroy(jump_right_local, 2.0f);
                        jump_right_local = null;
                        once_right = false;
                        once_right_false = true;
                        RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
                        {
                            Receivers = ReceiverGroup.Others
                        };
                        PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
                    }
                }
                if (gripDownL2)
                {
                    if (!Mods.once_left && Mods.jump_left_local == null)
                    {
                        if (sticky)
                        {
                            Mods.jump_left_local = GameObject.CreatePrimitive(0);
                        }
                        else
                        {
                            Mods.jump_left_local = GameObject.CreatePrimitive((PrimitiveType)3);
                        }
                        if (invis)
                        {
                            Object.Destroy(Mods.jump_left_local.GetComponent<Renderer>());
                        }
                        Mods.jump_left_local.transform.localScale = Mods.scale;
                        Mods.jump_left_local.transform.position = new Vector3(0f, -0.01f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                        Mods.jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                        object[] array2 = new object[]
                        {
                        new Vector3(0f, -0.01f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position,
                        GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
                        };
                        RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
                        {
                            Receivers = 0
                        };
                        PhotonNetwork.RaiseEvent(69, array2, raiseEventOptions3, SendOptions.SendReliable);
                        Mods.once_left = true;
                        Mods.once_left_false = false;
                        ColorChanger colorChanger2 = Mods.jump_left_local.AddComponent<ColorChanger>();
                        colorChanger2.colors = new Gradient
                        {
                            colorKeys = Mods.colorKeysPlatformMonke
                        };
                        colorChanger2.Start();
                    }
                }
                else
                {
                    if (!Mods.once_left_false && Mods.jump_left_local != null)
                    {
                        GameObject.Destroy(Mods.jump_left_local.GetComponent<Collider>());
                        Rigidbody comp = Mods.jump_left_local.AddComponent(typeof(Rigidbody)) as Rigidbody;
                        comp.velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 5);
                        Object.Destroy(jump_left_local, 2.0f);
                        jump_left_local = null;
                        once_left = false;
                        once_left_false = true;
                        RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
                        {
                            Receivers = ReceiverGroup.Others
                        };
                        PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
                    }
                }
                if (!PhotonNetwork.InRoom)
                {
                    for (int i = 0; i < Mods.jump_right_network.Length; i++)
                    {
                        Object.Destroy(Mods.jump_right_network[i]);
                    }
                    for (int j = 0; j < Mods.jump_left_network.Length; j++)
                    {
                        Object.Destroy(Mods.jump_left_network[j]);
                    }
                }
            }
            if (Mods.change1 == 2)
            {
                if (WristMenu.triggerDownR)
                {
                    if (!Mods.once_right && Mods.jump_right_local == null)
                    {
                        if (sticky)
                        {
                            Mods.jump_right_local = GameObject.CreatePrimitive(0);
                        }
                        else
                        {
                            Mods.jump_right_local = GameObject.CreatePrimitive((PrimitiveType)3);
                        }
                        if (invis)
                        {
                            Object.Destroy(Mods.jump_right_local.GetComponent<Renderer>());
                        }
                        Mods.jump_right_local.transform.localScale = Mods.scale;
                        Mods.jump_right_local.transform.position = new Vector3(0f, -0.01f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                        Mods.jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                        object[] array7 = new object[]
                        {
                        new Vector3(0f, -0.01f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
                        GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
                        };
                        RaiseEventOptions raiseEventOptions7 = new RaiseEventOptions
                        {
                            Receivers = 0
                        };
                        PhotonNetwork.RaiseEvent(70, array7, raiseEventOptions7, SendOptions.SendReliable);
                        Mods.once_right = true;
                        Mods.once_right_false = false;
                        ColorChanger colorChanger9 = Mods.jump_right_local.AddComponent<ColorChanger>();
                        colorChanger9.colors = new Gradient
                        {
                            colorKeys = Mods.colorKeysPlatformMonke
                        };
                        colorChanger9.Start();
                    }
                }
                else
                {
                    if (!Mods.once_right_false && Mods.jump_right_local != null)
                    {
                        Rigidbody platr = Mods.jump_right_local.AddComponent(typeof(Rigidbody)) as Rigidbody;
                        platr.velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 5);
                        Object.Destroy(jump_right_local, 2.0f);
                        jump_right_local = null;
                        once_right = false;
                        once_right_false = true;
                        RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
                        {
                            Receivers = ReceiverGroup.Others
                        };
                        PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
                    }
                }
                if (WristMenu.triggerDownL)
                {
                    if (!Mods.once_left && Mods.jump_left_local == null)
                    {
                        if (sticky)
                        {
                            Mods.jump_left_local = GameObject.CreatePrimitive(0);
                        }
                        else
                        {
                            Mods.jump_left_local = GameObject.CreatePrimitive((PrimitiveType)3);
                        }
                        if (invis)
                        {
                            Object.Destroy(Mods.jump_left_local.GetComponent<Renderer>());
                        }
                        Mods.jump_left_local.transform.localScale = Mods.scale;
                        Mods.jump_left_local.transform.position = new Vector3(0f, -0.01f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                        Mods.jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                        object[] array0 = new object[]
                        {
                        new Vector3(0f, -0.01f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position,
                        GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
                        };
                        RaiseEventOptions raiseEventOptions0 = new RaiseEventOptions
                        {
                            Receivers = 0
                        };
                        PhotonNetwork.RaiseEvent(69, array0, raiseEventOptions0, SendOptions.SendReliable);
                        Mods.once_left = true;
                        Mods.once_left_false = false;
                        ColorChanger colorChanger0 = Mods.jump_left_local.AddComponent<ColorChanger>();
                        colorChanger0.colors = new Gradient
                        {
                            colorKeys = Mods.colorKeysPlatformMonke
                        };
                        colorChanger0.Start();
                    }
                }
                else
                {
                    if (!Mods.once_left_false && Mods.jump_left_local != null)
                    {
                        Rigidbody comp = Mods.jump_left_local.AddComponent(typeof(Rigidbody)) as Rigidbody;
                        comp.velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 5);
                        Object.Destroy(jump_left_local, 2.0f);
                        jump_left_local = null;
                        once_left = false;
                        once_left_false = true;
                        RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
                        {
                            Receivers = ReceiverGroup.Others
                        };
                        PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
                    }
                }
                if (!PhotonNetwork.InRoom)
                {
                    for (int i = 0; i < Mods.jump_right_network.Length; i++)
                    {
                        Object.Destroy(Mods.jump_right_network[i]);
                    }
                    for (int j = 0; j < Mods.jump_left_network.Length; j++)
                    {
                        Object.Destroy(Mods.jump_left_network[j]);
                    }
                }
            }
        }
        public static ButtonInfo GetButton(string name)
        {
            foreach (ButtonInfo buttonInfo1 in WristMenu.buttons)
            {
                if (buttonInfo1.buttonText == name)
                {
                    return buttonInfo1;
                }
            }
            foreach (ButtonInfo buttonInfo1 in WristMenu.settingsbuttons)
            {
                if (buttonInfo1.buttonText == name)
                {
                    return buttonInfo1;
                }
            }
            return null;
        }
        public static void Settings()
        {
            WristMenu.settingsbuttons[0].enabled = new bool?(false);
            WristMenu.buttons[0].enabled = new bool?(false);
            Mods.inSettings = !Mods.inSettings;
            if (Mods.inSettings)
            {
                WristMenu.pageNumber = 0;
            }
            if (!Mods.inSettings)
            {
                WristMenu.pageNumber = 0;
            }
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void righthand()
        {
            Mods.right = true;
        }
        public static void GhostMonk()
        {
            Mods.GhostMonkGUI = true;
        }
        public static void InvisMonk()
        {
            Mods.InvisMonkGUI = true;
        }
        // DO NOT MESS WITH ANY OF THE THEME CHANGERS OR CHANGERS
        public static void Changeplat()
        {
            Mods.change1++;
            if (Mods.change1 > 2)
            {
                Mods.change1 = 1;
            }
            if (Mods.change1 == 1)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>PLATFORMS</color><color=white>] Enable Platforms: Grips</color>");
            }
            if (Mods.change1 == 2)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>PLATFORMS</color><color=white>] Enable Platforms: Triggers</color>");
            }
            Mods.GetButton("Change Platform Enable").enabled = new bool?(false);
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void ChangeFPS()
        {
            Mods.change3++;
            if (Mods.change3 > 2)
            {
                Mods.change3 = 1;
            }
            if (Mods.change3 == 1)
            {
                Mods.FPSPage = false;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>FPS & PAGE COUNTER</color><color=white>] Is Enabled: No</color>");
            }
            if (Mods.change3 == 2)
            {
                Mods.FPSPage = true;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>FPS & PAGE COUNTER</color><color=white>] Is Enabled: Yes</color>");
            }
            Mods.GetButton("Toggle FPS & Page Counter").enabled = new bool?(false);
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void Changemenu()
        {
            Mods.change6++;
            if (Mods.change6 > 2)
            {
                Mods.change6 = 1;
            }
            if (Mods.change6 == 1)
            {
                if (Mods.right)
                {
                    Mods.right = false;
                }
                NotifiLib.SendNotification("<color=white>[</color><color=blue>MENU LOCATION</color><color=white>] Current Location: Left Hand</color>");
            }
            if (Mods.change6 == 2)
            {
                Mods.right = true;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>MENU LOCATION</color><color=white>] Current Location: Right Hand</color>");
            }
            Mods.GetButton("Switch Menu Hands").enabled = new bool?(false);
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static bool inSettings = false;
        public static bool inVisuals = false;
        public static bool inMovement = false;
        public static bool inProjectile = false;
        public static bool inExploits = false;
        public static bool inPlayers = false;
        public static bool inSelf = false;
        public static bool inRoom = false;
        public static bool inSafety = false;

        public static GameObject orb;
        public static GameObject orb2;
        public static bool head3;
        public static bool fps;
        public static int ButtonSound = 67;
        public static bool invisplat = false;
        public static bool invisMonke = false;
        public static bool stickyplatforms = false;
        private static Vector3 scale = new Vector3(0.0125f, 0.28f, 0.3825f);
        public static int change1 = 1;
        public static int change2 = 1;
        public static int change3 = 1;
        public static int change4 = 1;
        public static int change6 = 1;
        public static int change7 = 1;
        public static int change8 = 1;
        public static int change9 = 1;
        public static int change10 = 1;
        public static int change11 = 1;
        public static int change12 = 1;
        public static int change13 = 1;
        public static int change14 = 1;
        public static int change15 = 1;
        public static int change16 = 1;
        public static int change17 = 1;
        public static bool longArms;
        public static bool GhostMonkGUI;
        public static bool InvisMonkGUI;
        public static bool ghostMonke = false;
        public static bool rightHand = false;
        public static bool Head1;
        public static bool head2;
        public static bool lastHit2;
        public static bool lastHit;
        public static bool right;
        public static float balll435342111;
        public static bool headback;
        public static bool downhead;
        public static GameObject pointer;
        public static LineRenderer Line;
        private static bool once_left;
        private static bool once_right;
        public static bool FPSPage;
        public static bool RGBMenu;
        public static Vector3 previousMousePosition;
        private static bool once_left_false;
        public static float FCMovmentSpeed = 6f;
        private static bool once_right_false;
        private static GameObject[] jump_left_network = new GameObject[9999];
        private static GameObject[] jump_right_network = new GameObject[9999];
        private static GameObject jump_left_local = null;
        private static GameObject jump_right_local = null;
        private static GradientColorKey[] colorKeysPlatformMonke = new GradientColorKey[4];
    }
    internal class random
    {
        internal static int Next(int length)
        {
            throw new NotImplementedException();
        }
    }
}

