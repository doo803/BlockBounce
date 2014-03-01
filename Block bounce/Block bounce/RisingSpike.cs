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
        int speed, currentFrame;
        bool movingUp, movingDown;
        float rotation;

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
        }

        // Update
        public void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X - texture.Width/2, (int)position.Y - texture.Height/2, texture.Width, texture.Height);
            sourceRect = new Rectangle(0, 0, texture.Width, texture.Height);

            origin = new Vector2(texture.Width / 2, texture.Height / 2);

            // Run animation logic
            currentFrame++;

            // Degrees to radians, radians = pi(X)/180, where X = degrees
            rotation = -(MathHelper.Pi * (currentFrame * 15))/180;

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
            spriteBatch.Draw(texture, position, sourceRect, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 0f);
        }
    }
}
