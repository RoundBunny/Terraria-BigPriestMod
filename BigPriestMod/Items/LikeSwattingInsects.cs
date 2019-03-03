using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BigPriestMod.Items
{
    public class RagBook : ModItem
    {
        public override void SetStaticDefaults() //used to set the name (defaults to the ID but with spaces before every capital letter except the first letter of the ID), tooltip and more.
        {
            Tooltip.SetDefault("Insects..."); //tooltip
            DisplayName.SetDefault("Rag's Book");
        }
        public override void SetDefaults()
        {
            item.damage = 80; //deals 200 damage
            item.magic = true; //deals magic damage
            item.noMelee = true; //the item sprite itself does no damage
            item.width = 28; //26 px wide
            item.height = 30; //26 px tall
            item.useTime = 8; //shoots a projectile every 15 frames
            item.useAnimation = 8; //the item itself is visible for 15 frames (no frame where it's invisible if you use auto-fire) and has a displayed use time of 18
            item.useStyle = 5; //animates like a gun 
            item.knockBack = 0; //none
            item.value = 150000; //15 gold
            item.rare = -12; //rainbow
            item.autoReuse = true; //auto-fires
            item.shoot = mod.ProjectileType("RagShot"); //shoots a modded projectile, in this case Patches
            item.shootSpeed = 20; //projectile has a velocity of 80
            item.mana = 5; //10 mana to use
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Dirt, 10); //crafted with 10 wood
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
        {
            int numberProjectiles = 30; // shoots 6 projectiles
            for (int index = 0; index < numberProjectiles; ++index)
            {
                Vector2 vector2_1 = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(201) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));   //this defines the projectile width, direction and position
                vector2_1.X = (float)(((double)vector2_1.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
                vector2_1.Y -= (float)(100 * index);
                float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
                float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                if ((double)num13 < 0.0) num13 *= -1f;
                if ((double)num13 < 20.0) num13 = 20f;
                float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
                float num15 = item.shootSpeed / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + (float)Main.rand.Next(-50, 51) * 0.02f; //change the Main.rand.Next here to, for example, (-10, 11) to reduce the spread. Change this to 0 to remove it altogether
                float SpeedY = num17 + (float)Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
            }
            return false;
        }
    }

}