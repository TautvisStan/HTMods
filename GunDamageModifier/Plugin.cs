using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;
using UnityEngine;

namespace GunDamageModifier
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.GunDamageModifier";
        public const string PluginName = "GunDamageModifier";
        public const string PluginVer = "1.0.0";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;
        public static ConfigEntry<int> AdditionalDamage;


        private void Awake()
        {
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);

            AdditionalDamage = Config.Bind("General",
             "Additional Damage",
             500,
             new ConfigDescription("The damage amount that gets added", new AcceptableValueRange<int>(-10000, 10000)));
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
        
        [HarmonyPatch(typeof(MGNAAEFLPAO), nameof(MGNAAEFLPAO.BLJNNEDCMEI))]
        [HarmonyPostfix]
        public static void MGNAAEFLPAO_BLJNNEDCMEI(MGNAAEFLPAO __instance, int CHMHJJNEMKB, int GBEIBBHOFDJ = 0, int ALFCKJLJNIH = 0, GameObject NMNPIAIJBGN = null, int EKHAOGKOCGP = 0)
        {
            __instance.EGEJHPIGGFJ += AdditionalDamage.Value;
        }
    }
   
}