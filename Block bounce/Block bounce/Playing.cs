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
    public class Playing
    {
        public BaseLevel baseLevel = new BaseLevel();
        public levels.level1 l1 = new levels.level1();
        public levels.level2 l2 = new levels.level2();
        public levels.level3 l3 = new levels.level3();
        public levels.level4 l4 = new levels.level4();
        public levels.level5 l5 = new levels.level5();
        public levels.level6 l6 = new levels.level6();

        public int currentLevel;
        public Vector2 playerPosition;
        public bool playerIsAlive, devMode;
        private int i;
        
        // Constructor
        public Playing()
        {
            i = 0;
            devMode = true;
            currentLevel = 1;
        }

        // Load Content
        public void LoadContent(ContentManager Content)
        {
            // Load Content from BaseLevel
            baseLevel.LoadContent(Content);

            // Load Content from level1
            l1.LoadContent(Content); 
           
            // Load Content from level2
            l2.LoadContent(Content);

            // Load Content from level3
            l3.LoadContent(Content);

            // Load Content from level4
            l4.LoadContent(Content);

            // Load Content from level5
            l5.LoadContent(Content);

            // Load content from level6
            l6.LoadContent(Content);
        }

        // Update
        public void Update(GameTime gameTime)
        {
            playerPosition = new Vector2(l1.p.playerPosition.X, l1.p.playerPosition.Y);
            playerIsAlive = l1.p.playerIsAlive;

            // Allow dev mode tools
            DevTools();

            switch (currentLevel)
            {
                // Update per each level
                #region
                case 1:
                    {
                        currentLevel = l1.currentLevel;
                        l1.Update(gameTime);
                        break;
                    }

                case 2:
                    {
                        currentLevel = l2.currentLevel;
                        l2.Update(gameTime);
                        break;
                    }

                case 3:
                    {
                        currentLevel = l3.currentLevel;
                        l3.Update(gameTime);
                        break;
                    }

                case 4:
                    {
                        currentLevel = l4.currentLevel;
                        l4.Update(gameTime);
                        break;
                    }
                case 5:
                    {
                        currentLevel = l5.currentLevel;
                        l5.Update(gameTime);
                        break;
                    }
                case 6:
                    {
                        currentLevel = l6.currentLevel;
                        l6.Update(gameTime);
                        break;
                    }
                #endregion
            }
        }                
       
        // Draw
        public void Draw(SpriteBatch spriteBatch)
        { 
            // Draw content based on current level

            switch (currentLevel)
            {
                // Draw when current level = 1
                #region
                case 1:
                    {
                        l1.Draw(spriteBatch);
                        break;
                    }

                case 2:
                    {
                        l2.Draw(spriteBatch);
                        break;
                    }

                case 3:
                    {
                        l3.Draw(spriteBatch);
                        break;
                    }
                case 4:
                    {
                        l4.Draw(spriteBatch);
                        break;
                    }
                case 5:
                    {
                        l5.Draw(spriteBatch);
                        break;
                    }
                case 6:
                    {
                        l6.Draw(spriteBatch);
                        break;
                    }
                #endregion
            }
        }

        // Allow user to skip levels if devMode is true
        public void DevTools()
        {
            KeyboardState keyState = Keyboard.GetState();

            if (devMode == true)
            { 
                // Skip forwards
                if(keyState.IsKeyDown(Keys.NumPad6) || GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed)
                {
                    i++;
                    if(i == 1)
                    {
                        currentLevel++;
                    }
                }

                // Skip backwards
                if (keyState.IsKeyDown(Keys.NumPad4) || GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
                {
                    i++;
                    if (i == 1)
                    {
                        currentLevel--;
                    }
                }
            }

            // reset i to 0 when keys used are all up
            if (keyState.IsKeyUp(Keys.NumPad6) && GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Released &&
                keyState.IsKeyUp(Keys.NumPad4) && GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Released)
            {
                i = 0;
            }
        }
    }
}
