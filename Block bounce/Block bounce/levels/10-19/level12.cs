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
    public class level12 : BaseLevel
    {
        Texture2D texture;

        public level12()
        {
            startPos = new Vector2(0, Game1.screenHeight - 30);
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            currentLevel = 12;

            endArea = new Rectangle(880, Game1.screenHeight - 30, 20, 20);

            texture = Content.Load<Texture2D>("level/12/background");

            #endregion

            // Begin level design
            #region
            // Decaying platforms
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(0, Game1.screenHeight - 70), 
                3, 60));

            // First layer 
            #region
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(200, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(220, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(240, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(260, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(280, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(300, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(320, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(340, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(360, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(380, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(400, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(420, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(440, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(460, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(480, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(500, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(520, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(540, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(560, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(580, Game1.screenHeight - 130),
                3, 60));
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(600, Game1.screenHeight - 130),
                3, 60));

            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(700, Game1.screenHeight - 190),
                3, 60));
            #endregion

            // Second layer 
            #region
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(200, Game1.screenHeight - 270),
                3, 60));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(250, Game1.screenHeight - 270)));

            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(300, Game1.screenHeight - 270),
                3, 60));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(350, Game1.screenHeight - 270)));

            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(400, Game1.screenHeight - 270),
                3, 60));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(450, Game1.screenHeight - 270)));

            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(500, Game1.screenHeight - 270),
                3, 60));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(550, Game1.screenHeight - 270)));

            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(600, Game1.screenHeight - 270),
                3, 60));

            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(100, Game1.screenHeight - 340),
                3, 60));

            #endregion

            // Third layer
            #region
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(200, Game1.screenHeight - 410),
                3, 60));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(250, Game1.screenHeight - 410)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(300, Game1.screenHeight - 410)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(350, Game1.screenHeight - 410)));

            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(400, Game1.screenHeight - 410),
                3, 60));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(450, Game1.screenHeight - 410)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(500, Game1.screenHeight - 410)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(550, Game1.screenHeight - 410)));

            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(600, Game1.screenHeight - 410),
                3, 60));

            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(700, Game1.screenHeight - 480),
                3, 60));
            #endregion

            // Spikes on fall
            #region
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(790, Game1.screenHeight - 480)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(790, Game1.screenHeight - 450)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(825, Game1.screenHeight - 450)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(790, Game1.screenHeight - 420)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(870, Game1.screenHeight - 330)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(835, Game1.screenHeight - 300)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(870, Game1.screenHeight - 300)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(870, Game1.screenHeight - 270)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(790, Game1.screenHeight - 180)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(790, Game1.screenHeight - 150)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(825, Game1.screenHeight - 150)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(790, Game1.screenHeight - 120)));

            #endregion

            // Wall
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/20platform600"), new Vector2(758, 100)));

            // Spikes
            spikeRowList.Add(new SpikeRow(Content.Load<Texture2D>("level/spike/spike"), new Rectangle(200, Game1.screenHeight - 30, 580, 30)));

            #endregion
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Vector2.Zero, Color.White);
            
            base.Draw(spriteBatch);
        }
    }
}
