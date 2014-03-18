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
    public class level9 : BaseLevel
    {
        Texture2D texture;

        public level9()
        {           
            startPos = new Vector2(0, Game1.screenHeight - 30);
            initStartPos = startPos;
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            currentLevel = 9;

            endArea = new Rectangle(880, 40, 20, 20);

            texture = Content.Load<Texture2D>("level/9/background");

            #endregion

            // Begin level design
            #region

            // Platforms
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(80, Game1.screenHeight - 100)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(200, Game1.screenHeight - 190)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(350, Game1.screenHeight - 190)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(500, Game1.screenHeight - 190)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(650, Game1.screenHeight - 190)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(800, Game1.screenHeight - 190)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(880, Game1.screenHeight - 285)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(400, Game1.screenHeight - 370)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(0, Game1.screenHeight - 370)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/800platform20"), new Vector2(100, Game1.screenHeight - 460)));

            // Spikes           
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(680, Game1.screenHeight - 450)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(650, Game1.screenHeight - 450)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(620, Game1.screenHeight - 450)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(520, Game1.screenHeight - 450)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(490, Game1.screenHeight - 450)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(460, Game1.screenHeight - 450)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(320, Game1.screenHeight - 450)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(290, Game1.screenHeight - 450)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(260, Game1.screenHeight - 450)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(160, Game1.screenHeight - 450)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(130, Game1.screenHeight - 450)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2(100, Game1.screenHeight - 450)));

            // Shooters
            shooterList.Add(new Shooter(Content.Load<Texture2D>("level/shooter/shooterleft"), new Vector2(880, Game1.screenHeight - 210), "left", 90));
            shooterList.Add(new Shooter(Content.Load<Texture2D>("level/shooter/shooterleft"), new Vector2(880, Game1.screenHeight - 235), "left", 90));
            shooterList.Add(new Shooter(Content.Load<Texture2D>("level/shooter/shooterleft"), new Vector2(880, Game1.screenHeight - 260), "left", 90));

            shooterList.Add(new Shooter(Content.Load<Texture2D>("level/shooter/shooterright"), new Vector2(0, Game1.screenHeight - 390), "right", 90));
            shooterList.Add(new Shooter(Content.Load<Texture2D>("level/shooter/shooterright"), new Vector2(400, Game1.screenHeight - 390), "right", 90));

            // Conveyors
            conveyorList.Add(new Conveyor(Content.Load<Texture2D>("level/conveyor/800conveyorleft20"), new Vector2(0, Game1.screenHeight - 372), "left"));

            // Checkpoints
            checkpointList.Add(new Checkpoint(new Vector2(880, 294)));

            #endregion

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Vector2.Zero, Color.White);
            base.Draw(spriteBatch);
        }

    }
}
