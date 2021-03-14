using Prime.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prime.Items.Weapons
{
	public class PrimeSword : PrimeItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Prime Sword");
			Tooltip.SetDefault("An awesome new sword");
		}

		public override void SetDefaults()
		{
			weaponTypeId = PrimeWeaponTypeID.ShadowMonk;
			item.damage = 20;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Expert;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.expertOnly = true;
			item.expert = true;
		}

		public override bool CanUseItem(Player player)
		{
			var primePlayer = player.GetPrimePlayer();
			return (primePlayer.isMonkClass && primePlayer.isShadowMonk);
		}

		public override void AddRecipes() 
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}