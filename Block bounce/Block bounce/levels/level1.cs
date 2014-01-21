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


namespace Block_bounce.levels
{
    public class level1
    {
        private Texture2D background, endAreaTexture;
        private int timer, initialTimer;
        public int currentLevel;
        private Rectangle endArea;

        public Player p;
        SoundManager sm = new SoundManager();
        List<Platform> platformList = new List<Platform>();
        
        // Constructor
        public level1()
        {
            timer = 0;
            initialTimer = 0;
            endArea = new Rectangle(880, Game1.screenHeight - 385, 20, 40);
        }

        // Load Content
        public void LoadContent(ContentManager Content)
        {
            currentLevel = 1;
            endAreaTexture = Content.Load<Texture2D>("level/redpixel");
            background = Content.Load<Texture2D>("level/1/background");
            p = new Player(Content.Load<Texture2D>("player/playertexture"), new Vector2(10, Game1.screenHeight - 30));            
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/900platform10"), new Vector2(0, Game1.screenHeight - 10)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(200, Game1.screenHeight - 95)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(400, Game1.screenHeight - 185)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(600, Game1.screenHeight - 275)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(800, Game1.screenHeight - 365)));
            sm.LoadContent(Content);
        }

        // Update
        public void Update(GameTime gameTime)
        {
            foreach (Platform plat in platformList)
            {
                if (p.boundingBox.isOnTopOf(plat.boundingBox))
                {
                    p.velocity.Y = 0f;
                    p.hasJumped = false;
                }

                else if (p.boundingBox.hasHitBottomOf(plat.boundingBox))
                {
                    p.velocity.Y = 0;
                    p.playerPosition.Y += 5;
                    p.hasJumped = true;
                }

                if (p.boundingBox.hasHitLeftOf(plat.boundingBox))
                {
                    p.velocity.X = 0;
                    p.playerPosition.X -= 1;
                }
            }

            // End position
            if (p.boundingBox.Intersects(endArea))
            {
                currentLevel = 2;
            }

            p.Update(gameTime);
            PlayerSounds();
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);

            spriteBatch.Draw(endAreaTexture, endArea, Color.White);

            foreach (Platform plat in platformList)
            {
                plat.Draw(spriteBatch);
            }

            p.Draw(spriteBatch);
        }

        // Player sounds
        public void PlayerSounds()
        {
            initialTimer++;

            // Jump sound
            if (p.hasJumped == true && initialTimer >= 5) // Stops sound from playing within the first 5 frames of game loading
            {
                timer++;
                if (timer == 1)
                {
                    sm.jumpSound.Play();
                }
            }

            else if (p.hasJumped == false)
            {
                timer = 0;
            }

            // Keep initialTimer from going over 20
            if (initialTimer >= 20)
            {
                initialTimer = 20;
            }
        }
    }
}
