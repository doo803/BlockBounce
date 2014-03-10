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
    public class RisingSpike
    {
        Texture2D texture;
        Vector2 position, upLimit, downLimit, origin;
        public Rectangle boundingBox, sourceRect;
        int speed, currentFrame, spriteHeight, spriteWidth;
        bool movingUp, movingDown;
        float timer;
        float interval;
        

        // Constructor
        public RisingSpike(Texture2D newTexture, Vector2 newPosition, Vector2 newUpLimit, Vector2 newDownLimit, int newSpeed)
        {
            texture = newTexture;
            position = newPosition;
            upLimit = newUpLimit;
            downLimit = newDownLimit;
            speed = newSpeed;
            movingUp = false;
            movingDown = true;
            spriteWidth = texture.Width;
            spriteHeight = 30;
            interval = 20f; // Change for animation speed, lower number = faster animation
            timer = 0f;
        }

        // Update
        public void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X - texture.Width/2, (int)position.Y - texture.Height/2, texture.Width, texture.Height);
            sourceRect = new Rectangle(0, 0, texture.Width, texture.Height);

            origin = new Vector2(texture.Width / 2, texture.Height / 2);

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
            if (currentFrame >= 6)
            {
                currentFrame = 0;
            }

            sourceRect = new Rectangle(0, currentFrame * (spriteHeight + 1), spriteWidth, spriteHeight);
            origin = new Vector2(0, 0);

            #endregion

            if (position.Y > downLimit.Y)
            {
                movingUp = true;
                movingDown = false;
            }

            if (position.Y < upLimit.Y)
            {
                movingUp = false;
                movingDown = true;
            }

            if (movingUp)
            {
                position.Y -= speed;
            }

            if (movingDown)
            {
                position.Y += speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRect, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0f);
        }
    }
}
