using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using UnityEngine;

namespace UnlimitedAmmo
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.UnlimitedAmmo";
        public const string PluginName = "UnlimitedAmmo";
        public const string PluginVer = "1.0.1";

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
        [HarmonyPatch(typeof(GDFKEAMIOAG), nameof(GDFKEAMIOAG.BLHEFLCEJEP))]
        [HarmonyPrefix]
        public static bool GDFKEAMIOAG_BLHEFLCEJEPPatch(GDFKEAMIOAG __instance, ref int __result)
        {
            __result = int.MaxValue;
            return false;
        }
        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.OKOJOGEAGMJ))]
        [HarmonyPrefix]
        public static void DFOGOCNBECG_OKOJOGEAGMJPatch(DFOGOCNBECG __instance, GDFKEAMIOAG IJPJAKELHHI, int NAIJAHOFCLC)
        {
            IJPJAKELHHI.DCEJODGFFGA = int.MaxValue;
        }
        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.NKPJEIFAOCN))]
        [HarmonyPrefix]
        public static bool DFOGOCNBECG_NKPJEIFAOCNPatch(DFOGOCNBECG __instance, ref int KPJANCMHICM)
        {
            return false;
        }
    }
}