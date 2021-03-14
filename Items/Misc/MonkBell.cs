using System;
using Prime.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prime.Items.Misc
{
    public class MonkBell : PrimeItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Favorite this item, to become a monk\nInitially, you will become a light monk\nUse this item, to switch between light & dark monk");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.scale = 1;
            item.maxStack = 1;
            item.useTime = 17;
            item.useAnimation = 17;
            item.UseSound = SoundID.Item35;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.rare = ItemRarityID.Yellow;
            item.consumable = false;
        }

        public override bool UseItem(Player player)
        {
            var primePlayer = player.GetPrimePlayer();

            if (!primePlayer.isMonkClass) return true;
            
            if (primePlayer.isLightMonk)
            {
                primePlayer.isShadowMonk = true;
                primePlayer.isLightMonk = false;
                return true;
            }

            if (primePlayer.isShadowMonk)
            {
                primePlayer.isLightMonk = true;
                primePlayer.isShadowMonk = false;
                return true;
            }

            return true;
        }
    }
}