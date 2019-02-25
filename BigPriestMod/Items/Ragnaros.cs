using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace BigPriestMod.Items
{
	public class Ragnaros : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ragnaros the Firelord");
			Tooltip.SetDefault("BY FIRE BE PURGED");
		}
		public override void SetDefaults()
		{
			item.damage = 8000;
			item.melee = true;
			item.width = 80;
			item.height = 160;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 69;
			item.value = 69420;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
