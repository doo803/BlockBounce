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
    public class BaseLevel
    {
        public Texture2D endAreaTexture;
        public int timer, initialTimer;
        public int currentLevel;
        public Rectangle endArea;
        public bool hasHitSpike, isColliding, isOnConveyor;
        public Player p;
        public SoundManager sm = new SoundManager();
        public List<Platform> platformList = new List<Platform>();
        public List<Spikes> spikeList = new List<Spikes>();
        public List<MovingSpike> movingSpikeList = new List<MovingSpike>();
        public List<Conveyor> conveyorList = new List<Conveyor>();
        public Vector2 startPos;
        
        // Constructor
        public BaseLevel()
        {
            hasHitSpike = false;
            timer = 0;
            initialTimer = 0;
        }

        // Load Content
        public virtual void LoadContent(ContentManager Content)
        {
            sm.LoadContent(Content);
            endAreaTexture = Content.Load<Texture2D>("level/redpixel");

            // **CHANGE THE VECTOR2 PER LEVEL
            p = new Player(Content.Load<Texture2D>("player/playertexture"), startPos);
        }

        // Update
        public virtual void Update(GameTime gameTime)
        {
            foreach (Platform plat in platformList)
            #region
            {
                if (p.boundingBox.isOnTopOf(plat.boundingBox))
                {
                    p.velocity.Y = 0;
                    p.hasJumped = false;
                }

                if (p.boundingBox.Y - 20 >= (plat.boundingBox.Y))
                {
                    isColliding = true;
                }

                else if (p.boundingBox.hasHitBottomOf(plat.boundingBox))
                {
                    p.velocity.Y = 0;
                    p.playerPosition.Y += 5;
                    p.hasJumped = true;
                }

                if (p.boundingBox.hasHitLeftOf(plat.boundingBox))
                {
                    if (p.velocity.X >= 1)
                    {
                        p.velocity.X = 0;
                    }
                }

                else if (p.boundingBox.hasHitRightOf(plat.boundingBox))
                {
                    if (p.velocity.X <= 1)
                    {
                        p.velocity.X = 0;
                    }
                }               
            }
            #endregion

            foreach (MovingSpike ms in movingSpikeList)
            #region
            {
                ms.Update(gameTime);
            }
            #endregion

            foreach (Spikes sp in spikeList)
            #region
                if (p.boundingBox.Intersects(sp.boundingBox))
                {
                    p.playerPosition = startPos;
                    p.velocity.Y = 0;
                    hasHitSpike = true;
                }
                #endregion

            foreach (MovingSpike ms in movingSpikeList)
            #region
                if (p.boundingBox.Intersects(ms.boundingBox))
                {
                    p.playerPosition = startPos;
                    p.velocity.Y = 0;
                    hasHitSpike = true;
                }
            #endregion

            foreach (Conveyor c in conveyorList)
            #region
            {
                c.Update(gameTime);
                if (p.boundingBox.isOnTopOf(c.boundingBox))
                {
                    p.velocity.X += c.speedMod;
                }
            }

            
            #endregion

            // Stops sound playing twice if player hits more than 1 spike 
            if (hasHitSpike == true)
            {
                sm.playerDieSound.Play();
                hasHitSpike = false;
            }

            // End position
            if (p.boundingBox.Intersects(endArea))
            {
                currentLevel++;
            }

            p.Update(gameTime);
            PlayerSounds();
        }

        // Draw
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(endAreaTexture, endArea, Color.White);

            foreach (Platform plat in platformList)
            {
                plat.Draw(spriteBatch);
            }

            foreach (Spikes sp in spikeList)
            {
                sp.Draw(spriteBatch);
            }

            foreach (MovingSpike ms in movingSpikeList)
            {
                ms.Draw(spriteBatch);
            }

            foreach (Conveyor c in conveyorList)
            {
                c.Draw(spriteBatch);
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

