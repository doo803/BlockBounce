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
    public class level7 : BaseLevel
    {
        Texture2D texture;
                                       
        // Constructor
        public level7()
        {
            startPos = new Vector2(0, Game1.screenHeight - 30);
        }

        // Load Content
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            currentLevel = 7;

            endArea = new Rectangle(880, 20, 20, 20);

            texture = Content.Load<Texture2D>("level/7/background");

            #endregion

            // Begin level design
            #region
            // Platforms
            #region
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(100, Game1.screenHeight - 100)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(500, Game1.screenHeight - 100)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(100, Game1.screenHeight - 170)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(300, Game1.screenHeight - 170)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(500, Game1.screenHeight - 170)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(700, Game1.screenHeight - 170)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(0, Game1.screenHeight - 190)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(400, Game1.screenHeight - 190)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(160, Game1.screenHeight - 260)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(360, Game1.screenHeight - 260)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(560, Game1.screenHeight - 260)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(760, Game1.screenHeight - 260)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(100, Game1.screenHeight - 280)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(500, Game1.screenHeight - 280)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(100, Game1.screenHeight - 350)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(300, Game1.screenHeight - 350)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(500, Game1.screenHeight - 350)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(700, Game1.screenHeight - 350)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(0, Game1.screenHeight - 370)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(400, Game1.screenHeight - 370)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(160, Game1.screenHeight - 440)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(360, Game1.screenHeight - 440)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(560, Game1.screenHeight - 440)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(760, Game1.screenHeight - 440)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(100, Game1.screenHeight - 460)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(500, Game1.screenHeight - 460)));

            #endregion

            // Checkpoints
            #region
            checkpointList.Add(new Checkpoint(new Vector2(0, 300)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(0, 320)));
            #endregion

            // Conveyors
            #region
            conveyorList.Add(new Conveyor(Content.Load<Texture2D>("level/conveyor/800conveyorright20"), new Vector2(100, Game1.screenHeight - 100), "right"));

            conveyorList.Add(new Conveyor(Content.Load<Texture2D>("level/conveyor/800conveyorleft20"), new Vector2(0, Game1.screenHeight - 190), "left"));

            conveyorList.Add(new Conveyor(Content.Load<Texture2D>("level/conveyor/800conveyorright20"), new Vector2(100, Game1.screenHeight - 280), "right"));

            conveyorList.Add(new Conveyor(Content.Load<Texture2D>("level/conveyor/800conveyorleft20"), new Vector2(0, Game1.screenHeight - 370), "left"));

            conveyorList.Add(new Conveyor(Content.Load<Texture2D>("level/conveyor/800conveyorright20"), new Vector2(100, Game1.screenHeight - 460), "right"));
            #endregion

            // Moving Spikes
            #region
            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(100, Game1.screenHeight - 130),
                                new Vector2(100, 0), new Vector2(870, 0)));

            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(770, Game1.screenHeight - 220),
                                new Vector2(0, 0), new Vector2(770, 0)));

            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(100, Game1.screenHeight - 310),
                                new Vector2(100, 0), new Vector2(870, 0)));

            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(770, Game1.screenHeight - 400),
                                new Vector2(0, 0), new Vector2(770, 0)));

            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(100, Game1.screenHeight - 490),
                                new Vector2(100, 0), new Vector2(870, 0)));

            #endregion

            // Floor
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/900platform10"), new Vector2(0, Game1.screenHeight - 10)));
            #endregion
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(texture, Vector2.Zero, Color.White);
        }
    }
}
