//TODO: custom voice support;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using BepInEx.Configuration;
using System.Collections.Generic;

namespace TextToSpeech
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.TextToSpeech";
        public const string PluginName = "TextToSpeech";
        public const string PluginVer = "1.0.0";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new Harmony(PluginGuid);

        internal static string PluginPath;

        public static VoiceManager vm;
        public int numVoice;
        public int voiceOK;
        public string voiceName;
        public string textesay;

        public static ConfigEntry<string> voiceSpeaker;
        public static ConfigEntry<string> voiceSpeakerFemale;
        public static ConfigEntry<int> voiceVolume;

        static bool speechBubble = false;
        static int oldSelection = 0;
        private void Awake()
        {
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);

            vm = this.gameObject.AddComponent<VoiceManager>();
            voiceOK = vm.Init();
            if (voiceOK != 1)
            {
                Log.LogInfo("TTS VOICE INITALISED");
                for (int i = 0; i < vm.VoiceNames.Count; i++)
                {
                    Log.LogInfo("Voice number " + i + " " + vm.VoiceNames[i]);
                    string voiceline = $"<voice required='Name={vm.VoiceNames[i]}'>";
                    vm.SayEX(voiceline, 1 + 8);
                }
            }
            else
            {
                Log.LogError("FAILED TO INITALIZE TTS VOICE");
                this.enabled = false;
            }
            vm.Volume(100);
            vm.VoiceNames[0] = "None";
            voiceSpeaker = Config.Bind("General", "TTS Voice Speaker", vm.VoiceNames[1], new ConfigDescription("Texh to Speech speaker voice", new AcceptableValueList<string>(vm.VoiceNames.ToArray())));
            voiceSpeakerFemale = Config.Bind("General", "TTS Voice Speaker Female", vm.VoiceNames[1], new ConfigDescription("Texh to Speech Female speaker voice", new AcceptableValueList<string>(vm.VoiceNames.ToArray())));

            voiceVolume = Config.Bind("General", "TTS Voice Volume", 100, new ConfigDescription("Texh to Speech speaker volume", new AcceptableValueRange<int>(0, 100)));

        }
        private void Start()
        {
            try
            {
                HTCCL.API.Buttons.RegisterCustomButton(this, "Test TTS Voice", () =>
                {
                    TEST();
                    return "Test TTS Voice";
                });
            }
            catch (Exception e)
            {

            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F5)) { TEST(); }
           // if (Input.GetKeyDown(KeyCode.F5)) { TEST2(); }
        }
        [HarmonyPatch(typeof(LIPNHOMGGHF), nameof(LIPNHOMGGHF.FIIAPDCOMBN))]
        [HarmonyPrefix]
        public static void ToggleSpeechPause(int EAGLGMBLBPO)
        {
            if (EAGLGMBLBPO > 0) TTSInterface.Pause();
            else TTSInterface.Resume();
        }
        [HarmonyPatch(typeof(LIPNHOMGGHF), nameof(LIPNHOMGGHF.PMIIOCMHEAE))]
        [HarmonyPrefix]
        public static void StopWhenChangingScene()
        {
            TTSInterface.Resume();
            TTSInterface.StopSpeaking();
        }
        [HarmonyPatch(typeof(NEGAFEHECNL),nameof(NEGAFEHECNL.BBICLKGGIGB))]
        [HarmonyPrefix]
        static void SpeakLinesPre()
        {
            if (NEGAFEHECNL.ABMMBFGLBOL != null)
            {
                speechBubble = NEGAFEHECNL.ABMMBFGLBOL.activeSelf;
                if (NEGAFEHECNL.IMJHCHECCED >= 175 && vm.Status(0) == 2 && !ShouldSkip())
                    NEGAFEHECNL.IMJHCHECCED = 170;
            }
        }
        static bool ShouldSkip()
        {
            BJMGCKGNCHO bjmgckgncho = HKJOAJOKOIJ.NAADDLFFIHG[HKJOAJOKOIJ.EMLDNFEIKCK];
            if (bjmgckgncho.IOIJFFLMBCH[1] != 0 || bjmgckgncho.IOIJFFLMBCH[2] != 0 || bjmgckgncho.IOIJFFLMBCH[3] != 0 || bjmgckgncho.IOIJFFLMBCH[4] != 0 || bjmgckgncho.FHBEOIPFFDA != 0 || bjmgckgncho.OHEIJEDGKLJ != 0)
            {
                return true;
            }
            return false;
        }
        [HarmonyPatch(typeof(NEGAFEHECNL), nameof(NEGAFEHECNL.BBICLKGGIGB))]
        [HarmonyPostfix]
        static void SpeakLinesPost()
        {
            if (NEGAFEHECNL.ABMMBFGLBOL != null && NEGAFEHECNL.EJFHLGMHAHB == 0)
            {
                if(speechBubble == false && NEGAFEHECNL.ABMMBFGLBOL.activeSelf == true)
                {
                    TTSInterface.SpeakPromoLines();
                }
                if (speechBubble == true && NEGAFEHECNL.ABMMBFGLBOL.activeSelf == false)
                {
                    TTSInterface.StopSpeaking();
                }
            }
        }
        [HarmonyPatch(typeof(NEGAFEHECNL), nameof(NEGAFEHECNL.PLDBKAJEANO))]
        [HarmonyPrefix]
        static bool AvoidCutout()
        {
            if (vm.Status(0) == 2) return false;
            return true;
        }

        [HarmonyPatch(typeof(NEGAFEHECNL), nameof(NEGAFEHECNL.GPPKMBAODNL))]
        [HarmonyPrefix]
        static void SpeakChoicePre()
        {
            oldSelection = NEGAFEHECNL.PEJALFBEOKC;
        }
        [HarmonyPatch(typeof(NEGAFEHECNL), nameof(NEGAFEHECNL.GPPKMBAODNL))]
        [HarmonyPostfix]
        static void SpeakChoice()
        {
            if (Math.Abs(oldSelection) < 10 && Math.Abs(NEGAFEHECNL.PEJALFBEOKC) >= 10)
            {
                if (NEGAFEHECNL.PEJALFBEOKC > 0)
                {
                    TTSInterface.SpeakSelection(1);
                }
                else
                {
                    TTSInterface.SpeakSelection(2);
                }
                
            }
        }
        private void TEST()
        {
            if (voiceOK != 1)
            {
                //    voiceName = vm.VoiceNames[1];
                //    vm.VoiceNumber = 2;
                //   voiceName = vm.VoiceNames[1];
                //    Debug.LogWarning("Voice number " + vm.VoiceNumber + " " + voiceName );
                //   textesay = "Hello. My name is Anna, and i am a woman. It's nice to meet you. Have a nice day and goodbye.";
                //   vm.Say (textesay);
                //  vm.SayEX("Funny, it's the same voice again", 1+8);
                //    textesay = "<voice required='Name=Bernard'> bonjour, je suis Bernard. Léger, là-bas, expliqué <voice required='Name=Juliette'> Et moi, je me nome Juliette.";
                //    vm.Say(textesay);

                string voiceline = $"<voice required='Name={voiceSpeaker.Value}'><volume level=\"{voiceVolume.Value}\"/>This is voice name {voiceSpeaker.Value}";
                vm.SayEX(voiceline, 1+2+8);
            }
        }
        private void TEST2()
        {
            if (voiceOK != 1)
            {
                string voiceline = $"<voice required='Name={voiceSpeaker.Value}'>{NEGAFEHECNL.MLLPFEKAONO[1]} {NEGAFEHECNL.MLLPFEKAONO[2]}";
                Debug.LogWarning(voiceline);
                vm.SayEX(voiceline, 1+2 + 8);
            }
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

        public static class TTSInterface
        {
            public static string GetSpeakerGender()
            {
                DFOGOCNBECG speaker = NJBJIIIACEP.OAAMGFLINOB[NEGAFEHECNL.NNMDEFLLNBF];
                if (speaker.EMDMDLNJFKP.gender == 1)
                {
                    return voiceSpeakerFemale.Value;
                }
                else
                {
                    return voiceSpeaker.Value;
                }
            }
            public static void SpeakSelection(int i)
            {
                string voiceline = $"<voice required='Name={GetSpeakerGender()}'><volume level=\"{voiceVolume.Value}\"/>{NEGAFEHECNL.MLLPFEKAONO[i]}";
                vm.SayEX(voiceline, 1 + 2 + 8);
            }
            public static void Pause()
            {
                vm.Pause();
            }
            public static void Resume()
            {
                vm.Resume();
            }
            public static void SpeakPromoLines()
            {
                string voiceline = $"<voice required='Name={GetSpeakerGender()}'><volume level=\"{voiceVolume.Value}\"/>{NEGAFEHECNL.MLLPFEKAONO[1]} {NEGAFEHECNL.MLLPFEKAONO[2]}";
                vm.SayEX(voiceline, 1 + 2 + 8);
            }
            public static void StopSpeaking()
            {
                vm.SayEX("", 1 + 2 + 8);
            }
        }
    }

 
