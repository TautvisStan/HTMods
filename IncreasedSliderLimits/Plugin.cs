using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using UnityEngine;

namespace IncreasedSliderLimits
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.IncreasedSliderLimits";
        public const string PluginName = "IncreasedSliderLimits";
        public const string PluginVer = "1.2.1";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        public static ConfigEntry<float> minStat;
        public static ConfigEntry<float> maxStat;
        public static ConfigEntry<float> minHeight;
        public static ConfigEntry<float> maxHeight;
        public static ConfigEntry<bool> KeepRepAttLocked;

        public static ConfigEntry<float> minbodyMass;
        public static ConfigEntry<float> maxbodyMass;
        public static ConfigEntry<float> minmuscleMass;
        public static ConfigEntry<float> maxmuscleMass;
        public static ConfigEntry<float> minarmMass;
        public static ConfigEntry<float> maxarmMass;

        private void Awake()
        {
           
            Plugin.Log = base.Logger;
            PluginPath = Path.GetDirectoryName(Info.Location);
            minStat = Config.Bind("General",
             "Min Stat",
             50f,
             "The min stat limit");
            maxStat = Config.Bind("General",
             "Max Stat",
             99f,
             "The max stat limit");
            KeepRepAttLocked = Config.Bind("General",
             "Keep Reputation and attitude limits",
             true,
             "Keep default popularity and attitude limits (may prevent some issues)");
            minHeight = Config.Bind("General",
             "Min Height",
             0.8f,
             "The min height limit (by the game units)");
            maxHeight = Config.Bind("General",
             "Max Height",
             1.2f,
             "The max height limit (by the game units)");


            minbodyMass = Config.Bind("General",
 "Min body mass",
 -100f,
 "The min body mass limit");
            maxbodyMass = Config.Bind("General",
"Max body mass",
100f,
"The max body mass limit");
            minmuscleMass = Config.Bind("General",
"Min muscle mass",
0f,
"The min muslce mass limit");
            maxmuscleMass = Config.Bind("General",
"Max muscle mass",
100f,
"The max muscle mass limit");
            minarmMass = Config.Bind("General",
"Min arm mass",
-100f,
"The min body mass limit");
            maxarmMass = Config.Bind("General",
"Max arm mass",
100f,
"The max arm mass limit");

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

        [HarmonyPatch(typeof(AKFIIKOMPLL), nameof(AKFIIKOMPLL.ODONMLDCHHF))]
        [HarmonyPrefix]  //canging slider limits in menus
        static void AKFIIKOMPLL_ODONMLDCHHF_Prefix(AKFIIKOMPLL __instance, float __0, float __1, float __2, ref float __3, ref float __4, int __5)
        {
            if (__1 == 1f && __2 == 5f && __3 == 50f && __4 == 99f && __5 == 0 && (__instance == LIPNHOMGGHF.FKANHDIMMBJ[1] || __instance == LIPNHOMGGHF.FKANHDIMMBJ[2] || __instance == LIPNHOMGGHF.FKANHDIMMBJ[3] || __instance == LIPNHOMGGHF.FKANHDIMMBJ[4] || __instance == LIPNHOMGGHF.FKANHDIMMBJ[5] || __instance == LIPNHOMGGHF.FKANHDIMMBJ[6]) && LIPNHOMGGHF.CHLJMEPFJOK == 4)
            {
                __3 = Plugin.minStat.Value;
                __4 = Plugin.maxStat.Value;
                if ((__instance == LIPNHOMGGHF.FKANHDIMMBJ[1] || __instance == LIPNHOMGGHF.FKANHDIMMBJ[6]) && KeepRepAttLocked.Value)
                {
                    __3 = 50f;
                    __4 = 99f;
                }
            }
            if (__1 == 0.01f && __2 == 10f && __3 == 0.8f && __4 == 1.2f && __5 == 0 && (__instance == LIPNHOMGGHF.FKANHDIMMBJ[3]) && LIPNHOMGGHF.CHLJMEPFJOK == 2)
            {
                __3 = Plugin.minHeight.Value;
                __4 = Plugin.maxHeight.Value;
            }
            if (__1 == 5f && __2 == 10f && __3 == -100f && __4 == 100f && __5 == 0 && (__instance == LIPNHOMGGHF.FKANHDIMMBJ[4]) && LIPNHOMGGHF.CHLJMEPFJOK == 2)
            {
                __3 = Plugin.minbodyMass.Value;
                __4 = Plugin.maxbodyMass.Value;
            }
            if (__1 == 5f && __2 == 10f && __3 == 0f && __4 == 100f && __5 == 0 && (__instance == LIPNHOMGGHF.FKANHDIMMBJ[5]) && LIPNHOMGGHF.CHLJMEPFJOK == 2)
            {
                __3 = Plugin.minmuscleMass.Value;
                __4 = Plugin.maxmuscleMass.Value;
            }
            if (__1 == 5f && __2 == 10f && __3 == -100f && __4 == 100f && __5 == 0 && (__instance == LIPNHOMGGHF.FKANHDIMMBJ[6]) && LIPNHOMGGHF.CHLJMEPFJOK == 2)
            {
                __3 = Plugin.minarmMass.Value;
                __4 = Plugin.maxarmMass.Value;
            }
        }
        [HarmonyPatch(typeof(Character), nameof(Character.IMMIIDECGCF))] //!!!!
        [HarmonyPrefix]  //changing stat limits when training
        static bool Character_IMMIIDECGCF(Character __instance, int LGLHGGDPNPD, ref float OEGLNPMNEOE)
        {
            if (NAEEIFNFBBO.CBMHGKFFHJE > 0)
            {
                OEGLNPMNEOE *= MBLIOKEDHHB.MCJHGEHEPMD;
                int num = Mathf.RoundToInt(__instance.stat[LGLHGGDPNPD]);
                if (LGLHGGDPNPD == 6 && OEGLNPMNEOE > 0f)
                {
                    OEGLNPMNEOE *= (150f - __instance.stat[LGLHGGDPNPD]) / 100f;
                }
                __instance.stat[LGLHGGDPNPD] += OEGLNPMNEOE;
                if ((LGLHGGDPNPD == 1 || LGLHGGDPNPD == 6) && KeepRepAttLocked.Value)
                {
                    if (__instance.stat[LGLHGGDPNPD] < 50f)
                    {
                        __instance.stat[LGLHGGDPNPD] = 50f;
                    }
                    if (__instance.stat[LGLHGGDPNPD] > 99f)
                    {
                        __instance.stat[LGLHGGDPNPD] = 99f;
                    }
                }
                else
                {
                    if (__instance.stat[LGLHGGDPNPD] < Plugin.minStat.Value)
                    {
                        __instance.stat[LGLHGGDPNPD] = Plugin.minStat.Value;
                    }
                    if (__instance.stat[LGLHGGDPNPD] > Plugin.maxStat.Value)
                    {
                        __instance.stat[LGLHGGDPNPD] = Plugin.maxStat.Value;
                    }
                }
                if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && FFCEGMEAIBP.LOBDMDPMFLK == 0 && __instance.id == Characters.star && NJBJIIIACEP.DCAFAIGGFCC != null && NJBJIIIACEP.DCAFAIGGFCC[1].GHGLMKCECOI == 0f)
                {
                    if (Mathf.RoundToInt(__instance.stat[LGLHGGDPNPD]) < num)
                    {
                        CHLPMKEGJBJ.DNNPEAOCDOG(CHLPMKEGJBJ.AEJEOKACNBJ, 1f, 1f);
                        NJBJIIIACEP.DCAFAIGGFCC[1].BFBKLJHKKGE(Characters.statName[LGLHGGDPNPD] + ": " + Mathf.RoundToInt(__instance.stat[LGLHGGDPNPD]).ToString("0") + "%", new Color(0.9f, 0.1f, 0.1f));
                    }
                    if (Mathf.RoundToInt(__instance.stat[LGLHGGDPNPD]) > num)
                    {
                        CHLPMKEGJBJ.DNNPEAOCDOG(CHLPMKEGJBJ.MBEMMCMOJFF, 1f, 1f);
                        NJBJIIIACEP.DCAFAIGGFCC[1].BFBKLJHKKGE(Characters.statName[LGLHGGDPNPD] + ": " + Mathf.RoundToInt(__instance.stat[LGLHGGDPNPD]).ToString("0") + "%", new Color(0.1f, 0.9f, 0.1f));
                    }
                }
            }
            return false;
        }
        [HarmonyPatch(typeof(Character), nameof(Character.LLJKACBKKJM))]  //!!!!
        [HarmonyPrefix]  //preventing it from reseting
        static bool CharacterLLJKACBKKJM(Character __instance)
        {
            {
                if (__instance.health < 0f)
                {
                    __instance.health = 0f;
                }
                if (__instance.health > 100f)
                {
                    __instance.health = 100f;
                }
                if (__instance.oldStat[0] < 0f)
                {
                    __instance.oldStat[0] = 0f;
                }
                if (__instance.oldStat[0] > 100f)
                {
                    __instance.oldStat[0] = 100f;
                }
                for (int i = 1; i <= 6; i++)
                {
                    if ((i == 1 || i == 6) && Plugin.KeepRepAttLocked.Value)
                    {
                        if (__instance.stat[i] < 50f)
                        {
                            __instance.stat[i] = 50f;
                        }
                        if (__instance.stat[i] > 99f)
                        {
                            __instance.stat[i] = 99f;
                        }
                        if (__instance.oldStat[i] < 50f)
                        {
                            __instance.oldStat[i] = 50f;
                        }
                        if (__instance.oldStat[i] > 99f)
                        {
                            __instance.oldStat[i] = 99f;
                        }
                    }
                    else
                    {
                        if (__instance.stat[i] < Plugin.minStat.Value)
                        {
                            __instance.stat[i] = Plugin.minStat.Value;
                        }
                        if (__instance.stat[i] > Plugin.maxStat.Value)
                        {
                            __instance.stat[i] = Plugin.maxStat.Value;
                        }
                        if (__instance.oldStat[i] < Plugin.minStat.Value)
                        {
                            __instance.oldStat[i] = Plugin.minStat.Value;
                        }
                        if (__instance.oldStat[i] > Plugin.maxStat.Value)
                        {
                            __instance.oldStat[i] = Plugin.maxStat.Value;
                        }
                    }
                }
                __instance.stat[0] = __instance.FOOLOEEKEAJ(0);
            }
            return false;
        }
        [HarmonyPatch(typeof(Character), nameof(Character.CGCGAAFNCED))]  //!!!!
        [HarmonyPrefix]  //mass limits
        static bool CharacterCGCGAAFNCED(Character __instance, float JIJABCGMCAG, float FHMHIGJBMHO)
        {
            {
                JIJABCGMCAG *= MBLIOKEDHHB.MCJHGEHEPMD;
                FHMHIGJBMHO *= MBLIOKEDHHB.MCJHGEHEPMD;
                JIJABCGMCAG *= Characters.weightChange;
                FHMHIGJBMHO *= Characters.weightChange;
                int num = Mathf.RoundToInt(__instance.CLDFPOBFKKK());
                __instance.bodyMass += JIJABCGMCAG;
                if (__instance.bodyMass < minbodyMass.Value)
                {
                    __instance.bodyMass = minbodyMass.Value;
                }
                if (__instance.bodyMass > maxbodyMass.Value)
                {
                    __instance.bodyMass = maxbodyMass.Value;
                }
                __instance.muscleMass += FHMHIGJBMHO;
                if (__instance.muscleMass < minmuscleMass.Value)
                {
                    __instance.muscleMass = minmuscleMass.Value;
                }
                if (__instance.muscleMass > maxmuscleMass.Value)
                {
                    __instance.muscleMass = maxmuscleMass.Value;
                }
                __instance.armMass += (JIJABCGMCAG + FHMHIGJBMHO) / 2f;
                if (__instance.armMass < minarmMass.Value)
                {
                    __instance.armMass = minarmMass.Value;
                }
                if (__instance.armMass > maxarmMass.Value)
                {
                    __instance.armMass = maxarmMass.Value;
                }
                if ((LIPNHOMGGHF.FAKHAFKOBPB == 50 || LIPNHOMGGHF.FAKHAFKOBPB == 60 || LIPNHOMGGHF.FAKHAFKOBPB == 70) && __instance.player >= 1 && __instance.player <= NJBJIIIACEP.NBBBLJDBLNM && NJBJIIIACEP.OAAMGFLINOB[__instance.player] != null)
                {
                    NJBJIIIACEP.OAAMGFLINOB[__instance.player].CAOJENFCEPF();
                }
                if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && NAEEIFNFBBO.CBMHGKFFHJE == 1 && __instance.id == Characters.star && __instance.player == NJBJIIIACEP.MLLALIOOPEP && NJBJIIIACEP.DCAFAIGGFCC != null)
                {
                    int num2 = Mathf.RoundToInt(__instance.CLDFPOBFKKK());
                    if (NJBJIIIACEP.DCAFAIGGFCC[1].GHGLMKCECOI == 0f && num2 == NAEEIFNFBBO.HCAHNIBLCMI(num2, 5))
                    {
                        if (num2 < num)
                        {
                            CHLPMKEGJBJ.DNNPEAOCDOG(CHLPMKEGJBJ.MBEMMCMOJFF, 1f, 0.5f);
                            NJBJIIIACEP.DCAFAIGGFCC[1].BFBKLJHKKGE("Weight: " + num2.ToString("0") + "lbs", new Color(0.1f, 0.9f, 0.1f));
                        }
                        if (num2 > num)
                        {
                            CHLPMKEGJBJ.DNNPEAOCDOG(CHLPMKEGJBJ.AEJEOKACNBJ, 1f, 0.5f);
                            NJBJIIIACEP.DCAFAIGGFCC[1].BFBKLJHKKGE("Weight: " + num2.ToString("0") + "lbs", new Color(0.9f, 0.1f, 0.1f));
                            NEGAFEHECNL.PCMJIACMFFN(67, 0, 0, 10);
                        }
                    }
                }
                return false;
            }
        }
        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.DNOMKDPFLGA))]
        [HarmonyTranspiler]  //Transpiler to actually make increased limits work in the game
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            var ConfigValueGetter = AccessTools.PropertyGetter(typeof(ConfigEntry<float>), "Value");
            CodeInstruction prev = null;

            foreach (var instruction in instructions)
            {
                bool changed = false;
                if (instruction.opcode == OpCodes.Ldc_R4)
                {
                    if ((float)instruction.operand == 50f && prev != null && prev.opcode != OpCodes.Ldfld)
                    {
                        CodeInstruction ins1 = new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(Plugin), "minStat"));
                        CodeInstruction ins2 = new CodeInstruction(OpCodes.Call, ConfigValueGetter);
                        yield return ins1;
                        yield return ins2;
                        changed = true;
                        prev = ins2;
                        //codes[i] = new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(Plugin), "minStat"));
                        //codes.Insert(i + 1, new CodeInstruction(OpCodes.Call, ConfigValueGetter));
                    }

                    else if ((float)instruction.operand == 99f)
                    {
                        CodeInstruction ins1 = new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(Plugin), "maxStat"));
                        CodeInstruction ins2 = new CodeInstruction(OpCodes.Call, ConfigValueGetter);
                        yield return ins1;
                        yield return ins2;
                        changed = true;
                        prev = ins2;
                        //codes[i] = new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(Plugin), "maxStat"));
                        //codes.Insert(i + 1, new CodeInstruction(OpCodes.Call, ConfigValueGetter));
                    }
                }
                if (!changed)
                {
                    yield return instruction;
                    prev = instruction;
                }
            }

        }
    }
}