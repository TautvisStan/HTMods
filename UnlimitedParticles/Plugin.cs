using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UnlimitedParticles
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.UnlimitedParticles";
        public const string PluginName = "UnlimitedParticles";
        public const string PluginVer = "1.0.4";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);
        public static ConfigEntry<int> configSize;
        public static ConfigEntry<bool> configScars;
        public static ConfigEntry<bool> configLostLimbBleed;
        internal static string PluginPath;
        public static Dictionary<int, float> _overrideTimers = new Dictionary<int, float>();
        public static float PuddleSpeed = 0;

        private void Awake()
        {
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);
            configSize = Config.Bind("General",
             "New Limit",
             10000,
             "New particles limit. Too many particles on screen might cause performance issues");
            configScars = Config.Bind("General",
             "Preserve scars",
             true,
             "Having this enabled will also prevent body scars from disappearing");
            configLostLimbBleed = Config.Bind("General",
 "Permanent lost limb bleed",
 false,
 "If enabled, lost limbs will never stop bleeding (Requires 'Preserve scars' to be enabled)");
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

        //extending array
        [HarmonyPatch(typeof(ALIGLHEIAGO), nameof(ALIGLHEIAGO.ICGNAJFLAHL))]
        [HarmonyPostfix]
        public static void ALIGLHEIAGO_ICGNAJFLAHL()
        {
            var testarray = new MEHJAJJNHLL[configSize.Value + 1];
            for (int m = 0; m <= configSize.Value; m++)
            {
                testarray[m] = new MEHJAJJNHLL();
                testarray[m].PLFGKLGCOMD = m;
            }
            if(ALIGLHEIAGO.HGLADILOIJA != null)
            {
                Array.Copy(ALIGLHEIAGO.HGLADILOIJA, testarray, ALIGLHEIAGO.AABNMPIJODF + 1);
            }
            ALIGLHEIAGO.HGLADILOIJA = testarray;
            ALIGLHEIAGO.AABNMPIJODF = configSize.Value;
        }



        //save scars from disappearing naturally
        static int[] oldGEPLNBJEDLH = new int[17];
        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.JEJGJPAOCBG))]
        [HarmonyPrefix]
        static void DFOGOCNBECG_JEJGJPAOCBG_Prefix(DFOGOCNBECG __instance)
        {
            if (configScars.Value)
            {
                for (int i = 1; i < 16; i++)
                {
                    oldGEPLNBJEDLH[i] = __instance.GEPLNBJEDLH[i];
                }
            }

        }
        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.JEJGJPAOCBG))]
        [HarmonyPostfix]
        static void DFOGOCNBECG_JEJGJPAOCBG_Postfix(DFOGOCNBECG __instance)
        {
            if (configScars.Value)
            {
                if (PFKAPGFJKHH.KBJJNCAJHFF() > 0)
                {
                    int num = 1;
                    int num2 = 16;
                    if (PFKAPGFJKHH.KBJJNCAJHFF() <= 1)
                    {
                        num = 3;
                        num2 = 3;
                    }
                    for (int i = num; i <= num2; i++)
                    {
                        if (__instance.GEPLNBJEDLH[i] <= 3 && __instance.NLDPMDNKGIC != 120)
                        {
                            if (World.KMDDHMEINIO(__instance.EMKLFKIAFLF(i), __instance.DFINJNKKMFL(i), __instance.KNEIMEMEAGP(i)) > 0 || (__instance.NLDPMDNKGIC == 57 && i >= 9 && i <= 10) || (__instance.NLDPMDNKGIC == 57 && i >= 12 && i <= 13))
                            {
                                return;
                            }
                            else
                            {
                                if (__instance.GEPLNBJEDLH[i] != oldGEPLNBJEDLH[i])
                                {
                                    if (__instance.GEPLNBJEDLH[i] < 0 && !configLostLimbBleed.Value) return;
                                    __instance.GEPLNBJEDLH[i] = oldGEPLNBJEDLH[i];
                                }
                            }
                        }
                    }
                }
            }
        }




        //prevent puddles from disappearing
        [HarmonyPatch(typeof(MEHJAJJNHLL), nameof(MEHJAJJNHLL.DIJBHIAAIOF))]
        [HarmonyPostfix]
        public static void ALIGLHEIAGOO_DIJBHIAAIOF(MEHJAJJNHLL __instance)
        {
            if (__instance != null)
            {
                bool flag = __instance.BPJFLJPKKJK >= 0;
                if (!flag)
                {
                    if (__instance.DDLDBDJEPJA <= 0) return;
                    if (__instance.CAILAODIPDO <= 0) return;
                    if (__instance.GKAKINIMLGA <= 0) return;
                    __instance.JPMOFJPKINC = 1;
                    float mcjhgehepmd = MBLIOKEDHHB.MCJHGEHEPMD;
                    int plfgklgcomd = __instance.PLFGKLGCOMD;
                    bool flag2 = !_overrideTimers.ContainsKey(plfgklgcomd);
                    if (flag2)
                    {
                        _overrideTimers.Add(plfgklgcomd, 0f);
                    }
                    bool flag3 = __instance.IMJHCHECCED + 2f < _overrideTimers[plfgklgcomd];
                    if (flag3)
                    {
                        _overrideTimers[plfgklgcomd] = __instance.IMJHCHECCED;
                    }
                    Dictionary<int, float> overrideTimers = _overrideTimers;
                    int num = plfgklgcomd;
                    overrideTimers[num] += mcjhgehepmd * PuddleSpeed;
                    bool flag4 = overrideTimers[plfgklgcomd] == 0f;
                    if (flag4)
                    {
                        overrideTimers[plfgklgcomd] = 1f;
                    }
                    __instance.IMJHCHECCED = (float)((int)overrideTimers[plfgklgcomd]);
                }
            }
        }
    }
}