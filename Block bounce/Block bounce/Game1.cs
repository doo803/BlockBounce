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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // Screen dimension
        public static int screenHeight = 600;
        public static int screenWidth = 900;
        public int difficulty;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // State enum
        public enum State
        { 
            Menu,
<<<<<<< HEAD
            DifficultySelect,
=======
            Difficulty,
>>>>>>> 87133217f72bb31c7f91a51829ccc8565590b739
            Playing,
            Pause,
            Credits,
        }

        // Set first state
        State gameState = State.Menu;

        // Instantiate objects
        Playing play = new Playing();
        Menu menu = new Menu();
        Pause pause = new Pause();
        Credits credits = new Credits();
        SoundManager sm = new SoundManager();
        HUD hud = new HUD();
        DifficultySelect diff = new DifficultySelect();

        public Game1()
        {           
            graphics = new GraphicsDeviceManager(this);
            this.Window.Title = "Block bounce";
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.PreferredBackBufferWidth = screenWidth;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load content from play
            play.LoadContent(Content);

            // Load content from menu
            menu.LoadContent(Content);

            // Load content from pause
            pause.LoadContent(Content);

            // Load content from difficultySelect
            diff.LoadContent(Content);

            // Load content from credits
            credits.LoadContent(Content);

            // Load content from soundmanager
            sm.LoadContent(Content);

            // Load content from HUD
            hud.LoadContent(Content);


        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            // Makes mouse visible
            IsMouseVisible = true;

            hud.difficulty = difficulty;

            hud.Update(gameTime);

            KeyboardState keyState = Keyboard.GetState();

            switch (gameState)
            {
                // UPDATE MENU STATE
                case State.Menu:
                    #region
                    {
                        
                        menu.Update(gameTime);

                        if (menu.menuVal == 1)
                        {
<<<<<<< HEAD
                            gameState = State.DifficultySelect;
=======
                            gameState = State.Difficulty;
>>>>>>> 87133217f72bb31c7f91a51829ccc8565590b739

                            // Stop menu music
                            MediaPlayer.Stop();
                            menu.songBegin = 0;
                            
                            // Play background music
                            MediaPlayer.Play(sm.level1Music);
                            MediaPlayer.IsRepeating = true;
                        }

                        if (menu.menuVal == 2)
                        {
                            // Stop menu music
                            MediaPlayer.Stop();
                            menu.songBegin = 0;

                            gameState = State.Credits;
                        }

                        if (menu.menuVal == 3)
                        {
                            // Stop menu music
                            MediaPlayer.Stop();
                            menu.songBegin = 0;

                            this.Exit();
                        }

                        break;
                    }
                    #endregion

<<<<<<< HEAD
                // UPDATE DIFFICULTYSELECT STATE
                case State.DifficultySelect:
                    #region
                    {

                        break;
                    }
                    #endregion

                // UPDATE PLAYING STATE
=======
                case State.Difficulty:
                    #region
                    {
                        diff.Update(gameTime);

                        switch (diff.menuVal)
                        { 
                            case 1:
                            {
                                difficulty = 1;
                                gameState = State.Playing;
                                diff.menuVal = 0;

                                // Begin HUD timer from 0
                                hud.ticks = 0;
                                hud.secondsTaken = 0;
                                hud.minutesTaken = 0;

                                break;
                            }

                            case 2:
                            {
                                difficulty = 2;
                                gameState = State.Playing;
                                diff.menuVal = 0;

                                // Begin HUD timer from 0
                                hud.ticks = 0;
                                hud.secondsTaken = 0;
                                hud.minutesTaken = 0;

                                break;
                            }

                            case 3:
                            {
                                difficulty = 3;
                                gameState = State.Playing;
                                diff.menuVal = 0;

                                // Begin HUD timer from 0
                                hud.ticks = 0;
                                hud.secondsTaken = 0;
                                hud.minutesTaken = 0;

                                break;
                            }

                            case 4:
                            {
                                difficulty = 4;
                                gameState = State.Playing;
                                diff.menuVal = 0;

                                // Begin HUD timer from 0
                                hud.ticks = 0;
                                hud.secondsTaken = 0;
                                hud.minutesTaken = 0;

                                break;
                            }
                        }
                        
                        break;
                    }
                    #endregion 

>>>>>>> 87133217f72bb31c7f91a51829ccc8565590b739
                case State.Playing:
                    #region
                    {
                        // Update Playing class
                        play.Update(gameTime);

                        // Open pause screen
                        if (keyState.IsKeyDown(Keys.Escape) || GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
                        {
                            gameState = State.Pause;
                            pause.pauseVal = 0;
                            MediaPlayer.Pause();
                            sm.pauseSound.Play();
                        }

                        if (play.playerIsAlive == false)
                        {
                            hud.deathCount++;
                        }
                 
                        break;
                    }
                    #endregion                

                // UPDATE PAUSE STATE
                case State.Pause:
                    #region
                    {
                        pause.Update(gameTime);

                        if (pause.pauseVal == 1)
                        {
                            gameState = State.Playing;
                            pause.pauseVal = 0;
                            sm.resumeSound.Play();
                            MediaPlayer.Resume();
                        }

                        if (pause.pauseVal == 2)
                        {
                            gameState = State.Menu;
                            pause.pauseVal = 0;
                            menu.menuVal = 0;
                            menu.enterReset = 0; // Removes problem with enter held down instantly selecting option in menu screen
                            play.playerPosition = new Vector2(10, Game1.screenHeight - 25);
                            pause.selection = 1;
                            MediaPlayer.Stop();
                            play.playerIsAlive = true;
                        }

                        break;
                    }
                    #endregion

                // UPDATE CREDITS STATE
                case State.Credits:
                    #region
                    {
                        credits.Update(gameTime);

                        if (keyState.IsKeyDown(Keys.Escape))
                        {
                            credits.player.Stop();
                            gameState = State.Menu;
                            menu.menuVal = 0;
                            menu.enterReset = 0; // Removes problem with enter held down instantly selecting option in menu screen
                        }

                        break;
                    }
                    #endregion

            }

            base.Update(gameTime);           
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearWrap,
                DepthStencilState.Default, RasterizerState.CullNone);

            base.Draw(gameTime);
           
            switch (gameState)
            {
                // DRAWING MENU STATE   
                #region
                case State.Menu:
                    {
                        menu.Draw(spriteBatch);
                        break;
                    }
                #endregion

<<<<<<< HEAD
                // DRAWING DRAW STATE
                case State.DifficultySelect:
                    #region
                    {
                        break;
                    }
                    #endregion
=======
                // DRAWING DIFFICULTY STATE
                #region
                case State.Difficulty:
                    {
                        diff.Draw(spriteBatch);
                        break;
                    }
                #endregion
>>>>>>> 87133217f72bb31c7f91a51829ccc8565590b739

                // DRAWING PLAYING STATE
                #region
                case State.Playing:
                    {
                        // Draw from playing
                        play.Draw(spriteBatch);

                        // Draw from hud
                        hud.Draw(spriteBatch);

                        
                        break;
                    }
                #endregion

                // DRAWING PAUSE STATE
                #region
                case State.Pause:
                    {
                        // Draw from pause class
                        pause.Draw(spriteBatch);

                        break;
                    }
                #endregion

                // DRAWING CREDITS STATE
                #region
                case State.Credits:
                    {
                        credits.Draw(spriteBatch);
                        break;
                    }
                #endregion
            }
            spriteBatch.End();
            
        }
    }
}

static class RectangleHelper
{
    const int penetrationMargin = 5;
    public static bool isOnTopOf(this Rectangle r1, Rectangle r2)
    {
        return (r1.Bottom >= r2.Top - penetrationMargin &&
            r1.Bottom <= r2.Top  &&
            r1.Right >= r2.Left  &&
            r1.Left <= r2.Right );
    }

    public static bool hasHitBottomOf(this Rectangle r1, Rectangle r2)
    {
        return (r1.Top >= r2.Bottom - 10 &&
            r1.Top <= r2.Bottom &&
            r1.Right >= r2.Left &&
            r1.Left <= r2.Right);
    }

    public static bool hasHitLeftOf(this Rectangle r1, Rectangle r2)
    {
        return (r1.Right >= r2.Left - 5 &&
            r1.Right <= r2.Left &&
            r1.Bottom >= r2.Top &&
            r1.Top <= r2.Bottom);
    }

    public static bool hasHitRightOf(this Rectangle r1, Rectangle r2)
    {
        return (r1.Left >= r2.Right - 5 &&
            r1.Left <= r2.Right &&
            r1.Bottom >= r2.Top &&
            r1.Top <= r2.Bottom);
    }
}
