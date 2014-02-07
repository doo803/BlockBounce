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
    public class PushPlatform
    {
        public Texture2D texture;
        public Vector2 position;
        public Rectangle boundingBox;
        public Vector2 velocity;

        // Constructor
        public PushPlatform(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
        }

        // Update
        public void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            position.X += velocity.X;
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
