using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Diagnostics;
using System.IO;

namespace NoMoreMissions
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.NoMoreMissions";
        public const string PluginName = "NoMoreMissions";
        public const string PluginVer = "1.0.3";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);
        public static bool loaded = false;

        internal static string PluginPath;

        static bool asked = false;


        private void Awake()
        {
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);
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
        //NEGAFEHECNL::GBLGKLJIONK ask yourself
        //FBKJNNPOGHP auto
        [HarmonyPatch(typeof(Progress))]
        public static class Progress_Patch
        {
            [HarmonyPrefix]
            [HarmonyPatch(nameof(Progress.CLCFJJCHFCM))]
            public static bool Progress_CLCFJJCHFCM_Pre(ref int __result, int HDIBEIKKGDN, int JDLHJKNGCFD)
            {
                string method = (new System.Diagnostics.StackTrace()).GetFrame(2).GetMethod().Name;
                if(!method.Contains("NEGAFEHECNL::GBLGKLJIONK"))
                {
                    __result = 0;
                    return false;
                }
                asked = true;
                return true;
            }
            [HarmonyPostfix]
            [HarmonyPatch(nameof(Progress.CLCFJJCHFCM))]
            public static void Progress_CLCFJJCHFCM_Post(ref int __result, int HDIBEIKKGDN, int JDLHJKNGCFD)
            {
                asked = false;
            }

            [HarmonyPrefix]
            [HarmonyPatch(nameof(Progress.AICFIBKMLPG))]
            public static bool Progress_AICFIBKMLPG_Patch(ref int __result, int HDIBEIKKGDN, int JDLHJKNGCFD)
            {
                if (!asked)
                {
                    __result = 0;
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }

}