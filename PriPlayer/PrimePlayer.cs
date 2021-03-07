using System;
using System.Collections.Generic;
using Prime.Items.Potions;
using Prime.Items.Tools;
using Terraria;
using Terraria.ModLoader;

namespace Prime.PriPlayer
{
    public class PrimePlayer : ModPlayer
    {
        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            var starterPickaxe = new Item();
            starterPickaxe.SetDefaults(ModContent.ItemType<StarterPickaxe>());
            starterPickaxe.stack = 1;
            items.Add(starterPickaxe);

            var starterHammer = new Item();
            starterHammer.SetDefaults(ModContent.ItemType<StarterHammer>());
            starterHammer.stack = 1;
            items.Add(starterHammer);
        }

        public override void OnMissingMana(Item item, int neededMana)
        {
            var manaPercentage = player.statManaMax2 * 0.2;
            var powerStarId = ModContent.ItemType<MagicEssence>();

            if (!(player.statMana < manaPercentage) && player.statMana >= neededMana) return;
            if (!player.HasItem(ModContent.ItemType<MagicEssence>())) return;

            QuickManaHeal(powerStarId);
        }

        private void QuickManaHeal(int itemId)
        {
            for (var index = 0; index < 58; ++index)
            {
                if (player.inventory[index].netID != itemId || player.inventory[index].stack <= 0 ||
                    !ItemLoader.CanUseItem(player.inventory[index], player)) continue;

                var inventoryItem = player.inventory[index];
                
                Main.PlaySound(inventoryItem.UseSound, player.position);
                ItemLoader.UseItem(inventoryItem, player);
                player.statMana += inventoryItem.healMana;

                if (player.statMana > player.statManaMax2)
                    player.statMana = player.statManaMax2;

                if (inventoryItem.healMana <= 0) continue;
                
                player.AddBuff(94, Terraria.Player.manaSickTime);
                if (Main.myPlayer == player.whoAmI)
                    player.ManaEffect(inventoryItem.healMana);

                if (ItemLoader.ConsumeItem(inventoryItem, player))
                    --inventoryItem.stack;
                if (inventoryItem.stack <= 0)
                    inventoryItem.TurnToAir();
            }
        }

        private bool HasAccessoryEquipped(int itemId)
        {
            for (var index = 3; index < 8 + player.extraAccessorySlots; ++index)
            {
                return player.armor[index].netID == itemId;
            }

            return false;
        }
    }
}