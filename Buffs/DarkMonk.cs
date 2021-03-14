using System;
using Prime.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Prime.Buffs
{
    public class DarkMonk : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Dark State");
            Description.SetDefault($"Let's you use Shadow weapons\nIncreases all shadow damage by 10%");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var primePlayer = player.GetPrimePlayer();
            primePlayer.monkShadowDamageBoost += 0.5f;
        }
    }
}