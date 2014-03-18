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
    public class level6 : BaseLevel
    {
        
        // Constructor
        public level6()
        {
            startPos = new Vector2(0, Game1.screenHeight - 30);
            initStartPos = startPos;
        }

        // Load Content
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            currentLevel = 6;

            endArea = new Rectangle (880, Game1.screenHeight - 30, 20, 20);

            #endregion

            // Begin level design
            #region
            // Platforms

            // Centre wall
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/20platform600"), new Vector2(Game1.screenWidth / 2 - 10, 50)));

            // Checkpoint
            checkpointList.Add(new Checkpoint(new Vector2(Game1.screenWidth / 2 - 10, 30)));

            // Left side
            #region
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(-50, Game1.screenHeight - 100)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/700platform20"), new Vector2(90, Game1.screenHeight - 190)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(-50, Game1.screenHeight - 280)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/700platform20"), new Vector2(90, Game1.screenHeight - 370)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(-50, Game1.screenHeight - 460)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/700platform20"), new Vector2(90, Game1.screenHeight - 550)));
            #endregion

            // Right side
            #region
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(550, Game1.screenHeight - 100)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(550, Game1.screenHeight - 280)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/400platform20"), new Vector2(550, Game1.screenHeight - 460)));
            #endregion

            // MOVING spikes
            // Left side
            #region
            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(0, Game1.screenHeight - 130),
                                new Vector2(0, 0), new Vector2(320, 0)));

            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(90, Game1.screenHeight - 220),
                                new Vector2(90, 0), new Vector2(410, 0)));

            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(0, Game1.screenHeight - 310),
                                new Vector2(0, 0), new Vector2(320, 0)));

            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(90, Game1.screenHeight - 400),
                                new Vector2(90, 0), new Vector2(410, 0)));

            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(0, Game1.screenHeight - 490),
                                new Vector2(0, 0), new Vector2(320, 0)));
            #endregion

            // Right side
            #region
            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(870, Game1.screenHeight - 130),
                                new Vector2(550, 0), new Vector2(870, 0)));

            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(780, Game1.screenHeight - 220),
                                new Vector2(460, 0), new Vector2(780, 0)));

            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(870, Game1.screenHeight - 310),
                                new Vector2(550, 0), new Vector2(870, 0)));

            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(780, Game1.screenHeight - 400),
                                new Vector2(460, 0), new Vector2(780, 0)));

            movingSpikeList.Add(new MovingSpike(Content.Load<Texture2D>("level/spike/spike"), new Vector2(870, Game1.screenHeight - 490),
                                new Vector2(550, 0), new Vector2(870, 0)));
            #endregion

            // Floor
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/900platform10"), new Vector2(0, Game1.screenHeight - 10)));
            #endregion
        }
    }
}
