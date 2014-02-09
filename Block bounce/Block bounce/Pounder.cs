using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Block_bounce
{
    public class Pounder
    {
        public Rectangle boundingBoxSpike, boundingBoxPlat, sourceRect;
        public Texture2D texture;
        public Vector2 position, origin;
        public int spriteWidth, spriteHeight, currentFrame;
        public float timer, interval;

        public Pounder(Texture2D newTexture, Vector2 newPosition, int newInterval)
        {
            texture = newTexture;
            position = newPosition;
            interval = newInterval;
            currentFrame = 0;
            spriteWidth = newTexture.Width;
        }

        public void Update(GameTime gameTime)
        {
            timer++;
            if (timer >= interval)
            {
                currentFrame++;
                timer = 0;
            }

            sourceRect = new Rectangle(0, currentFrame * 100, spriteWidth, spriteHeight);

            // Change spriteHeight based on current frame
            spriteHeight = 24 + (8 * currentFrame);
            if (currentFrame < 7)
            {
                spriteHeight = 24 + (8 * currentFrame);
            }

            else if (currentFrame >= 7)
            {
                spriteHeight = 24 + 58;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRect, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
