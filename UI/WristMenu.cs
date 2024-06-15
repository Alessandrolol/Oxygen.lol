using Oxygen.Backend;
using Oxygen.UI;
using Oxygen.Utilities;
using HarmonyLib;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Text = UnityEngine.UI.Text;
using static System.Net.Mime.MediaTypeNames;
using Viveport;
using Oxygen.ModTypes;


namespace Oxygen.UI
{
    public class ButtonInfo
    {
        public string buttonText = "Error";
        public Action method = null;
        public Action disableMethod = null;
        public bool? enabled = false;
        public string toolTip = "This button doesn't have a tooltip/tutorial";
    }
    internal class WristMenu : MonoBehaviour
    {
        public static void Disconnect()
        {
            PhotonNetwork.Disconnect();
            Mods.GetButton("Disconnect").enabled = new bool?(false);
        }
        public static PhotonView rig2view(VRRig p)
        {
            return (PhotonView)Traverse.Create(p).Field("photonView").GetValue();
        }
        public static List<ButtonInfo> settingsbuttons = new List<ButtonInfo> // settings
        {
            new ButtonInfo { buttonText = "Exit Settings", method =() => Mods.Settings(), enabled = false, toolTip = "Go To Main!"},
            new ButtonInfo { buttonText = "Switch Menu Hands", method =() => Mods.Changemenu(), enabled = false, toolTip = "Switches the menu location on your hands!"},
            new ButtonInfo { buttonText = "Switch Tracer Location", method =() => Visuals.TracersChanger("Switch Tracer Location"), enabled = false, toolTip = "Switches the Tracers Locations (Right Hand,Left Hand,Body Position)!"},
            new ButtonInfo { buttonText = "Gun Orb Changer", method =() => SwitchAbles.OrbTypeChanger("Gun Orb Changer"), enabled = false, toolTip = "Switches the Gun orb Type (Linear,Orb,Linear & Orb)!"},
            new ButtonInfo { buttonText = "Switch Skeleton Esp Color", method =() => SwitchAbles.SkeletonEspTypeChanger("Switch Skeleton Esp Color"), enabled = false, toolTip = "Switches the Skeleton Esp Color (Tag Esp,Hunt Esp,Battle Esp,Menu Theme,Player Color)!"},
            new ButtonInfo { buttonText = "Switch Esp Color", method =() => SwitchAbles.ESPColorChanger("Switch Esp Color"), enabled = false, toolTip = "Switches the Esp Color (Tag Esp,Hunt Esp,Battle Esp,Menu Theme,Player Color)!"},
        };
        public static List<ButtonInfo> buttons = new List<ButtonInfo> // main
        {
            new ButtonInfo { buttonText = "Settings", method =() => Mods.Settings(), enabled = false, toolTip = "Go to Settings!"},
            new ButtonInfo { buttonText = "Save Config", method =() => Mods.Save(), enabled = true, toolTip = "Saves All Button actives!"},
            new ButtonInfo { buttonText = "Load Config", method =() => Mods.Load(), enabled = false, toolTip = "Load All Button Actives!"},
            new ButtonInfo { buttonText = "Settings", method =() => Mods.Settings(), enabled = false, toolTip = "Go to Settings!"},
            //infection Mods:;1
            new ButtonInfo { buttonText = "Tag All[RT]",enabled = false, method =() => Tagging.TagAll(), toolTip = "Tags Everyone!"},
            new ButtonInfo { buttonText = "Tag Gun", enabled = false, method =() => Tagging.TagAura(), toolTip = "Tags A Person!"},
            new ButtonInfo { buttonText = "Tag Aura", enabled = false, method =() => Tagging.TagAura(), toolTip = "Tags Everyone Around You!"},
            new ButtonInfo { buttonText = "AntiTag Freeze", enabled = false,method =() => GorillaLocomotion.Player.Instance.disableMovement = false, toolTip = "Anti Tag Freeze!"},
            //infection Mods:;2
            new ButtonInfo { buttonText = "UnTag All [RT][M]",enabled = false, method =() => Tagging.UnTagAll(), toolTip = "UnInfects Everyone!"},
            new ButtonInfo { buttonText = "UnTag Gun [M]", enabled = false, method =() => Tagging.UnTagAura(), toolTip = "UnInfects A Person!"},
            new ButtonInfo { buttonText = "UnTag Aura [M]", enabled = false, method =() => Tagging.UnTagAura(), toolTip = "UnInfects Everyone Around You!"},
            new ButtonInfo { buttonText = "Mat All [M] [D?]", enabled = false,method =() => Tagging.MatAll(), toolTip = "Changes Everyone's Material Very Fast!"},
            new ButtonInfo { buttonText = "Mat Gun [M] [D?]", enabled = false,method =() => GorillaLocomotion.Player.Instance.disableMovement = false, toolTip = "Changes A Person's Material Very Fast!"},
            //Room Mods
            new ButtonInfo { buttonText = "AntiBan[Stump?]", method =() => Saftey.FullAnticban(), enabled = false, toolTip = "Tries To Prevent You From Getting Banned, Teleports you there too!"},
            new ButtonInfo { buttonText = "AntiReport", method =() => Saftey.AntiReport(), enabled = true, toolTip = "Tries To Prevent You From Getting Report Banned!"},
            new ButtonInfo { buttonText = "Anti Moderator", method =() => Saftey.AntiMod(), enabled = true, toolTip = "Prevents From being in a room with a moderator!"},
            new ButtonInfo { buttonText = "Disconnect", method =() => Disconnect(), enabled = false, toolTip = "Leaves Your Current Room"},
            //visuals
            new ButtonInfo { buttonText = "Beacons", method =() => Visuals.Beacons(), enabled = true, toolTip = "Spawns a Beacons On Top Of Peoples Head!"},
            new ButtonInfo { buttonText = "Tracers", method =() => Visuals.Tracers(), enabled = false, toolTip = "Spawns A line on your hand then chases people!"},
            new ButtonInfo { buttonText = "Esp", method =() => Visuals.ESP(), enabled = false, toolTip = "Makes the player a shader!"},
            new ButtonInfo { buttonText = "Skeleton Esp", method =() => Visuals.BoneEsp(), enabled = false, toolTip = "Shos Player Skeletons!"},

        };
        public static List<ButtonInfo> VisualButtons = new List<ButtonInfo>
        {
             
        };
        public static List<ButtonInfo> SelfButtons = new List<ButtonInfo>
        {

        };
        public static List<ButtonInfo> PlayersButtons = new List<ButtonInfo>
        {

        };
        public static List<ButtonInfo> ProjectileButtons = new List<ButtonInfo>
        {

        };
        public static List<ButtonInfo> MovementButtons = new List<ButtonInfo>
        {

        };
        public static List<ButtonInfo> RoomButtons = new List<ButtonInfo>
        {

        };
        public static List<ButtonInfo> Exploits = new List<ButtonInfo>
        {

        };
        public static List<ButtonInfo> SafetyButtons = new List<ButtonInfo>
        {

        };
        public static bool ChangingColors = true; 
        public static Color FirstColor = Color.cyan; 
        public static Color SecondColor = Color.black; 
        public static Color NormalColor = Color.white; 
        public static Color ButtonColorDisable = Color.yellow; 
        public static Color ButtonColorEnabled = Color.magenta;
        public static Color EnableTextColor = Color.black; 
        public static Color DIsableTextColor = Color.black;

