﻿using System;
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
    // **CHANGE THIS PER LEVEL
    public class level5
    {
        private Texture2D background, endAreaTexture;
        private int timer, initialTimer;
        public int currentLevel;
        private Rectangle endArea;
        private Vector2 startPos;
        private bool hasHitSpike;

        public Player p;
        SoundManager sm = new SoundManager();
        List<Platform> platformList = new List<Platform>();
        List<Spikes> spikeList = new List<Spikes>();
        List<Wall> wallList = new List<Wall>();

        // Constructor
        // **CHANGE THIS PER LEVEL
        public level5()
        {
            // **CHANGE THIS PER LEVEL
            startPos = new Vector2(0, Game1.screenHeight - 30);

            // **CHANGE THIS PER LEVEL
            endArea = new Rectangle(880, Game1.screenHeight - 30, 20, 20);

            // **CHANGE THIS PER LEVEL
            currentLevel = 5;

            hasHitSpike = false;
            timer = 0;
            initialTimer = 0;
        }

        // Load Content
        public void LoadContent(ContentManager Content)
        {
            // **CHANGE THIS PER LEVEL -- IF USING NON-DEFAULT BACKGROUND
            background = Content.Load<Texture2D>("level/default/background");

            sm.LoadContent(Content);
            endAreaTexture = Content.Load<Texture2D>("level/redpixel");

            // **CHANGE THE VECTOR2 PER LEVEL
            p = new Player(Content.Load<Texture2D>("player/playertexture"), startPos);

            // **CHANGE THESE PER LEVEL
            // Wall
            

            // Platforms   
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(-50, Game1.screenHeight - 105)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(-50, Game1.screenHeight - 205)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(-50, Game1.screenHeight - 305)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(-50, Game1.screenHeight - 405)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(100, Game1.screenHeight - 475)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(300, Game1.screenHeight - 475)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(615, Game1.screenHeight - 425)));

            // Spikes (29x30)
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/wall/80spikewall600"), new Vector2((Game1.screenWidth / 2) - 40, Game1.screenHeight - 350)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/wall/80spikewall600"), new Vector2((Game1.screenWidth / 2) - 40, -520)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2((Game1.screenWidth / 2) - 14.5f, Game1.screenHeight - 375)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2((Game1.screenWidth / 2) - 14.5f, 75)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2((Game1.screenWidth - 95), Game1.screenHeight - 375)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/wall/80spikewall600"), new Vector2((Game1.screenWidth - 120), Game1.screenHeight - 350)));

            // Leave this
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/900platform10"), new Vector2(0, Game1.screenHeight - 10)));

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
            }

            // Reset player to start if hits spike
            foreach (Spikes sp in spikeList)
                if (p.boundingBox.Intersects(sp.boundingBox))
                {
                    p.playerPosition = startPos;
                    p.velocity.Y = 0;
                    hasHitSpike = true;
                }
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
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);

            spriteBatch.Draw(endAreaTexture, endArea, Color.White);

            foreach (Platform plat in platformList)
            {
                plat.Draw(spriteBatch);
            }

            foreach (Spikes sp in spikeList)
            {
                sp.Draw(spriteBatch);
            }

            foreach (Wall w in wallList)
            {
                w.Draw(spriteBatch);
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