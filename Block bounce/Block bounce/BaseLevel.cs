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
        public Texture2D endAreaTexture, bulletLeft, bulletRight, backgroundMain, brokenTexture, check1, check2;
        public int timer, initialTimer, difficulty;
        public int currentLevel, i;
        public Rectangle endArea;
        public bool hasDied, isColliding, isOnConveyor;
        public Player p;
        public DecayingPlatform decayPlat;
        public HUD hud = new HUD();
        public SoundManager sm = new SoundManager();
        public List<Platform> platformList = new List<Platform>();
        public List<MovingPlatform> movingPlatformList = new List<MovingPlatform>();
        public List<CirclePlatform> circlePlatformList = new List<CirclePlatform>();
        public List<DecayingPlatform> decayingPlatformList = new List<DecayingPlatform>();
        public List<PushPlatform> pushPlatformList = new List<PushPlatform>();
        public List<Spikes> spikeList = new List<Spikes>();
        public List<MovingSpike> movingSpikeList = new List<MovingSpike>();
        public List<SpikeRow> spikeRowList = new List<SpikeRow>();
        public List<Pounder> pounderList = new List<Pounder>();
        public List<Conveyor> conveyorList = new List<Conveyor>();
        public List<Shooter> shooterList = new List<Shooter>();
        public List<Bullet> bulletList = new List<Bullet>();
        public List<Checkpoint> checkpointList = new List<Checkpoint>();
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
            //backgroundMain = Content.Load<Texture2D>("level/backgroundmain");
            endAreaTexture = Content.Load<Texture2D>("level/redpixel");
            brokenTexture = Content.Load<Texture2D>("level/platform/brokenTexture");

            check1 = Content.Load<Texture2D>("level/checkpoint/checkpoint1");
            check2 = Content.Load<Texture2D>("level/checkpoint/checkpoint2");

            bulletLeft = Content.Load<Texture2D>("level/shooter/bulletleft");
            bulletRight = Content.Load<Texture2D>("level/shooter/bulletright");

            p = new Player(Content.Load<Texture2D>("player/playertexture"), startPos);

            // Floor
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/900platform10"),
                new Vector2(0, Game1.screenHeight - 10)));
        }

        // Update
        public virtual void Update(GameTime gameTime)
        {
            initialTimer++;

            foreach (Platform plat in platformList)
            #region
            {
                plat.Update(gameTime);
                
                if (p.boundingBox.isOnTopOf(plat.boundingBox) && p.velocity.Y >= 0)
                {
                    p.velocity.Y = 0;
                    p.hasJumped = false;
                }

                else if (p.boundingBox.hasHitBottomOf(plat.boundingBox))
                {
                    p.velocity.Y = 0;
                    p.playerPosition.Y += 5;
                    p.hasJumped = true;
                }

                if (p.boundingBox.Y - 20 >= (plat.boundingBox.Y))
                {
                    isColliding = true;
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

            foreach (DecayingPlatform dplat in decayingPlatformList)
            #region
            {
                dplat.Update(gameTime);

                if (p.boundingBox.isOnTopOf(dplat.boundingBox))
                {
                    dplat.beginDecay = true;
                }

                if (dplat.decaying == 2)
                {
                    dplat.boundingBox = new Rectangle(0, 0, 0, 0);
                }

                if (p.boundingBox.isOnTopOf(dplat.boundingBox))
                {
                    p.velocity.Y = 0;
                    p.hasJumped = false;
                }               

                else if (p.boundingBox.hasHitBottomOf(dplat.boundingBox))
                {
                    p.velocity.Y = 0;
                    p.playerPosition.Y += 5;
                    p.hasJumped = true;
                }

                if (p.boundingBox.hasHitLeftOf(dplat.boundingBox))
                {
                    if (p.velocity.X >= 1)
                    {
                        p.velocity.X = 0;
                    }
                }

                else if (p.boundingBox.hasHitRightOf(dplat.boundingBox))
                {
                    if (p.velocity.X <= 1)
                    {
                        p.velocity.X = 0;
                    }
                }
            }
            #endregion

            foreach (CirclePlatform cplat in circlePlatformList)
            #region
            {
                cplat.Update(gameTime);
            }
            #endregion

            foreach (PushPlatform pushPlat in pushPlatformList)
            #region
            {
                pushPlat.Update(gameTime);

                // Move the platform when pushed by player
                if (p.boundingBox.hasHitLeftOf(pushPlat.boundingBox) && p.velocity.X > 0 ||
                    p.boundingBox.hasHitRightOf(pushPlat.boundingBox) && p.velocity.X < 0)
                {
                    pushPlat.velocity.X = p.velocity.X;
                }

                else
                {
                    pushPlat.velocity.X = 0;
                }

                // Stop the platform from going off the screen 

                if (pushPlat.position.X <= 0 && pushPlat.velocity.X < 0)
                {
                    pushPlat.velocity.X = 0;

                    if (p.velocity.X < 0 && p.boundingBox.hasHitRightOf(pushPlat.boundingBox))
                    {
                        p.velocity.X = 0;
                    }
                }

                else if (pushPlat.position.X + pushPlat.texture.Width >= Game1.screenWidth)
                {
                    pushPlat.position.X = Game1.screenWidth - pushPlat.texture.Width;

                    if (p.velocity.X > 0 && p.boundingBox.hasHitLeftOf(pushPlat.boundingBox))
                    {
                        p.velocity.X = 0;
                    }
                }

                // Player Collisions
                #region
                if (p.boundingBox.isOnTopOf(pushPlat.boundingBox))
                {
                    p.velocity.Y = 0;
                    p.hasJumped = false;
                }

                else if (p.boundingBox.hasHitBottomOf(pushPlat.boundingBox))
                {
                    p.velocity.Y = 0;
                    p.playerPosition.Y += 5;
                    p.hasJumped = true;
                }

                #endregion
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

            foreach (SpikeRow sprow in spikeRowList)
            #region
                if (p.boundingBox.Intersects(sprow.boundingBox))
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

            foreach (Pounder pound in pounderList)
            #region
            {
                pound.Update(gameTime);

                if (p.boundingBox.Intersects(pound.boundingBoxSpike))
                {
                    p.playerPosition = startPos;
                    p.velocity.Y = 0;
                    hasDied = true;
                }
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
                        bulletList.Add(new Bullet(bulletRight, sh.direction, new Vector2(sh.position.X + sh.texture.Width / 2 - 8, sh.position.Y + sh.texture.Height / 2 - 8)));
                    }

                    else if (sh.direction == "right")
                    {
                        bulletList.Add(new Bullet(bulletLeft, sh.direction, new Vector2(sh.position.X + sh.texture.Width / 2 - 8, sh.position.Y + sh.texture.Height / 2 - 8)));
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

            foreach (Checkpoint check in checkpointList)
            #region
            {
                if(difficulty == 1)
                {
                    check.Update(gameTime);

                    if(p.boundingBox.Intersects(check.boundingBox))
                    {
                        check.activated = true;
                    }

                    if(check.activated)
                    {
                        startPos = new Vector2(check.boundingBox.X, check.boundingBox.Y);
                    }
                }
            }
            #endregion

            if (difficulty == 0)
            {
                string difficultyString = System.IO.File.ReadAllText(@"Difficulty.txt");
                difficulty = Convert.ToInt32(difficultyString);
            }

            // Stops sound playing twice if player hits more than 1 spike 
            if (hasDied == true)
            {
                sm.playerDieSound.Play();
                hasDied = false;
                hud.deathCount += 1;
                p.playerDied = true;
            }

            // End position
            if (p.boundingBox.Intersects(endArea))
            {
                currentLevel++;
            }

            hud.Update(gameTime);
            p.Update(gameTime);
            PlayerSounds();
        }

        // Draw
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(backgroundMain, Vector2.Zero, Color.White);

            spriteBatch.Draw(endAreaTexture, endArea, Color.White);

            foreach (Bullet b in bulletList)
            #region
            {
                b.Draw(spriteBatch);
            }
            #endregion

            foreach (Pounder pound in pounderList)
            #region
            {
                pound.Draw(spriteBatch);
            }
            #endregion

            foreach (Platform plat in platformList)
            #region
            {
                plat.Draw(spriteBatch);
            }
            #endregion

            foreach (MovingPlatform mplat in movingPlatformList)
            #region
            {
                mplat.Draw(spriteBatch);
            }
            #endregion

            foreach (DecayingPlatform dplat in decayingPlatformList)
            #region
            {
                dplat.Draw(spriteBatch);
                // Also draw brokenTexture
                spriteBatch.Draw(brokenTexture, dplat.position, dplat.boundingBox, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            }
            #endregion

            foreach (CirclePlatform cplat in circlePlatformList)
            #region
            {
                cplat.Draw(spriteBatch);
            }
            #endregion

            foreach (PushPlatform pushPlat in pushPlatformList)
            #region
            {
                pushPlat.Draw(spriteBatch);
            }
            #endregion

            foreach (Spikes sp in spikeList)
            #region
            {
                sp.Draw(spriteBatch);
            }
            #endregion

            foreach (MovingSpike ms in movingSpikeList)
            #region
            {
                ms.Draw(spriteBatch);
            }
            #endregion

            foreach (SpikeRow sprow in spikeRowList)
            #region
            {
                sprow.Draw(spriteBatch);
            }
            #endregion

            foreach (Conveyor c in conveyorList)
            #region
            {
                c.Draw(spriteBatch);
            }
            #endregion
            
            foreach (Shooter sh in shooterList)
            #region
            {
                sh.Draw(spriteBatch);
            }
            #endregion

            foreach (Checkpoint check in checkpointList)
            #region
            {
                if(hud.difficulty == 1 || difficulty == 1)
                {
                    if(check.activated)
                    {
                        spriteBatch.Draw(check1, check.boundingBox, Color.White);
                    }

                    else if (!check.activated)
                    {
                        spriteBatch.Draw(check2, check.boundingBox, Color.White);
                    }
                }
            }
            #endregion

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

        }
    }
}