        public static Vector3 MenuScale = new Vector3(0.1f, 1f, 1f) * 1f; 
        public static Vector3 MenuPos = new Vector3(0.05f, 0f, 0f) * 1f; 
        public static Vector3 PointerScale = new Vector3(0.01f, 0.01f, 0.01f);
        public static Vector3 PointerPos = new Vector3(0f, -0.1f, 0f); 
        public static Vector3 ToolTipPos = new Vector3(0.06f, 0f, -0.18f) * 1f; 
        public static Vector2 ToolTipScale = new Vector2(0.2f, 0.03f) * 1f; 
        public static Vector3 MenuTitlePos = new Vector3(0.06f, 0f, 0.175f); 
        public static Vector2 MenuTitleScale = new Vector2(0.28f, 0.05f); 
        public static Vector3 ButtonScale = new Vector3(0.09f, 0.8f, 0.08f); 
        public static Vector2 ButtonTextScale = new Vector2(0.2f, 0.03f) * 1f; 

        public static int ClickCooldown = 10; 
        public static int MaxNotis = 5; 
        public static string MenuTitle = "Oxygen.lol"; 
        public static Color MenuTitleColor = Color.white; 
        public static Color ToolTipColor = Color.white; 
        public static Color DisconnectButtonColor = Color.red; 
        public static Color DisconnectTextColor = Color.white; 
        public static Color NextPrevButtonColor = Color.black; 
        public static Color NextPrevTextColor = Color.white; 

        public static bool gripDownR;
        public static bool triggerDownR; 
        public static bool abuttonDown;
        public static bool bbuttonDown; 
        public static bool xbuttonDown; 
        public static bool ybuttonDown; 
        public static bool gripDownL; 
        public static bool triggerDownL; 

