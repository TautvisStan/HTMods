using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using UnityEngine;

namespace WinAllCourtCases
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.WinAllCourtCases";
        public const string PluginName = "WinAllCourtCases";
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
        [HarmonyPatch(typeof(NEGAFEHECNL), nameof(NEGAFEHECNL.DDFCHMANLEL))]
        [HarmonyPostfix]
        public static void NEGAFEHECNL_DDFCHMANLEL_Postfix()
        {
            if (NEGAFEHECNL.ODOAPLMOJPD == 5)
            {
                if (NEGAFEHECNL.BBPPMGDKCBJ[1].id == Characters.star) NEGAFEHECNL.PEJALFBEOKC = 1;
                if (NEGAFEHECNL.BBPPMGDKCBJ[2].id == Characters.star) NEGAFEHECNL.PEJALFBEOKC = 2;
            }
        }
    }
}