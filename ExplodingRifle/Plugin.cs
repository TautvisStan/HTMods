using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;
using UnityEngine;

namespace ExplodingRifle
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.ExplodingRifle";
        public const string PluginName = "ExplodingRifle";
        public const string PluginVer = "1.0.0";

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
        
        //redefining rifle bullet type
        [HarmonyPatch(typeof(GDFKEAMIOAG), nameof(GDFKEAMIOAG.KMOINLEIEFP))]
        [HarmonyPostfix]
        public static void GDFKEAMIOAG_KMOINLEIEFP(GDFKEAMIOAG __instance, int EOACDBFKAJN)
        {
            if (__instance.BPJFLJPKKJK == 77)
            {
                __instance.KBCBBFICEOF = 109;
            }
        }
        //adding explosions to the bullet type
        [HarmonyPatch(typeof(MGNAAEFLPAO), nameof(MGNAAEFLPAO.BLJNNEDCMEI))]
        [HarmonyPostfix]
        public static void MGNAAEFLPAO_BLJNNEDCMEI(MGNAAEFLPAO __instance, int CHMHJJNEMKB, int GBEIBBHOFDJ = 0, int ALFCKJLJNIH = 0, GameObject NMNPIAIJBGN = null, int EKHAOGKOCGP = 0)
        {
            if (__instance.BPJFLJPKKJK == 109)
            {
                __instance.HLFLAOAEPHL = 1;
            }
        }
    }
   
}