        private static int lastPressedButtonIndex = -1;
        public static GameObject menu = null;
        private static GameObject canvasObj = null;
        private static GameObject reference = null;
        public static int pageNumber = 0;
        public static WristMenu instance = new WristMenu();
        public static GameObject menuObj;
        public static int selectedButton = 1;
        private static Text tooltipText;
        private static string tooltipString;
        public static bool toggle = false;
        public static bool toggle1 = false;
        public static bool toggle2 = false;
        public static bool toggle3 = false;
        private static int pageSize = 4;
        public static bool toggle4 = false;
        void Update()
        {
            try
            {
                if (Time.time > Mods.balll435342111 + 0.1f && Mods.FPSPage)
                {
                    Mods.balll435342111 = Time.time;
                    int num = Mathf.RoundToInt(1f / Time.deltaTime);
                    titiel.text = MenuTitle + string.Format("\n Fps: {0} | Page: {1}", num, pageNumber + 1);
                }
                gripDownL = ControllerInputPoller.instance.leftGrab;
                gripDownR = ControllerInputPoller.instance.rightGrab;
                triggerDownL = ControllerInputPoller.instance.leftControllerIndexFloat == 1f;
                triggerDownR = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
                abuttonDown = ControllerInputPoller.instance.rightControllerPrimaryButton;
                bbuttonDown = ControllerInputPoller.instance.rightControllerSecondaryButton;
                xbuttonDown = ControllerInputPoller.instance.leftControllerPrimaryButton;
                ybuttonDown = ControllerInputPoller.instance.leftControllerSecondaryButton;
                if (Mods.change7 == 5 && !menu.GetComponent<Rigidbody>())
                {
                    if (triggerDownL)
                    {
                        if (!toggle)
                        {
                            Toggle("PreviousPage");
                            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(Mods.ButtonSound, false, 0.1f);
                            toggle = true;
                        }
                    }
                    else
                    {
                        toggle = false;
                    }
                    if (triggerDownR)
                    {
                        if (!toggle1)
                        {
                            Toggle("NextPage");
                            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(Mods.ButtonSound, false, 0.1f);
                            toggle1 = true;
                        }
                    }
                    else
                    {
                        toggle1 = false;
                    }
                }
                // stuff for left hand menu
                if (ybuttonDown && !Mods.right)
                {
                    if (menu == null)
                    {
                        instance.Draw();
                    }
                    else if (!Mods.right)
                    {
                        menu.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position; // moves the menu to your left hand
                        menu.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                        if (reference == null)
                        {
                            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            reference.name = "buttonPresser";
                        }
                        reference.transform.parent = GorillaLocomotion.Player.Instance.rightControllerTransform; // attaches the pointer to your right hand
                        reference.transform.localPosition = PointerPos; // moves it out a lil
                        reference.transform.localScale = PointerScale; // makes it small
                        // makes the pointer follow the color of the menu
                        if (ChangingColors)
                        {
                            reference.GetComponent<Renderer>().material.color = FirstColor;
                        }
                        else
                        {
                            reference.GetComponent<Renderer>().material.color = NormalColor;
                        }
                    }
                    if (menu.GetComponent<Rigidbody>())
                    {
                        Object.Destroy(menu.GetComponent<Rigidbody>());
                    }
                }
                else if (!ybuttonDown && !Mods.right && !menu.GetComponent<Rigidbody>())
                {
                    // this makes the menu throwable
                    Object.Destroy(reference);
                    reference = null;
                    menu.AddComponent<Rigidbody>();
                    menu.GetComponent<Rigidbody>().isKinematic = false;
                    menu.GetComponent<Rigidbody>().useGravity = true;
                    menu.GetComponent<Rigidbody>().velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0f, false);
                }
                // stuff for right hand menu
                if (bbuttonDown && Mods.right)
                {
                    if (menu == null)
                    {
                        instance.Draw();
                    }
                    else if (Mods.right)
                    {
                        menu.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                        menu.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                        menu.transform.RotateAround(menu.transform.position, menu.transform.forward, 180f);
                        if (reference == null)
                        {
                            reference = GameObject.CreatePrimitive(0);
                            reference.name = "buttonPresser";
                        }
                        reference.transform.parent = GorillaLocomotion.Player.Instance.leftControllerTransform;
                        reference.transform.localPosition = PointerPos;
                        reference.transform.localScale = PointerScale;
                        if (ChangingColors)
                        {
                            reference.GetComponent<Renderer>().material.color = FirstColor;
                        }
                        else
                        {
                            reference.GetComponent<Renderer>().material.color = NormalColor;
                        }
                    }
                    if (menu.GetComponent<Rigidbody>())
                    {
                        Object.Destroy(menu.GetComponent<Rigidbody>());
                    }
                }
                else if (!abuttonDown && Mods.right && !menu.GetComponent<Rigidbody>())
                {
                    Object.Destroy(reference);
                    reference = null;
                    menu.AddComponent<Rigidbody>();
                    menu.GetComponent<Rigidbody>().isKinematic = false;
                    menu.GetComponent<Rigidbody>().useGravity = true;
                    menu.GetComponent<Rigidbody>().velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0f, false);
                }
                // random shit 9
                foreach (ButtonInfo buttonInfo in settingsbuttons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in buttons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in VisualButtons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in MovementButtons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in Exploits)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in RoomButtons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in SelfButtons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in PlayersButtons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in ProjectileButtons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in SafetyButtons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
            }
            catch { }
        }
        private static string GetButtonTooltip(int index)
        {
            if (Mods.inSettings) // makes tooltips for mods in settings
            {

                ButtonInfo buttonInfo = settingsbuttons[index];
                return $"{buttonInfo.buttonText}: {buttonInfo.toolTip}";
            }
            else
            {
                if (Mods.inVisuals) // makes tooltips for mods in category 1
                {
                    ButtonInfo buttonInfoo = VisualButtons[index];
                    return $"{buttonInfoo.buttonText}: {buttonInfoo.toolTip}";
                }
                if (Mods.inMovement) // makes tooltips for mods in category 2
                {
                    ButtonInfo buttonInfoo = MovementButtons[index];
                    return $"{buttonInfoo.buttonText}: {buttonInfoo.toolTip}";
                }
                if (Mods.inExploits) // makes tooltips for mods in category 3
                {
                    ButtonInfo buttonInfoo = Exploits[index];
                    return $"{buttonInfoo.buttonText}: {buttonInfoo.toolTip}";
                }
                if (Mods.inPlayers) // makes tooltips for mods in category 4
                {
                    ButtonInfo buttonInfoo = PlayersButtons[index];
                    return $"{buttonInfoo.buttonText}: {buttonInfoo.toolTip}";
                }
                if (Mods.inProjectile) // makes tooltips for mods in category 5
                {
                    ButtonInfo buttonInfoo = ProjectileButtons[index];
                    return $"{buttonInfoo.buttonText}: {buttonInfoo.toolTip}";
                }
                if (Mods.inMovement) // makes tooltips for mods in category 6
                {
                    ButtonInfo buttonInfoo = MovementButtons[index];
                    return $"{buttonInfoo.buttonText}: {buttonInfoo.toolTip}";
                }
                if (Mods.inRoom) // makes tooltips for mods in category 7
                {
                    ButtonInfo buttonInfoo = RoomButtons[index];
                    return $"{buttonInfoo.buttonText}: {buttonInfoo.toolTip}";
                }
                ButtonInfo buttonInfo = buttons[index];
                return $"{buttonInfo.buttonText}: {buttonInfo.toolTip}";
            }
        }
        public void Draw()
        { 
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Object.Destroy(menu.GetComponent<Rigidbody>());
            Object.Destroy(menu.GetComponent<BoxCollider>());
            GameObject.Destroy(menu.GetComponent<BoxCollider>());
            GameObject.Destroy(menu.GetComponent<Collider>());
            Object.Destroy(menu.GetComponent<Renderer>());
            menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f) * GorillaLocomotion.Player.Instance.scale;
            menuObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Object.Destroy(menuObj.GetComponent<Rigidbody>());
            Object.Destroy(menuObj.GetComponent<BoxCollider>());
            menuObj.transform.parent = menu.transform;
            menuObj.transform.rotation = Quaternion.identity;
            menuObj.transform.localScale = MenuScale;
            if (ChangingColors)
            {
                if (Mods.RGBMenu)
                {
                    GradientColorKey[] array13 = new GradientColorKey[7];
                    array13[0].color = Color.red;
                    array13[0].time = 0f;
                    array13[1].color = Color.yellow;
                    array13[1].time = 0.2f;
                    array13[2].color = Color.green;
                    array13[2].time = 0.3f;
                    array13[3].color = Color.cyan;
                    array13[3].time = 0.5f;
                    array13[4].color = Color.cyan;
                    array13[4].time = 0.6f;
                    array13[5].color = Color.magenta;
                    array13[5].time = 0.8f;
                    array13[6].color = Color.red;
                    array13[6].time = 1f;
                    ColorChanger colorChanger2 = menuObj.AddComponent<ColorChanger>();
                    colorChanger2.colors = new Gradient
                    {
                        colorKeys = array13
                    };
                    colorChanger2.Start();
                }
                else
                {
                    GradientColorKey[] array = new GradientColorKey[4];
                    array[0].color = FirstColor;
                    array[0].time = 0f;
                    array[1].color = FirstColor;
                    array[1].time = 0.3f;
                    array[2].color = SecondColor;
                    array[2].time = 0.6f;
                    array[3].color = FirstColor;
                    array[3].time = 1f;
                    ColorChanger colorChanger = menuObj.AddComponent<ColorChanger>();
                    colorChanger.colors = new Gradient
                    {
                        colorKeys = array
                    };
                    colorChanger.Start();
                }
            }
            else
            {
                menuObj.GetComponent<Renderer>().material.color = NormalColor;
            }
            if (Mods.change10 == 10)
            {
                // clear menu
                Object.Destroy(menuObj.GetComponent<Renderer>());
            }
            menuObj.transform.position = MenuPos;
            canvasObj = new GameObject();
            canvasObj.transform.parent = menu.transform;
            Canvas canvas = canvasObj.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScaler.dynamicPixelsPerUnit = 1000f;
            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObj.transform
                }
            }.AddComponent<Text>();
            text.gameObject.name = "name";
            titiel = text;
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            int yau = pageNumber + 1;
            text.text = MenuTitle;
            text.fontSize = 1;
            text.alignment = TextAnchor.MiddleCenter;
            text.color = MenuTitleColor;
            if (FirstColor == Color.white && SecondColor == Color.white)
            {
                // if menu is white, the menu title is black
                text.color = Color.black;
            }
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = MenuTitleScale;
            component.position = MenuTitlePos;
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            AddPageButtons();
            string[] array2 = buttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array3 = settingsbuttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array4 = VisualButtons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array5 = Exploits.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array6 = RoomButtons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array7 = ProjectileButtons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array8 = PlayersButtons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array9 = MovementButtons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array10 = SelfButtons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array11 = SafetyButtons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();


            if (Mods.inSettings)
            {
                for (int i = 0; i < array3.Length; i++)
                {
                    AddButton((float)i * 0.13f + 0.26f * 1f, array3[i]);
                }
            }
            else
            {
                if (Mods.inVisuals)
                {
                    for (int i = 0; i < array4.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array4[i]);
                    }
                }
                if (Mods.inExploits)
                {
                    for (int i = 0; i < array5.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array5[i]);
                    }
                }
                if (Mods.inRoom)
                {
                    for (int i = 0; i < array6.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array6[i]);
                    }
                }
                if (Mods.inProjectile)
                {
                    for (int i = 0; i < array7.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array7[i]);
                    }
                }
                if (Mods.inPlayers)
                {
                    for (int i = 0; i < array8.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array8[i]);
                    }
                }
                if (Mods.inMovement)
                {
                    for (int i = 0; i < array9.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array9[i]);
                    }
                }
                if (Mods.inSelf)
                {
                    for (int i = 0; i < array10.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array10[i]);
                    }
                }
                if (Mods.inSafety)
                {
                    for (int i = 0; i < array11.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array11[i]);
                    }
                }
                if (!Mods.inVisuals && !Mods.inExploits && !Mods.inRoom && !Mods.inProjectile && !Mods.inPlayers && !Mods.inMovement && !Mods.inSelf && !Mods.inSafety && !Mods.inSettings)
                {
                    for (int i = 0; i < array2.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array2[i]);
                    }
                }
            }
            GameObject tooltipObj = new GameObject();
            tooltipObj.transform.SetParent(canvasObj.transform);
            tooltipObj.transform.localPosition = new Vector3(0, 0, 1) * 1f;
            tooltipText = tooltipObj.GetComponent<Text>();
            if (tooltipText == null)
                tooltipText = tooltipObj.AddComponent<Text>();
            tooltipText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            tooltipText.text = tooltipString;
            tooltipText.fontSize = 20;
            tooltipText.alignment = TextAnchor.MiddleCenter;
            tooltipText.resizeTextForBestFit = true;
            tooltipText.resizeTextMinSize = 0;
            tooltipText.color = ToolTipColor;
            if (FirstColor == Color.white && SecondColor == Color.white)
            {
                // if menu is white, the tooltip is black
                tooltipText.color = Color.black;
            }
            RectTransform componenttooltip = tooltipObj.GetComponent<RectTransform>();
            componenttooltip.localPosition = Vector3.zero;
            componenttooltip.sizeDelta = ToolTipScale;
            componenttooltip.position = ToolTipPos;
            componenttooltip.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }
        public static Text titiel;
        private static void AddPageButtons()
        {
            int num = (buttons.Count + pageSize - 1) / pageSize;
            int num2 = pageNumber + 1;
            int num3 = pageNumber - 1;
            if (num2 > num - 1)
            {
                num2 = 0;
            }
            if (num3 < 0)
            {
                num3 = num - 1;
            }
            // on menu next & prev
            float num4 = 0f;
            GameObject gameObject = GameObject.CreatePrimitive((PrimitiveType)3);
            Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - num4);
            gameObject.AddComponent<BtnCollider>().relatedText = "PreviousPage";
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
            GradientColorKey[] array = new GradientColorKey[3];
            array[0].color = new Color32(50, 50, 50, 255);
            array[0].time = 0f;
            array[1].color = new Color32(90, 90, 90, 255);
            array[1].time = 0.5f;
            array[2].color = new Color32(50, 50, 50, 255);
            array[2].time = 1f;
            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colors = new Gradient
            {
                colorKeys = array
            };
            colorChanger.Start();
            Text text = new GameObject
            {
                transform =
                    {
                       parent = canvasObj.transform
                    }
            }.AddComponent<Text>();
            text.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
            text.text = "[" + num3.ToString() + "] << Prev";
            text.fontSize = 1;
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.03f);
            component.localPosition = new Vector3(0.064f, 0f, 0.111f - num4 / 2.55f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            num4 = 0.13f;
            GameObject gameObject2 = GameObject.CreatePrimitive((PrimitiveType)3);
            Object.Destroy(gameObject2.GetComponent<Rigidbody>());
            gameObject2.GetComponent<BoxCollider>().isTrigger = true;
            gameObject2.transform.parent = menu.transform;
            gameObject2.transform.rotation = Quaternion.identity;
            gameObject2.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
            gameObject2.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - num4);
            gameObject2.AddComponent<BtnCollider>().relatedText = "NextPage";
            gameObject2.GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
            GradientColorKey[] array2 = new GradientColorKey[3];
            array2[0].color = new Color32(50, 50, 50, 255);
            array2[0].time = 0f;
            array2[1].color = new Color32(90, 90, 90, 255);
            array2[1].time = 0.5f;
            array2[2].color = new Color32(50, 50, 50, 255);
            array2[2].time = 1f;
            ColorChanger colorChanger2 = gameObject2.AddComponent<ColorChanger>();
            colorChanger2.colors = new Gradient
            {
                colorKeys = array2
            };
            colorChanger2.Start();
            Text text2 = new GameObject
            {
                transform =
                    {
                       parent = canvasObj.transform
                    }
            }.AddComponent<Text>();
            text2.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text2.text = "Next >> [" + num2.ToString() + "]";
            text2.fontSize = 1;
            text2.alignment = TextAnchor.MiddleCenter;
            text2.resizeTextForBestFit = true;
            text2.resizeTextMinSize = 0;
            RectTransform component2 = text2.GetComponent<RectTransform>();
            component2.localPosition = Vector3.zero;
            component2.sizeDelta = new Vector2(0.2f, 0.03f);
            component2.localPosition = new Vector3(0.064f, 0f, 0.111f - num4 / 2.55f);
            component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            pageSize = 4;
            if (Mods.change4 == 4)
            {
                // bottom disconnect
                GameObject gameObject9 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject9.name = "disconnect";
                gameObject9.GetComponent<BoxCollider>().isTrigger = true;
                gameObject9.transform.parent = menu.transform;
                gameObject9.transform.rotation = Quaternion.identity;
                gameObject9.transform.localScale = new Vector3(0.12f, 0.9f, 0.1f);
                gameObject9.transform.localPosition = new Vector3(0.56f, 0f, -0.6f);
                gameObject9.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
                gameObject9.GetComponent<Renderer>().material.color = DisconnectButtonColor;
                Text text12 = new GameObject
                {
                    name = "disconnect text",
                    transform =
                    {
                      parent = canvasObj.transform
                    }
                }.AddComponent<Text>();
                text12.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
                text12.text = "Disconnect";
                text12.fontSize = 1;
                text12.color = Color.white;
                text12.alignment = TextAnchor.MiddleCenter;
                text12.resizeTextForBestFit = true;
                text12.resizeTextMinSize = 0;
                text12.color = DisconnectTextColor;
                RectTransform compenment20 = text12.GetComponent<RectTransform>();
                compenment20.localPosition = Vector3.zero;
                compenment20.sizeDelta = new Vector2(0.2f, 0.03f);
                compenment20.localPosition = new Vector3(0.064f, 0f, -0.24f);
                compenment20.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                if (Mods.change7 == 4)
                {
                    // if bottom Next & Prev, move the bottom disconnect a lil bit down
                    gameObject9.transform.localPosition = new Vector3(0.56f, 0f, -0.7f);
                    compenment20.localPosition = new Vector3(0.064f, 0f, -0.28f);
                }
            }
        }
        public static void DestroyMenu()
        {
            Object.Destroy(menu);
            Object.Destroy(canvasObj);
            Object.Destroy(reference);
            menu = null;
            menuObj = null;
            canvasObj = null;
            reference = null;
        }
        public static GameObject Button;
        public static Text text2;
        public static string text;
        private static void AddButton(float offset, string text)
        {
            Button = GameObject.CreatePrimitive((PrimitiveType)3);
            Object.Destroy(Button.GetComponent<Rigidbody>());
            Button.GetComponent<BoxCollider>().isTrigger = true;
            Button.transform.parent = menu.transform;
            Button.transform.rotation = Quaternion.identity;
            Button.transform.localScale = ButtonScale * GorillaLocomotion.Player.Instance.scale;
            if (Mods.change7 == 1)
            {
                Button.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - offset);
            }
            if (Mods.change7 == 2 | Mods.change7 == 3 | Mods.change7 == 4 | Mods.change7 == 5)
            {
                Button.transform.localPosition = new Vector3(0.56f, 0f, 0.6f - offset);
            }
            Button.AddComponent<BtnCollider>().relatedText = text;
            int num = -1;
            if (Mods.inSettings)
            {
                for (int i = 0; i < settingsbuttons.Count; i++)
                {
                    if (text == settingsbuttons[i].buttonText)
                    {
                        num = i;
                        break;
                    }
                }
            }
            else
            {
                if (Mods.inSafety)
                {
                    for (int i = 0; i < SafetyButtons.Count; i++)
                    {
                        if (text == SafetyButtons[i].buttonText)
                        {
                            num = i;
                            break;
                        }
                    }
                }
                if (Mods.inProjectile)
                {
                    for (int i = 0; i < ProjectileButtons.Count; i++)
                    {
                        if (text == ProjectileButtons[i].buttonText)
                        {
                            num = i;
                            break;
                        }
                    }
                }
                if (Mods.inMovement)
                {
                    for (int i = 0; i < MovementButtons.Count; i++)
                    {
                        if (text == MovementButtons[i].buttonText)
                        {
                            num = i;
                            break;
                        }
                    }
                }
                if (Mods.inSelf)
                {
                    for (int i = 0; i < SelfButtons.Count; i++)
                    {
                        if (text == SelfButtons[i].buttonText)
                        {
                            num = i;
                            break;
                        }
                    }
                }
                if (Mods.inPlayers)
                {
                    for (int i = 0; i < PlayersButtons.Count; i++)
                    {
                        if (text == PlayersButtons[i].buttonText)
                        {
                            num = i;
                            break;
                        }
                    }
                }
                if (Mods.inExploits)
                {
                    for (int i = 0; i < Exploits.Count; i++)
                    {
                        if (text == Exploits[i].buttonText)
                        {
                            num = i;
                            break;
                        }
                    }
                }
                if (Mods.inRoom)
                {
                    for (int i = 0; i < RoomButtons.Count; i++)
                    {
                        if (text == RoomButtons[i].buttonText)
                        {
                            num = i;
                            break;
                        }
                    }
                }
                if (!Mods.inSafety && !Mods.inProjectile && !Mods.inMovement&& !Mods.inSelf && !Mods.inPlayers && !Mods.inExploits && !Mods.inRoom && !Mods.inSettings)
                {
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (text == buttons[i].buttonText)
                        {
                            num = i;
                            break;
                        }
                    }
                }
            }
            text2 = new GameObject
            {
                transform =
                {
                    parent = canvasObj.transform
                }
            }.AddComponent<Text>();
            text2.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text2.text = text;
            text2.fontSize = 1;
            text2.alignment = TextAnchor.MiddleCenter;
            text2.resizeTextForBestFit = true;
            text2.resizeTextMinSize = 0;
            RectTransform component = text2.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = ButtonTextScale;
            if (Mods.change7 == 1)
            {
                component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 2.55f);
            }
            if (Mods.change7 == 2 | Mods.change7 == 3 | Mods.change7 == 4 | Mods.change7 == 5)
            {
                component.localPosition = new Vector3(0.064f, 0f, 0.237f - offset / 2.55f);
            }
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (Mods.inSettings)
            {
                if (settingsbuttons[num].enabled == true)
                {
                    Button.GetComponent<Renderer>().material.color = ButtonColorEnabled;
                    text2.color = EnableTextColor;
                    if (Mods.change13 == 10)
                    {
                        Object.Destroy(Button.GetComponent<Renderer>());
                    }
                }
                else
                {
                    Button.GetComponent<Renderer>().material.color = ButtonColorDisable;
                    text2.color = DIsableTextColor;
                    if (Mods.change12 == 10)
                    {
                        Object.Destroy(Button.GetComponent<Renderer>());
                    }
                }
            }
            else
            {
                if (Mods.inRoom)
                {
                    if (RoomButtons[num].enabled == true)
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorEnabled;
                        text2.color = EnableTextColor;
                        if (Mods.change13 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                    else
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorDisable;
                        text2.color = DIsableTextColor;
                        if (Mods.change12 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                }
                if (Mods.inPlayers)
                {
                    if (PlayersButtons[num].enabled == true)
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorEnabled;
                        text2.color = EnableTextColor;
                        if (Mods.change13 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                    else
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorDisable;
                        text2.color = DIsableTextColor;
                        if (Mods.change12 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                }
                if (Mods.inMovement)
                {
                    if (MovementButtons[num].enabled == true)
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorEnabled;
                        text2.color = EnableTextColor;
                        if (Mods.change13 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                    else
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorDisable;
                        text2.color = DIsableTextColor;
                        if (Mods.change12 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                }
                if (Mods.inSafety)
                {
                    if (SafetyButtons[num].enabled == true)
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorEnabled;
                        text2.color = EnableTextColor;
                        if (Mods.change13 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                    else
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorDisable;
                        text2.color = DIsableTextColor;
                        if (Mods.change12 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                }
                if (Mods.inSelf)
                {
                    if (SelfButtons[num].enabled == true)
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorEnabled;
                        text2.color = EnableTextColor;
                        if (Mods.change13 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                    else
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorDisable;
                        text2.color = DIsableTextColor;
                        if (Mods.change12 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                }
                if (Mods.inExploits)
                {
                    if (Exploits[num].enabled == true)
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorEnabled;
                        text2.color = EnableTextColor;
                        if (Mods.change13 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                    else
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorDisable;
                        text2.color = DIsableTextColor;
                        if (Mods.change12 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                }
                if (Mods.inProjectile)
                {
                    if (ProjectileButtons[num].enabled == true)
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorEnabled;
                        text2.color = EnableTextColor;
                        if (Mods.change13 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                    else
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorDisable;
                        text2.color = DIsableTextColor;
                        if (Mods.change12 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                }
                if (!Mods.inRoom && !Mods.inRoom && !Mods.inMovement && !Mods.inSafety && !Mods.inSelf && !Mods.inExploits && !Mods.inProjectile && !Mods.inSettings)
                {
                    if (buttons[num].enabled == true)
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorEnabled;
                        text2.color = EnableTextColor;
                        if (Mods.change13 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                    else
                    {
                        Button.GetComponent<Renderer>().material.color = ButtonColorDisable;
                        text2.color = DIsableTextColor;
                        if (Mods.change12 == 10)
                        {
                            Object.Destroy(Button.GetComponent<Renderer>());
                        }
                    }
                }
            }
        }
        public void Start()
        {
            Draw();
        }
        public static void Toggle(string relatedText)
        {
            if (Mods.inSettings)
            {
                int num = (settingsbuttons.Count + pageSize - 1) / pageSize;
                if (relatedText == "NextPage")
                {
                    if (pageNumber < num - 1)
                    {
                        pageNumber++;
                    }
                    else
                    {
                        pageNumber = 0;
                    }
                    DestroyMenu();
                    instance.Draw();
                }
                else
                {
                    if (relatedText == "PreviousPage")
                    {
                        if (pageNumber > 0)
                        {
                            pageNumber--;
                        }
                        else
                        {
                            pageNumber = num - 1;
                        }
                        DestroyMenu();
                        instance.Draw();
                    }
                    else
                    {
                        if (relatedText == "DisconnectingButton")
                        {
                            PhotonNetwork.Disconnect();
                            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(Mods.ButtonSound, false, 0.1f);
                        }
                        else
                        {
                            int num2 = -1;
                            for (int i = 0; i < settingsbuttons.Count; i++)
                            {
                                if (relatedText == settingsbuttons[i].buttonText)
                                {
                                    num2 = i;
                                    break;
                                }
                            }
                            if (settingsbuttons[num2].enabled != null)
                            {
                                settingsbuttons[num2].enabled = !settingsbuttons[num2].enabled;
                                lastPressedButtonIndex = num2;
                                if (lastPressedButtonIndex != -1 && lastPressedButtonIndex < settingsbuttons.Count)
                                {
                                    tooltipString = GetButtonTooltip(lastPressedButtonIndex);
                                    tooltipText.text = tooltipString;
                                    lastPressedButtonIndex = -1;
                                }
                                DestroyMenu();
                                instance.Draw();
                            }
                        }
                    }
                }
            }
            else
            {
                if (!Mods.inSettings)
                {
                    int num = (buttons.Count + pageSize - 1) / pageSize;
                    if (relatedText == "NextPage")
                    {
                        if (pageNumber < num - 1)
                        {
                            pageNumber++;
                        }
                        else
                        {
                            pageNumber = 0;
                        }
                        DestroyMenu();
                        instance.Draw();
                    }
                    else
                    {
                        if (relatedText == "PreviousPage")
                        {
                            if (pageNumber > 0)
                            {
                                pageNumber--;
                            }
                            else
                            {
                                pageNumber = num - 1;
                            }
                            DestroyMenu();
                            instance.Draw();
                        }
                        else
                        {
                            if (relatedText == "DisconnectingButton")
                            {
                                PhotonNetwork.Disconnect();
                                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(Mods.ButtonSound, false, 0.1f);
                            }
                            else
                            {
                                int num2 = -1;
                                for (int i = 0; i < buttons.Count; i++)
                                {
                                    if (relatedText == buttons[i].buttonText)
                                    {
                                        num2 = i;
                                        break;
                                    }
                                }
                                if (buttons[num2].enabled != null)
                                {
                                    buttons[num2].enabled = !buttons[num2].enabled;
                                    lastPressedButtonIndex = num2;
                                    if (lastPressedButtonIndex != -1 && lastPressedButtonIndex < buttons.Count)
                                    {
                                        tooltipString = GetButtonTooltip(lastPressedButtonIndex);
                                        tooltipText.text = tooltipString;
                                        lastPressedButtonIndex = -1;
                                    }
                                    DestroyMenu();
                                    instance.Draw();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

internal class BtnCollider : MonoBehaviour
{
    public static int framePressCooldown = 0;
    private void OnTriggerEnter(Collider collider)
    {
        if (Time.frameCount >= framePressCooldown + WristMenu.ClickCooldown && collider.name == "buttonPresser")
        {
            if (!Mods.right)
            {
                GorillaTagger.Instance.StartVibration(false, .01f, 0.001f);
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(Mods.ButtonSound, false, 0.1f);
            }
            else
            {
                GorillaTagger.Instance.StartVibration(true, .01f, 0.001f);
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(Mods.ButtonSound, true, 0.1f);
            }
            WristMenu.Toggle(this.relatedText);
            framePressCooldown = Time.frameCount;
        }
    }
    public string relatedText;
}
