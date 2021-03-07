using Microsoft.Xna.Framework;
using Prime.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prime.Items.Tools
{
    public class MythrilPrimePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Bloody red");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MythrilPickaxe);
            item.useTime = 2;
            item.axe = 55;
            item.rare = ItemRarityID.Purple;
        }

        public override void AddRecipes()
        {
            var recipe01 = new ModRecipe(mod);
            recipe01.AddIngredient(ModContent.ItemType<CobaltPrimePickaxe>(), 1);
            recipe01.AddIngredient(ItemID.MythrilBar, 15);
            recipe01.AddTile(TileID.MythrilAnvil);
            recipe01.SetResult(this);
            recipe01.AddRecipe();
            
            var recipe02 = new ModRecipe(mod);
            recipe02.AddIngredient(ModContent.ItemType<PalladiumPrimePickaxe>(), 1);
            recipe02.AddIngredient(ItemID.MythrilBar, 15);
            recipe02.AddTile(TileID.MythrilAnvil);
            recipe02.SetResult(this);
            recipe02.AddRecipe();
        }

        public override void MeleeEffects(Terraria.Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(10))
            {
                var dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Sparkle>());
            }
        }
    }
}