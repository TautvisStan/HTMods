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
        public const string PluginVer = "1.1.1";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        public static ConfigEntry<int> configIncreasedTimes;
        public static ConfigEntry<int> configIncreasedLimbs;

        public static ConfigEntry<bool> configSeparateForPlayer;
        public static ConfigEntry<int> configIncreasedTimesPlayer;
        public static ConfigEntry<int> configIncreasedLimbsPlayer;
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


            configSeparateForPlayer = Config.Bind("General",
             "Separate for player",
             false,
             new ConfigDescription("If enabled, different modifiers will be enabled for player"));

            configIncreasedTimesPlayer = Config.Bind("General",
             "Increased times (Player)",
             50,
             new ConfigDescription("How many times injuries are likely"));

            configIncreasedLimbsPlayer = Config.Bind("General",
             "Increased times (limbs) (Player)",
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
        public static int GetMainPlayerNum()
        {
            for (int j = 0; j <= HKJOAJOKOIJ.NGCNKGDDKGF; j++)
            {
                if (HKJOAJOKOIJ.NAADDLFFIHG[j].AHBNKMMMGFI > 0 && HKJOAJOKOIJ.NAADDLFFIHG[j].BPJFLJPKKJK >= 0 && HKJOAJOKOIJ.NAADDLFFIHG[j].FOAPDJMIFGP > 0 && HKJOAJOKOIJ.NAADDLFFIHG[j].FOAPDJMIFGP <= NJBJIIIACEP.NBBBLJDBLNM)
                {
                    return HKJOAJOKOIJ.NAADDLFFIHG[j].FOAPDJMIFGP;
                }
            }
            return 0;
        }
        [HarmonyPatch(typeof(DFOGOCNBECG))]
        public static class DFOGOCNBECGPatch
        {
            [HarmonyPrefix]
            [HarmonyPatch(nameof(DFOGOCNBECG.KCFNOONDGKE))]
            public static void KCFNOONDGKEPatch(DFOGOCNBECG __instance, int __result, int CNHJJIPILFK,ref float DGJAEIBKLJO)
            {
                if (configSeparateForPlayer.Value && __instance.PLFGKLGCOMD == GetMainPlayerNum())
                {
                    DGJAEIBKLJO *= configIncreasedTimesPlayer.Value;
                    return;
                }
                DGJAEIBKLJO *= configIncreasedTimes.Value;
            }
            [HarmonyPrefix]
            [HarmonyPatch(nameof(DFOGOCNBECG.CMOPOKMFJMG))]
            public static void CMOPOKMFJMGPatch(DFOGOCNBECG __instance, int IKBHGAKKJMM, ref float DGJAEIBKLJO, float BEMKANDCFCP)
            {
                if (configSeparateForPlayer.Value && __instance.PLFGKLGCOMD == GetMainPlayerNum())
                {
                    DGJAEIBKLJO *= configIncreasedLimbsPlayer.Value;
                    return;
                }
                DGJAEIBKLJO *= configIncreasedLimbs.Value;
            }
        }
    }
}