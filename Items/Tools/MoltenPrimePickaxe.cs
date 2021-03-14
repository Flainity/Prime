using Microsoft.Xna.Framework;
using Prime.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prime.Items.Tools
{
    public class MoltenPrimePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Ouch, it's hot!");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MoltenPickaxe);
            item.useTime = 2;
            item.axe = 55;
            item.rare = ItemRarityID.Purple;
        }

        public override void AddRecipes()
        {
            var crimsonRecipe = new ModRecipe(mod);
            crimsonRecipe.AddIngredient(ModContent.ItemType<CrimtanePrimePickaxe>(), 1);
            crimsonRecipe.AddIngredient(ItemID.HellstoneBar, 20);
            crimsonRecipe.AddTile(TileID.Anvils);
            crimsonRecipe.SetResult(this);
            crimsonRecipe.AddRecipe();
            
            var corruptionRecipe = new ModRecipe(mod);
            corruptionRecipe.AddIngredient(ModContent.ItemType<DemonitePrimePickaxe>(), 1);
            corruptionRecipe.AddIngredient(ItemID.HellstoneBar, 20);
            corruptionRecipe.AddTile(TileID.Anvils);
            corruptionRecipe.SetResult(this);
            corruptionRecipe.AddRecipe();
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