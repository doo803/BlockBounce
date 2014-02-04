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
    public class CirclePlatform : Platform
    {
        int leftLimit, rightLimit;
        string direction;
        double pi = 3.14159265;
        int movingTowards; // 1 = left, 2 = right
        int movingTowardsVert; // 1 = up, 2 = down
        int horSpeed, vertSpeed, baseSpeed;
        int centerX, centerY, radius;
        int circlePosX, circlePosY;

        public CirclePlatform(Texture2D newTexture, Vector2 newPosition, int newLeftLimit, int newRightLimit, string newDirection, int newSpeed)
            : base(newTexture, newPosition)
        {
            leftLimit = newLeftLimit;
            rightLimit = newRightLimit;
            direction = newDirection;
            baseSpeed = newSpeed;
            radius = rightLimit - leftLimit;
            centerX = (int)position.X + radius;
            centerY = (int)position.Y + radius;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            horSpeed = 1;
            vertSpeed = 1;
            
            #region
            if (position.X < leftLimit)
            {
                movingTowards = 2;
            }

            if (position.X > rightLimit)
            {
                movingTowards = 1;
            }

            if (position.X < leftLimit)
            {
                if (direction == "clockwise")
                {
                    movingTowardsVert = 1;
                }

                if (direction == "anticlockwise")
                {
                    movingTowardsVert = 2;
                }
            }

            else if (position.X > rightLimit)
            {
                if (direction == "clockwise")
                {
                    movingTowardsVert = 2;
                }

                if (direction == "anticlockwise")
                {
                    movingTowardsVert = 1;
                }
            }

            if (movingTowards == 1)
            {
                position.X -= horSpeed;
            }

            else if (movingTowards == 2)
            {
                position.X += horSpeed;
            }

            if (movingTowardsVert == 1)
            {
                position.Y -= vertSpeed;
            }

            else if (movingTowardsVert == 2)
            {
                position.Y += vertSpeed;
            }
            #endregion

            // Make platform move in circle fashion vertically
            #region
            

            double diameter = 2 * pi * radius;
            
            circlePosX = centerX + (int)Math.Cos(30) * radius;
            circlePosY = centerY + (int)Math.Sin(30) * radius;
 
            

            #endregion
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Draw(texture, new Vector2(circlePosX, circlePosY), Color.White);
        }
    }
}
