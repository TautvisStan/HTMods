using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using UnityEngine;
using BepInEx.Configuration;

namespace BlockColorChange
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "GeeEm.HardTime.BlockColorChange";
        public const string PluginName = "BlockColorChange";
        public const string PluginVer = "1.0.0";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        public static ConfigEntry<float>[] BlockColor = new ConfigEntry<float>[12];



        private void Awake()
        {
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    BlockColor[i*3+j] = Config.Bind("General",
                     $"{BlockName(i)} color {ColorName(j)}",
                     DefaultColor(i, j),
                     new ConfigDescription($"Color component for block {BlockName(i)} color {ColorName(j)}", new AcceptableValueRange<float>(0,1)));

                    BlockColor[i * 3 + j].SettingChanged += Plugin_SettingChanged;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Characters.prisonColours[i + 1].r = BlockColor[i * 3 + 0].Value;
                Characters.prisonColours[i + 1].g = BlockColor[i * 3 + 1].Value;
                Characters.prisonColours[i + 1].b = BlockColor[i * 3 + 2].Value;
            }

        }

        private void Plugin_SettingChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                Characters.prisonColours[i + 1].r = BlockColor[i * 3 + 0].Value;
                Characters.prisonColours[i + 1].g = BlockColor[i * 3 + 1].Value;
                Characters.prisonColours[i + 1].b = BlockColor[i * 3 + 2].Value;
            }
        }

        public string BlockName(int i)
        {
            switch (i)
            {
                case 0: return "North";
                case 1: return "East";
                case 2: return "South";
                case 3: return "West";
            }
            return "";
        }
        public string ColorName(int j)
        {
            switch (j)
            {
                case 0: return "Red";
                case 1: return "Green";
                case 2: return "Blue";
            }
            return "";
        }

        public float DefaultColor(int i, int j)
        {
            Color block = Characters.prisonColours[i+1];
            switch (j) 
            {
                case 0: return block.r;
                case 1: return block.g;
                case 2: return block.b;
            }
            return 0;

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
    }
}