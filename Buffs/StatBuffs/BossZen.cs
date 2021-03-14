using Prime.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Prime.Buffs.StatBuffs
{
    public class BossZen : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Boss Zen");
            Description.SetDefault("The active boss is reducing spawn rates");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) => player.GetPrimePlayer().bossZen = true;
    }
}