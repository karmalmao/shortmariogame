using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AIE_02_Raylib_Mario
{
    class Game
    {
        public int windowWidth = 1900;
        public int windowHeight = 1000;
        public string windowTitle = "e";

        


        Texture2D marioTexture;
        Texture2D cursor;
        float marioXPos = 400;
        float marioYPos = 200;
        float marioWidth = 32;
        float marioHeight = 32;
        float movespeed = 10;
        float gravity = 10;

        
        
        float cursorwidth = 1;
        float cursorheight = 1;

        float jumpForce = 20;
        float resetJumpForce = 20;
        float bounceForce = 20;
        float resetBounceForce = 20;
        private Vector2 cursorpos;
        private Color LIME;

        public void LoadGame()
        {
            // TODO: Load game assets here
            marioTexture = Raylib.LoadTexture("./assets/mario_1.png");
            cursor = Raylib.LoadTexture("./assets/crate_1.png");
        }

        public void Update(float deltaTime)
        {

            #region Inputs
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                marioXPos += movespeed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                marioXPos -= movespeed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                marioYPos += movespeed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                marioYPos -= movespeed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_Y))
            {
                movespeed = movespeed += 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_U))
            {
                movespeed = movespeed -= 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                marioYPos -= jumpForce;
                jumpForce -= 1;
            }
            #endregion
            #region Mario logic
            if (marioXPos > windowWidth - 10)
            {
                marioXPos = 1890;
            }
            if (marioYPos > windowHeight)
            {
                marioYPos = windowHeight;
                jumpForce = resetJumpForce;
            }
            if (marioXPos < 0)
            {
                marioXPos = 0;
            }
            if (marioYPos < 10)
            {
                marioYPos = 10;
            }
            if (1 == 1)
            {
             windowTitle = "Your speed is " + movespeed;
            }
            marioYPos += gravity;
            #endregion
            while (Raylib.WindowShouldClose())
            {
                cursorpos = Raylib.GetMousePosition();
            }
            
            

        }

        public void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);

            // TODO: Drawing related logic here

            // draws some text
            Raylib.DrawText("Your movespeed is " + movespeed, 10, 10, 32, Color.DARKGRAY);

            // draws a rotating texture in center of screen
            RayLibExt.DrawTexture(marioTexture, marioXPos, marioYPos, marioWidth, marioHeight,
                Color.WHITE, 0, 0.5f, 1.0f);
            Raylib.DrawCircleV(cursorpos, 40, LIME);

            Raylib.EndDrawing();
        }
    }
}
