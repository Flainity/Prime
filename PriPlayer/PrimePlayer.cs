using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Prime.Buffs;
using Prime.Items.Misc;
using Prime.Items.Potions;
using Prime.Items.Tools;
using Prime.Projectiles.Typeless;
using Prime.Utilities;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Prime.PriPlayer
{
    public class PrimePlayer : ModPlayer
    {
        public bool isMonkClass;
        public bool isLightMonk;
        public bool isShadowMonk;

        public float monkLightDamageBoost = 1f;
        public float monkShadowDamageBoost = 1f;

        public static bool areThereAnyBosses = false;
        public bool bossZen = false;
        
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

        public override void ResetEffects()
        {
            monkLightDamageBoost = 1f;
            monkShadowDamageBoost = 1f;
            bossZen = false;
        }

        public override void OnMissingMana(Item item, int neededMana)
        {
            var manaPercentage = player.statManaMax2 * 0.2;
            var powerStarId = ModContent.ItemType<MagicEssence>();

            if (!(player.statMana < manaPercentage) && player.statMana >= neededMana) return;
            if (!player.HasItem(ModContent.ItemType<MagicEssence>())) return;

            QuickManaHeal(powerStarId);
        }

        public override void PostUpdateMiscEffects()
        {
            PrimePlayerMiscEffects.PrimePostUpdateMiscEffects(player, mod);
            var primePlayer = player.GetPrimePlayer();
            /*if (player.whoAmI == Main.myPlayer && primePlayer.isLightMonk && player.ownedProjectileCounts[ModContent.ProjectileType<LightMonkAura>()] < 1)
                Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<LightMonkAura>(), 1, 0.0f, player.whoAmI);*/
        }

        public override void PreUpdate()
        {
            isMonkClass = HasItemFavorited(ModContent.ItemType<MonkBell>());

            if (!isMonkClass) return;
            if (isLightMonk == false && isShadowMonk == false) { isLightMonk = true; }

            if (isLightMonk) { player.AddBuff(ModContent.BuffType<LightMonk>(), 2, false); }
            else if (isShadowMonk) { player.AddBuff(ModContent.BuffType<DarkMonk>(), 2, false); }
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
                if (player.armor[index].netID == itemId) return true;
            }

            return false;
        }

        private bool HasItemFavorited(int itemId)
        {
            for (var index = 0; index < 58; index++)
            {
                if (player.inventory[index].netID == itemId)
                {
                    return player.inventory[index].favorited;
                }
            }

            return false;
        }
    }
}