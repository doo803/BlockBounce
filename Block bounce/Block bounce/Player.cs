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

namespace Block_bounce
{
    public class Player
    {
        public Texture2D playerTexture;
        public Vector2 playerPosition;
        public bool playerIsAlive, playerDied;
        public int initialTimer;
        public Rectangle boundingBox;
        public float playerSpeed, gravForce, terminalVelocity;

        // Gravity and jumping

        public Vector2 velocity;
        public bool hasJumped;

        // Instantiate soundmanager
        public SoundManager sm = new SoundManager();
        
        // Constructor
        public Player(Texture2D newTexture, Vector2 newPosition)
        {
            playerTexture = newTexture;
            hasJumped = false;
            playerPosition = newPosition;
            terminalVelocity = 5f;
            initialTimer = 0;
            gravForce = 0.5f;

            playerSpeed = 5f;
            playerIsAlive = true;            
        }

        // Update
        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            initialTimer++;
           
            // Control volume
            #region
            sm.Update(gameTime);
            #endregion

            playerPosition += velocity;

            // Set terminal velocity
            if (velocity.Y >= terminalVelocity)
            { 
                velocity.Y = terminalVelocity;
            }

            // Player bounding box
            boundingBox = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerTexture.Width, playerTexture.Height);

            // Control player movement left and right
            #region
            // Move player left
            if (keyState.IsKeyDown(Keys.Left) || 
                GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
            {
                velocity.X = -playerSpeed;
            }

            // Move player right
            else if (keyState.IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
            {
                velocity.X = playerSpeed;
            }
            #endregion

            // Move player with thumbstick
            #region
            else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < -0.1f)
            {
                velocity.X = -playerSpeed;
            }

            else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0.1f)
            {
                velocity.X = playerSpeed;
            }

            #endregion            

            // Don't move if stationary
            else velocity.X = 0f;

            // Begin jump
            if ((keyState.IsKeyDown(Keys.Space) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) && hasJumped == false)
            {
                playerPosition.Y -= 10;
                velocity.Y = -10;
                hasJumped = true;
            }


            float i = 1;
            velocity.Y += gravForce * i;           

            // Make sure player stays in screen bounds
            #region
            // Stop player going off left side of screen
            if (playerPosition.X <= 0)
            {
                playerPosition.X = 0;
            }

            // Stop player going off right side of screen
            if ((playerPosition.X + playerTexture.Width) >= Game1.screenWidth)
            {
                playerPosition.X = Game1.screenWidth - playerTexture.Width;
            }

            // Stop player going off top of screen 
            if ((playerPosition.Y) <= 0)
            {
                velocity.Y = 0;
                playerPosition.Y += 5;
                hasJumped = true;
            }

            #endregion

        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {             
            spriteBatch.Draw(playerTexture, playerPosition, Color.White);                      
        }

        // Draw player death
        public void DrawPlayerDeath(SpriteBatch spriteBatch)
        { 
            
        }
    }
}
