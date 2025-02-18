//TODO: Separate cam rotation (mouse?);
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using UnityEngine;

namespace Splitscreen
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.Splitscreen";
        public const string PluginName = "Splitscreen";
        public const string PluginVer = "1.0.4";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        public static Camera SecondCamera { get; set; } = null;
        public static int SecondPlayerCharID { get; set; } = 0;
        public static int SecondPlayerSceneID { get; set; } = 2;
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
        [HarmonyPatch(typeof(Scene_Game), nameof(Scene_Game.Update))]
        [HarmonyPostfix]
        private static void Game_Update()
        {

            if (HKJOAJOKOIJ.NAADDLFFIHG[1] != null && HKJOAJOKOIJ.NAADDLFFIHG[1].GOOKPABIPBC != 0 && HKJOAJOKOIJ.NAADDLFFIHG[0].GOOKPABIPBC != 0)
            {
                SecondPlayerCharID = HKJOAJOKOIJ.NAADDLFFIHG[1].GOOKPABIPBC;
                SecondPlayerSceneID = HKJOAJOKOIJ.NAADDLFFIHG[1].FOAPDJMIFGP;
            }
            else if (HKJOAJOKOIJ.NAADDLFFIHG[2] != null && HKJOAJOKOIJ.NAADDLFFIHG[2].GOOKPABIPBC != 0 && HKJOAJOKOIJ.NAADDLFFIHG[1].GOOKPABIPBC != 0)
            {
                SecondPlayerCharID = HKJOAJOKOIJ.NAADDLFFIHG[2].GOOKPABIPBC;
                SecondPlayerSceneID = HKJOAJOKOIJ.NAADDLFFIHG[2].FOAPDJMIFGP;
            }
            else
            {
                SecondPlayerCharID = 0;
                SecondPlayerSceneID = 0;
            }
            if(SecondPlayerCharID != 0 && SecondCamera == null)
            {
                if (SecondCamera == null && NJBJIIIACEP.OAAMGFLINOB[2] != null)
                {

                    SecondCamera = Instantiate(Camera.main.gameObject).GetComponent<Camera>();

                    SecondCamera.gameObject.tag = "Untagged";
                    CameraClassCopy.ICGNAJFLAHL();
                    Camera.main.rect = new Rect(0f, 0.5f, 1f, 1f);
                    SecondCamera.rect = new Rect(0f, 0f, 1f, 0.5f);
//vertical
//Camera.main.rect = new Rect(0f, 0f, 0.5f, 1f);
//Splitscreen.Plugin.SecondCamera.rect = new Rect(0.5f, 0f, 1f, 1f)
                }
            }
            if (SecondCamera != null)
            {
                if (NJBJIIIACEP.OAAMGFLINOB != null && NJBJIIIACEP.OAAMGFLINOB.Length > SecondPlayerSceneID && NJBJIIIACEP.OAAMGFLINOB[SecondPlayerSceneID] != null)
                {
                    CameraClassCopy.NNMDEFLLNBF = SecondPlayerSceneID;
                    CameraClassCopy.JCKCCDKDEKP = SecondPlayerSceneID;
                    CameraClassCopy.BPJFLJPKKJK = BLNKDHIGFAN.BPJFLJPKKJK;
                    CameraClassCopy.ONOKPJKPEFL = BLNKDHIGFAN.ONOKPJKPEFL;
                    CameraClassCopy.BKMPKCDDMLF = BLNKDHIGFAN.BKMPKCDDMLF;
                    CameraClassCopy.BEMIDHDBAPB = BLNKDHIGFAN.BEMIDHDBAPB;

                    CameraClassCopy.GMJKGKDFHOH = BLNKDHIGFAN.GMJKGKDFHOH;
                    CameraClassCopy.CJJEGOLMCMF = BLNKDHIGFAN.CJJEGOLMCMF;
                    CameraClassCopy.MLEFLJDMHJL = BLNKDHIGFAN.MLEFLJDMHJL;

                    CameraClassCopy.OGCNMOGKCPE = BLNKDHIGFAN.OGCNMOGKCPE;
                    CameraClassCopy.JHGPIHNAADD = BLNKDHIGFAN.JHGPIHNAADD;
                    CameraClassCopy.AMMOCBAOABP = BLNKDHIGFAN.AMMOCBAOABP;
                    CameraClassCopy.DCLAJILMLMK = BLNKDHIGFAN.DCLAJILMLMK;
                    CameraClassCopy.NLBDCNFGBDL = BLNKDHIGFAN.NLBDCNFGBDL;
                }
                else
                {
                    SecondPlayerCharID = 0;
                    CameraClassCopy.NNMDEFLLNBF = 0;
                    CameraClassCopy.JCKCCDKDEKP = 0;
                }
            }
        }
        [HarmonyPatch(typeof(BLNKDHIGFAN))]
        public class BLNKDHIGFAN_Patch
        {
            [HarmonyPatch(nameof(BLNKDHIGFAN.DIJBHIAAIOF))]
            [HarmonyPostfix]
            public static void DIJBHIAAIOF(int JNCFFGOIJMF = 0)
            {
                if (SecondCamera != null)
                    CameraClassCopy.DIJBHIAAIOF(JNCFFGOIJMF);
            }
            [HarmonyPatch(nameof(BLNKDHIGFAN.EHNKMGPGIBO))]
            [HarmonyPostfix]
            public static void EHNKMGPGIBO()
            {
                if (SecondCamera != null)
                    CameraClassCopy.EHNKMGPGIBO();
            }
            [HarmonyPatch(nameof(BLNKDHIGFAN.FIJILHEFHIK))]
            [HarmonyPostfix]
            public static void FIJILHEFHIK(float MMBJPONJJGM, float EJOKLBHLEEJ)
            {
                if (SecondCamera != null)
                    CameraClassCopy.FIJILHEFHIK(MMBJPONJJGM, EJOKLBHLEEJ);
            }
            [HarmonyPatch(nameof(BLNKDHIGFAN.GMGLHLHLDGM))]
            [HarmonyPostfix]
            public static void GMGLHLHLDGM(int GKNIAFAOLJK, int CBCBKBNCNCC = 70)
            {
                if (SecondCamera != null)
                    CameraClassCopy.GMGLHLHLDGM(GKNIAFAOLJK, CBCBKBNCNCC);
            }
            [HarmonyPatch(nameof(BLNKDHIGFAN.HEJMJEKNCND))]
            [HarmonyPostfix]
            public static void HEJMJEKNCND(float COBPODAOBFG, float JKKHKFIELBP, float DDEDKGKFOMG = -1f, float OCIDDIPCGED = -1f)
            {
                if (SecondCamera != null)
                    CameraClassCopy.HEJMJEKNCND(COBPODAOBFG, JKKHKFIELBP, DDEDKGKFOMG, OCIDDIPCGED);
            }
            [HarmonyPatch(nameof(BLNKDHIGFAN.HJPNCDFFLLI))]
            [HarmonyPostfix]
            public static void HJPNCDFFLLI()
            {
                if (SecondCamera != null)
                    CameraClassCopy.HJPNCDFFLLI();
            }
        /*    [HarmonyPatch(nameof(BLNKDHIGFAN.ICGNAJFLAHL))]
            [HarmonyPostfix]
            public static void ICGNAJFLAHL()
            {

            }*/
            [HarmonyPatch(nameof(BLNKDHIGFAN.JLPLEOBKPCD))]
            [HarmonyPostfix]
            public static void JLPLEOBKPCD()
            {
                if (SecondCamera != null)
                    CameraClassCopy.JLPLEOBKPCD();
            }
            [HarmonyPatch(nameof(BLNKDHIGFAN.KHGDEBJPJON))]
            [HarmonyPostfix]
            public static void KHGDEBJPJON(float KPOFOJOJGDF, float AIEOAPKICPM, float IHEDIODNPFI, float HALIOKJGKDO)
            {
                if (SecondCamera != null)
                    CameraClassCopy.KHGDEBJPJON(KPOFOJOJGDF, AIEOAPKICPM, IHEDIODNPFI, HALIOKJGKDO);
            }
            [HarmonyPatch(nameof(BLNKDHIGFAN.OGACMNANIIM))]
            [HarmonyPostfix]
            public static void OGACMNANIIM(DFOGOCNBECG OAAMGFLINOB)
            {
                if (SecondCamera != null)
                    CameraClassCopy.OGACMNANIIM(OAAMGFLINOB);
            }
            [HarmonyPatch(nameof(BLNKDHIGFAN.OOAMFDCLFMG))]
            [HarmonyPostfix]
            public static void OOAMFDCLFMG(Vector3 IJIAKGAJJAE, Vector3 NKPHKLBPAGF, Vector3 COONEHGPNGG, Vector3 MLBBODNCOOB, Vector3 DABLFMBMHLL)
            {
                if (SecondCamera != null)
                    CameraClassCopy.OOAMFDCLFMG(IJIAKGAJJAE, NKPHKLBPAGF, COONEHGPNGG, MLBBODNCOOB, DABLFMBMHLL);
            }
            [HarmonyPatch(nameof(BLNKDHIGFAN.OPLJCOFMGNO))]
            [HarmonyPostfix]
            public static void OPLJCOFMGNO(float HABMNGPDKJA)
            {
                if (SecondCamera != null)
                    CameraClassCopy.OPLJCOFMGNO(HABMNGPDKJA);
            }
            [HarmonyPatch(nameof(BLNKDHIGFAN.OPNLNIADJIA))]
            [HarmonyPostfix]
            public static void OPNLNIADJIA(GameObject GMBNIJFILBA)
            {
                if (SecondCamera != null)
                {
                    if (GMBNIJFILBA.name.Contains("Label" + SecondPlayerSceneID.ToString("00")))
                    {
                        CameraClassCopy.OPNLNIADJIA(GMBNIJFILBA);
                    }
                }
            }
            [HarmonyPatch(nameof(BLNKDHIGFAN.PGJOAKANLCN))]
            [HarmonyPostfix]
            public static void PGJOAKANLCN(int GOOKPABIPBC, int BDHHBIIKMLP = 2, int FKEMEFPKBBL = 1, float JNLAJNFCDHA = 0.75f)
            {
                if (SecondCamera != null)
                {
                    CameraClassCopy.PGJOAKANLCN(GOOKPABIPBC, BDHHBIIKMLP, FKEMEFPKBBL, JNLAJNFCDHA);
                }
            }
        }
        [HarmonyPatch(typeof(DFOGOCNBECG))]
        public class DFOGOCNBECG_Patch
        {
            [HarmonyPatch(nameof(DFOGOCNBECG.JIAEBDELEFH))]
            [HarmonyPostfix]
            public static void JIAEBDELEFH(DFOGOCNBECG __instance, ref float __result, int IKBHGAKKJMM)
            {
                if (SecondCamera != null)
                {
                    if (__instance.GOOKPABIPBC == SecondPlayerCharID)
                    {
                        if (__instance.PCNHIIPBNEK[IKBHGAKKJMM] != null)
                        {
                            __result = SecondCamera.WorldToScreenPoint(__instance.PCNHIIPBNEK[IKBHGAKKJMM].transform.position).x;
                            return;
                        }
                        __result = 0f;
                    }
                }
            }
            [HarmonyPatch(nameof(DFOGOCNBECG.PEKBCFNOMML))]
            [HarmonyPostfix]
            public static void PEKBCFNOMML(DFOGOCNBECG __instance, ref float __result, int IKBHGAKKJMM)
            {
                if (SecondCamera != null)
                {
                    if (__instance.GOOKPABIPBC == SecondPlayerCharID)
                    {
                        if (__instance.PCNHIIPBNEK[IKBHGAKKJMM] != null)
                        {
                            __result = SecondCamera.WorldToScreenPoint(__instance.PCNHIIPBNEK[IKBHGAKKJMM].transform.position).y;
                            return;
                        }
                        __result = 0f;
                    }
                }
            }
            [HarmonyPatch(nameof(DFOGOCNBECG.JCILAMMPNLJ))]
            [HarmonyPostfix]
            public static void JCILAMMPNLJ(DFOGOCNBECG __instance, ref float __result, int IKBHGAKKJMM)
            {
                if (SecondCamera != null)
                {
                    if (__instance.GOOKPABIPBC == SecondPlayerCharID)
                    {
                        if (__instance.PCNHIIPBNEK[IKBHGAKKJMM] != null)
                        {
                            __result = SecondCamera.WorldToScreenPoint(__instance.PCNHIIPBNEK[IKBHGAKKJMM].transform.position).z;
                            return;
                        }
                        __result = 0f;
                    }
                }
            }
        }
        //in the view of the second camera
        [HarmonyPatch(typeof(NAEEIFNFBBO), nameof(NAEEIFNFBBO.JOBLMELAKJI))]
        [HarmonyPostfix]
        public static void NAEEIFNFBBO_JOBLMELAKJI(ref int __result, Vector3 KAPDKNMIAAP, float GJGFOKOEANG = 0f)
        {
            if (SecondCamera != null)
            {
                Vector3 vector = SecondCamera.WorldToScreenPoint(KAPDKNMIAAP);
                if (vector.z > 0f && vector.y >= -GJGFOKOEANG && vector.y <= (float)Screen.height + GJGFOKOEANG && vector.x >= -GJGFOKOEANG && vector.x <= (float)Screen.width + GJGFOKOEANG)
                {
                    __result = 1;
                }
            }
        }
        //P2 controls
        [HarmonyPatch(typeof(BJMGCKGNCHO), nameof(BJMGCKGNCHO.IOKJAPIEGLB))]
        [HarmonyPostfix]
        public static void BJMGCKGNCHO_IOKJAPIEGLB(BJMGCKGNCHO __instance, ref float __result)
        {
            if (SecondCamera != null)
            {
                if (__instance.GOOKPABIPBC == SecondPlayerCharID)
                {
                    __result = SecondCamera.transform.eulerAngles.y + Mathf.Atan2(__instance.IMBKMMOCBBF, __instance.PNLIFOBMMGG) * 57.29578f;
                }
            }
        }


        public static float temp1;
        public static float temp2;
        public static float temp3;
        public static float temp4;
        public static float temp5;
        public static float temp6;
        //P2 camera controls
        [HarmonyPatch(typeof(BJMGCKGNCHO), nameof(BJMGCKGNCHO.NCOEPCFFBJA))]
        [HarmonyPrefix]
        public static void BJMGCKGNCHO_NCOEPCFFBJA_PRE(BJMGCKGNCHO __instance)
        {
            if (SecondCamera != null)
            {
                if (__instance.PLFGKLGCOMD == 0)
                {
                    
                    temp1 = __instance.IMBKMMOCBBF;
                    temp2 = __instance.PNLIFOBMMGG;
                    temp3 = BLNKDHIGFAN.IFPJBJLEEDB;
                    temp4 = BLNKDHIGFAN.LHBKHGBDPLH;
                    temp5 = BLNKDHIGFAN.KHKIEPDJELK;
                    temp6 = BLNKDHIGFAN.GIBHLNFEPKE;
                }
            }
        }
        [HarmonyPatch(typeof(BJMGCKGNCHO), nameof(BJMGCKGNCHO.NCOEPCFFBJA))]
        [HarmonyPostfix]
        public static void BJMGCKGNCHO_NCOEPCFFBJA_POST(BJMGCKGNCHO __instance)
        {
            if (SecondCamera != null)
            {
               
                    if (NAEEIFNFBBO.JPNIIADMEIE == 0 && LIPNHOMGGHF.GCJKOBOBIGA == 0 && LIPNHOMGGHF.ANFMAHGLGJN > 15 && __instance.BPJFLJPKKJK >= 2 && LIPNHOMGGHF.FAKHAFKOBPB == 50 && (NEGAFEHECNL.LODPJDDLEKI < 1500 || NEGAFEHECNL.LODPJDDLEKI >= 1540) && (__instance.MGJCMCPCPDN != 0f || __instance.JLBOEDNDIPI != 0f))
                    {
                        if (__instance.GOOKPABIPBC == SecondPlayerCharID)
                        {
                            CameraClassCopy.IFPJBJLEEDB = __instance.MGJCMCPCPDN;
                            CameraClassCopy.LHBKHGBDPLH = -__instance.JLBOEDNDIPI * 0.2f;
                            CameraClassCopy.KHKIEPDJELK = __instance.JLBOEDNDIPI * 0.75f;
                            CameraClassCopy.GIBHLNFEPKE = 2f;
                            BLNKDHIGFAN.IFPJBJLEEDB = temp3;
                            BLNKDHIGFAN.LHBKHGBDPLH = temp4;
                            BLNKDHIGFAN.KHKIEPDJELK = temp5;
                            BLNKDHIGFAN.GIBHLNFEPKE = temp6;
                        }
                    }
            }
        }
        //controller icon scaling
        [HarmonyPatch(typeof(BJMGCKGNCHO), nameof(BJMGCKGNCHO.IKONMOHNADC))]
        [HarmonyPrefix]
        public static bool BJMGCKGNCHO_IKONMOHNADC(BJMGCKGNCHO __instance)
        {
            if (SecondCamera != null)
            {
                if (__instance.GOOKPABIPBC == SecondPlayerCharID)
                {
                    if (LIPNHOMGGHF.FAKHAFKOBPB == 14 && __instance.FOAPDJMIFGP > 0 && __instance.KNAGBDPGBMB == 0)
                    {
                        if (__instance.KKDJJEMPLGI >= 1f && __instance.BPAHGEMEIHF >= __instance.KKDJJEMPLGI)
                        {
                            __instance.KKDJJEMPLGI = 0.95f;
                        }
                        if (__instance.KKDJJEMPLGI <= 1f && __instance.BPAHGEMEIHF <= __instance.KKDJJEMPLGI)
                        {
                            __instance.KKDJJEMPLGI = 1.05f;
                        }
                    }
                    else
                    {
                        __instance.KKDJJEMPLGI = 1f;
                    }
                    __instance.BPAHGEMEIHF = Mathf.MoveTowards(__instance.BPAHGEMEIHF, __instance.KKDJJEMPLGI, 0.005f);
                    if (LIPNHOMGGHF.FAKHAFKOBPB == 50)
                    {
                        __instance.BPAHGEMEIHF = 0.75f;
                    }
                    float num = 1f;
                    if ((LIPNHOMGGHF.FAKHAFKOBPB == 14 || LIPNHOMGGHF.FAKHAFKOBPB == 50) && __instance.FOAPDJMIFGP > 0)
                    {
                        float num2 = NAEEIFNFBBO.FHPCDHIGILG(SecondCamera.transform.position.x, SecondCamera.transform.position.z, NJBJIIIACEP.OAAMGFLINOB[__instance.FOAPDJMIFGP].NJDGEELLAKG, NJBJIIIACEP.OAAMGFLINOB[__instance.FOAPDJMIFGP].BMFDFFLPBOJ);
                        num = 2f - num2 / 45f;
                        if (num < 0.3f)
                        {
                            num = 0.3f;
                        }
                    }
                    __instance.AGEGHJOCFHG.transform.localScale = new Vector3(__instance.BPAHGEMEIHF * num, __instance.BPAHGEMEIHF * num, __instance.BPAHGEMEIHF * num);
                    return false;
                }
            }
            return true;
        }
        public static int temp1int;
        [HarmonyPatch(typeof(NJBJIIIACEP),nameof(NJBJIIIACEP.HHLFNLLNKPP))]
        [HarmonyPrefix]
        public static void NJBJIIIACEP_HHLFNLLNKPP_PRE()
        {
            temp1int = NJBJIIIACEP.NBBBLJDBLNM;
            NJBJIIIACEP.NBBBLJDBLNM = 4;
        }
        [HarmonyPatch(typeof(NJBJIIIACEP), nameof(NJBJIIIACEP.HHLFNLLNKPP))]
        [HarmonyPostfix]
        public static void NJBJIIIACEP_HHLFNLLNKPP_POST()
        {
            NJBJIIIACEP.NBBBLJDBLNM = temp1int;
        }
        [HarmonyPatch(typeof(DLNHHGFNIIG), nameof(DLNHHGFNIIG.DIJBHIAAIOF))]
        [HarmonyPrefix]
        public static void DLNHHGFNIIG_DIJBHIAAIOF(DLNHHGFNIIG __instance, ref int IDHFOGNOIFC)
        {

            if (__instance.PLFGKLGCOMD == 2)
            {
                if (__instance.NNMDEFLLNBF != NJBJIIIACEP.OAAMGFLINOB[NJBJIIIACEP.DCAFAIGGFCC[1].NNMDEFLLNBF].NNMDEFLLNBF)
                {
                    __instance.NNMDEFLLNBF = NJBJIIIACEP.OAAMGFLINOB[NJBJIIIACEP.DCAFAIGGFCC[1].NNMDEFLLNBF].NNMDEFLLNBF;
                    if (__instance.NNMDEFLLNBF != __instance.PGKOMOIMNJN)
                    {
                        IDHFOGNOIFC = 1;
                    }
                }
            }
            if (__instance.PLFGKLGCOMD == 3 && SecondCamera != null)
            {
                if (__instance.NNMDEFLLNBF != SecondPlayerSceneID)
                {
                    
                    __instance.NNMDEFLLNBF = SecondPlayerSceneID;
                    if (__instance.NNMDEFLLNBF != __instance.PGKOMOIMNJN)
                    {
                        IDHFOGNOIFC = 1;
                    }
                }
            }
            if (__instance.PLFGKLGCOMD == 4 && SecondCamera != null)
            {
                if (__instance.NNMDEFLLNBF != NJBJIIIACEP.OAAMGFLINOB[SecondPlayerSceneID].NNMDEFLLNBF)
                {
                    
                    __instance.NNMDEFLLNBF = NJBJIIIACEP.OAAMGFLINOB[SecondPlayerSceneID].NNMDEFLLNBF;
                    if (__instance.NNMDEFLLNBF != __instance.PGKOMOIMNJN)
                    {
                        IDHFOGNOIFC = 1;
                    }
                }
            }
        }

    }
}
/*
ANGLE
Log("Main " + BLNKDHIGFAN.BPJFLJPKKJK);
Log(Splitscreen.CameraClassCopy.BPJFLJPKKJK);

SCOPE
Log("Main " + BLNKDHIGFAN.GMJKGKDFHOH);
Log(Splitscreen.CameraClassCopy.GMJKGKDFHOH);


*/