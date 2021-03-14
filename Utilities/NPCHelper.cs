using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;

namespace Prime.Utilities
{
    public static class NpcHelper
    {
        public static int DropItemWithProbability(Rectangle rectangle, int itemId, int amount, int probability)
        {
            var random = new Random();
            return random.Next(0, 100) < probability ? Item.NewItem(rectangle, itemId, amount) : 0;
        }

        /// <summary>
        /// Drops an item from a list of items.
        /// The probability is calculated automatically by the amount of items in the list.
        /// That means, every item in the list will drop with the same probability.
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="itemIds"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static int DropItemWithProbability(Rectangle rectangle, IList<int> itemIds, int amount)
        {
            var randomNumber = Main.rand.Next(itemIds.Count);

            return itemIds.Where((t, i) => randomNumber == i).Select(t => Item.NewItem(rectangle, t, amount)).FirstOrDefault();
        }
    }
}