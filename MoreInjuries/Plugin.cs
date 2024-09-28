using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using UnityEngine;

namespace MoreInjuries
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.MoreInjuries";
        public const string PluginName = "MoreInjuries";
        public const string PluginVer = "1.1.0";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        public static ConfigEntry<int> configIncreasedTimes;
        public static ConfigEntry<int> configIncreasedLimbs;
        private void Awake()
        {
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);


            configIncreasedTimes = Config.Bind("General",
             "Increased times",
             50,
             new ConfigDescription("How many times injuries are likely"));

            configIncreasedLimbs = Config.Bind("General",
 "Increased times (limbs)",
 10,
 new ConfigDescription("How many times lost limbs are likely"));
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
        [HarmonyPatch(typeof(DFOGOCNBECG))]
        public static class DFOGOCNBECGPatch
        {
            [HarmonyPrefix]
            [HarmonyPatch(nameof(DFOGOCNBECG.KCFNOONDGKE))]
            public static void KCFNOONDGKEPatch(DFOGOCNBECG __instance, int __result, int CNHJJIPILFK,ref float DGJAEIBKLJO)
            {
                DGJAEIBKLJO *= configIncreasedTimes.Value;
            }
            [HarmonyPrefix]
            [HarmonyPatch(nameof(DFOGOCNBECG.CMOPOKMFJMG))]
            public static void CMOPOKMFJMGPatch(DFOGOCNBECG __instance, int IKBHGAKKJMM, ref float DGJAEIBKLJO, float BEMKANDCFCP)
            {
                DGJAEIBKLJO *= configIncreasedLimbs.Value;
            }
        }
    }
}