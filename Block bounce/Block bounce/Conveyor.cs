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
    public class Conveyor
    {
        Texture2D texture;
        Vector2 position, origin;
        String direction;
        public Rectangle boundingBox, sourceRect;
        public int speedMod, spriteWidth, spriteHeight, currentFrame;
        public float timer, interval;

        public Conveyor(Texture2D newTexture, Vector2 newPosition, String newDirection)
        {
            texture = newTexture;
            position = newPosition;
            direction = newDirection;
            timer = 0f;
            interval = 1f; // Change for animation speed, lower number = faster animation
            currentFrame = 1;
            spriteWidth = texture.Width;
            spriteHeight = 20;
        }

        public void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if(direction == "left")
            {
                speedMod = -2;
            }

            else if (direction == "right")
            {
                speedMod = 2;
            }

            // Animation
            #region
            // Increase the timer by the number of milliseconds since update was last called
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // Check the time is more than the chosen interval
            if (timer > interval)
            {
                // Show next frame
                currentFrame++;

                // Reset timer
                timer = 0f;
            }

            // if we are on the last frame of animation, reset current frame to beginning of spritesheet
            if (currentFrame >= 20)
            {
                currentFrame = 0;
            }

            sourceRect = new Rectangle(0, currentFrame * spriteHeight, spriteWidth, spriteHeight);
            origin = new Vector2(0, 0);

            #endregion
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRect, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
