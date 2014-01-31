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
    public class DecayingPlatform : Platform
    {
        int decaying; // 0 = not decaying, 1 = decaying, 2 = decayed (invisible)
        int decayTimer, delay, respawnTimer, respawnRate;
        public bool beginDecay;
        float decayState;

        public DecayingPlatform(Texture2D newTexture, Vector2 newPosition, int newDelay, int newRespawnRate)
            : base(newTexture, newPosition)
        {
            delay = newDelay;
            respawnRate = newRespawnRate;
        }

        public void LoadContent(ContentManager Content)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            if (beginDecay == true)
            {
                beginDecay = false;
                // Start decay increasing
                decaying = 1;
            }

            if (decaying == 0)
            {
                boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }

            if (decaying == 1)
            {                
                decayTimer++;
                if (decayTimer >= delay)
                {
                    decayTimer = 0;
                    decayState++;
                }

                if (decayState >= 10)
                {
                    decaying = 2;
                }

                boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }

            if (decaying == 2)
            {
                respawnTimer++;

                // Remove bounding box
                boundingBox = new Rectangle(0, 0, 0, 0);
            }

            // Respawn the platform
            if(respawnTimer >= respawnRate)
            {
                decaying = 0;
                respawnTimer = 0;
                decayState = 0;
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White * (1f - (decayState / 10)));
        }        
    }
}
