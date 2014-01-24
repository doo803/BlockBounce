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
    public class MovingSpike
    {
        public Boolean isVisible, movingRight, movingLeft;
        public Vector2 position, leftLimit, rightLimit;
        public Texture2D texture;
        public Rectangle boundingBox;
        public int speed;


        // Constructor
        public MovingSpike(Texture2D newTexture, Vector2 newPosition, Vector2 newLeftLimit, Vector2 newRightLimit)
        {
            texture = newTexture;
            position = newPosition;
            leftLimit = newLeftLimit;
            rightLimit = newRightLimit;
            movingRight = true;
            movingLeft = false;      
            speed = 5;
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        // Update
        public void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (position.X <= leftLimit.X)
            {
                movingRight = true;
                movingLeft = false;
            }

            if (position.X >= rightLimit.X)
            {
                movingRight = false;
                movingLeft = true;
            }

            if (movingLeft == true)
            {
                position.X -= speed;
            }

            if (movingRight == true)
            {
                position.X += speed;
            }
        }
    }
}
