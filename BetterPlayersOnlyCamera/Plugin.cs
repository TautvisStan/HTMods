using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BetterStarsOnlyCamera
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.BetterStarsOnlyCamera";
        public const string PluginName = "BetterStarsOnlyCamera";
        public const string PluginVer = "1.0.0";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;


        public static int oldScope = -1;


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
        [HarmonyPatch(typeof(BLNKDHIGFAN), nameof(BLNKDHIGFAN.DIJBHIAAIOF))]
        [HarmonyPrefix]
        public static void DIJBHIAAIOFPatch()
        {
            if (BLNKDHIGFAN.GMJKGKDFHOH == -1 && SceneManager.GetActiveScene().name == "Game")
            {
                NEGAFEHECNL.NNMDEFLLNBF = 0;
            }
        }
              /*  int playernum = 1;//GetMainPlayerNum();
                if (BLNKDHIGFAN.JCKCCDKDEKP != playernum)
                {
                    BLNKDHIGFAN.JCKCCDKDEKP = playernum;
                }
                if (BLNKDHIGFAN.NNMDEFLLNBF != playernum)
                {
                    BLNKDHIGFAN.NNMDEFLLNBF = playernum;
                }
            }
            if(oldScope == -1 && BLNKDHIGFAN.GMJKGKDFHOH != -1)
            {
                BLNKDHIGFAN.JCKCCDKDEKP = 0;
                BLNKDHIGFAN.NNMDEFLLNBF = 0;
            }
            oldScope = BLNKDHIGFAN.GMJKGKDFHOH;
        }*/
    /*    public int GetMainPlayerNum()
        {
            for (int j = 0; j <= HKJOAJOKOIJ.NGCNKGDDKGF; j++)
            {
                if (HKJOAJOKOIJ.NAADDLFFIHG[j].AHBNKMMMGFI > 0 && HKJOAJOKOIJ.NAADDLFFIHG[j].BPJFLJPKKJK >= 0 && HKJOAJOKOIJ.NAADDLFFIHG[j].FOAPDJMIFGP > 0 && HKJOAJOKOIJ.NAADDLFFIHG[j].FOAPDJMIFGP <= NJBJIIIACEP.NBBBLJDBLNM)
                {
                    return HKJOAJOKOIJ.NAADDLFFIHG[j].FOAPDJMIFGP;
                }
            }
            return 0;
        }*/
        
    }
}