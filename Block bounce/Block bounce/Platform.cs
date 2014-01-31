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
    public class Platform
    {
        public Texture2D texture;
        public Vector2 position;
        public Rectangle boundingBox;

        // Constructor
        public Platform(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        // Draw
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, boundingBox, Color.White);
        }
    }
}
