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
    public class Menu
    {
        public Texture2D texture, selection1Texture, selection2Texture, selection3Texture;
        public int selection, keyPress, menuVal, enterReset, songBegin;
        public Vector2 option1, option2, option3;

        // Instantiate sound manager
        SoundManager sm = new SoundManager();

        // Constructor
        public Menu()
        {
            selection = 1;
            keyPress = 0;
            enterReset = 0;
            songBegin = 0;
        }

        // Update
        public void Update(GameTime gameTime)
        {
            // Get keyboard state
            KeyboardState keyState = Keyboard.GetState();

            // Start song
            #region
            songBegin++;
            if (songBegin == 1)
            {
                MediaPlayer.Play(sm.menuMusic);
                MediaPlayer.IsRepeating = true;
            }
            #endregion

            // Control volume
            #region
            sm.Update(gameTime);
            #endregion

            // remove problem if enter is held down from pause screen
            #region
            if (keyState.IsKeyUp(Keys.Enter) && GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Released)
            {
                enterReset = 1;
            }
            #endregion

            // Reset keyPress to 0
            #region
            if (keyState.IsKeyUp(Keys.Up) && keyState.IsKeyUp(Keys.Down) &&
                GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Released &&
                GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Released)
            {
                keyPress = 0;
            }
            #endregion

            // Move selection down
            #region 
            if (keyState.IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
            {
                keyPress++;

                if (keyPress >= 2)
                {
                    keyPress = 2;
                }

                if (keyPress == 1)
                {
                    selection++;
                    sm.click.Play();
                }
            }
            #endregion

            // Move selection up
            #region
            if (keyState.IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
            {
                keyPress++;

                if (keyPress >= 2)
                {
                    keyPress = 2;
                }

                if (keyPress == 1)
                {
                    selection--;
                    sm.click.Play();
                }
            }
            #endregion

            // Keep selection within desired range
            #region
            if (selection > 3)
            {
                selection = 3;
            }

            if (selection < 1)
            {
                selection = 1;
            }
            #endregion

            // Perform actions for selections
            #region
            if ((keyState.IsKeyDown(Keys.Enter) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) && enterReset == 1)
            {
                switch (selection)
                {
                    case 1:
                        {
                            menuVal = 1;
                            break;
                        }

                    case 2:
                        {
                            menuVal = 2;
                            break;
                        }
                    case 3:
                        {
                            menuVal = 3;
                            break;
                        }
                }
            }
            #endregion
        }

        // Load Content
        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("menu/background");
            selection1Texture = Content.Load<Texture2D>("menu/selection1");
            selection2Texture = Content.Load<Texture2D>("menu/selection2");
            selection3Texture = Content.Load<Texture2D>("menu/selection3");
            sm.LoadContent(Content);
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        { 
            // Draw background
            spriteBatch.Draw(texture, Vector2.Zero, Color.White);

            switch (selection)
            {
                // DRAWING FOR SELECTION = 1 
                case 1:
                    { 
                        spriteBatch.Draw(selection1Texture, Vector2.Zero, Color.White);
                        break;
                    }
                
                // DRAWING FOR SELECTION = 2
                case 2:
                    {
                        spriteBatch.Draw(selection2Texture, Vector2.Zero, Color.White);
                        break;
                    }

                // DRAWING FOR SELECTION = 3
                case 3:
                    {
                        spriteBatch.Draw(selection3Texture, Vector2.Zero, Color.White);
                        break;
                    }
            }
        }
    }
}
