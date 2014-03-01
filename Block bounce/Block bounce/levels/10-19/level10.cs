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
    public class level10 : BaseLevel
    {
        public level10()
        {
            startPos = new Vector2(0, 40);
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            currentLevel = 10;

            endArea = new Rectangle(880, Game1.screenHeight - 30, 20, 20);

            #endregion

            // Begin level design
            #region
            // Top level

            // Platforms
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(0, 60)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(0, 260)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(400, 260)));

            // Moving platforms
            movingPlatformList.Add(new MovingPlatform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(800, 140), 0, 4, 
                new Vector2 (40, 0), new Vector2(700, 0), new Vector2(0, 140), new Vector2(0, 140)));
            
            // Checkpoint
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(880, 140)));
            checkpointList.Add(new Checkpoint(new Vector2(880, 120)));

            // Spikes
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(200, 110)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(400, 110)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(600, 110)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(102, 40)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(302, 40)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(502, 40)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(702, 40)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(0, 240)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(290, 240)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(580, 240)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(609, 240)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(638, 240)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(667, 240)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(696, 240)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(725, 240)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(754, 240)));

            // Bottom level

            // Platforms
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(100, 500)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(500, 500)));

            // Moving platforms
            movingPlatformList.Add(new MovingPlatform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(400, 420), 0, 4,
                new Vector2(140, 0), new Vector2(800, 0), new Vector2(0, 420), new Vector2(0, 420)));

            // Spikes
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(300, 390)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(500, 390)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(700, 390)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(202, 320)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(402, 320)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(602, 320)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(802, 320)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(100, 480)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(390, 480)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(680, 480)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(709, 480)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(738, 480)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(767, 480)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(796, 480)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(825, 480)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(854, 480)));

            #endregion

        }
    }
}
