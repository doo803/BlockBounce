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
    public class level13 : BaseLevel
    {
        public level13()
        {
            startPos = new Vector2(0, 560);
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            currentLevel = 13;

            endArea = new Rectangle(880, Game1.screenHeight - 40, 20, 20);

            #endregion

            // Begin level design
            #region
            // Spike
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(150, 470)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(210, 560)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(270, 470)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(330, 560)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(390, 470)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(490, 470)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(550, 560)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(610, 470)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(670, 560)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(300, 440)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(260, 370)));


            // Upper level
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(200, 340)));
            

            // Wall
            platformList.Add(new Platform(Content.Load<Texture2D>("level/wall/20wall600"), new Vector2(800, 100)));

            // Conveyor
            conveyorList.Add(new Conveyor(Content.Load<Texture2D>("level/conveyor/200conveyorleft20"), new Vector2(480, 580), "left"));
            conveyorList.Add(new Conveyor(Content.Load<Texture2D>("level/conveyor/100conveyorleft20"), new Vector2(680, 580), "left"));

            conveyorList.Add(new Conveyor(Content.Load<Texture2D>("level/conveyor/100conveyorleft20"), new Vector2(285, 458), "left"));

            // Shooter 
            shooterList.Add(new Shooter(Content.Load<Texture2D>("level/shooter/shooterleft"), new Vector2(775, 560),
                "left", 60));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(795, 560)));

            shooterList.Add(new Shooter(Content.Load<Texture2D>("level/shooter/shooterleft"), new Vector2(440, 560),
                "left", 60));

            // Pounder
            pounderList.Add(new Pounder(Content.Load<Texture2D>("level/pounder/pounder"), new Vector2(640, 376), 2, 12));
            pounderList.Add(new Pounder(Content.Load<Texture2D>("level/pounder/pounder"), new Vector2(600, 376), 2, 10));
            pounderList.Add(new Pounder(Content.Load<Texture2D>("level/pounder/pounder"), new Vector2(560, 376), 2, 8));
            pounderList.Add(new Pounder(Content.Load<Texture2D>("level/pounder/pounder"), new Vector2(520, 376), 2, 6));
            pounderList.Add(new Pounder(Content.Load<Texture2D>("level/pounder/pounder"), new Vector2(480, 376), 2, 4));
            pounderList.Add(new Pounder(Content.Load<Texture2D>("level/pounder/pounder"), new Vector2(440, 376), 2, 2));
            pounderList.Add(new Pounder(Content.Load<Texture2D>("level/pounder/pounder"), new Vector2(400, 376), 2, 0));

            // Platform
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(100, 560)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/900platform10"), new Vector2(0, 580)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/700platform20"), new Vector2(0, 460)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/700platform20"), new Vector2(100, 360)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/700platform20"), new Vector2(0, 260)));

            // Rising spike
            //risingSpikeList.Add(new RisingSpike(Content.Load<Texture2D>("level/spike/risingspike"), new Vector2(300, 290),
            //    new Vector2(0, 290), new Vector2(0, 320), 2));

            // Checkpoints
            checkpointList.Add(new Checkpoint(new Vector2(775, 540)));
            checkpointList.Add(new Checkpoint(new Vector2(0, 440)));
            
            #endregion
        }
    }
}