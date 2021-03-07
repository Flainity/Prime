using Terraria.ModLoader;

namespace Prime
{
    internal class PrimeRecipes
    {
        private static ModRecipe GetNewRecipe()
        {
            return new ModRecipe(ModContent.GetInstance<PrimeMod>());
        }
    }
}