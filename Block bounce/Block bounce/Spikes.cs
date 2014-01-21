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
    public class Spikes
    {
        public Boolean isVisible;
        public Vector2 position;
        public Texture2D texture;
        public Rectangle boundingBox;


        // Constructor
        public Spikes(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
            isVisible = false;
            boundingBox = new Rectangle((int)newPosition.X, (int)newPosition.Y, newTexture.Width, newTexture.Height);
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
