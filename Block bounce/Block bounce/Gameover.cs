using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Block_bounce
{
    public class GameOver
    {
        Texture2D redOverlay, text, prompt;
        Vector2 position;
        public int i, time;
        public float scale, elapsed;
        bool increasing;

        // Constructor
        public GameOver()
        {
            scale = 0.75f;
        }

        // Load Content
        public void LoadContent(ContentManager Content)
        {
            redOverlay = Content.Load<Texture2D>("gameover/redoverlay");
            text = Content.Load<Texture2D>("gameover/text");
            prompt = Content.Load<Texture2D>("gameover/respawnprompt");
        }

        // Update
        public void Update(GameTime gameTime)
        {
            position = new Vector2(450, 300);

            // The time since Update was called last.

            elapsed++;

            if (scale < 0.9)
            {
                increasing = true;
            }

            if (scale > 1.4)
            {
                increasing = false;
            }
            
            if (increasing)
            {
                scale += 0.0125f;
            }

            if (!increasing)
            {
                scale -= 0.0125f;
            }
      
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(redOverlay, Vector2.Zero, Color.White);
            spriteBatch.Draw(prompt, new Vector2(0, -400), Color.White);

            spriteBatch.Draw(text, position, null, Color.White, 0f, position, scale,
                SpriteEffects.None, 0f);
        }
    }
}
