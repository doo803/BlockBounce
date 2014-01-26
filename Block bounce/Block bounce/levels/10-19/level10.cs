﻿using System;
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
    public class level10 : BaseLevel
    {
        public level10()
        {
            startPos = new Vector2(0, 40);
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            currentLevel = 10;

            endArea = new Rectangle(880, Game1.screenHeight - 30, 20, 20);

            #endregion

            // Begin level design
            #region
            movingPlatformList.Add(new MovingPlatform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(0, 60), 4, 
                new Vector2 (0, 0), new Vector2(700, 0), new Vector2(0, 60), new Vector2(0, 60)));
            #endregion

        }
    }
}
