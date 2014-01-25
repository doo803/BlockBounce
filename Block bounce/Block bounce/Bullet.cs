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
        public Rectangle boundingBox;
        Vector2 position;
        int speed;
        public bool isVisible;

        public Bullet(Texture2D newTexture, string newDirection, Vector2 newPosition)
        {
            position = newPosition;
            texture = newTexture;
            direction = newDirection;
            isVisible = true;
            speed = 6;
        }

        public void LoadContent(ContentManager Content)
        { 

        }

        public void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White); 
        }
    }
}
