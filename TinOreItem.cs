using Eco.Core.Items;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;

namespace Eco.Mods.TechTree
{
    [BecomesRubble(new[] { typeof(IronOreRubbleSet1Chunk1Object), typeof(IronOreRubbleSet1Chunk2Object), typeof(IronOreRubbleSet1Chunk3Object) })]
    [BecomesRubble(new[] { typeof(IronOreRubbleSet2Chunk1Object), typeof(IronOreRubbleSet2Chunk2Object), typeof(IronOreRubbleSet2Chunk3Object), typeof(IronOreRubbleSet2Chunk4Object) })]
    [BecomesRubble(new[] { typeof(IronOreRubbleSet3Chunk1Object), typeof(IronOreRubbleSet3Chunk2Object), typeof(IronOreRubbleSet3Chunk3Object) })]
    [BecomesRubble(new[] { typeof(IronOreRubbleSet4Chunk1Object), typeof(IronOreRubbleSet4Chunk2Object), typeof(IronOreRubbleSet4Chunk3Object) })]
    [Minable(1)]
    [Serialized]
    [Solid]
    [Wall]
    public partial class TinOreBlock : Block
    {
        public Type RepresentedItemType { get { return typeof(TinOreItem); } }
    }

    [Currency]
    [Ecopedia("Natural Resources", "Ore", true, InPageTooltip.DynamicTooltip)]
    [LocDisplayName("Tin Ore")]
    [MaxStackSize(20)]
    [ResourcePile]
    [Serialized]
    [Tag("Currency", 1)]
    [Tag("Ore", 1)]
    [Tag("Excavatable", 1)]
    [Weight(10000)]
    public partial class TinOreItem : BlockItem<TinOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Tin Ore"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Ore of tin used to smelt bronze."); } }

        public override bool CanStickToWalls { get { return false; } }
    }
}
