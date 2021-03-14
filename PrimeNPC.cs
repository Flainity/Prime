using System;
using System.Collections.Generic;
using Prime.Items.Misc;
using Prime.Items.Tools;
using Prime.Items.Weapons;
using Prime.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prime
{
    public class PrimeNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            NpcHelper.DropItemWithProbability(npc.getRect(), ModContent.ItemType<TimewarpTonic>(), 1, 5);
            
            base.NPCLoot(npc);
        }

        public static bool AnyBossNPCs()
        {
            for (var i = 0; i < 200; ++i)
            {
                if (Main.npc[i].active && Main.npc[i].boss)
                    return true;
            }

            return false;
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (!player.GetPrimePlayer().bossZen) return;
            
            spawnRate = 0;
            maxSpawns = 0;
        }
    }
}