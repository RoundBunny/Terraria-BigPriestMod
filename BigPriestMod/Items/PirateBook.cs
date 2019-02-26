using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BigPriestMod.Items
{
    public class PirateBook : ModItem
    {
        public override void SetStaticDefaults() //used to set the name (defaults to the ID but with spaces before every capital letter except the first letter of the ID), tooltip and more.
        {
            Tooltip.SetDefault("Aye aye"); //tooltip
            DisplayName.SetDefault("Pirate Book");
        }
        public override void SetDefaults()
        {
            item.damage = 200; //deals 200 damage
            item.magic = true; //deals magic damage
            item.noMelee = true; //the item sprite itself does no damage
            item.width = 28; //26 px wide
            item.height = 30; //26 px tall
            item.useTime = 15; //shoots a projectile every 15 frames
            item.useAnimation = 15; //the item itself is visible for 15 frames (no frame where it's invisible if you use auto-fire) and has a displayed use time of 18
            item.useStyle = 5; //animates like a gun (
            item.knockBack = 0; //none
            item.value = 150000; //15 gold
            item.rare = -12; //rainbow
            item.autoReuse = true; //auto-fires
            item.shoot = mod.ProjectileType("Patches"); //shoots a modded projectile, in this case Patches
            item.shootSpeed = 20; //projectile has a velocity of 80
            item.mana = 5; //10 mana to use
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 10); //crafted with 10 wood
            recipe.AddIngredient(75); //crafted with Item 75, Fallen Star
            recipe.AddTile(18); //crafted at Tile 18, Workbench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
        {
            int spread = 15; //The angle of random spread.
            float spreadMult = 0.1f; //Multiplier for bullet spread, set it higher and it will make for some outrageous spread.
            for (int i = 0; i < 8; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(80)); //12 is the spread in degrees, although like with Set Spread it's technically a 24 degree spread due to the fact that it's randomly between 12 degrees above and 12 degrees below your cursor.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI); //create the projectile
            }
            return false; //Makes sure to not spawn the original projectile
        }
    }

}