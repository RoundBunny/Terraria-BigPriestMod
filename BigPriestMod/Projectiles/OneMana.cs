using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace BigPriestMod.Projectiles 
{
    public class OneMana : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 40; //Set the hitbox width
            projectile.height = 39; //Set the hitbox height
            projectile.timeLeft = 60*2; //The amount of time the projectile is alive for
            projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed
            projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
            projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
            projectile.ranged = true; //Tells the game whether it is a ranged projectile or not
            projectile.aiStyle = 0; // Inferno Fork Bolt

        }
        public override void AI() 
        {
            projectile.light = 0.3f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 59, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
            
        }
    

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            owner.AddBuff(117, 3*60); //hitting an enemy with this projectile increases your damage by 10% for 3 seconds

        }
        


    }
}
