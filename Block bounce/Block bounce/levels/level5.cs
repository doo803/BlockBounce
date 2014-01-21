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
    public class level5 : BaseLevel
    {
        // Load Content
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            // Set level-specific variables
            #region
            currentLevel = 5;

            startPos = new Vector2(0, Game1.screenHeight - 30);

            endArea = new Rectangle(880, Game1.screenHeight - 30, 20, 20);

            #endregion

            // Begin level design
            #region
            // Platforms   
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(-50, Game1.screenHeight - 105)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(-50, Game1.screenHeight - 205)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(-50, Game1.screenHeight - 305)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(-50, Game1.screenHeight - 405)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/100platform20"), new Vector2(100, Game1.screenHeight - 475)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(300, Game1.screenHeight - 475)));
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/40platform20"), new Vector2(615, Game1.screenHeight - 425)));

            // Spikes (29x30)
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/wall/80spikewall600"), new Vector2((Game1.screenWidth / 2) - 40, Game1.screenHeight - 350)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/wall/80spikewall600"), new Vector2((Game1.screenWidth / 2) - 40, -520)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2((Game1.screenWidth / 2) - 14.5f, Game1.screenHeight - 375)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/downspike"), new Vector2((Game1.screenWidth / 2) - 14.5f, 75)));

            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/spike/spike"), new Vector2((Game1.screenWidth - 95), Game1.screenHeight - 375)));
            spikeList.Add(new Spikes(Content.Load<Texture2D>("level/wall/80spikewall600"), new Vector2((Game1.screenWidth - 120), Game1.screenHeight - 350)));

            // Leave this
            platformList.Add(new Platform(Content.Load<Texture2D>("level/platform/900platform10"), new Vector2(0, Game1.screenHeight - 10)));
            #endregion
        }
    }
}
