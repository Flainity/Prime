using System;
using System.Collections.Generic;
using Prime.Items.Weapons;
using Prime.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Prime.Items
{
    public abstract class PrimeItem : ModItem
    {
        public bool isTrueDamage;

        public int weaponTypeId = 0;
        
        public override bool CloneNewInstances => true;

        public override bool IgnoreDamageModifiers => isTrueDamage;

        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            base.ModifyWeaponDamage(player, ref add, ref mult, ref flat);
            var primePlayer = player.GetPrimePlayer();

            if (primePlayer.isShadowMonk && weaponTypeId == PrimeWeaponTypeID.ShadowMonk)
            {
                add += primePlayer.monkShadowDamageBoost - 1f;
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (weaponTypeId == PrimeWeaponTypeID.ShadowMonk)
            {
                var damageTooltipLine = tooltips.Find((TooltipLine tt) => tt.mod.Equals("Terraria") && tt.Name.Equals("Damage"));
                if (damageTooltipLine == null) return;
                damageTooltipLine.text = damageTooltipLine.text.Split(' ')[0] + " shadow damage";
            }
        }
    }
}