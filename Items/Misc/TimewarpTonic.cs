using System;
using Prime.Buffs.Debuff;
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

        public override bool CanUseItem(Player player)
        {
            return !player.HasBuff(ModContent.BuffType<StuckInTime>());
        }

        public override bool UseItem(Player player)
        {
            if (Main.dayTime)
            {
                Main.dayTime = false;
                Main.time = 0;
            }
            else
            {
                Main.dayTime = true;
                Main.time = 0;
            }

            if (Main.dayTime && ++Main.moonPhase >= 8)
                Main.moonPhase = 0;
            
            player.AddBuff(ModContent.BuffType<StuckInTime>(), 45000, false);

            return true;
        }
    }
}