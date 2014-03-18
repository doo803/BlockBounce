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
    public class level4 : BaseLevel
    {
        private Texture2D background;

        // Constructor
        public level4()
        {
            startPos = new Vector2(0, Game1.screenHeight - 475);
            initStartPos = startPos;
        }

        // Load Content
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            endArea = new Rectangle(880, Game1.screenHeight - 30, 20, 20);

            currentLevel = 4;

            background = Content.Load<Texture2D>("level/4/background");
            #endregion

            // Begin level design
            #region
            // Platforms            
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(-70, Game1.screenHeight - 455)));

            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(50, Game1.screenHeight - 100)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(200, Game1.screenHeight - 100)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(350, Game1.screenHeight - 100)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(500, Game1.screenHeight - 100)));

            // Spikes (29x30)
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(0, Game1.screenHeight - 30)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/10spikerow"), new Vector2(290, Game1.screenHeight - 30)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(580, Game1.screenHeight - 30)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(610, Game1.screenHeight - 30)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2(640, Game1.screenHeight - 30)));

            // Leave this
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/900platform10"), new Vector2(0, Game1.screenHeight - 10)));
            #endregion
        }   
    
        // Draw ** Use if drawing non inherited objects (e.g non-default background) **
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);

            base.Draw(spriteBatch);            
        }
    }
}
