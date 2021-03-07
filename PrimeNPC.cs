using Prime.Items.Misc;
using Prime.Items.Tools;
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
            NPCHelper.DropItemWithProbability(npc.getRect(), ModContent.ItemType<TimewarpTonic>(), 1, 2);
            
            base.NPCLoot(npc);
        }
    }
}