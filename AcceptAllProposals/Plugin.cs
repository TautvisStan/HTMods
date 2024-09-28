using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AcceptAllProposals
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.AcceptAllProposals";
        public const string PluginName = "AcceptAllProposals";
        public const string PluginVer = "1.1.1";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;
        

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

    /*    [HarmonyPatch(typeof(NEGAFEHECNL), nameof(NEGAFEHECNL.LBPJGAGBCLP))]  //matches
        [HarmonyPrefix]
        static bool NEGAFEHECNL_LBPJGAGBCLP(ref int __result, int GKNIAFAOLJK)
        {
            if(Input.GetKey(KeyCode.N))
            {
                __result = 1;
                return false;
            }
            return true;
        }
        [HarmonyPatch(typeof(NEGAFEHECNL), nameof(NEGAFEHECNL.GFNGNOGAMBL))]  //manager
        [HarmonyPrefix]
        static bool NEGAFEHECNL_GFNGNOGAMBL(ref int __result, int GKNIAFAOLJK)
        {
            if (Input.GetKey(KeyCode.N))
            {
                __result = 1;
                return false;
            }
            return true;
        }
        [HarmonyPatch(typeof(NEGAFEHECNL), nameof(NEGAFEHECNL.PMKDGGFHOEO))]  //partner
        [HarmonyPrefix]
        static bool NEGAFEHECNL_PMKDGGFHOEO(ref int __result, int GKNIAFAOLJK)
        {
            if (Input.GetKey(KeyCode.N))
            {
                __result = 1;
                return false;
            }
            return true;
        }*/

        	 [HarmonyPatch(typeof(NEGAFEHECNL), nameof(NEGAFEHECNL.GBLGKLJIONK))]  //A bunch of new stuff GBLGKLJIONK??
            [HarmonyPostfix]
            static void NEGAFEHECNL_GBLGKLJIONK(ref int __result)
            {
                if (Input.GetKey(KeyCode.N))
                { 
                    NEGAFEHECNL.PEJALFBEOKC = 1;
                    __result = 1;
                }
            }
    }
}