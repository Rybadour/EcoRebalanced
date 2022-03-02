using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;

namespace EcoRebalanced
{
    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class PulleyObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Pulley"); } }

        public virtual Type RepresentedItemType { get { return typeof(PulleyItem); } }

        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));
            this.GetComponent<PowerGridComponent>().Initialize(10, new MechanicalPower());
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        static PulleyObject()
        {
        }
    }


    [Serialized]
    [LocDisplayName("Pulley")]
    public partial class PulleyItem : WorldObjectItem<PulleyObject>, IPersistentData
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Pulley"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A simple block used to transfer mechanical power over distances."); } }

        static PulleyItem()
        {
        }

        [Serialized, TooltipChildren] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(BasicEngineeringSkill), 1)]
    public partial class PulleyRecipe : RecipeFamily
    {
        public PulleyRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Pulley",  //noloc
                Localizer.DoStr("Pulley"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(PlantFibersItem), 30, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                    new IngredientElement(typeof(HewnLogItem), 10, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<PulleyItem>(1)
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(BasicEngineeringSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                typeof(PulleyRecipe),
                2,
                typeof(BasicEngineeringSkill),
                typeof(BasicEngineeringFocusedSpeedTalent),
                typeof(BasicEngineeringParallelSpeedTalent)
            );
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Pulley"), typeof(PulleyRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

}