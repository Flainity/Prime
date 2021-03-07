using System;
using Microsoft.Xna.Framework;
using Terraria;

namespace Prime.Utilities
{
    public static class NPCHelper
    {
        public static int DropItemWithProbability(Rectangle rectangle, int itemId, int amount, int probability)
        {
            var random = new Random();
            return random.Next(0, 100) < probability ? Item.NewItem(rectangle, itemId, amount) : 0;
        }
    }
}