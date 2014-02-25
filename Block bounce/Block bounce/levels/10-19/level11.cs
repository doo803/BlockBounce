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
    public class level11 : BaseLevel
    {
        public level11()
        {
            startPos = new Vector2(0, Game1.screenHeight - 30);
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            currentLevel = 11;

            endArea = new Rectangle(880, Game1.screenHeight - 30, 20, 20);

            #endregion

            // Begin level design
            #region
            // Moving platforms
            movingPlatformList.Add(new MovingPlatform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(100, Game1.screenHeight - 70), 2, 0,
                new Vector2(100, 0), new Vector2(100, 0), new Vector2(0, Game1.screenHeight - 70), new Vector2(0, Game1.screenHeight - 500)));

            movingPlatformList.Add(new MovingPlatform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(620, Game1.screenHeight - 500), 0, 2,
                new Vector2(190, 0), new Vector2(620, 0), new Vector2(0, Game1.screenHeight - 500), new Vector2(0, Game1.screenHeight - 500)));

            movingPlatformList.Add(new MovingPlatform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(724, Game1.screenHeight - 500), 2, 0,
                new Vector2(724, 0), new Vector2(724, 0), new Vector2(0, Game1.screenHeight - 70), new Vector2(0, Game1.screenHeight - 500)));

            // Spikes 
            // Floor spikes
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(160, Game1.screenHeight - 30)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(450, Game1.screenHeight - 30)));

            // Spikes as first platform going up       
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(61, Game1.screenHeight - 200)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(139, Game1.screenHeight - 200)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(178, Game1.screenHeight - 200)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(217, Game1.screenHeight - 200)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(61, Game1.screenHeight - 275)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(100, Game1.screenHeight - 275)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(178, Game1.screenHeight - 275)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(217, Game1.screenHeight - 275)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(61, Game1.screenHeight - 350)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(100, Game1.screenHeight - 350)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(139, Game1.screenHeight - 350)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(217, Game1.screenHeight - 350)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(61, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(139, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(178, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(217, Game1.screenHeight - 425)));

            // Spikes to stop player jumping off upper platform
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(256, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(295, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(334, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(373, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(412, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(451, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(490, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(529, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(568, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(607, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(646, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(685, Game1.screenHeight - 425)));

            // Spikes as last platform going down   
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(685, Game1.screenHeight - 200)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(724, Game1.screenHeight - 200)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(763, Game1.screenHeight - 200)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(841, Game1.screenHeight - 200)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(876, Game1.screenHeight - 200)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(685, Game1.screenHeight - 275)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(724, Game1.screenHeight - 275)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(802, Game1.screenHeight - 275)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(843, Game1.screenHeight - 275)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(876, Game1.screenHeight - 275)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(685, Game1.screenHeight - 350)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(763, Game1.screenHeight - 350)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(802, Game1.screenHeight - 350)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(841, Game1.screenHeight - 350)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(876, Game1.screenHeight - 350)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(685, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(724, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(763, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(841, Game1.screenHeight - 425)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/floatingspike"), new Vector2(876, Game1.screenHeight - 425)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(440, 50)));
            checkpointList.Add(new Checkpoint(new Vector2(440, 30)));

            #endregion

        }

    }
}
