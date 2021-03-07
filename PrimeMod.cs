using System;
using Terraria.ModLoader;

namespace Prime
{
	public class PrimeMod : Mod
	{
		internal static PrimeMod Mod;
		
		public override void Load()
		{
			if (ModLoader.version < new Version(0, 11, 8))
			{
				throw new Exception("\nThis mod uses functionality only present in the latest tModLoader. Please update tModLoader to use this mod!");
			}

			PrimeMod.Mod = this;
		}
	}
}