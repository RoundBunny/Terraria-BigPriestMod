using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BigPriestMod.Items
{
    public class ExampleBulletA : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidian Statue");
            Tooltip.SetDefault("Aggro players HATE him!");
        }

        public override void SetDefaults()
        {
            item.damage = 480; //This is added with the weapon's damage
            item.ranged = true;
            item.width = 14;
            item.height = 32;
            item.maxStack = 999;
            item.consumable = true; //Tells the game that this should be used up once fired
            item.knockBack = 1f; //Added with the weapon's knockback
            item.value = 500;
            item.rare = 2;
            item.shoot = mod.ProjectileType("ExampleBulletA");
            item.shootSpeed = 7f; //Added to the weapon's shoot speed
            item.ammo = mod.ItemType("ExampleBulletA"); //Tells game that the type of ammo is of ExampleBulletA
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock);
            recipe.SetResult(this, 111);
            recipe.AddRecipe();
        }
    }
}
