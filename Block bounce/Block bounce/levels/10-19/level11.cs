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
            // Set level-specific variables
            #region
            currentLevel = 10;

            endArea = new Rectangle(880, Game1.screenHeight - 30, 20, 20);

            #endregion

            base.LoadContent(Content);
        }

    }
}
