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
    public class DifficultySelect
    {
<<<<<<< HEAD
        // Constructor
        public DifficultySelect()
        {
        
=======
        public Texture2D texture, box1, box2, box3, box4;
        public int selection, keyPress, menuVal, enterReset, difficulty;

        // Instantiate sound manager
        SoundManager sm = new SoundManager();

        // Constructor
        public DifficultySelect()
        {
            selection = 1;
            keyPress = 0;
            enterReset = 0;
>>>>>>> 87133217f72bb31c7f91a51829ccc8565590b739
        }

        // Load Content
        public void LoadContent(ContentManager Content)
        {
<<<<<<< HEAD
            
=======
            sm.LoadContent(Content);
            texture = Content.Load<Texture2D>("difficulty/difftexture");
            box1 = Content.Load<Texture2D>("difficulty/sel1");
            box2 = Content.Load<Texture2D>("difficulty/sel2");
            box3 = Content.Load<Texture2D>("difficulty/sel3");
            box4 = Content.Load<Texture2D>("difficulty/sel4");
>>>>>>> 87133217f72bb31c7f91a51829ccc8565590b739
        }

        // Update
        public void Update(GameTime gameTime)
        {
<<<<<<< HEAD
        
=======
            // Get keyboard state
            KeyboardState keyState = Keyboard.GetState();

            // Keep selection within a 1-4 range
            #region
            if (selection >= 4)
            {
                selection = 4;
            }

            if (selection <= 1)
            {
                selection = 1;
            }
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

                    case 4:
                        {
                            menuVal = 4;
                            break;
                        }
                }
            }
            #endregion
>>>>>>> 87133217f72bb31c7f91a51829ccc8565590b739
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
<<<<<<< HEAD
        
=======
            spriteBatch.Draw(texture, Vector2.Zero, Color.White);

            switch (selection)
            #region
            {
                case 1:
                    {
                        spriteBatch.Draw(box1, Vector2.Zero, Color.White);
                        break;
                    }

                case 2:
                    {
                        spriteBatch.Draw(box2, Vector2.Zero, Color.White);
                        break;
                    }

                case 3:
                    {
                        spriteBatch.Draw(box3, Vector2.Zero, Color.White);
                        break;
                    }

                case 4:
                    {
                        spriteBatch.Draw(box4, Vector2.Zero, Color.White);
                        break;
                    }
            }
            #endregion
>>>>>>> 87133217f72bb31c7f91a51829ccc8565590b739
        }
    }
}
