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
    public class Pause
    {
        public int pauseVal, selection, keyPress;
        public Texture2D texture, resumeTexture, quitTexture;

        // Instantiate soundmanager
        SoundManager sm = new SoundManager();

        // Constructor
        public Pause()
        {
            pauseVal = 0;
            keyPress = 0;
        }

        // Load Content
        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("pause/background");
            resumeTexture = Content.Load<Texture2D>("pause/selection1");
            quitTexture = Content.Load<Texture2D>("pause/selection2");
            sm.LoadContent(Content);
        }

        // Update
        public void Update(GameTime gameTime)
        {
            // Get keyboard state
            KeyboardState keyState = Keyboard.GetState();

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
            if (selection > 2)
            {
                selection = 2;
            }

            if (selection < 1)
            {
                selection = 1;
            }
            #endregion

            // Perform actions for selections
            #region
            if (keyState.IsKeyDown(Keys.Enter) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                switch (selection)
                {
                    case 1:
                        {
                            pauseVal = 1;
                            break;
                        }

                    case 2:
                        {
                            pauseVal = 2;                            
                            break;
                        }
                }
            }
            #endregion
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
                        spriteBatch.Draw(resumeTexture, Vector2.Zero, Color.White);
                        break;
                    }

                // DRAWING FOR SELECTION = 2
                case 2:
                    {
                        spriteBatch.Draw(quitTexture, Vector2.Zero, Color.White);
                        break;
                    }                
            }
        }
    }
}
