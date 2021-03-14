using System;
using System.Globalization;
using Prime.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prime.Items.Potions
{
    public class MagicEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This magical essence will be used automatically, when you run out of mana.\nIt restores 75% of your maximum mana.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ManaPotion);
            item.maxStack = 9999;
            item.UseSound = SoundID.Item3;
            item.value = Item.buyPrice(silver: 50);
            item.expert = true;
            item.rare = ItemRarityID.Expert;
        }

        public override void GetHealMana(Player player, bool quickHeal, ref int healValue)
        {
            var primePlayer = player.GetPrimePlayer();
            healValue = (int) Math.Round(player.statManaMax2 * .75);
        }
    }
}