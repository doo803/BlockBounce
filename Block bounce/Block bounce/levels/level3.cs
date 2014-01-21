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
    // **CHANGE THIS PER LEVEL
    public class level3 : BaseLevel
    {
        // Load Content
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            endArea = new Rectangle(880, Game1.screenHeight - 455, 20, 20);

            currentLevel = 3;

            startPos = new Vector2(0, Game1.screenHeight - 30);

            #endregion

            // Begin level design
            #region
            // Platforms            
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(-50, Game1.screenHeight - 105)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(-50, Game1.screenHeight - 205)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(-50, Game1.screenHeight - 305)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(-50, Game1.screenHeight - 405)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(150, Game1.screenHeight - 455)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(350, Game1.screenHeight - 455)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(550, Game1.screenHeight - 455)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(750, Game1.screenHeight - 455)));

            // Leave this
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/900platform10"), new Vector2(0, Game1.screenHeight - 10)));
            #endregion

        }
    }
}
