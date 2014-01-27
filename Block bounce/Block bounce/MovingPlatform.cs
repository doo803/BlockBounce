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
        public int vertSpeed, horSpeed, playerSpeedModHor, playerSpeedModVert;
        Vector2 leftLimit, rightLimit, upLimit, downLimit;

        public MovingPlatform(Texture2D newTexture, Vector2 newPosition, 
            int newVertSpeed, int newHorSpeed,
            Vector2 newLeftLimit, Vector2 newRightLimit, 
            Vector2 newDownLimit, Vector2 newUpLimit)
            : base(newTexture, newPosition)
        {
            vertSpeed = newVertSpeed;
            horSpeed = newHorSpeed;
            leftLimit = newLeftLimit;
            rightLimit = newRightLimit;
            upLimit = newUpLimit;
            downLimit = newDownLimit;
            movingRight = true;
            movingLeft = false;
            movingDown = false;
            movingUp = true;
            playerSpeedModHor = horSpeed;
            playerSpeedModVert = vertSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (position.X < leftLimit.X)
            {
                movingRight = true;
                movingLeft = false;
            }

            if (position.X > rightLimit.X)
            {
                movingRight = false;
                movingLeft = true;
            }

            if (position.Y > downLimit.Y)
            {
                movingUp = true;
                movingDown = false;
            }

            if (position.Y < upLimit.Y)
            {
                movingUp = false;
                movingDown = true;
            }

            if (movingLeft == true)
            {
                position.X -= horSpeed;
            }

            if (movingRight == true)
            {
                position.X += horSpeed;
            }

            if (movingUp == true)
            {
                position.Y -= vertSpeed;
            }

            if (movingDown == true)
            {
                position.Y += vertSpeed;
            }
        }

    }
}
