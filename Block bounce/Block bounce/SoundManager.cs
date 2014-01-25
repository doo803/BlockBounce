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
    public class SoundManager
    {
        public SoundEffect jumpSound, click, pauseSound, resumeSound, playerDieSound, shotSound;
        public Song level1Music, menuMusic;
        public int volumeTimer, volumeTimer2;
        public float volume;

        // Constructor
        public SoundManager()
        {
            volume = 0.0f;
            volumeTimer = 0;
            volumeTimer2 = 0;            
        }

        // Load content
        public void LoadContent(ContentManager Content)
        {
            level1Music = Content.Load<Song>("audio/level1music");
            click = Content.Load<SoundEffect>("audio/click");
            pauseSound = Content.Load<SoundEffect>("audio/pausesound");
            resumeSound = Content.Load<SoundEffect>("audio/resumesound");
            jumpSound = Content.Load<SoundEffect>("audio/jump");
            menuMusic = Content.Load<Song>("audio/menumusic");
            playerDieSound = Content.Load<SoundEffect>("audio/playerdie");
            shotSound = Content.Load<SoundEffect>("audio/shot");
        }

        // Update
        public void Update(GameTime gameTime)
        {
            MediaPlayer.Volume = (float)volume;
            //SoundEffect.MasterVolume = (float)volume;

            KeyboardState keyState = Keyboard.GetState();

            // Keep volume within 0.0f to 1.0f range
            #region
            if (volume >= 1.0f)
            {
                volume = 1.0f;
            }

            if (volume <= 0f)
            {
                volume = 0f;
            }
            #endregion

            // Change volume
            #region
            // Up
            if (keyState.IsKeyDown(Keys.PageUp))
            {
                volumeTimer++;

                if (volumeTimer == 1)
                {
                    volume += 0.1f;
                }
            }

            // Down
            if (keyState.IsKeyDown(Keys.PageDown))
            {
                volumeTimer2++;

                if (volumeTimer2 == 1)
                {
                    volume -= 0.1f;
                }
            }

            // Reset volume timers

            if (keyState.IsKeyUp(Keys.PageUp) && keyState.IsKeyUp(Keys.PageDown))
            {
                volumeTimer = 0;
                volumeTimer2 = 0;
            }

            #endregion
        }
    }
}