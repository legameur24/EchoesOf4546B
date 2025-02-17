using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Extensions;
using UnityEngine;
using Ingredient = CraftData.Ingredient;

namespace EchoesOf4546B.Prefab.Items.Equipment
{
    public static class DiamondBlade
    {
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType("diamondsblade", "Hardened Blade", "Diamond-hardened blade delivers higher damage.")
            .WithIcon(SpriteManager.Get(TechType.DiamondBlade));

        public static void Register()
        {
            var customPrefab = new CustomPrefab(Info);

            var DiamondBladeObj = new CloneTemplate(Info, TechType.DiamondBlade);
            DiamondBladeObj.ModifyPrefab += obj =>
            {
                var diamondsBlade = obj.GetComponent<Knife>();
                var Knife = obj.AddComponent<DiamondsBlade>().CopyComponent(diamondsBlade);
                Object.DestroyImmediate(diamondsBlade);
                Knife.damage *= 5f;
            };
            customPrefab.SetGameObject(DiamondBladeObj);
            customPrefab.SetRecipe(new RecipeData(new Ingredient(TechType.Knife), new Ingredient(TechType.Diamond, 2)))
                .WithFabricatorType(CraftTree.Type.Workbench);

            customPrefab.SetPdaGroupCategory(TechGroup.Miscellaneous, TechCategory.Tools);
            customPrefab.SetEquipment(EquipmentType.Hand);
            customPrefab.Register();
        }
    }

    public class DiamondsBlade : Knife
    {
        public float hitForce = 1669;
        public ForceMode forceMode = ForceMode.Acceleration;

        public override string animToolName { get; } = TechType.DiamondBlade.AsString(true);

        public override void OnToolUseAnim(GUIHand hand)
        {
            base.OnToolUseAnim(hand);

            GameObject hitObj = null;
            Vector3 hitPosition = default;
            UWE.Utils.TraceFPSTargetPosition(Player.main.gameObject, attackDist, ref hitObj, ref hitPosition);
            if (!hitObj)
            {
                return;
            }

            var liveMixin = hitObj.GetComponentInParent<LiveMixin>();
            if (liveMixin && IsValidTarget(liveMixin))
            {
                var rigidbody = hitObj.GetComponentInParent<Rigidbody>();

                if (rigidbody)
                {
                    rigidbody.AddForce(MainCamera.camera.transform.forward * hitForce, forceMode);
                }
            }
        }
    }
}