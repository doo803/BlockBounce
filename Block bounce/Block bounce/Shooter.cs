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
    public class Shooter
    {
        public Texture2D texture;
        public Vector2 position;
        public string direction;
        public int shootTimer, interval;
        public bool makeBullet;
        public Rectangle boundingBox;

        public Shooter(Texture2D newTexture, Vector2 newPosition, string newDirection, int newInterval)
        {
            texture = newTexture;
            position = newPosition;
            direction = newDirection;
            shootTimer = 0;
            interval = newInterval;
        }

        public void LoadContent(ContentManager Content)
        {
            
        }

        public void Update(GameTime gameTime)
        {
            shootTimer++;
            if (shootTimer >= interval)
            {
                makeBullet = true;
                shootTimer = 0;
            }

            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);

        }

    }
}
