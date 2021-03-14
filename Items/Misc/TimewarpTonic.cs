using System;
using Prime.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prime.Items.Misc
{
    public class TimewarpTonic : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("When this tonic is consumed, the daytime will change to it's opposite");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.scale = 1;
            item.maxStack = 999;
            item.useTime = 17;
            item.useAnimation = 17;
            item.UseSound = SoundID.Item3;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.rare = ItemRarityID.Orange;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            Main.time = Main.time / (Main.dayTime ? 54000 : 32400) * (Main.dayTime ? 32400 : 54000);
            Main.dayTime = !Main.dayTime;
            if (Main.dayTime && ++Main.moonPhase >= 8)
                Main.moonPhase = 0;

            return true;
        }
    }
}