using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;
using Microsoft.Xna.Framework;

namespace BigPriestMod.Items
{
    public class SilverHand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Silver Hand");
            Tooltip.SetDefault("To Battle!");
        }
        public override void SetDefaults()
        {
            item.ranged = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 3;
            item.useAnimation = 3;
            item.knockBack = 6;
            item.value = 1000;
            item.rare = -12;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Annoy");
            item.autoReuse = true;
            item.damage = 50; //The damage
            item.maxStack = 1; //How many of this item you can stack
            item.noMelee = true; //Whether the weapon should do melee damage or not
            item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
            item.value = 1; //How much the item is worth
            item.shoot = mod.ProjectileType("OneMana"); //What the item shoots, retains an int value | 3
            item.shootSpeed = 80; //How fast the projectile fires
            item.useAmmo = mod.ItemType("OneMana"); //The item ammo ID that it will use

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3336, 1); //made with plantera expert item
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
        {
            int spread = 15; //The angle of random spread.
            float spreadMult = 0.1f; //Multiplier for bullet spread, set it higher and it will make for some outrageous spread.
            for (int i = 0; i < 2; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5)); //12 is the spread in degrees, although like with Set Spread it's technically a 24 degree spread due to the fact that it's randomly between 12 degrees above and 12 degrees below your cursor.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI); //create the projectile
            }
            return false; //Makes sure to not spawn the original projectile
        }
    }
}