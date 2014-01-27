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
        public levels.level7 l7 = new levels.level7();
        public levels.level8 l8 = new levels.level8();
        public levels.level9 l9 = new levels.level9();
        public levels.level10 l10 = new levels.level10();
        public levels.level11 l11 = new levels.level11();

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

            // Load Content from level6
            l6.LoadContent(Content);

            // Load Content from level7
            l7.LoadContent(Content);

            // Load Content from level8
            l8.LoadContent(Content);

            // Load Content from level9
            l9.LoadContent(Content);

            // Load Content from level10
            l10.LoadContent(Content);

            // Load Content from level11
            l11.LoadContent(Content);
        }

        // Update
        public void Update(GameTime gameTime)
        {

            // Allow dev mode tools
            DevTools();

            switch (currentLevel)
            {
                // Update per each level
                #region
                case 1:
                    {
                        // Player alive check
                        #region
                        if (l1.p.playerDied == true)
                        {
                            playerIsAlive = false;
                            l1.p.playerDied = false;
                        }

                        else playerIsAlive = true;
                        #endregion
                        currentLevel = l1.currentLevel;                       
                        l1.Update(gameTime);
                        break;
                    }

                case 2:
                    {
                        // Player alive check
                        #region
                        if (l2.p.playerDied == true)
                        {
                            playerIsAlive = false;
                            l2.p.playerDied = false;
                        }

                        else playerIsAlive = true;
                        #endregion
                        currentLevel = l2.currentLevel;
                        l2.Update(gameTime);
                        break;
                    }

                case 3:
                    {
                        // Player alive check
                        #region
                        if (l3.p.playerDied == true)
                        {
                            playerIsAlive = false;
                            l3.p.playerDied = false;
                        }

                        else playerIsAlive = true;
                        #endregion
                        currentLevel = l3.currentLevel;
                        l3.Update(gameTime);
                        break;
                    }

                case 4:
                    {
                        // Player alive check
                        #region
                        if (l4.p.playerDied == true)
                        {
                            playerIsAlive = false;
                            l4.p.playerDied = false;
                        }

                        else playerIsAlive = true;
                        #endregion
                        currentLevel = l4.currentLevel;
                        l4.Update(gameTime);
                        break;
                    }
                case 5:
                    {
                        // Player alive check
                        #region
                        if (l5.p.playerDied == true)
                        {
                            playerIsAlive = false;
                            l5.p.playerDied = false;
                        }

                        else playerIsAlive = true;
                        #endregion
                        currentLevel = l5.currentLevel;
                        l5.Update(gameTime);
                        break;
                    }
                case 6:
                    {
                        // Player alive check
                        #region
                        if (l6.p.playerDied == true)
                        {
                            playerIsAlive = false;
                            l6.p.playerDied = false;
                        }

                        else playerIsAlive = true;
                        #endregion
                        currentLevel = l6.currentLevel;
                        l6.Update(gameTime);
                        break;
                    }
                case 7:
                    {
                        // Player alive check
                        #region
                        if (l7.p.playerDied == true)
                        {
                            playerIsAlive = false;
                            l7.p.playerDied = false;
                        }

                        else playerIsAlive = true;
                        #endregion
                        currentLevel = l7.currentLevel;
                        l7.Update(gameTime);
                        break;
                    }
                case 8:
                    {
                        // Player alive check
                        #region
                        if (l8.p.playerDied == true)
                        {
                            playerIsAlive = false;
                            l8.p.playerDied = false;
                        }

                        else playerIsAlive = true;
                        #endregion
                        currentLevel = l8.currentLevel;
                        l8.Update(gameTime);
                        break;
                    }
                case 9:
                    {
                        // Player alive check
                        #region
                        if (l9.p.playerDied == true)
                        {
                            playerIsAlive = false;
                            l9.p.playerDied = false;
                        }

                        else playerIsAlive = true;
                        #endregion
                        currentLevel = l9.currentLevel;
                        l9.Update(gameTime);
                        break;
                    }
                case 10:
                    {
                        // Player alive check
                        #region
                        if (l10.p.playerDied == true)
                        {
                            playerIsAlive = false;
                            l10.p.playerDied = false;
                        }

                        else playerIsAlive = true;
                        #endregion
                        currentLevel = l10.currentLevel;
                        l10.Update(gameTime);
                        break;
                    }
                case 11:
                    {
                        // Player alive check
                        #region
                        if (l11.p.playerDied == true)
                        {
                            playerIsAlive = false;
                            l11.p.playerDied = false;
                        }

                        else playerIsAlive = true;
                        #endregion
                        currentLevel = l11.currentLevel;
                        l11.Update(gameTime);
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
                case 7:
                    {
                        l7.Draw(spriteBatch);
                        break;
                    }
                case 8:
                    {
                        l8.Draw(spriteBatch);
                        break;
                    }
                case 9:
                    {
                        l9.Draw(spriteBatch);
                        break;
                    }
                case 10:
                    {
                        l10.Draw(spriteBatch);
                        break;
                    }
                case 11:
                    {
                        l11.Draw(spriteBatch);
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
