using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace BigPriestMod.Items
{
	public class Barnes : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Barnes");
			Tooltip.SetDefault("Tonight...");
		}
		public override void SetDefaults()
		{
			item.ranged = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 6;
			item.value = 1000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.damage = 420; //The damage
            item.maxStack = 1; //How many of this item you can stack
            item.noMelee = true; //Whether the weapon should do melee damage or not
            item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
            item.value = 1; //How much the item is worth
            item.shoot = mod.ProjectileType("ExampleBulletA"); //What the item shoots, retains an int value | 3
            item.shootSpeed = 32; //How fast the projectile fires
            item.useAmmo = mod.ItemType("ExampleBulletA"); //The item ammo ID that it will use

        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3460,10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
