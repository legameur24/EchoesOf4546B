using BepInEx;
using EchoesOf4546B.Prefab.Items.Equipment;
using EchoesOf4546B.Prefab.Items.Materials;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Color = UnityEngine.Color;

namespace EchoesOf4546B.Prefab.Buildables.Fabricator
{
    [BepInPlugin("com.snmodding.nautilus.customfabricator", "Nautilus Custom Fabricator Example Mod", PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    public class PrecursorFabricator : BaseUnityPlugin
    {
        private void Awake()
        {
            CustomPrefab customFab = new("PrecursorFab", "Precursor Fabricator", "A precursor fabricator to craft very high technology!", SpriteManager.Get(TechType.PrecursorDroid));

            customFab.CreateFabricator(out CraftTree.Type treeType)
            .AddCraftNode(AlienAlloy.Info.TechType)
            .AddCraftNode(TechType.PrecursorKey_Purple)
            .AddCraftNode(TechType.PrecursorKey_Blue)
            .AddCraftNode(TechType.PrecursorKey_Orange);

            FabricatorTemplate fabPrefab = new(customFab.Info, treeType)
            {
                FabricatorModel = FabricatorTemplate.Model.Workbench,

                ModifyPrefab = prefab => prefab.GetComponentsInChildren<Renderer>().ForEach(r => r.materials.ForEach(m => m.color = Color.black))

            };
            customFab.SetGameObject(fabPrefab);
            customFab.Register();
        }

    }
}
