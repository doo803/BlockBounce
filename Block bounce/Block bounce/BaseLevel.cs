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
        public Texture2D endAreaTexture, bulletLeft, bulletRight;
        public int timer, initialTimer;
        public int currentLevel, i;
        public Rectangle endArea;
        public bool hasDied, isColliding, isOnConveyor;
        public Player p;
        public HUD hud = new HUD();
        public SoundManager sm = new SoundManager();
        public List<Platform> platformList = new List<Platform>();
        public List<MovingPlatform> movingPlatformList = new List<MovingPlatform>();
        public List<Spikes> spikeList = new List<Spikes>();
        public List<MovingSpike> movingSpikeList = new List<MovingSpike>();
        public List<Conveyor> conveyorList = new List<Conveyor>();
        public List<Shooter> shooterList = new List<Shooter>();
        public List<Bullet> bulletList = new List<Bullet>();
        public Vector2 startPos;
        
        // Constructor
        public BaseLevel()
        {
            hasDied = false;
            timer = 0;
            initialTimer = 0;
            i = 0;
        }

        // Load Content
        public virtual void LoadContent(ContentManager Content)
        {
            sm.LoadContent(Content);
            endAreaTexture = Content.Load<Texture2D>("level/redpixel");

            bulletLeft = Content.Load<Texture2D>("level/shooter/bulletleft");
            bulletRight = Content.Load<Texture2D>("level/shooter/bulletright");

            // **CHANGE THE VECTOR2 PER LEVEL
            p = new Player(Content.Load<Texture2D>("player/playertexture"), startPos);

            // Floor
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/900platform10"), new Vector2(0, Game1.screenHeight - 10)));
        }

        // Update
        public virtual void Update(GameTime gameTime)
        {
            initialTimer++;

            foreach (Platform plat in platformList)
            #region
            {
                
                if (p.boundingBox.isOnTopOf(plat.boundingBox) && p.velocity.Y >= 0)
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

            foreach (MovingPlatform mplat in movingPlatformList)
            #region
            {
                mplat.Update(gameTime);

                if (p.boundingBox.isOnTopOf(mplat.boundingBox))
                {
                    p.velocity.Y = 0;
                    p.hasJumped = false;
                }

                if (p.boundingBox.Y - 20 >= (mplat.boundingBox.Y))
                {
                    isColliding = true;
                }

                else if (p.boundingBox.hasHitBottomOf(mplat.boundingBox))
                {
                    p.velocity.Y = 0;
                    p.playerPosition.Y += 5;
                    p.hasJumped = true;
                }

                if (p.boundingBox.hasHitLeftOf(mplat.boundingBox))
                {
                    if (p.velocity.X >= 1)
                    {
                        p.velocity.X = 0;
                    }
                }

                else if (p.boundingBox.hasHitRightOf(mplat.boundingBox))
                {
                    if (p.velocity.X <= 1)
                    {
                        p.velocity.X = 0;
                    }
                }

                // Move player with platform
                if (p.boundingBox.Intersects(mplat.boundingBox) || p.boundingBox.isOnTopOf(mplat.boundingBox))
                {
                    if (mplat.movingLeft == true)
                    {
                        p.velocity.X -= mplat.playerSpeedModHor;
                    }

                    else if (mplat.movingRight == true)
                    {
                        p.velocity.X += mplat.playerSpeedModHor;
                    }

                    if (mplat.movingUp == true)
                    {
                        p.velocity.Y -= mplat.playerSpeedModVert;
                    }

                    else if (mplat.movingDown == true)
                    {
                        p.velocity.Y += mplat.playerSpeedModVert;
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
                    hasDied = true;
                }
                #endregion

            foreach (MovingSpike ms in movingSpikeList)
            #region
                if (p.boundingBox.Intersects(ms.boundingBox))
                {
                    p.playerPosition = startPos;
                    p.velocity.Y = 0;
                    hasDied = true;
                }
            #endregion

            foreach (Conveyor c in conveyorList)
            #region
            {
                c.Update(gameTime);
                if (p.boundingBox.isOnTopOf(c.boundingBox) || p.boundingBox.Intersects(c.boundingBox))
                {
                    p.velocity.X += c.speedMod;
                }
            }

            
            #endregion

            foreach (Shooter sh in shooterList)
            #region
            {
                sh.Update(gameTime);

                if (sh.makeBullet == true)
                {
                    //sm.shotSound.Play();

                    if (sh.direction == "left")
                    {
                        bulletList.Add(new Bullet(bulletLeft, sh.direction, new Vector2(sh.position.X + sh.texture.Width / 2 - 4, sh.position.Y + sh.texture.Height / 2 - 3)));
                    }

                    else if (sh.direction == "right")
                    {
                        bulletList.Add(new Bullet(bulletRight, sh.direction, new Vector2(sh.position.X + sh.texture.Width / 2 - 4, sh.position.Y + sh.texture.Height / 2 - 3)));
                    }

                    sh.makeBullet = false;
                }

                // Remove bullets
                for (int i = 0; i < bulletList.Count; i++)
                {
                    if (!bulletList[i].isVisible)
                    {
                        bulletList.RemoveAt(i);
                        i--;
                    }
                }

                if (p.boundingBox.isOnTopOf(sh.boundingBox))
                {
                    p.velocity.Y = 0;
                    p.hasJumped = false;
                }

                if (p.boundingBox.Y - 20 >= (sh.boundingBox.Y))
                {
                    isColliding = true;
                }

                else if (p.boundingBox.hasHitBottomOf(sh.boundingBox))
                {
                    p.velocity.Y = 0;
                    p.playerPosition.Y += 5;
                    p.hasJumped = true;
                }

                if (p.boundingBox.hasHitLeftOf(sh.boundingBox))
                {
                    if (p.velocity.X >= 1)
                    {
                        p.velocity.X = 0;
                    }
                }

                else if (p.boundingBox.hasHitRightOf(sh.boundingBox))
                {
                    if (p.velocity.X <= 1)
                    {
                        p.velocity.X = 0;
                    }
                }
               
            }
            #endregion

            foreach (Bullet b in bulletList)
            #region
            {
                b.Update(gameTime);

                if (p.boundingBox.Intersects(b.boundingBox))
                {
                    p.playerPosition = startPos;
                    p.velocity.Y = 0;
                    hasDied = true;
                }

                foreach (Platform plat in platformList)
                {
                    if (b.boundingBox.Intersects(plat.boundingBox))
                    {
                        b.isVisible = false;
                    }
                }

                foreach (Shooter sh in shooterList)
                {
                    if (b.boundingBox.hasHitLeftOf(sh.boundingBox) && sh.direction == "right")
                    {
                        b.isVisible = false;
                    }

                    if (b.boundingBox.hasHitRightOf(sh.boundingBox) && sh.direction == "left")
                    {
                        b.isVisible = false;
                    }                
                }
            }
            #endregion

            // Stops sound playing twice if player hits more than 1 spike 
            if (hasDied == true)
            {
                sm.playerDieSound.Play();
                hasDied = false;
                hud.deathCount += 1;
                p.playerDied = true;
            }

            hud.Update(gameTime);

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

            foreach (MovingPlatform mplat in movingPlatformList)
            {
                mplat.Draw(spriteBatch);
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

            foreach (Shooter sh in shooterList)
            {
                sh.Draw(spriteBatch);
            }

            foreach (Bullet b in bulletList)
            {
                b.Draw(spriteBatch);
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

