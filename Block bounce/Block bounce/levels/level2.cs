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
    // **CHANGE THIS PER LEVEL
    public class level2 : BaseLevel
    {
        private Texture2D background;

        // Constructor
        public level2()
        {
            startPos = new Vector2(0, Game1.screenHeight - 365 - 20);
        }

        // Load Content
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            endArea = new Rectangle(880, Game1.screenHeight - 30, 20, 30);

            currentLevel = 2;
           
            background = Content.Load<Texture2D>("level/2/background");

            #endregion

            // Begin level design
            #region
            // Platforms
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/900platform10"), new Vector2(0, Game1.screenHeight - 10)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(600, Game1.screenHeight - 95)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(400, Game1.screenHeight - 185)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(200, Game1.screenHeight - 275)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(0, Game1.screenHeight - 365)));
            #endregion
        }

        // Draw ** Use if drawing non inherited objects (e.g non-default background) **
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
        }
    }
}
