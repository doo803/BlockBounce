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
    public class Checkpoint
    {
        public bool activated;
        public Rectangle boundingBox;
        Vector2 position;

        // Constructor
        public Checkpoint(Vector2 newPosition)
        {
            position = newPosition;
            boundingBox = new Rectangle((int)position.X, (int)position.Y, 20, 20);
        }

        // Update
        public void Update(GameTime gameTime)
        {
            
        }
    }
}
