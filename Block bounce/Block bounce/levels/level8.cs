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
    public class level8 : BaseLevel
    {
        // Constructor
        public level8()
        {
            startPos = new Vector2(0, 40);
        }

        // Load Content
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            currentLevel = 8;

            endArea = new Rectangle (880, Game1.screenHeight - 30, 20, 20);

            #endregion

            // Begin level design

            // Platforms
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(0, 60)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(0, Game1.screenHeight - 460)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(430, 60)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(400, Game1.screenHeight - 460)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(860, 220)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(100, Game1.screenHeight - 300)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(430, 220)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(500, Game1.screenHeight - 300)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(0, Game1.screenHeight - 140)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(400, Game1.screenHeight - 140)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(430, 380)));


            // Spikes
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(-100, Game1.screenHeight - 485)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(300, Game1.screenHeight - 485)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(300, Game1.screenHeight - 325)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(700, Game1.screenHeight - 325)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(-100, Game1.screenHeight - 165)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(300, Game1.screenHeight - 165)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(200, Game1.screenHeight - 285)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(233, Game1.screenHeight - 285)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(266, Game1.screenHeight - 285)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(600, Game1.screenHeight - 285)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(633, Game1.screenHeight - 285)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(666, Game1.screenHeight - 285)));



            // Conveyors
            conveyorList.Add(new Conveyor(Content.Load<Texture2D>("level/conveyor/100conveyorleft20"), new Vector2(600, Game1.screenHeight - 302), "left"));
            conveyorList.Add(new Conveyor(Content.Load<Texture2D>("level/conveyor/200conveyorleft20"), new Vector2(100, Game1.screenHeight - 302), "left"));

            conveyorList.Add(new Conveyor(Content.Load<Texture2D>("level/conveyor/100conveyorright20"), new Vector2(197, Game1.screenHeight - 142), "right"));
            conveyorList.Add(new Conveyor(Content.Load<Texture2D>("level/conveyor/200conveyorright20"), new Vector2(597, Game1.screenHeight - 142), "right"));

            // Floor
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/900platform10"), new Vector2(0, Game1.screenHeight - 10)));
        }
    }
}
