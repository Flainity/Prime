using System;
using Prime.Buffs.StatBuffs;
using Terraria;
using Terraria.ModLoader;

namespace Prime.PriPlayer
{
    public class PrimePlayerMiscEffects
    {
        public static void PrimePostUpdateMiscEffects(Player player, Mod mod)
        {
            PrimePlayer.areThereAnyBosses = PrimeNPC.AnyBossNPCs();
            
            if (PrimePlayer.areThereAnyBosses && player.whoAmI == Main.myPlayer)
                player.AddBuff(ModContent.BuffType<BossZen>(), 2, false);
        }
    }
}