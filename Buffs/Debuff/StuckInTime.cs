using System;
using Prime.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Prime.Buffs.Debuff
{
    public class StuckInTime : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Stuck in time");
            Description.SetDefault($"You are stuck in time!\nYou can reuse the Timewarp Tonic when you get out.");
            Main.debuff[Type] = true;
            canBeCleared = false;
        }
    }
}