using Prime.PriPlayer;
using Terraria;

namespace Prime.Utilities
{
    public static class PlayerHelper
    {
        /// <summary>
        /// Returns an instance of the Prime player object
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static PrimePlayer GetPrimePlayer(this Player player)
        {
            return player.GetModPlayer<PrimePlayer>();
        }

        /// <summary>
        /// Clears a selected array of buffs from the player
        /// </summary>
        /// <param name="player"></param>
        /// <param name="buffs"></param>
        public static void ClearBuffs(this Player player, params int[] buffs)
        {
            for (var i = 0; i < buffs.Length; i++)
                player.ClearBuff(i);
        }
    }
}