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
			item.damage = 80;
			item.melee = true;
			item.width = 80;
			item.height = 160;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = 1;
			item.knockBack = 69;
			item.value = 69420;
			item.rare = -12;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Ragnaros");
            item.shoot = mod.ProjectileType("RagShot");
			item.autoReuse = true;
            item.shootSpeed = 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(175, 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
