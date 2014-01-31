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

            #endregion

            // Begin level design
            #region
            // Decaying platforms
            decayingPlatformList.Add(new DecayingPlatform(Content.Load<Texture2D>("level/platform/20platform20"), new Vector2(100, Game1.screenHeight - 100), 
                3, 60));

            // Spikes
            spikeRowList.Add(new SpikeRow(Content.Load<Texture2D>("level/spike/spike"), new Rectangle(200, Game1.screenHeight - 30, 580, 30)));

            #endregion
        }
    }
}
