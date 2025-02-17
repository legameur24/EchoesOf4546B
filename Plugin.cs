using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Logging;
using EchoesOf4546B.Prefab.Buildables.Fabricator;
using EchoesOf4546B.Prefab.Items.Equipment;
using EchoesOf4546B.Prefab.Items.Materials;
using HarmonyLib;
using Nautilus.Handlers;
using Nautilus.Utility;
using Story;
using System.Collections;
using System.IO;
using System.Reflection;
using TerrainPatcher;
using TMPro;
using UnityEngine;

namespace EchoesOf4546B
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("Esper89.TerrainPatcher")]
    [BepInDependency("com.lee23.epicstructureloader")]
    public class Plugin : BaseUnityPlugin
    {
        private const string MyGuid = "com.yansox.EchoesOf4546B";
        private const string PluginName = "Echoes Of 4546B";
        private const string VersionString = "0.1.1";

        public static string AssetsFolderPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets");

        internal static Texture2D alienAlloyIcon;


        private static readonly Harmony Harmony = new(MyGuid);

        public new static ManualLogSource Logger { get; private set; }
        
        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        private void Awake()
        {
            Logger = base.Logger;

            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            InitializePrefabs();
        }
        public static AssetBundle AssetBundle { get; private set; }
        private void InitializePrefabs()
        {

            DiamondBlade.Register();
            AlienAlloy.Register();

            LanguageHandler.RegisterLocalizationFolder();
            
            string IconAlloyAlienPath = AssetsFolderPath + "Alien_Alloy_Icon.png";
            alienAlloyIcon = ImageUtils.LoadTextureFromFile(IconAlloyAlienPath);
        }
       
        public IEnumerator Start()
        {
            yield return new WaitForSeconds(2);

            StructureLoading.RegisterStructures();
        }
    }
}