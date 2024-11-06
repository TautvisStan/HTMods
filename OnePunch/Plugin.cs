using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

namespace OnePunch
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.OnePunch";
        public const string PluginName = "OnePunch";
        public const string PluginVer = "1.1.6";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;



        public static ConfigEntry<bool> NoHealthAndStun;
        public static ConfigEntry<bool> Dizzyness;
        public static ConfigEntry<bool> InjureTarget;
        public static ConfigEntry<bool> KOTarget;

        public static ConfigEntry<int> Dismemberment;
        public static ConfigEntry<bool> ModEnabled;
        public static ConfigEntry<bool> MultiplayerToggle;
        public static ConfigEntry<KeyCode> ModKeybind;
        public static HashSet<int> EligibleCharacters = new HashSet<int>();
        private void Awake()
        {
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);

            NoHealthAndStun = Config.Bind("General",
             "No Health",
             true,
             "Attacks will remove all health and stun the target");
            Dizzyness = Config.Bind("General",
             "Dizzyness",
             true,
             "Attacks will apply dizzyness to the target");
            InjureTarget = Config.Bind("General",
             "Injure",
             false,
             "Attacks will injure the target");
            KOTarget = Config.Bind("General",
             "Knock out",
             false,
             "Attacks will knock out the target");

            Dismemberment = Config.Bind("General",
             "Dismemberment",
             0, new ConfigDescription("(Experimental) 0: Disabled; 1: random limbs are removed; 2: All limbs are removed", new AcceptableValueList<int>(0, 1, 2))
             );
            ModEnabled = Config.Bind("General",
            "Mod is enabled",
             true,
             "You can use this as a simple way to enable/disable the mod");
            ModKeybind = Config.Bind("General",
             "Mod enabling keybind",
             KeyCode.None,
             "Keybind to enable/disable the mod");
            MultiplayerToggle = Config.Bind("General",
             "Multiplayer toggle",
             false,
             "If enabled, all players will have this power");
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
        private void Update()
        {
            if (Input.GetKeyDown(ModKeybind.Value))
            {
                ModEnabled.Value = !ModEnabled.Value;
            }
        }
        [HarmonyPatch(typeof(DFOGOCNBECG))]
        public static class DFOGOCNBECG_Patch
        {
            [HarmonyPatch(nameof(DFOGOCNBECG.DIIMPIPKAFK))]
            [HarmonyPrefix] //Submission strike attacks
            static void DIIMPIPKAFK_Prefix(DFOGOCNBECG __instance, DFOGOCNBECG ELPIOHCPOIJ, int DODBHICKEPB, float CLNCAKDCODN, float FJDILPBOGEJ)
            {
                if (!GetEligiblePlayers().Contains(__instance.EMDMDLNJFKP.id)) return;
                if (!ModEnabled.Value) return;
                if (Plugin.NoHealthAndStun.Value) DamageStun(ELPIOHCPOIJ);
                if (Plugin.Dizzyness.Value) DizzyTarget(ELPIOHCPOIJ);
                if (Plugin.InjureTarget.Value) Injure(ELPIOHCPOIJ);
                if (Plugin.KOTarget.Value) KnockOut(ELPIOHCPOIJ);
                if (Plugin.Dismemberment.Value == 1) RandomDismemberment(ELPIOHCPOIJ);
                if (Plugin.Dismemberment.Value == 2) FullObliterate(ELPIOHCPOIJ);
                /*  if (Plugin.Dismemberment.Value)
                  {
                      if (DODBHICKEPB == 1)
                      {
                          ELPIOHCPOIJ.CMOPOKMFJMG(3, 10000000, 1f);
                      }
                      if (DODBHICKEPB == 88)
                      {
                          ELPIOHCPOIJ.CMOPOKMFJMG(1, 10000000, 1f);
                      }
                  }*/

            }
            [HarmonyPatch(nameof(DFOGOCNBECG.MHNNBEOCPGA))]
            [HarmonyPrefix] //Grapple attacks
            static void MHNNBEOCPGA_Prefix(DFOGOCNBECG __instance, int MKCPMOJGBEM, float FPLEMEKHJLD, float FJDILPBOGEJ)
            {
                if (!GetEligiblePlayers().Contains(__instance.EMDMDLNJFKP.id)) return;
                if (!ModEnabled.Value) return;
                if (__instance.DPHHFKLDOOG > 0 || __instance.ELPIOHCPOIJ.NLDPMDNKGIC == 643 || __instance.ELPIOHCPOIJ.NLDPMDNKGIC == 644)
                {

                    if (Plugin.NoHealthAndStun.Value) DamageStun(__instance.ELPIOHCPOIJ);
                    if (Plugin.Dizzyness.Value) DizzyTarget(__instance.ELPIOHCPOIJ);
                    if (Plugin.InjureTarget.Value) Injure(__instance.ELPIOHCPOIJ);
                    if (Plugin.KOTarget.Value) KnockOut(__instance.ELPIOHCPOIJ);
                    if (Plugin.Dismemberment.Value == 1) RandomDismemberment(__instance.ELPIOHCPOIJ);
                    if (Plugin.Dismemberment.Value == 2) FullObliterate(__instance.ELPIOHCPOIJ);
                    /* if (Plugin.Dismemberment.Value)
                     {
                         if (__instance.DPHHFKLDOOG > 0 || __instance.ELPIOHCPOIJ.NLDPMDNKGIC == 643 || __instance.ELPIOHCPOIJ.NLDPMDNKGIC == 644)
                         {
                             if (MKCPMOJGBEM == 2 || MKCPMOJGBEM == 4)
                             {
                                 __instance.ELPIOHCPOIJ.CMOPOKMFJMG(3, 10000000, 1f);
                             }
                         }
                     }*/
                }
            }
            [HarmonyPatch(nameof(DFOGOCNBECG.LKGOPCPNDNK))]
            [HarmonyPrefix] //Strike attacks
            static void LKGOPCPNDNK_Prefix(DFOGOCNBECG __instance, DFOGOCNBECG __0, int __1, float __2)
            {
                if (!GetEligiblePlayers().Contains(__instance.EMDMDLNJFKP.id)) return;
                if (!ModEnabled.Value) return;
                if (Plugin.NoHealthAndStun.Value) DamageStun(__0);
                if (Plugin.Dizzyness.Value) DizzyTarget(__0);
                if (Plugin.InjureTarget.Value) Injure(__0);
                if (Plugin.KOTarget.Value) KnockOut(__0);
                if (Plugin.Dismemberment.Value == 1) RandomDismemberment(__0);
                if (Plugin.Dismemberment.Value == 2) FullObliterate(__0);
                /*  if (Plugin.Dismemberment.Value)
                  {

                  }*/

            }
            [HarmonyPatch(nameof(DFOGOCNBECG.PFGONEIPHLJ))]
            [HarmonyPrefix] //Ground attacks
            static void PFGONEIPHLJ_Prefix(DFOGOCNBECG __instance, float KCMMOFECACH, float HAFBGEAMBMI, float JHCBBFEIKHL, int HNMOIBIFJID, float CLNCAKDCODN, float FJDILPBOGEJ)
            {
                if (!GetEligiblePlayers().Contains(__instance.EMDMDLNJFKP.id)) return;
                if (!ModEnabled.Value) return;
                HAFBGEAMBMI *= __instance.JNLAJNFCDHA;
                KCMMOFECACH *= __instance.JNLAJNFCDHA;
                float num = __instance.NJDGEELLAKG;
                float num2 = __instance.BMFDFFLPBOJ;
                float num3 = HAFBGEAMBMI;
                if (num3 < KCMMOFECACH / 2f)
                {
                    num3 = KCMMOFECACH / 2f;
                }
                num += NAEEIFNFBBO.PDOBPEFCMCK(__instance.PJJFOALHEPF, num3);
                num2 += NAEEIFNFBBO.GPMMBFPCFFL(__instance.PJJFOALHEPF, num3);
                CLNCAKDCODN *= 0.5f + __instance.HNFHLLJOFKI[2] / 200f;
                int num4 = 0;
                int num5 = 0;
                int num6 = 0;
                float num7 = 9999f;
                for (int i = 1; i <= NJBJIIIACEP.NBBBLJDBLNM; i++)
                {
                    DFOGOCNBECG dfogocnbecg = NJBJIIIACEP.OAAMGFLINOB[i];
                    if (i != __instance.PLFGKLGCOMD && dfogocnbecg.AHBNKMMMGFI > 0f && __instance.KPEFINJBJLJ[i] == 0 && LIPNHOMGGHF.FAKHAFKOBPB != 60)
                    {
                        int num8 = dfogocnbecg.KFHGMKAKGDC();
                        if ((HNMOIBIFJID > 0 && num8 > 0) || num8 >= 3)
                        {
                            float num9 = (dfogocnbecg.DFINJNKKMFL(1) + dfogocnbecg.DFINJNKKMFL(3)) / 2f;
                            num9 += 4f * (__instance.JNLAJNFCDHA * dfogocnbecg.JNLAJNFCDHA);
                            if (i == __instance.NNMDEFLLNBF)
                            {
                                //Debug.Log("impactY=" + JHCBBFEIKHL.ToString() + " topY=" + num9.ToString());
                            }
                            if (JHCBBFEIKHL > dfogocnbecg.FNNBCDPJBIO - 3f && JHCBBFEIKHL <= num9)
                            {
                                int num10 = dfogocnbecg.MDOAGGHHHDC(num, num2, KCMMOFECACH);
                                if (num10 == 0)
                                {
                                    num10 = dfogocnbecg.MDOAGGHHHDC((__instance.NJDGEELLAKG + num) / 2f, (__instance.BMFDFFLPBOJ + num2) / 2f, KCMMOFECACH / 2f);
                                }
                                if (__instance.GDIEPKEPCAJ() == 0 && num8 >= 3 && dfogocnbecg.ECCLLOHOJDO(10) > 0 && __instance.KDDHPODFDHB != -1)
                                {
                                    num10 = 0;
                                }
                                if (dfogocnbecg.DFINJNKKMFL(1) > dfogocnbecg.FNNBCDPJBIO + 10f * dfogocnbecg.JNLAJNFCDHA)
                                {
                                    num10 = 0;
                                }
                                if (num10 > 0 && __instance.GDIEPKEPCAJ() > 0)
                                {
                                    if (__instance.GEPLNBJEDLH[9] < 0 && __instance.GEPLNBJEDLH[12] < 0)
                                    {
                                        num10 = 0;
                                    }
                                    if (GIMNNPMAKNJ.JIHKMLJICDO(__instance.NJDGEELLAKG, __instance.BMFDFFLPBOJ, 0f) != GIMNNPMAKNJ.JIHKMLJICDO(dfogocnbecg.NJDGEELLAKG, dfogocnbecg.BMFDFFLPBOJ, 0f))
                                    {
                                        num10 = 0;
                                    }
                                    if (Mathf.Abs(__instance.EKOHAKPAOGN - dfogocnbecg.EKOHAKPAOGN) > 2f || Mathf.Abs(__instance.FNNBCDPJBIO - dfogocnbecg.FNNBCDPJBIO) > 2f || __instance.NELODEMHJHN != dfogocnbecg.NELODEMHJHN)
                                    {
                                        num10 = 0;
                                    }
                                    if (__instance.KPEFINJBJLJ[0] != 0)
                                    {
                                        num10 = 0;
                                    }
                                    if ((__instance.NEMJMNEGAAH(i) > 0 || dfogocnbecg.FIEMGOLBHIO == 3) && __instance.NNMDEFLLNBF > 0 && __instance.NNMDEFLLNBF != i && __instance.JKIPPBBKNOC != i)
                                    {
                                        num10 = 0;
                                    }
                                }
                                if (dfogocnbecg.CJAFIDDNBOC() > 0)
                                {
                                    num10 = 0;
                                }
                                if (GIMNNPMAKNJ.DMPAOJMIAHN(__instance.NJDGEELLAKG, __instance.DFINJNKKMFL(1), __instance.BMFDFFLPBOJ, dfogocnbecg.NJDGEELLAKG, dfogocnbecg.DFINJNKKMFL(1), dfogocnbecg.BMFDFFLPBOJ) > 0)
                                {
                                    num10 = 0;
                                }
                                if (dfogocnbecg.NELODEMHJHN > 0 && HAPFAOIMGOL.OMOGPIJGMKO[dfogocnbecg.NELODEMHJHN].HOBALCFBGBK() != 0)
                                {
                                    num10 = 0;
                                }
                                if (num10 > 0)
                                {
                                    float num11 = NAEEIFNFBBO.FHPCDHIGILG(num, num2, dfogocnbecg.NJDGEELLAKG, dfogocnbecg.BMFDFFLPBOJ);
                                    if (num8 <= 2)
                                    {
                                        num11 *= 4f;
                                    }
                                    if (__instance.GDIEPKEPCAJ() > 0 && dfogocnbecg.MKKDHANKPEN > 0)
                                    {
                                        num11 *= 2f;
                                    }
                                    if ((__instance.NEMJMNEGAAH(i) > 0 || dfogocnbecg.FIEMGOLBHIO == 3) && __instance.NNMDEFLLNBF != i && __instance.JKIPPBBKNOC != i)
                                    {
                                        num11 *= 10f;
                                    }
                                    if (num11 < num7)
                                    {
                                        num5 = 1;
                                        num4 = i;
                                        num6 = num10;
                                        num7 = num11;
                                    }
                                }
                            }
                        }
                    }
                }
                if (__instance.KPEFINJBJLJ[0] == 0 && __instance.GPKBOEBABNI[0] == 0 && __instance.GDIEPKEPCAJ() == 0)
                {
                    for (int i = 1; i <= HAPFAOIMGOL.HOEGNFNHMOA; i++)
                    {
                        GGKBLABCJFN ggkblabcjfn = HAPFAOIMGOL.OMOGPIJGMKO[i];
                        if (ggkblabcjfn.LOBDMDPMFLK < 0 || (ggkblabcjfn.LOBDMDPMFLK > 0 && HNMOIBIFJID >= 2))
                        {
                            float num11 = NAEEIFNFBBO.FHPCDHIGILG(__instance.NJDGEELLAKG, __instance.BMFDFFLPBOJ, ggkblabcjfn.NJDGEELLAKG, ggkblabcjfn.BMFDFFLPBOJ);
                            if (ggkblabcjfn.GBLDMIAPNEP(num, JHCBBFEIKHL, num2, 0f) > 0 && i != __instance.NELODEMHJHN && num11 < num7)
                            {
                                num5 = 2;
                                num4 = i;
                                num7 = num11;
                            }
                        }
                    }
                }
                if (num5 == 1 && num4 > 0)
                {
                    int i = num4;
                    DFOGOCNBECG dfogocnbecg = NJBJIIIACEP.OAAMGFLINOB[i];
                    if (Plugin.NoHealthAndStun.Value) DamageStun(dfogocnbecg);
                    if (Plugin.Dizzyness.Value) DizzyTarget(dfogocnbecg);
                    if (Plugin.InjureTarget.Value) Injure(dfogocnbecg);
                    if (Plugin.KOTarget.Value) KnockOut(dfogocnbecg);
                    if (Plugin.Dismemberment.Value == 1) RandomDismemberment(dfogocnbecg);
                    if (Plugin.Dismemberment.Value == 2) FullObliterate(dfogocnbecg);

                }
            }




     /*       [HarmonyPatch(nameof(DFOGOCNBECG.CMOPOKMFJMG))]
            [HarmonyPrefix] //Dismemberment
            static void CMOPOKMFJMG_Prefix(DFOGOCNBECG __instance, ref int IKBHGAKKJMM, ref float DGJAEIBKLJO, ref float BEMKANDCFCP)
            {
                if(Dismemberment.Value == true)
                {
                    StackFrame frame = new StackFrame(1, true);
                    var method = frame.GetMethod();
                    if(method.Name == "DIIMPIPKAFK") // Submission strikes
                    {
                        DGJAEIBKLJO = 1000000f;
                    }
                    if (method.Name == "DIIMPIPKAFK") // Submission strikes
                    {
                        DGJAEIBKLJO = 1000000f;
                    }
                } 
            }*/
        }
        public static HashSet<int> GetEligiblePlayers()
        {
            HashSet<int> ints = new()
            {
                Characters.star
            };
            if (MultiplayerToggle.Value)
            {
                for (int j = 0; j <= HKJOAJOKOIJ.NGCNKGDDKGF; j++)
                {
                    if (HKJOAJOKOIJ.NAADDLFFIHG[j].AHBNKMMMGFI > 0 && HKJOAJOKOIJ.NAADDLFFIHG[j].BPJFLJPKKJK >= 0 && HKJOAJOKOIJ.NAADDLFFIHG[j].FOAPDJMIFGP > 0 && HKJOAJOKOIJ.NAADDLFFIHG[j].FOAPDJMIFGP <= NJBJIIIACEP.NBBBLJDBLNM)
                    {
                        ints.Add(HKJOAJOKOIJ.NAADDLFFIHG[j].GOOKPABIPBC);
                    }
                }
            }
            return ints;
        }
        public static void RandomDismemberment(DFOGOCNBECG instance)
        {
            int limb = UnityEngine.Random.Range(3, 16);
            instance.CMOPOKMFJMG(limb, 1000000f, 10f);
        }
        public static void FullObliterate(DFOGOCNBECG instance)
        {
            for (int i = 3; i <= 15; i++) 
            {
                instance.CMOPOKMFJMG(i, 1000000f, 10f);
            }
        }
        public static void Injure(DFOGOCNBECG instance)
        {
            //DFOGOCNBECG instance = NJBJIIIACEP.OAAMGFLINOB[NJBJIIIACEP.DCAFAIGGFCC[2].NNMDEFLLNBF];
            instance.PGJEOKAEPCL = UnityEngine.Random.Range(1, 31);
            // instance.EMDMDLNJFKP.injury = instance.AIFCLDHKEJN;
            if (FFCEGMEAIBP.LOBDMDPMFLK == 0 && instance.EMDMDLNJFKP.injuryTime < 2)
            {
                instance.EMDMDLNJFKP.injuryTime = 2;
            }
            CHLPMKEGJBJ.BPLLANFDDDP(instance.GPGOFIFBCLP, CHLPMKEGJBJ.KEMDEGPNJAD[NAEEIFNFBBO.PMEEFNOLAGF(1, 2, 0)], -0.1f, 1f);
            instance.KMGCIKMAJCJ(NAEEIFNFBBO.PMEEFNOLAGF(2, 3, 0), 1f);
            CHLPMKEGJBJ.KIKKPCJGDLM(0, 0, 0f);
            instance.HLGALFAGDGC /= 2f;
            instance.BBBGPIILOBB /= 2f;
            Characters.LPGPAKHJMMA(NJBJIIIACEP.OAAMGFLINOB[instance.JNNBBJKLEFK].GOOKPABIPBC, instance.GOOKPABIPBC);
            NJBJIIIACEP.PKGACKAGENN(instance.JNNBBJKLEFK, instance.PLFGKLGCOMD, 1);
        }
        public static void KnockOut(DFOGOCNBECG instance)
        {
            instance.DMEDPMIPBAO = 1;
            instance.MGPDGDCIBGC = 1f;
        }
        public static void DamageStun(DFOGOCNBECG instance)
        {
            instance.HLGALFAGDGC = 0;
            instance.OIHGGHEDIFF = 0;
            instance.OKPAGLBJIOH = float.MaxValue;
        }
        public static void DizzyTarget(DFOGOCNBECG instance)
        {
            instance.FLOPBFFLLDE = float.MinValue;
        }
    }

}