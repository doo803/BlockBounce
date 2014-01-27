﻿using System;
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
    public class HUD
    {
        public int secondsTaken, minutesTaken, screenWidth, screenHeight, deathCount, ticks;
        public SpriteFont font;
        public bool showHud;

        // Constructor
        public HUD()
        {
            showHud = true;
            font = null;
        }

        // Load Content
        public void LoadContent(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("hud/arial");
        }

        // Update
        public void Update(GameTime gameTime)
        {
            ticks++;
            secondsTaken = ticks / 60;

            if (secondsTaken == 60) 
            {
                ticks = 0;
                secondsTaken = 0;
                minutesTaken++;
            }

        }

        // Draw function
        public void Draw(SpriteBatch spriteBatch)
        {

            // If showHud = true, then display HUD
            if (showHud)
            {
                if (secondsTaken < 10)
                {
                    spriteBatch.DrawString(font, "Time: " + minutesTaken + ":0" + secondsTaken, new Vector2(600, 5), Color.Red);
                }

                else if (secondsTaken >= 10)
                {
                    spriteBatch.DrawString(font, "Time: " + minutesTaken + ":" + secondsTaken, new Vector2(600, 5), Color.Red);
                }
                
                spriteBatch.DrawString(font, "Deaths: " + deathCount, new Vector2(750, 5), Color.Red);
            }
        }
    }
}
