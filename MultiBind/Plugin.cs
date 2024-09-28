using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MultiBind
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.MultiBind";
        public const string PluginName = "MultiBind";
        public const string PluginVer = "1.1.6";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        public static int[] KeyboardInstance = new int[4] { 0, -1, -1, -1 };
        public static bool ControllerMode = false;
        public static int ControllerModeInt = 1;

        public static ConfigEntry<string> ConfigAdd;
        public static ConfigEntry<string> ConfigRemove;
        public static ConfigEntry<string> ConfigControllerMode;

        public class ControlScheme
        {
            public ConfigEntry<string> ConfigUp { get; set; }
            public ConfigEntry<string> ConfigDown { get; set; }
            public ConfigEntry<string> ConfigRight { get; set; }
            public ConfigEntry<string> ConfigLeft { get; set; }

            public ConfigEntry<string> ConfigS { get; set; }
            public ConfigEntry<string> ConfigX { get; set; }
            public ConfigEntry<string> ConfigZ { get; set; }
            public ConfigEntry<string> ConfigA { get; set; }
            public ConfigEntry<string> ConfigSpace { get; set; }
            public ConfigEntry<string> ConfigShift { get; set; }
            public ConfigEntry<string> ConfigControl { get; set; }
            public ConfigEntry<string> ConfigTab { get; set; }
            public ConfigEntry<string> ConfigLeftTrigger { get; set; }
            public ConfigEntry<string> ConfigJoin { get; set; }


        }
        public static ControlScheme[] Player = new ControlScheme[4] { new(), new(), new(), new() };
        public AcceptableValueList<string> KeyboardButtons = new AcceptableValueList<string>("None", "Backspace", "Delete", "Tab", "Clear", "Return", "Pause", "Escape", "Space", "Quote", "Comma", "Minus", "Period", "Slash", "Alpha0", "Alpha1", "Alpha2", "Alpha3", "Alpha4", "Alpha5", "Alpha6", "Alpha7", "Alpha8", "Alpha9", "Semicolon", "Equals", "LeftBracket", "Backslash", "RightBracket", "BackQuote", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Keypad0", "Keypad1", "Keypad2", "Keypad3", "Keypad4", "Keypad5", "Keypad6", "Keypad7", "Keypad8", "Keypad9", "KeypadPeriod", "KeypadDivide", "KeypadMultiply", "KeypadMinus", "KeypadPlus", "KeypadEnter", "KeypadEquals", "UpArrow", "DownArrow", "RightArrow", "LeftArrow", "Insert", "Home", "End", "PageUp", "PageDown", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "Numlock", "CapsLock", "ScrollLock", "RightShift", "LeftShift", "RightControl", "LeftControl", "RightAlt", "LeftAlt", "RightCommand", "RightApple", "LeftCommand", "LeftApple", "LeftWindows", "RightWindows", "Print", "Menu", "Mouse0", "Mouse1", "Mouse2", "Mouse3", "Mouse4", "Mouse5", "Mouse6");

        private void SetupControls(ControlScheme controlScheme, string player)
        {
            controlScheme.ConfigUp = Config.Bind(player,
             "Up Button (" + player + ")",
             "UpArrow",
             new ConfigDescription(
                "Move up button (" + player + ")",
               KeyboardButtons));
            controlScheme.ConfigDown = Config.Bind(player,
             "Down Button (" + player + ")",
             "DownArrow",
             new ConfigDescription(
                    "Move down button (" + player + ")",
               KeyboardButtons));
            controlScheme.ConfigLeft = Config.Bind(player,
             "Left Button (" + player + ")",
             "LeftArrow",
             new ConfigDescription(
                    "Move left button (" + player + ")",
               KeyboardButtons));
            controlScheme.ConfigRight = Config.Bind(player,
             "Right Button (" + player + ")",
             "RightArrow",
             new ConfigDescription(
                    "Move right button (" + player + ")",
               KeyboardButtons));
            controlScheme.ConfigA = Config.Bind(player,
             "Attack Button (" + player + ")",
             "A",
             new ConfigDescription(
                    "Attack button / West Button (" + player + ")",
               KeyboardButtons));
            controlScheme.ConfigS = Config.Bind(player,
             "Grapple Button (" + player + ")",
             "S",
             new ConfigDescription(
                    "Grapple button / North Button (" + player + ")",
               KeyboardButtons));
            controlScheme.ConfigZ = Config.Bind(player,
             "Run Button (" + player + ")",
             "Z",
             new ConfigDescription(
                    "Run button / South Button (" + player + ")",
               KeyboardButtons));
            controlScheme.ConfigX = Config.Bind(player,
             "Pick Up Button (" + player + ")",
             "X",
             new ConfigDescription(
                    "Pick up button / East Button (" + player + ")",
               KeyboardButtons));
            controlScheme.ConfigSpace = Config.Bind(player,
             "Taunt Button (" + player + ")",
             "Space",
             new ConfigDescription(
                    "Taunt button (" + player + ")",
               KeyboardButtons));
            controlScheme.ConfigShift = Config.Bind(player,
             "Focus (Shift) Button (" + player + ")",
             "LeftShift (" + player + ")",
             new ConfigDescription(
                    "Change focus (shift) button / Left Shoulder Button (" + player + ")",
               KeyboardButtons));
            controlScheme.ConfigControl = Config.Bind(player,
             "Focus (Control) Button (" + player + ")",
             "LeftControl",
             new ConfigDescription(
                    "Change focus (control) button / Right Shoulder Button (" + player + ")",
               KeyboardButtons));
            controlScheme.ConfigTab = Config.Bind(player,
             "Change Control (TAB) Button (" + player + ")",
             "Tab",
             new ConfigDescription(
                    "Left Trigger Button / Right Trigger (" + player + ")",
               KeyboardButtons));
            controlScheme.ConfigLeftTrigger = Config.Bind(player,
             "LeftTrigger (" + player + ")",
             "None",
             new ConfigDescription(
                    "Change the left trigger button / Left Trigger (" + player + ")",
               KeyboardButtons));
            controlScheme.ConfigJoin = Config.Bind(player,
             "Join Button (" + player + ")",
             "None",
             new ConfigDescription(
                    "\"Join\" button that let's you join a game in progress (" + player + ")",
               KeyboardButtons));
        }
        private void Awake()
        {
            Plugin.Log = base.Logger;
            PluginPath = Path.GetDirectoryName(Info.Location);
            ConfigAdd = Config.Bind("General",
             "AddPlayer Button",
             "KeypadPlus",
             new ConfigDescription(
                    "Button to add a new \"fake\" keyboard",
               KeyboardButtons));
            ConfigRemove = Config.Bind("General",
             "RemovePlayer Button",
             "KeypadMinus",
             new ConfigDescription(
                    "Button to remove a new \"fake\" keyboard",
               KeyboardButtons));
            ConfigControllerMode = Config.Bind("General",
             "ControllerMode",
             "KeypadEnter",
             new ConfigDescription(
                    "Will toggle a controller mode so you can use the keyboard in the main ",
               KeyboardButtons));
            SetupControls(Player[0], "Main Keyboard Player");
            SetupControls(Player[1], "Additional Player 1");
            SetupControls(Player[2], "Additional Player 2");
            SetupControls(Player[3], "Additional Player 3");


            AddHTCCLButtons();

        }
        private void AddHTCCLButtons()
        {
            if (IsHTCCLLoaded())
            {
                AddButtons();
            }
            else
            {
                Log.LogInfo("HTCCL not found");
            }
        }
        private bool IsHTCCLLoaded()
        {
            try
            {
                // Try to load HTCCL.dll assembly
                Assembly.Load("HTCCL");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void AddButtons()
        {
            try
            {
                // Use reflection to get the class type
                Type ClassType = Type.GetType("HTCCL.API.Buttons, HTCCL");

                // Check if the class type is found
                if (ClassType != null)
                {
                    // Invoke the method from Class
                    MethodInfo methodInfo = ClassType.GetMethod("RegisterCustomButton", BindingFlags.Static | BindingFlags.Public);
                    Func<string> ButtonAdd = delegate() {
                        string text = AddNewPlayer() ? "New keyboard player added" : "Failed to add new keyboard player";
                        return text;
                    };
                    Func<string> ButtonRemove = delegate () {
                        string text = RemovePlayer() ? "New keyboard player removed" : "Failed to remove new keyboard player";
                        return text;
                    };
                    Func<string> ButtonToggle = delegate () {
                        ToggleController();
                        return "Controller mode toggled";
                    };
                    object[] parameters = new object[] { this, "Add new keyboard player", ButtonAdd, false };
                    methodInfo.Invoke(null, parameters);

                    object[] parameters2 = new object[] { this, "Remove new keyboard player", ButtonRemove, false };
                    methodInfo.Invoke(null, parameters2);

                    object[] parameters3 = new object[] { this, "Toggle Controller Mode", ButtonToggle, false };
                    methodInfo.Invoke(null, parameters3);
                }
                else
                {
                    Log.LogError("HTCCL.API.Buttons not found in HTCCL");
                }
            }
            catch (Exception ex)
            {
                Log.LogError($"Error calling method from HTCCL: {ex.Message}");
            }
        }
        private void OnEnable()
        {
            Harmony.PatchAll();
            Logger.LogInfo($"Loaded {PluginName}!");
        }

        private void OnDisable()
        {
            Harmony.UnpatchSelf();
            Logger.LogInfo($"Unloaded {PluginName}!");
        }
        private bool AddNewPlayer()
        {
            int i;
            for (i = 1; i <= 3; i++)
            {
                if (KeyboardInstance[i] > HKJOAJOKOIJ.NGCNKGDDKGF)
                {
                    KeyboardInstance[i] = -1;
                }
            }
            for (i = 1; i <= 3; i++)
            {
                if (KeyboardInstance[i] == -1)
                {
                    int instance = HKJOAJOKOIJ.NGCNKGDDKGF + 1;
                    HKJOAJOKOIJ.NAADDLFFIHG[instance] = new BJMGCKGNCHO();
                    HKJOAJOKOIJ.NAADDLFFIHG[instance].PLFGKLGCOMD = i;  //playernumber
                    KeyboardInstance[i] = instance;
                    HKJOAJOKOIJ.NAADDLFFIHG[instance].AHBNKMMMGFI = 1;
                    HKJOAJOKOIJ.NAADDLFFIHG[instance].BPJFLJPKKJK = 0;
                    HKJOAJOKOIJ.NAADDLFFIHG[instance].CMECDGMCMLC = "Virtual";
                    if (NAEEIFNFBBO.GAABAPFHBPM <= 1)
                    {
                        HKJOAJOKOIJ.NAADDLFFIHG[instance].BPJFLJPKKJK = ControllerModeInt;
                        HKJOAJOKOIJ.NAADDLFFIHG[instance].CMECDGMCMLC = "FakeKeyboard";
                    }
                    HKJOAJOKOIJ.NGCNKGDDKGF++;
                    CHLPMKEGJBJ.DNNPEAOCDOG(CHLPMKEGJBJ.IKONDJPBOGP[5], 1f, 1f);
                    return true;
                }
            }
            return false;
        }
        private bool RemovePlayer()
        {
            int i;
            for (i = 1; i <= 3; i++)
            {
                if (KeyboardInstance[i] > HKJOAJOKOIJ.NGCNKGDDKGF)
                {
                    KeyboardInstance[i] = -1;
                }
            }
            for (i = 3; i > 0; i--)
            {
                if (KeyboardInstance[i] != -1)
                {
                    HKJOAJOKOIJ.NGCNKGDDKGF--;
                    KeyboardInstance[i] = -1;
                    CHLPMKEGJBJ.DNNPEAOCDOG(CHLPMKEGJBJ.IKONDJPBOGP[5], 1f, 1f);
                    return true;
                }
            }
            return false;
        }
        private void ToggleController()
        {
            ControllerMode = !ControllerMode;
            if (ControllerMode)
            {
                ControllerModeInt = 3;
                MOIHOCAMOOE.BPJFLJPKKJK = 0;
            }
            else
            {
                ControllerModeInt = 1;
                MOIHOCAMOOE.BPJFLJPKKJK = 1;
            }
            HKJOAJOKOIJ.NAADDLFFIHG[0].BPJFLJPKKJK = ControllerModeInt;
            HKJOAJOKOIJ.NAADDLFFIHG[0].CMECDGMCMLC = "Keyboard";
            HKJOAJOKOIJ.NAADDLFFIHG[0].AHBNKMMMGFI = 1;
            for (int i = 0; i < 4; i++)
            {
                if (KeyboardInstance[i] != -1)
                {
                    HKJOAJOKOIJ.NAADDLFFIHG[KeyboardInstance[i]].BPJFLJPKKJK = ControllerModeInt;
                }
            }
            CHLPMKEGJBJ.DNNPEAOCDOG(CHLPMKEGJBJ.IKONDJPBOGP[5], 1f, 1f);
        }
        private void Update()
        {
            if (SceneManager.GetActiveScene().name == "Titles")
            {
                if (Input.GetKeyDown(Ulil.GetKeyCode(ConfigRemove.Value)))
                {
                    RemovePlayer();
                }
                if (Input.GetKeyDown(Ulil.GetKeyCode(ConfigAdd.Value)))
                {
                    AddNewPlayer();
                }
                if (Input.GetKeyDown(Ulil.GetKeyCode(ConfigControllerMode.Value)))
                {
                    ToggleController();
                }
            }
        }
        public static void HandleControls(BJMGCKGNCHO __instance, ControlScheme scheme)
        {
       //     __instance.NHFPIIKCNFO();
            __instance.LMADDGDMBGB = Mathf.MoveTowards(__instance.LMADDGDMBGB, 0f, 1f * MBLIOKEDHHB.MCJHGEHEPMD);
            if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && __instance.AHBNKMMMGFI > 0 && __instance.FOAPDJMIFGP > 0)
            {
                __instance.NAIJAHOFCLC++;
            }
            else
            {
                __instance.NAIJAHOFCLC = 0;
            }

            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigJoin.Value)))
            {
                __instance.JIIMLBLGKAL(0);
            }
            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigUp.Value)))
            {
                __instance.JLBOEDNDIPI = 1f;
            }
            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigDown.Value)))
            {
                __instance.JLBOEDNDIPI = -1f;
            }
            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigRight.Value)))
            {
                __instance.MGJCMCPCPDN = 1f;
            }
            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigLeft.Value)))
            {
                __instance.MGJCMCPCPDN = -1f;
            }
            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigS.Value)))  //North
            {
                __instance.IOIJFFLMBCH[1] = 1;
            }
            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigX.Value))) //East
            {
                __instance.IOIJFFLMBCH[2] = 1;
            }
            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigZ.Value)))  //South
            {
                __instance.IOIJFFLMBCH[3] = 1;
            }
            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigA.Value)))  //West
            {
                __instance.IOIJFFLMBCH[4] = 1;
            }
            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigSpace.Value)))
            {
                __instance.IOIJFFLMBCH[5] = 1;
            }
            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigShift.Value)))  //LShoulder
            {
                __instance.IOIJFFLMBCH[6] = -1;
               if(ControllerMode) __instance.FHBEOIPFFDA = 1;
            }
            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigControl.Value))) //RShoulder
            {
                __instance.IOIJFFLMBCH[6] = 1;
                if (ControllerMode) __instance.OHEIJEDGKLJ = 1;
            }
            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigTab.Value)))  //Right Trigger
            {
                __instance.EMJMDDNMFFA = 1f;
            }
            if (Input.GetKey(Ulil.GetKeyCode(scheme.ConfigLeftTrigger.Value)))  //Left Trigger
            {
                __instance.PNGFDALFGLE = 1f;
            }
            __instance.IMBKMMOCBBF = __instance.MGJCMCPCPDN;
            __instance.PNLIFOBMMGG = __instance.JLBOEDNDIPI;




            if (__instance.PNGFDALFGLE < 0.5f)
            {
                __instance.PNGFDALFGLE = 0f;
            }
            if (__instance.EMJMDDNMFFA < 0.5f)
            {
                __instance.EMJMDDNMFFA = 0f;
            }
            if (__instance.PNGFDALFGLE >= 1f && __instance.EMJMDDNMFFA < 1f)
            {
                __instance.FCLGPMFNEPE = -1f;
            }
            if (__instance.EMJMDDNMFFA >= 1f && __instance.PNGFDALFGLE < 1f)
            {
                __instance.FCLGPMFNEPE = 1f;
            }
            if (__instance.PNGFDALFGLE >= 1f && __instance.EMJMDDNMFFA >= 1f)
            {
                if (__instance.FCLGPMFNEPE == 1f)
                {
                    __instance.FCLGPMFNEPE = -2f;
                }
                if (__instance.FCLGPMFNEPE == -1f)
                {
                    __instance.FCLGPMFNEPE = 2f;
                }
            }
            if (__instance.PNGFDALFGLE < 1f && __instance.EMJMDDNMFFA < 1f)
            {
                __instance.FCLGPMFNEPE = 0f;
            }
            if (NAEEIFNFBBO.GAABAPFHBPM == 1 && __instance.HPOKFBBGEBG() != 0f)
            {
                Cursor.visible = false;
            }
            if (__instance.PLFGKLGCOMD > 0 && __instance.AHBNKMMMGFI > 0 && HKJOAJOKOIJ.EMLDNFEIKCK != __instance.PLFGKLGCOMD)
            {
                __instance.BDCKBOLGDNB();
            }
            if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && __instance.BPJFLJPKKJK >= 2 && __instance.AHBNKMMMGFI > 0 && __instance.FOAPDJMIFGP == 0 && __instance.DHBFOHLEFOD[2] > 0)
            {
                __instance.JIIMLBLGKAL(0);
            }
            if (NAEEIFNFBBO.JPNIIADMEIE == 0 && LIPNHOMGGHF.FAKHAFKOBPB == 50 && LIPNHOMGGHF.GCJKOBOBIGA == 0 && __instance.BPJFLJPKKJK >= 2 && __instance.PLFGKLGCOMD == HKJOAJOKOIJ.EMLDNFEIKCK && (__instance.MGJCMCPCPDN != 0f || __instance.JLBOEDNDIPI != 0f))
            {
                __instance.IMBKMMOCBBF = __instance.LFGHFKBKHOJ;
                __instance.PNLIFOBMMGG = __instance.APEDCJMNPFK;
                BLNKDHIGFAN.IFPJBJLEEDB = __instance.MGJCMCPCPDN;
                BLNKDHIGFAN.LHBKHGBDPLH = -__instance.JLBOEDNDIPI * 0.2f;
                BLNKDHIGFAN.KHKIEPDJELK = __instance.JLBOEDNDIPI * 0.75f;
                BLNKDHIGFAN.GIBHLNFEPKE = 2f;
            }
        }
        public static class Ulil
        {
            public static KeyCode GetKeyCode(string name)
            {
                return (KeyCode)System.Enum.Parse(typeof(KeyCode), name, true);
            }
        }
        [HarmonyPatch(typeof(BJMGCKGNCHO))]
        public static class BJMGCKGNCHO_Patch
        {
            [HarmonyPrefix]
            [HarmonyPatch(nameof(BJMGCKGNCHO.NCOEPCFFBJA))]
            public static bool NCOEPCFFBJA_Patch(BJMGCKGNCHO __instance)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (__instance.PLFGKLGCOMD == Plugin.KeyboardInstance[i] && __instance.BPJFLJPKKJK == ControllerModeInt && __instance.AHBNKMMMGFI > 0)
                    {
                        Plugin.HandleControls(__instance, Plugin.Player[i]);
                        return false;
                    }
                }
                return true;
            }

        }
    }
}