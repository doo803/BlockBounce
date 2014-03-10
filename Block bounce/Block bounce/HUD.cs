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
    public class HUD
    {
        public int secondsTaken, minutesTaken, screenWidth, screenHeight, deathCount, ticks, difficulty, level, levelDeaths;
        public SpriteFont font;
        public bool showHud;

        // Constructor
        public HUD()
        {
            showHud = true;
            font = null;
            level = 1;
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

            string[] difficultyString = { difficulty.ToString() };

            System.IO.File.WriteAllLines("Difficulty.txt", difficultyString);

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

                switch (difficulty)
                {
                    #region
                    case 1:
                        {
                            spriteBatch.DrawString(font, "Difficulty: -Easy-", new Vector2(400, 5), Color.Red);
                            break;
                        }

                    case 2:
                        {
                            spriteBatch.DrawString(font, "Difficulty: --Normal--", new Vector2(400, 5), Color.Red);
                            break;
                        }

                    case 3:
                        {
                            spriteBatch.DrawString(font, "Difficulty: *Hard*", new Vector2(400, 5), Color.Red);
                            spriteBatch.DrawString(font, "/ 5", new Vector2(835, 25), Color.Red);
                            break;
                        }

                    case 4:
                        {
                            spriteBatch.DrawString(font, "Difficulty: **Insane**", new Vector2(400, 5), Color.Red);
                            break;
                        }
                    #endregion
                }

                spriteBatch.DrawString(font, "Level: " + level, new Vector2(10, 5), Color.Red);
            }
        }
    }
}
