using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using UnityEngine;

namespace HealthCheats
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.HealthCheats";
        public const string PluginName = "HealthCheats";
        public const string PluginVer = "1.4.0";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        public static ConfigEntry<string> ConfigTarget;
        public static ConfigEntry<string> ConfigHMax;
        public static ConfigEntry<string> ConfigHMin;
        public static ConfigEntry<string> ConfigSMax;
        public static ConfigEntry<string> ConfigSMin;
        public static ConfigEntry<string> ConfigBMax;
        public static ConfigEntry<string> ConfigBMin;
        public static ConfigEntry<string> ConfigAMax;
        public static ConfigEntry<string> ConfigAMin;
        public static ConfigEntry<string> ConfigAtMax;
        public static ConfigEntry<string> ConfigAtMin;
        public static ConfigEntry<string> ConfigInMax;
        public static ConfigEntry<string> ConfigInMin;
        public static ConfigEntry<string> ConfigKOMax;
        public static ConfigEntry<string> ConfigKOMin;
        public static ConfigEntry<string> ConfigBlowUp;
        public static ConfigEntry<string> ConfigDismember;
        public static ConfigEntry<string> ConfigRestoreLimbs;



        public AcceptableValueList<string> KeyboardButtons = new AcceptableValueList<string>("None", "Backspace", "Delete", "Tab", "Clear", "Return", "Pause", "Escape", "Space", "Quote", "Comma", "Minus", "Period", "Slash", "Alpha0", "Alpha1", "Alpha2", "Alpha3", "Alpha4", "Alpha5", "Alpha6", "Alpha7", "Alpha8", "Alpha9", "Semicolon", "Equals", "LeftBracket", "Backslash", "RightBracket", "BackQuote", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Keypad0", "Keypad1", "Keypad2", "Keypad3", "Keypad4", "Keypad5", "Keypad6", "Keypad7", "Keypad8", "Keypad9", "KeypadPeriod", "KeypadDivide", "KeypadMultiply", "KeypadMinus", "KeypadPlus", "KeypadEnter", "KeypadEquals", "UpArrow", "DownArrow", "RightArrow", "LeftArrow", "Insert", "Home", "End", "PageUp", "PageDown", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "Numlock", "CapsLock", "ScrollLock", "RightShift", "LeftShift", "RightControl", "LeftControl", "RightAlt", "LeftAlt", "RightCommand", "RightApple", "LeftCommand", "LeftApple", "LeftWindows", "RightWindows", "Print", "Menu", "Mouse0", "Mouse1", "Mouse2", "Mouse3", "Mouse4", "Mouse5", "Mouse6");

        public int PlayerNum;

        private void Awake()
        {
            Plugin.Log = base.Logger;
            
            PluginPath = Path.GetDirectoryName(Info.Location);

            ConfigTarget = Config.Bind("Controls",
             "ApplyToTarget",
             "LeftAlt",
             new ConfigDescription(
                "Applies the effect to target instead",
                KeyboardButtons));

            ConfigHMax = Config.Bind("Controls",
             "Max Health",
             "Q",
             new ConfigDescription(
                "Sets health to max",
                KeyboardButtons));

            ConfigHMin = Config.Bind("Controls",
             "0 Health",
             "W",
             new ConfigDescription(
                "Sets health to 0",
                KeyboardButtons));

            ConfigSMax = Config.Bind("Controls",
             "Max Stun",
             "E",
             new ConfigDescription(
                "Sets stun to max",
                KeyboardButtons));

            ConfigSMin = Config.Bind("Controls",
             "0 Stun",
             "R",
             new ConfigDescription(
                "Sets stun to 0",
                KeyboardButtons));

            ConfigBMax = Config.Bind("Controls",
             "Max Blindness",
             "T",
             new ConfigDescription(
                "Sets \"blindness\" to max",
                KeyboardButtons));

            ConfigBMin = Config.Bind("Controls",
             "0 Blindness",
             "Y",
             new ConfigDescription(
                "Sets \"blindness\" to 0",
                KeyboardButtons));

            ConfigAMax = Config.Bind("Controls",
             "Max Adrenaline",
             "D",
             new ConfigDescription(
                "Sets adrenaline to max",
                KeyboardButtons));

            ConfigAMin = Config.Bind("Controls",
             "0 Adrenaline",
             "F",
             new ConfigDescription(
                "Sets adrenaline to 0",
                KeyboardButtons));

            ConfigAtMax = Config.Bind("Controls",
             "Max Adrenaline Timer",
             "G",
             new ConfigDescription(
                "Sets adrenaline timer to max",
                KeyboardButtons));

            ConfigAtMin = Config.Bind("Controls",
             "Adrenaline Timer End",
             "H",
             new ConfigDescription(
                "Ends the adrenaline timer",
                KeyboardButtons));

            ConfigInMax = Config.Bind("Controls",
             "Injure the character",
             "J",
             new ConfigDescription(
                "Injures the character",
                KeyboardButtons));

            ConfigInMin = Config.Bind("Controls",
             "Heal the injury",
             "K",
             new ConfigDescription(
                "Removes the character injury",
                KeyboardButtons));

            ConfigKOMax = Config.Bind("Controls",
             "Knock out a target",
             "C",
             new ConfigDescription(
                "Instantly knock out (and DQ) a target",
                KeyboardButtons));

            ConfigKOMin = Config.Bind("Controls",
             "Recover target from knockout",
             "V",
             new ConfigDescription(
                "Recover target from knockout",
                KeyboardButtons));

            ConfigBlowUp = Config.Bind("Controls",
             "Explode the target",
             "B",
             new ConfigDescription(
                "Spawn an explosion on target",
                KeyboardButtons));

            ConfigDismember = Config.Bind("Controls",
 "Dismember",
 "N",
 new ConfigDescription(
    "Dismember a random limb from the target",
    KeyboardButtons));

            ConfigRestoreLimbs = Config.Bind("Controls",
 "Restore limbs",
 "M",
 new ConfigDescription(
    "Restore all lost limbs",
    KeyboardButtons));


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
        public int GetMainPlayerNum()
        {
            for (int j = 0; j <= HKJOAJOKOIJ.NGCNKGDDKGF; j++)
            {
                if (HKJOAJOKOIJ.NAADDLFFIHG[j].AHBNKMMMGFI > 0 && HKJOAJOKOIJ.NAADDLFFIHG[j].BPJFLJPKKJK >= 0 && HKJOAJOKOIJ.NAADDLFFIHG[j].FOAPDJMIFGP > 0 && HKJOAJOKOIJ.NAADDLFFIHG[j].FOAPDJMIFGP <= NJBJIIIACEP.NBBBLJDBLNM)
                {
                    return HKJOAJOKOIJ.NAADDLFFIHG[j].FOAPDJMIFGP;
                }
            }
            return 0;
        }

        public enum CommandList
        {
            HealthMax,
            HealthMin,
            StunMax,
            StunMin,
            BlindMax,
            BlindMin,
            AdrenalineMax,
            AdrenalineMin,
            AdrenalineTimerMax,
            AdrenalineTimerMin,
            InjureMax,
            InjureMin,
            KOMax,
            KOMin,
            Explode,
            Dismember,
            RestoreLimbs
        }
        private void Update()
        {

            try
            {
                if (Input.GetKey(Ulil.GetKeyCode(ConfigTarget.Value))) //target
                {
                    SendCommand(true);

                }
                else //player
                {
                    SendCommand(false);
                }
            }
            catch (Exception e)
            {

            }
        }
        public void SendCommand(bool targetInsteadOfSelf)
        {
            if (Input.GetKey(Ulil.GetKeyCode(ConfigHMax.Value)))  //health max
            {
                SendFurther(targetInsteadOfSelf, CommandList.HealthMax);
            }
            if (Input.GetKey(Ulil.GetKeyCode(ConfigHMin.Value))) //health 0
            {
                SendFurther(targetInsteadOfSelf, CommandList.HealthMin);
            }
            if (Input.GetKey(Ulil.GetKeyCode(ConfigSMax.Value))) //stun max
            {
                SendFurther(targetInsteadOfSelf, CommandList.StunMax);
            }
            if (Input.GetKey(Ulil.GetKeyCode(ConfigSMin.Value))) //stun 0
            {
                SendFurther(targetInsteadOfSelf, CommandList.StunMin);
            }
            if (Input.GetKey(Ulil.GetKeyCode(ConfigBMax.Value))) //blindness max
            {
                SendFurther(targetInsteadOfSelf, CommandList.BlindMax);
            }
            if (Input.GetKey(Ulil.GetKeyCode(ConfigBMin.Value))) //blindness 0
            {
                SendFurther(targetInsteadOfSelf, CommandList.BlindMin);
            }
            if (Input.GetKey(Ulil.GetKeyCode(ConfigAMax.Value))) //adrenaline max
            {
                SendFurther(targetInsteadOfSelf, CommandList.AdrenalineMax);
            }
            if (Input.GetKey(Ulil.GetKeyCode(ConfigAMin.Value))) //adrenaline 0
            {
                SendFurther(targetInsteadOfSelf, CommandList.AdrenalineMin);
            }
            if (Input.GetKey(Ulil.GetKeyCode(ConfigAtMax.Value))) //adr timer max
            {
                SendFurther(targetInsteadOfSelf, CommandList.AdrenalineTimerMax);
            }
            if (Input.GetKey(Ulil.GetKeyCode(ConfigAtMin.Value))) //adr timer 0
            {
                SendFurther(targetInsteadOfSelf, CommandList.AdrenalineTimerMin);
            }
            if (Input.GetKeyDown(Ulil.GetKeyCode(ConfigInMax.Value))) //injure
            {
                SendFurther(targetInsteadOfSelf, CommandList.InjureMax);
            }
            if (Input.GetKeyDown(Ulil.GetKeyCode(ConfigInMin.Value))) //heal
            {
                SendFurther(targetInsteadOfSelf, CommandList.InjureMin);
            }
            if (Input.GetKeyDown(Ulil.GetKeyCode(ConfigKOMax.Value))) //KO
            {
                SendFurther(targetInsteadOfSelf, CommandList.KOMax);
            }
            if (Input.GetKeyDown(Ulil.GetKeyCode(ConfigKOMin.Value))) //recover
            {
                SendFurther(targetInsteadOfSelf, CommandList.KOMin);
            }
            if (Input.GetKeyDown(Ulil.GetKeyCode(ConfigBlowUp.Value))) //Explode
            {
                SendFurther(targetInsteadOfSelf, CommandList.Explode);
            }
            if (Input.GetKeyDown(Ulil.GetKeyCode(ConfigDismember.Value))) //Dismember
            {
                SendFurther(targetInsteadOfSelf, CommandList.Dismember);
            }
            if (Input.GetKeyDown(Ulil.GetKeyCode(ConfigRestoreLimbs.Value))) //Restore limbs
            {
                SendFurther(targetInsteadOfSelf, CommandList.RestoreLimbs);
            }
        }
        public void SendFurther(bool targetInsteadOfSelf, CommandList command)
        {
            DFOGOCNBECG instance;
            PlayerNum = GetMainPlayerNum();
            if (PlayerNum == 0) return;
            if(targetInsteadOfSelf)
            {
                if (NJBJIIIACEP.OAAMGFLINOB[PlayerNum].NNMDEFLLNBF == 0) return;
                instance = NJBJIIIACEP.OAAMGFLINOB[NJBJIIIACEP.OAAMGFLINOB[PlayerNum].NNMDEFLLNBF];
            }
            else
            {
                instance = NJBJIIIACEP.OAAMGFLINOB[PlayerNum];
            }
            switch(command)
            {
                case CommandList.HealthMax: { Health(instance, true); break; }
                case CommandList.HealthMin: { Health(instance, false); break; }
                case CommandList.StunMax: { Stun(instance, true); break; }
                case CommandList.StunMin: { Stun(instance, false); break; }
                case CommandList.BlindMax: { Blind(instance, true); break; }
                case CommandList.BlindMin: { Blind(instance, false); break; }
                case CommandList.AdrenalineMax: { Adrenaline(instance, true); break; }
                case CommandList.AdrenalineMin: { Adrenaline(instance, false); break; }
                case CommandList.AdrenalineTimerMax: { AdrenalineTimer(instance, true); break; }
                case CommandList.AdrenalineTimerMin: { AdrenalineTimer(instance, false); break; }
                case CommandList.InjureMax: { Injure(instance); break; }
                case CommandList.InjureMin: { Heal(instance); break; }
                case CommandList.KOMax: { KnockOut(instance); break; }
                case CommandList.KOMin: { Recover(instance); break; }
                case CommandList.Explode: { BlowUp(instance); break; }
                case CommandList.Dismember: { Dismember(instance); break; }
                case CommandList.RestoreLimbs: { RestoreLimbs(instance); break; }
            }


        }
        public static void Health(DFOGOCNBECG instance, bool max)
        {
            if (max)
            {
                instance.HLGALFAGDGC = int.MaxValue;
                instance.OIHGGHEDIFF = int.MaxValue;
            }
            else
            {
                instance.HLGALFAGDGC = 0;
                instance.OIHGGHEDIFF = 0;
            }
        }
        public static void Stun(DFOGOCNBECG instance, bool max)
        {
            if (max)
            {
                instance.OKPAGLBJIOH = int.MaxValue;
            }
            else
            {
                instance.OKPAGLBJIOH = 0;
            }
        }
        public static void Blind(DFOGOCNBECG instance, bool max)
        {
            if (max)
            {
                instance.FLOPBFFLLDE = int.MaxValue;
            }
            else
            {
                instance.FLOPBFFLLDE = 0;
            }
        }
        public static void Adrenaline(DFOGOCNBECG instance, bool max)
        {
            if (max)
            {
                instance.BBBGPIILOBB = int.MaxValue;
            }
            else
            {
                instance.BBBGPIILOBB = 0;
            }
        }
        public static void AdrenalineTimer(DFOGOCNBECG instance, bool max)
        {
            if (max)
            {
                instance.LLGHFGNMCGF = int.MaxValue;
            }
            else
            {
                instance.LLGHFGNMCGF = 1;
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
        public static void Heal(DFOGOCNBECG instance)
        {
            instance.PGJEOKAEPCL = 0;
            instance.EMDMDLNJFKP.injuryTime = 0;
            instance.EMDMDLNJFKP.injury = 0;
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
        public static void Recover(DFOGOCNBECG instance)
        {
            instance.DMEDPMIPBAO = 0;
        }
        public static void BlowUp(DFOGOCNBECG instance)
        {
            ALIGLHEIAGO.MDFJMAEDJMG(3, 2, new UnityEngine.Color(10f, 10f, 10f), 5, null, instance.NJDGEELLAKG, (float)(instance.FNNBCDPJBIO + 2.5), instance.BMFDFFLPBOJ, 0f, 0f, 0f, 1);
        }
        public static void Dismember(DFOGOCNBECG instance)
        {
            int limb = UnityEngine.Random.Range(3, 16);
            instance.CMOPOKMFJMG(limb, 1000000f, 10f);
        }
        public static void RestoreLimbs(DFOGOCNBECG instance)
        {
            for (int i = 1; i <= 16; i++)
            {
                if (instance.GEPLNBJEDLH[i] < 0)
                {
                    instance.GEPLNBJEDLH[i] = 0;
                    instance.PCNHIIPBNEK[i].SetActive(true);
                }
                if (instance.EMDMDLNJFKP.scar[i] < 0)
                {
                    instance.EMDMDLNJFKP.scar[i] = 0;
                }
            }
            instance.EMDMDLNJFKP.injury = 0;
            instance.PGJEOKAEPCL = 0;
        }
    }
        public static class Ulil
        {
            public static KeyCode GetKeyCode(string name)
            {
                return (KeyCode)System.Enum.Parse(typeof(KeyCode), name, true);
            }
        }
}
//target                    NJBJIIIACEP.OAAMGFLINOB[NJBJIIIACEP.OAAMGFLINOB[NJBJIIIACEP.DCAFAIGGFCC[1].NNMDEFLLNBF].NNMDEFLLNBF].
//self                     NJBJIIIACEP.OAAMGFLINOB[NJBJIIIACEP.DCAFAIGGFCC[1].NNMDEFLLNBF].