using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static CraftData;

namespace EchoesOf4546B.Prefab.Items.Materials
{
    internal class AlienAlloy
    {
        private static AssetBundle Bundle => Plugin.AssetBundle;
        private static Sprite LoadIcon(string name) => Bundle.LoadAsset<Sprite>(name);
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType("PrecursorAlloy", "Precursor Alloy", "?2Li2C3. An alien alloy is very resistant and considered to hyper-alloy.")
            .WithIcon(SpriteManager.Get(TechType.PrecursorIonCrystalMatrix));

        
        public static void Register()
        {
            

            var customPrefab = new CustomPrefab(Info);
            var DiamondBladeObj = new CloneTemplate(Info, TechType.PrecursorIonCrystalMatrix)
            {
                ModifyPrefab = prefab => prefab.GetComponentsInChildren<Renderer>().ForEach(r => r.materials.ForEach(m => m.color = Color.black))
            };
            
            customPrefab.SetGameObject(DiamondBladeObj);

            customPrefab.SetRecipe(new RecipeData(new Ingredient(TechType.PrecursorIonCrystal, 2), new Ingredient(TechType.Lithium, 2), new Ingredient(TechType.Diamond, 3)))
                .WithFabricatorType(CraftTree.Type.None);


            customPrefab.SetEquipment(EquipmentType.None);
            customPrefab.Register();
        }
    }
}
