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
    public class SpikeRow
    {
        Texture2D texture;
        public Rectangle boundingBox;
        Vector2 position;
        public SpikeRow(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            boundingBox = newRectangle;
            position = new Vector2(boundingBox.X, boundingBox.Y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, boundingBox, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }        
    }
}
