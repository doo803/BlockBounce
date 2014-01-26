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
    public class MovingPlatform : Platform
    {
        public bool movingRight, movingLeft, movingDown, movingUp;
        public int speed, playerSpeedMod;
        Vector2 leftLimit, rightLimit, upLimit, downLimit;

        public MovingPlatform(Texture2D newTexture, Vector2 newPosition, int newSpeed, 
            Vector2 newLeftLimit, Vector2 newRightLimit, 
            Vector2 newUpLimit, Vector2 newDownLimit)
            : base(newTexture, newPosition)
        {
            speed = newSpeed;
            leftLimit = newLeftLimit;
            rightLimit = newRightLimit;
            upLimit = newUpLimit;
            downLimit = newDownLimit;
            movingRight = true;
            movingLeft = false;
            movingDown = false;
            movingUp = false;
            playerSpeedMod = speed;
        }

        public override void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (position.X <= leftLimit.X)
            {
                movingRight = true;
                movingLeft = false;
            }

            if (position.X >= rightLimit.X)
            {
                movingRight = false;
                movingLeft = true;
            }

            if (position.Y < downLimit.Y)
            {
                movingUp = true;
                movingDown = false;
            }

            if (position.Y > upLimit.Y)
            {
                movingUp = false;
                movingDown = true;
            }

            if (movingLeft == true)
            {
                position.X -= speed;
            }

            if (movingRight == true)
            {
                position.X += speed;
            }
        }

    }
}
