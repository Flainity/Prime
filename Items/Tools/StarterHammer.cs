using Microsoft.Xna.Framework;
using Prime.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prime.Items.Tools
{
    public class StarterHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A basic hammer, just freakin fast");
        }

        public override void SetDefaults()
        {
            item.damage = 1;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 2;
            item.useAnimation = 20;
            item.hammer = 55;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}