public class VoiceManager : MonoBehaviour
    {
        private int VoiceInit = 0;
        public List<string> VoiceNames = new List<string>();

        [DllImport("SAPI_UNITY_DLL")] private static extern int Uni_Voice_Init();
        [DllImport("SAPI_UNITY_DLL")] private static extern void Uni_Voice_Close();
        [DllImport("SAPI_UNITY_DLL")] private static extern int Uni_Voice_Status(int voiceStat);
        [DllImport("SAPI_UNITY_DLL")] private static extern int Uni_Voice_Speak([MarshalAs(UnmanagedType.LPWStr)] string TextToSpeech); // SPF_ASYNC & SPF_IS_XML
        [DllImport("SAPI_UNITY_DLL")] private static extern int Uni_Voice_SpeakEX([MarshalAs(UnmanagedType.LPWStr)] string TextToSpeech, int voiceFlag); // CUSTOM FLAG

        [DllImport("SAPI_UNITY_DLL")] private static extern int Uni_Voice_Volume(int volume); //  zero to 100
        [DllImport("SAPI_UNITY_DLL")] private static extern int Uni_Voice_Rate(int rate); // -10 to 10

        [DllImport("SAPI_UNITY_DLL")] private static extern void Uni_Voice_Pause();
        [DllImport("SAPI_UNITY_DLL")] private static extern void Uni_Voice_Resume();


        // CUSTOM VOICE FLAG !!! ******************************************************************************************************************
        /* https://msdn.microsoft.com/en-us/library/ee431843%28v=vs.85%29.aspx & https://msdn.microsoft.com/en-us/library/ms717077%28v=vs.85%29.aspx

        SPF_DEFAULT
            Specifies that the default settings should be used.  The defaults are:
                * Speak the given text string synchronously
                * Not purge pending speak requests
                * Parse the text as XML only if the first character is a left-angle-bracket (<)
                * Not persist global XML state changes across speak calls
                * Not expand punctuation characters into words.
            To override this default, use the other flag values given below.

        SPF_ASYNC
            Specifies that the Speak call should be asynchronous. That is, it will return immediately after the speak request is queued.
        SPF_PURGEBEFORESPEAK
            Purges all pending speak requests prior to this speak call.
        SPF_IS_FILENAME
            The string passed to Uni_Voice_Speak is a file name, and the file text should be spoken.
        SPF_IS_XML
            The input text will be parsed for XML markup.
        SPF_IS_NOT_XML
            The input text will not be parsed for XML markup.
        SPF_PERSIST_XML
            Global state changes in the XML markup will persist across speak calls.
        SPF_NLP_SPEAK_PUNC
            Punctuation characters should be expanded into words (e.g. "This is a sentence." would become "This is a sentence period").
        SPF_PARSE_SAPI
            Force XML parsing As MS SAPI.
        SPF_PARSE_SSML
            Force XML parsing As W3C SSML.
        */

        const int SPF_DEFAULT = 0;
        const int SPF_ASYNC = 1;
        const int SPF_PURGEBEFORESPEAK = 2;
        const int SPF_IS_FILENAME = 4;
        const int SPF_IS_XML = 8;
        const int SPF_IS_NOT_XML = 16;
        const int SPF_PERSIST_XML = 32;
        const int SPF_NLP_SPEAK_PUNC = 64;
        const int SPF_PARSE_SAPI = 128;
        const int SPF_PARSE_SSML = 256;
        // CUSTOM VOICE FLAG !!! ******************************************************************************************************************

        // Use this for initialization
        public int Init()
        {
            // Info (64Bits OS):
            // Executing Windows\sysWOW64\speech\SpeechUX\SAPI.cpl brings up a Window that displays (!) all of the 32 bit Voices
            // and the current single 64 bit Voice "Anna".

            // HKEY_LOCAL_MACHINE\\SOFTWARE\Microsoft\Speech\\Voices\\Tokens\\xxxVOICExxxINSTALLEDxxx\\Attributes >>> (Name)
            //const string speechTokens = "Software\\Microsoft\\Speech\\Voices\\Tokens";
            VoiceNames.Add("");
            ScanRegistryFolder("Software\\Microsoft\\Speech\\Voices\\Tokens");
         //   ScanRegistryFolder("software\\Microsoft\\Speech_OneCore\\Voices\\Tokens");
        //    ScanRegistryFolder("SOFTWARE\\WOW6432Node\\Microsoft\\SPEECH\\Voices\\Tokens");
            // return 0 >>> Init ok
            if (VoiceNames.Count != 1)
            {
                VoiceInit = Uni_Voice_Init();
            }
            else VoiceInit = 1;
            return VoiceInit;
        }


        private void ScanRegistryFolder(string speechTokens)
        {
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(speechTokens))
            {
           //     VoiceNumber = registryKey.SubKeyCount; // key found not mean true voice number !!!
            //    VoiceNames = new string[VoiceNumber + 1];
            //    VoiceNumber = 0;
          //  Debug.LogWarning(registryKey);
                foreach (var regKeyFound in registryKey.GetSubKeyNames())
                {
                  //  Debug.LogWarning(regKeyFound);
                    string finalKey = "HKEY_LOCAL_MACHINE\\" + speechTokens + "\\" + regKeyFound + "\\Attributes";
                   // Debug.LogWarning(finalKey);
                    string gotchaVoiceName = "";
                    gotchaVoiceName = (string)Registry.GetValue(finalKey, "Name", "");
                    if (gotchaVoiceName != "")
                    {
                        //Debug.Log("Langage Name = " + gotchaVoiceName);
                        if(!VoiceNames.Contains(gotchaVoiceName))
                            VoiceNames.Add(gotchaVoiceName);
                    }
                }
            }
        }

        public int Say(string textToSay)
        {
            // https://msdn.microsoft.com/en-us/library/ms717077(v=vs.85).aspx

            // "This is <emph>very</emph> important!  This sounds normal <pitch middle = '+40'/> but the pitch drops half way through"
            // "This is <emph>very</emph> important!. This is very important! "
            // "<volume level="Level">  Text to be spoken</volume>"
            // "<rate speed="-5">This text should be spoken at rate zero.</rate>" -10 to +10
            // "<silence msec='1000'/>"
            // "I will spell the word <spell>Love</spell> for you."
            // "<voice required='Name=Microsoft Anna'> Hello i'm Anna. Have a nice day. <voice required='Name=IVONA 2 Amy'> It's Amy here. Good day too"
            // "All system <emph>ready</emph>. Engine online, weapons online. We are ready. 9<silence msec='1000'/>8<silence msec='1000'/>7<silence msec='1000'/>6<silence msec='1000'/>5<silence msec='1000'/>4<silence msec='1000'/>3<silence msec='1000'/>2<silence msec='1000'/>1<silence msec='1000'/>0. Take off!!!"
            return Uni_Voice_Speak(textToSay);
        }

        public int SayEX(string textToSay, int flagOfSpeak)
        {
            return Uni_Voice_SpeakEX(textToSay, flagOfSpeak);
        }

        public int Status(int statToCheck)
        {
            // statToCheck = 0 >> return '2' for a running speak. '0' or '1' in other case.
            // statToCheck = 1 >> return the position of the actual spoken word in the textToSay string. ;)
            //        ex for "Hello my friend" can return the position of H >> 1, m >> 7 and f >> 10
            // statToCheck = 2 >> return Total speak stream
            // statToCheck = 3 >> return Actual speak stream
            return (Uni_Voice_Status(statToCheck));
        }

        public void Volume(int vol)
        {
            Uni_Voice_Volume(vol); //  zero to 100
        }

        public void Rate(int rat)
        {
            Uni_Voice_Rate(rat); // -10 to 10
        }

        public void Pause()
        {
            Uni_Voice_Pause();
        }

        public void Resume()
        {
            Uni_Voice_Resume();
        }



        void OnApplicationQuit()
        {
            Uni_Voice_Close();
        }
    }
    // **************************************************************************
    //               Unity Text To Speech V2 ZJP. Voice Manager
    // **************************************************************************



}