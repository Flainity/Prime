using Prime.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Prime.Buffs
{
    public class LightMonk : ModBuff
    {
        private readonly int _damageIncrease = 10;
        
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Light State");
            Description.SetDefault($"Let's you use Light weapons\nIncreases all light damage by {_damageIncrease}");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var primePlayer = player.GetPrimePlayer();
            primePlayer.monkLightDamageBoost += _damageIncrease;
        }
        
        
    }
}