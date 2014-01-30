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
    public class Bullet
    {
        string direction;
        public Texture2D texture;
        public Rectangle boundingBox, sourceRect;
        Vector2 position, origin;
        int speed;
        public bool isVisible;
        public int spriteWidth, spriteHeight, currentFrame;
        public float timer, interval;

        public Bullet(Texture2D newTexture, string newDirection, Vector2 newPosition)
        {
            position = newPosition;
            texture = newTexture;
            direction = newDirection;
            isVisible = true;
            speed = 6;
            timer = 0f;
            interval = 20f; // Change for animation speed, lower number = faster animation
            currentFrame = 1;
            spriteWidth = texture.Width;
            spriteHeight = 15;
        }

        public void LoadContent(ContentManager Content)
        { 

        }

        public void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, 15);

            if (direction == "left")
            {
                position.X -= speed;
            }

            else if (direction == "right")
            {
                position.X += speed;
            }

            // Destroy bullet if it reaches side of screen
            if (position.X <= -20)
            {
                isVisible = false;
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
            if (currentFrame >= 6)
            {
                currentFrame = 0;
            }

            sourceRect = new Rectangle(0, currentFrame * (spriteHeight + 1), spriteWidth, spriteHeight);
            origin = new Vector2(0, 0);

            #endregion
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRect, Color.Red, 0f, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
