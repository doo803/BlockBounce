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
        }

        // Load Content
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            currentLevel = 6;

            endArea = new Rectangle (Game1.screenWidth / 2 + 200, 200, 20, 20);

            #endregion

            // Begin level design
            #region

            // Leave this
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/900platform10"), new Vector2(0, Game1.screenHeight - 10)));
            #endregion
        }
    }
}
