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
    public class Credits
    {
        public Video video;
        public VideoPlayer player;
        public Texture2D videoTexture;
        public Rectangle screen;

        // Constructor
        public Credits()
        {
            screen = new Rectangle(0, 0, Game1.screenWidth, Game1.screenHeight);
        }

        public void LoadContent(ContentManager Content)
        {
            video = Content.Load<Video>("credits/credits");
            player = new VideoPlayer();
        }

        public void Update(GameTime gameTime)
        {
            if (player.State == MediaState.Stopped)
            {
                player.IsLooped = false;
                player.Play(video);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (player.State != MediaState.Stopped)
                videoTexture = player.GetTexture();

            if (videoTexture != null)
            {
                spriteBatch.Draw(videoTexture, screen, Color.White);

            }
        }
    }
}
