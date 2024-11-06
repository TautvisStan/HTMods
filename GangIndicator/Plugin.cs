using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GangIndicator
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.GangIndicator";
        public const string PluginName = "GangIndicator";
        public const string PluginVer = "1.0.1";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);
        private static WaitForSecondsRealtime wait2 = new(2f);
        private static WaitForSecondsRealtime wait1 = new(1f);
        internal static string PluginPath;
        public static bool DisplayGang = false;


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
        private void Start()
        {
            this.StartCoroutine(ToggleBetweenNameGane());
        }
        public static IEnumerator ToggleBetweenNameGane()
        {
            while(true)
            {
                DisplayGang = true;
                yield return wait1;
                DisplayGang = false;
                yield return wait2;
            }
        }
        [HarmonyPatch(typeof(DLNHHGFNIIG), nameof(DLNHHGFNIIG.DIJBHIAAIOF))]
        [HarmonyPostfix]
        public static void DIJBHIAAIOFPatch(DLNHHGFNIIG __instance, int IDHFOGNOIFC = 0)
        {
            DFOGOCNBECG dfogocnbecg = NJBJIIIACEP.OAAMGFLINOB[__instance.NNMDEFLLNBF];
            Character character = dfogocnbecg.EMDMDLNJFKP;
            if (DisplayGang && character.team != 0)
            {
                __instance.KMCJNPILHFA.text = "[" + Characters.c[character.team].teamName + "]";
            }
            else
            {
                __instance.KMCJNPILHFA.text = character.name;
            }
        }
    }
}