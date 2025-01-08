using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;

namespace UnlimitedReversals
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.UnlimitedReversals";
        public const string PluginName = "UnlimitedReversals";
        public const string PluginVer = "1.1.0";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        public static ConfigEntry<bool> DisableBotches;
        

        private void Awake()
        {
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);
            DisableBotches = Config.Bind("General",
             "DisableBotches",
             false,
             "Move botching (when both wrestlers fall down) will be disabled");
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

        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.AHOHHCDBLMA))]
        [HarmonyPrefix]  //risk counter
        static void DFOGOCNBECG_AHOHHCDBLMAPrefix(DFOGOCNBECG __instance, DFOGOCNBECG ELPIOHCPOIJ, ref int DGJAEIBKLJO, int GBEJFLOIBOH, float DILPLMPNICB, float KMNBIPKAJAE = 0f)
        {
            if (ELPIOHCPOIJ.EMDMDLNJFKP.id != Characters.star) return;
            DGJAEIBKLJO = int.MaxValue;
        }
        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.PCHGFNPPOEM))] 
        [HarmonyPrefix]  //risk reversal
        static void DFOGOCNBECG_PCHGFNPPOEMPrefix(DFOGOCNBECG __instance, DFOGOCNBECG ELPIOHCPOIJ, ref int DGJAEIBKLJO, float NIIEGJGDAAM = -1f)
        {
            if (ELPIOHCPOIJ.EMDMDLNJFKP.id != Characters.star) return;
            DGJAEIBKLJO = int.MaxValue;
        }

        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.JPPFMOKHMNE))]
        [HarmonyPrefix]  //break  moves
        static void DFOGOCNBECG_JPPFMOKHMNEPrefix(DFOGOCNBECG __instance, int FFFFLHENONC, ref int DGJAEIBKLJO)
        {
            if (DisableBotches.Value == false) return;
            if ((__instance.ELPIOHCPOIJ.EMDMDLNJFKP.id == Characters.star) || (__instance.EMDMDLNJFKP.id == Characters.star))
            {
                DGJAEIBKLJO = int.MinValue;
            }
        }
        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.GEJEKGNJGFG))] 
        [HarmonyPrefix]  //break submissions
        static void DFOGOCNBECG_GEJEKGNJGFGPrefix(DFOGOCNBECG __instance, DFOGOCNBECG ELPIOHCPOIJ, ref float DGJAEIBKLJO)
        {
            if (ELPIOHCPOIJ.EMDMDLNJFKP.id != Characters.star) return;
            DGJAEIBKLJO = 0;
        }
        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.NPOCCMLMFCL))]
        [HarmonyPrefix]  //size difference
        static bool DFOGOCNBECG_NPOCCMLMFCLPrefix(DFOGOCNBECG __instance, ref float __result, DFOGOCNBECG ELPIOHCPOIJ)
        {
            if (ELPIOHCPOIJ.EMDMDLNJFKP.id != Characters.star) return true;
            __result = 0;
            return false;
        }
        public static float temp1;
        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.AHAPJFIDGAO))]
        [HarmonyPrefix]  //Roll out of ground attacks
        static void DFOGOCNBECG_AHAPJFIDGAOPrefix(DFOGOCNBECG __instance, ref int __result, float __0, float __1, float __2)
        {
            if (__instance.EMDMDLNJFKP.id != Characters.star) return;
            temp1 = __instance.OKPAGLBJIOH;
            __instance.OKPAGLBJIOH = -9999999;
        }
        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.AHAPJFIDGAO))]
        [HarmonyPostfix]  //Roll out of ground attacks
        static void DFOGOCNBECG_AHAPJFIDGAOPostfix(DFOGOCNBECG __instance, ref int __result, float __0, float __1, float __2)
        {
            if (__instance.EMDMDLNJFKP.id != Characters.star) return;
            __instance.OKPAGLBJIOH = temp1;
        }
        public static float temp2;
        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.NGCPFPFMPFM))]
        [HarmonyPrefix]  //Rising attacks
        static void DFOGOCNBECG_NGCPFPFMPFMPrefix(DFOGOCNBECG __instance, ref int __result, int __0)
        {
            if (__instance.EMDMDLNJFKP.id != Characters.star) return;
            temp2 = __instance.HNFHLLJOFKI[3];
            __instance.HNFHLLJOFKI[3] = 9999999;
        }
        [HarmonyPatch(typeof(DFOGOCNBECG), nameof(DFOGOCNBECG.NGCPFPFMPFM))]
        [HarmonyPostfix]  //Rising attacks
        static void DFOGOCNBECG_NGCPFPFMPFMPostfix(DFOGOCNBECG __instance, ref int __result, int __0)
        {
            if (__instance.EMDMDLNJFKP.id != Characters.star) return;
            __instance.HNFHLLJOFKI[3] = temp2;
        }
    }
}