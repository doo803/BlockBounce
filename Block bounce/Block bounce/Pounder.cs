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

<<<<<<< HEAD
        public Pounder(Texture2D newTexture, Vector2 newPosition, int newInterval)
=======
        public Pounder(Texture2D newTexture, Vector2 newPosition, int newInterval, int newCurrentFrame)
>>>>>>> 87133217f72bb31c7f91a51829ccc8565590b739
        {
            texture = newTexture;
            position = newPosition;
            interval = newInterval;
<<<<<<< HEAD
            currentFrame = 0;
=======
            timer = 0;
            currentFrame = newCurrentFrame;
>>>>>>> 87133217f72bb31c7f91a51829ccc8565590b739
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

<<<<<<< HEAD
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
=======
            if (currentFrame <= 12)
            {
                sourceRect = new Rectangle(0, texture.Height - 24 - (((texture.Height - 24)/ 12) * currentFrame),
                    texture.Width, 24 + (((texture.Height - 24) / 12) * currentFrame));
            }

            if (currentFrame > 12)
            {
                sourceRect = new Rectangle(0, texture.Height + (((texture.Height) / 24) * (currentFrame - 12)), texture.Width,
                    texture.Height - (((texture.Height) / 24) * (currentFrame - 12)));
            }

            if (currentFrame >= 33)
            {
                currentFrame = 0;
            }
          
            // Options for death area of object to be whole object or just the bottom end

            //boundingBoxSpike = new Rectangle((int)position.X, (int)position.Y + (sourceRect.Height - 10), texture.Width, 10);
            boundingBoxSpike = new Rectangle((int)position.X, (int)position.Y, sourceRect.Width, sourceRect.Height);
>>>>>>> 87133217f72bb31c7f91a51829ccc8565590b739
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRect, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
