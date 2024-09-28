using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;

namespace ExplodingBarbedWireBat
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.ExplodingBarbedWireBat";
        public const string PluginName = "ExplodingBarbedWireBat";
        public const string PluginVer = "1.0.2";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;
        public static ConfigEntry<float> configSize;
        public static ConfigEntry<bool> configExplosionOnThrow;


        private void Awake()
        {
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);
            configSize = Config.Bind("General",
             "ExplosionSize",
             2f,
             "The size of an explosion");
            configExplosionOnThrow = Config.Bind("General",
             "ExplosionOnThrow",
             true,
             "Make explosions when the weapon hits someone midair");
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
        public class DFOGOCNBECGPatch
        {
            [HarmonyPostfix]
            [HarmonyPatch(nameof(DFOGOCNBECG.IANCANDCNEH))]
            static void Postfix(DFOGOCNBECG __instance, int CGCIFACJJFM, int GKNIAFAOLJK, float BKCOBKGNDAA, float JHCBBFEIKHL, float HCFCAFCHOKA, float FPLEMEKHJLD)
            {
                if (CGCIFACJJFM > 0)
                {
                    var x = BKCOBKGNDAA;
                    var y = JHCBBFEIKHL;
                    var z = HCFCAFCHOKA;
                    GDFKEAMIOAG hgbifncnack = JFLEBEBCGFA.HLLBCKILNNG[CGCIFACJJFM];
                    if (hgbifncnack.CMECDGMCMLC == "Barbed Bat")
                    {
                        if (BKCOBKGNDAA == 0f && JHCBBFEIKHL == 0f && HCFCAFCHOKA == 0f)
                        {
                            x = hgbifncnack.NJDGEELLAKG;
                            y = hgbifncnack.FNNBCDPJBIO;
                            z = hgbifncnack.BMFDFFLPBOJ;
                        }
                        ALIGLHEIAGO.MDFJMAEDJMG(3, 2, new UnityEngine.Color(10f, 10f, 10f), Plugin.configSize.Value, null, x, y, z, 0f, 0f, 0f, 1);
                    }
                }
            }
        }
        [HarmonyPatch(typeof(GDFKEAMIOAG))]
        public class GDFKEAMIOAGPatch
        {
            [HarmonyPostfix]
            [HarmonyPatch(nameof(GDFKEAMIOAG.NDHLEAEDNAK))]
            static void NDHLEAEDNAKPostfix(GDFKEAMIOAG __instance)
            {
                if (Plugin.configExplosionOnThrow.Value)
                {
                    if (__instance.CMECDGMCMLC == "Barbed Bat")
                    {
                        int test = 1;
                        while (test <= NJBJIIIACEP.NBBBLJDBLNM)
                        {
                            DFOGOCNBECG gmikimhfabp = NJBJIIIACEP.OAAMGFLINOB[test];
                            if (__instance.FNNBCDPJBIO > gmikimhfabp.FNNBCDPJBIO && __instance.FNNBCDPJBIO < gmikimhfabp.DFINJNKKMFL(3) + __instance.FBAMIOMCLKM / 2f && __instance.BGPEKDFJGII == 0)
                            {
                                int num = 0;
                                int num2 = gmikimhfabp.KFHGMKAKGDC();
                                if (num2 >= 3)
                                {
                                    num = gmikimhfabp.MDOAGGHHHDC(__instance.NJDGEELLAKG, __instance.BMFDFFLPBOJ, __instance.NIMHPNKOPAE);
                                }
                                else if (__instance.GBLDMIAPNEP(gmikimhfabp.NJDGEELLAKG, __instance.FNNBCDPJBIO, gmikimhfabp.BMFDFFLPBOJ, 0f) > 0)
                                {
                                    if (num2 == 2)
                                    {
                                        num = 2;
                                    }
                                    else
                                    {
                                        num = 1;
                                    }
                                }
                                if (num2 < 0 && __instance.FNNBCDPJBIO < gmikimhfabp.DFINJNKKMFL(1) - 5f)
                                {
                                    num = 0;
                                }
                                if (num > 0)
                                {
                                    float num3 = (__instance.NJDGEELLAKG + gmikimhfabp.NJDGEELLAKG) / 2f;
                                    float num4 = (__instance.BMFDFFLPBOJ + gmikimhfabp.BMFDFFLPBOJ) / 2f;
                                    ALIGLHEIAGO.MDFJMAEDJMG(3, 2, new UnityEngine.Color(10f, 10f, 10f), Plugin.configSize.Value, null, num3, __instance.FNNBCDPJBIO, num4, 0f, 0f, 0f, 1);
                                }
                            }
                            test++;
                        }
                    }
                }
            }
        }
    }
   
}