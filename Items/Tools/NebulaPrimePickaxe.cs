using Microsoft.Xna.Framework;
using Prime.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prime.Items.Tools
{
    public class NebulaPrimePickaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.NebulaPickaxe);
            item.useTime = 2;
            item.axe = 55;
            item.rare = ItemRarityID.Purple;
        }

        public override void AddRecipes()
        {
            var recipe01 = new ModRecipe(mod);
            recipe01.AddIngredient(ModContent.ItemType<PicksawPrime>(), 1);
            recipe01.AddIngredient(ItemID.FragmentNebula, 12);
            recipe01.AddIngredient(ItemID.LunarBar, 10);
            recipe01.AddTile(TileID.LunarCraftingStation);
            recipe01.SetResult(this);
            recipe01.AddRecipe();
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