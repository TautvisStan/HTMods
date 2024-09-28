using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using UnityEngine;

namespace SelectibleCrime
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.SelectibleCrime";
        public const string PluginName = "SelectibleCrime";
        public const string PluginVer = "1.0.0";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);
        public static int CrimeButton;
        internal static string PluginPath;
        public static int CachedCrime = 0;

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
        [HarmonyPatch(typeof(LIPNHOMGGHF))]
        public static class LIPNHOMGGHF_Patch
        {
            [HarmonyPostfix]
            [HarmonyPatch("ICGNAJFLAHL")]
            public static void ICGNAJFLAHL_Patch()
            {
                if (LIPNHOMGGHF.FAKHAFKOBPB == 60)
                {
                    if (LIPNHOMGGHF.CHLJMEPFJOK == 1 && LIPNHOMGGHF.ODOAPLMOJPD == 0)
                    {
                        LIPNHOMGGHF.DFLLBNMHHIH();
                        LIPNHOMGGHF.FKANHDIMMBJ[LIPNHOMGGHF.HOAOLPGEBKJ].ICGNAJFLAHL(2, "Crime", -400f, -235f, 1.5f, 1.5f);
                        CrimeButton = LIPNHOMGGHF.HOAOLPGEBKJ;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(Scene_Editor))]
        public static class Scene_Editor_Patch
        {
            [HarmonyPostfix]
            [HarmonyPatch("Update")]
            public static void Scene_Editor_Update()
            {
                if (LIPNHOMGGHF.CHLJMEPFJOK == 1 && LIPNHOMGGHF.ODOAPLMOJPD == 0)
                {
                    Characters.c[Characters.foc].crime = Mathf.RoundToInt(LIPNHOMGGHF.FKANHDIMMBJ[CrimeButton].ODONMLDCHHF(Characters.c[Characters.foc].crime, 1f, 10f, -71f, 29, 1));
                    LIPNHOMGGHF.FKANHDIMMBJ[CrimeButton].FFCNPGPALPD = NEGAFEHECNL.NIMOICFLNEL(Characters.c[Characters.foc].crime, 0, "L");

                }
                CachedCrime = Characters.c[Characters.foc].crime;
            }
        }
        [HarmonyPatch(typeof(Progress), nameof(Progress.LOOPFGAFBDF))]
        [HarmonyPostfix]
        public static void Progress_LOOPFGAFBDF_Postfix()
        {
            Characters.c[Characters.star].crime = CachedCrime;
        }
    }
}