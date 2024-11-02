//TODO: Separate cam rotation (controller/mouse?); Separate healthbars; shared camera settings;
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
        public const string PluginVer = "0.0.2";

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
        private void Update()
        {
            if (NJBJIIIACEP.OAAMGFLINOB != null && NJBJIIIACEP.OAAMGFLINOB.Length > SecondPlayerSceneID && NJBJIIIACEP.OAAMGFLINOB[SecondPlayerSceneID] != null)
            {
                SecondPlayerCharID = NJBJIIIACEP.OAAMGFLINOB[SecondPlayerSceneID].GOOKPABIPBC;
                Splitscreen.CameraClassCopy.NNMDEFLLNBF = SecondPlayerSceneID;
                Splitscreen.CameraClassCopy.JCKCCDKDEKP = SecondPlayerSceneID;
            }
            else
            {
                SecondPlayerCharID = 0;
                Splitscreen.CameraClassCopy.NNMDEFLLNBF = 0;
                Splitscreen.CameraClassCopy.JCKCCDKDEKP = 0;
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
            [HarmonyPatch(nameof(BLNKDHIGFAN.ICGNAJFLAHL))]
            [HarmonyPostfix]
            public static void ICGNAJFLAHL()
            {
                if (SecondCamera == null && NJBJIIIACEP.OAAMGFLINOB[2] != null)
                {

                    SecondCamera = Instantiate(Camera.main.gameObject).GetComponent<Camera>();

                    CameraClassCopy.BPJFLJPKKJK = BLNKDHIGFAN.BPJFLJPKKJK;
                    CameraClassCopy.ONOKPJKPEFL = BLNKDHIGFAN.ONOKPJKPEFL;
                    CameraClassCopy.BKMPKCDDMLF = BLNKDHIGFAN.BKMPKCDDMLF;
                    CameraClassCopy.BEMIDHDBAPB = BLNKDHIGFAN.BEMIDHDBAPB;

                    CameraClassCopy.GMJKGKDFHOH = BLNKDHIGFAN.GMJKGKDFHOH;
                    CameraClassCopy.CJJEGOLMCMF = BLNKDHIGFAN.CJJEGOLMCMF;
                    CameraClassCopy.MLEFLJDMHJL = BLNKDHIGFAN.MLEFLJDMHJL;


                    
                //    SecondCamera.gameObject.tag = "Untagged";
                    CameraClassCopy.ICGNAJFLAHL();
                    Camera.main.rect = new Rect(0f, 0.5f, 1f, 1f);
                    SecondCamera.rect = new Rect(0f, 0f, 1f, 0.5f);
                }
            }
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
                    CameraClassCopy.PGJOAKANLCN(GOOKPABIPBC, BDHHBIIKMLP, FKEMEFPKBBL, JNLAJNFCDHA);
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