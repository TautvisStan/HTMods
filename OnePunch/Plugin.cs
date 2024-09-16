using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace OnePunch
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.WrestlingEmpire.OnePunch";
        public const string PluginName = "OnePunch";
        public const string PluginVer = "1.1.2";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;



        public static ConfigEntry<bool> NoHealthAndStun;
        public static ConfigEntry<bool> Dizzyness;
        public static ConfigEntry<bool> InjureTarget;
        public static ConfigEntry<bool> KOTarget;

       // public static ConfigEntry<bool> Dismemberment;

        private void Awake()
        {
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);

            NoHealthAndStun = Config.Bind("General",
             "No Health",
             true,
             "Punches will remove all health and stun the target");
            Dizzyness = Config.Bind("General",
             "Dizzyness",
             true,
             "Punches will apply dizzyness to the target");
            InjureTarget = Config.Bind("General",
             "Injure",
             false,
             "Punches will injure the target");
            KOTarget = Config.Bind("General",
             "Knock out",
             false,
             "Punches will DQ and knock out the target");

       /*     Dismemberment = Config.Bind("General",
 "Dismemberment",
 false,
 "Dismemberment");*/
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
        public static class DFOGOCNBECG_Patch
        {
            [HarmonyPatch(nameof(DFOGOCNBECG.DIIMPIPKAFK))]
            [HarmonyPrefix] //Submission strike attacks
            static void DIIMPIPKAFK_Prefix(DFOGOCNBECG __instance, DFOGOCNBECG ELPIOHCPOIJ, int DODBHICKEPB, float CLNCAKDCODN, float FJDILPBOGEJ)
            {
                if (__instance.EMDMDLNJFKP.id != Characters.star) return;
                if (Plugin.NoHealthAndStun.Value) DamageStun(ELPIOHCPOIJ);
                if (Plugin.Dizzyness.Value) DizzyTarget(ELPIOHCPOIJ);
                if (Plugin.InjureTarget.Value) Injure(ELPIOHCPOIJ);
                if (Plugin.KOTarget.Value) KnockOut(ELPIOHCPOIJ);
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
                if (__instance.EMDMDLNJFKP.id != Characters.star) return;
                if (__instance.DPHHFKLDOOG > 0 || __instance.ELPIOHCPOIJ.NLDPMDNKGIC == 643 || __instance.ELPIOHCPOIJ.NLDPMDNKGIC == 644)
                {

                    if (Plugin.NoHealthAndStun.Value) DamageStun(__instance.ELPIOHCPOIJ);
                    if (Plugin.Dizzyness.Value) DizzyTarget(__instance.ELPIOHCPOIJ);
                    if (Plugin.InjureTarget.Value) Injure(__instance.ELPIOHCPOIJ);
                    if (Plugin.KOTarget.Value) KnockOut(__instance.ELPIOHCPOIJ);
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
                if (__instance.EMDMDLNJFKP.id != Characters.star) return;
                if (Plugin.NoHealthAndStun.Value) DamageStun(__0);
                if (Plugin.Dizzyness.Value) DizzyTarget(__0);
                if (Plugin.InjureTarget.Value) Injure(__0);
                if (Plugin.KOTarget.Value) KnockOut(__0);
              /*  if (Plugin.Dismemberment.Value)
                {
              
                }*/

            }
            [HarmonyPatch(nameof(DFOGOCNBECG.PFGONEIPHLJ))]
            [HarmonyPrefix] //Ground attacks
            static void PFGONEIPHLJ_Prefix(DFOGOCNBECG __instance, float KCMMOFECACH, float HAFBGEAMBMI, float JHCBBFEIKHL, int HNMOIBIFJID, float CLNCAKDCODN, float FJDILPBOGEJ)
            {
                if (__instance.EMDMDLNJFKP.id != Characters.star) return;
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
            if (FFCEGMEAIBP.FEAOFHKANPP == 16)
            {
                CHLPMKEGJBJ.KIKKPCJGDLM(0, NAEEIFNFBBO.CFPJBJFFJFH(3, 20), 1f);
                FFCEGMEAIBP.MBJFIEPNHPP *= 0.8f;
            }
            else
            {
                CHLPMKEGJBJ.KIKKPCJGDLM(0, -1, 1f);
                CHLPMKEGJBJ.KIKKPCJGDLM(0, NAEEIFNFBBO.PMEEFNOLAGF(16, 20, 0), 0f);
                FFCEGMEAIBP.MBJFIEPNHPP += instance.HNFHLLJOFKI[1] * (instance.HNFHLLJOFKI[1] / 10f) * instance.DFKNBACDFGM(0);
                if (FFCEGMEAIBP.NHMKFGOLHJA == 16)
                {
                    FFCEGMEAIBP.MBJFIEPNHPP += instance.HNFHLLJOFKI[1] * (instance.HNFHLLJOFKI[1] / 10f) * instance.DFKNBACDFGM(0);
                }
            }
            FFCEGMEAIBP.IJOIMLGJION += 250f * instance.DFKNBACDFGM(0);
            instance.HLGALFAGDGC /= 2f;
            instance.BBBGPIILOBB /= 2f;
            if (FFCEGMEAIBP.LOBDMDPMFLK != 0)
            {
                for (int i = 1; i <= NJBJIIIACEP.NBBBLJDBLNM; i++)
                {
                    if (NJBJIIIACEP.OAAMGFLINOB[i].FIEMGOLBHIO == 3 || NJBJIIIACEP.OAAMGFLINOB[i].FIEMGOLBHIO == 0)
                    {
                        NJBJIIIACEP.OAAMGFLINOB[i].PFHOHKJMLLN = 48;
                    }
                }
            }
            Characters.LPGPAKHJMMA(NJBJIIIACEP.OAAMGFLINOB[instance.JNNBBJKLEFK].GOOKPABIPBC, instance.GOOKPABIPBC);
            NJBJIIIACEP.PKGACKAGENN(instance.JNNBBJKLEFK, instance.PLFGKLGCOMD, 1);
        }
        public static void KnockOut(DFOGOCNBECG instance)
        {
            instance.DMEDPMIPBAO = 1;
            if (FFCEGMEAIBP.LOBDMDPMFLK > 0 && instance.FIEMGOLBHIO == 1 && instance.MGPDGDCIBGC == 0)
            {
                FFCEGMEAIBP.NCAAOLGAGCG(instance.JNNBBJKLEFK, instance.PLFGKLGCOMD);
            }
            instance.MGPDGDCIBGC = 1f;


            FFCEGMEAIBP.JPBHIEOKODO = FFCEGMEAIBP.BCENJCEONEB(1);
            if (FFCEGMEAIBP.JPBHIEOKODO == 0)
            {
                FFCEGMEAIBP.CADLONHABMC = 0;
                if (FFCEGMEAIBP.GDKCEGBINCM >= 1 && FFCEGMEAIBP.GDKCEGBINCM <= 2)
                {
                    FFCEGMEAIBP.GDKCEGBINCM = 0;
                }
            }
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