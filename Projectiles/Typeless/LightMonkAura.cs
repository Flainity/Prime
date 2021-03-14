using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prime.Projectiles.Typeless
{
    public class LightMonkAura : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Light Monk Aura");
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.height = 70;
            projectile.width = 70;
            projectile.ignoreWater = true;
            projectile.minionSlots = 0f;
            projectile.timeLeft = 18000;
            projectile.tileCollide = false;
        }
        
        public override void AI()
        {
            base.projectile.friendly = true;
            base.projectile.hostile = false;
            Player player = Main.player[base.projectile.owner];
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.15f / 255f, (float)(255 - base.projectile.alpha) * 0.15f / 255f, (float)(255 - base.projectile.alpha) * 0.01f / 255f);
            projectile.Center = player.Center;
        }
        
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float num = Vector2.Distance(base.projectile.Center, Utils.TopLeft(targetHitbox));
            float dist2 = Vector2.Distance(base.projectile.Center, Utils.TopRight(targetHitbox));
            float dist3 = Vector2.Distance(base.projectile.Center, Utils.BottomLeft(targetHitbox));
            float dist4 = Vector2.Distance(base.projectile.Center, Utils.BottomRight(targetHitbox));
            float minDist = num;
            if (dist2 < minDist)
            {
                minDist = dist2;
            }
            if (dist3 < minDist)
            {
                minDist = dist3;
            }
            if (dist4 < minDist)
            {
                minDist = dist4;
            }
            return new bool?(minDist <= 98f);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D sprite = Main.projectileTexture[base.projectile.type];
            Color drawColour = Color.White;
            Rectangle sourceRect = new Rectangle(base.projectile.width * (int)base.projectile.localAI[1], base.projectile.height * (int)base.projectile.localAI[0], base.projectile.width, base.projectile.height);
            Vector2 origin = new Vector2((float)(projectile.width / 2), (float)(projectile.height / 2));
            float opacity = 1f;
            int sparkCount = 0;
            int fadeTime = 20;
            if (base.projectile.timeLeft < fadeTime)
            {
                opacity = (float)base.projectile.timeLeft * (1f / (float)fadeTime);
                sparkCount = fadeTime - base.projectile.timeLeft;
            }
            for (int i = 0; i < sparkCount * 2; i++)
            {
                int dustType = 132;
                if (Utils.NextBool(Main.rand))
                {
                    dustType = 264;
                }
                float rangeDiff = 2f;
                Vector2 dustPos = new Vector2(Utils.NextFloat(Main.rand, -1f, 1f), Utils.NextFloat(Main.rand, -1f, 1f));
                dustPos.Normalize();
                dustPos *= 98f + Utils.NextFloat(Main.rand, -rangeDiff, rangeDiff);
                int dust = Dust.NewDust(base.projectile.Center + dustPos, 1, 1, dustType, 0f, 0f, 0, default(Color), 0.75f);
                Main.dust[dust].noGravity = true;
            }
            spriteBatch.Draw(sprite, base.projectile.Center - Main.screenPosition, new Rectangle?(sourceRect), drawColour * opacity, base.projectile.rotation, origin, 1f, SpriteEffects.None, 0f);
            return false;
        }
    }
}