﻿using Raylib_cs;

int display = Raylib.GetCurrentMonitor();    //get monitor display

const int screenWidth = 800;                 //original window size
const int screenHeight = 450;                //original window size

int monitordisplay = Raylib.GetCurrentMonitor();    //get monitor display

Raylib.InitWindow(screenWidth, screenHeight, "VidoGam");    //set window size
Raylib.SetTargetFPS(60);                                   //set target fps for the window

Texture2D pixelDojo = Raylib.LoadTexture("PixelDojo.png");

Texture2D ladyFighterEat = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Kunoichi\Eating.png");

Texture2D ladyFighterIdle = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Kunoichi\Idle.png");

Texture2D monkFighterIdle = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Ninja_Monk\Idle.png");

Texture2D plebFighterIdle = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Ninja_Peasant\Idle.png");

pixelDojo.Width = Raylib.GetMonitorWidth(monitordisplay);
pixelDojo.Height = Raylib.GetMonitorHeight(monitordisplay);

ladyFighterEat.Width = 300;
ladyFighterEat.Height = 300;

ladyFighterIdle.Width = 100;
ladyFighterIdle.Height = 100;

monkFighterIdle.Width = 100;
monkFighterIdle.Height = 100;

plebFighterIdle.Width = 100;
plebFighterIdle.Height = 100;




int currentRoom = 0;

while (!Raylib.WindowShouldClose())
{

    if (currentRoom == 0)
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Enter) && (Raylib.IsKeyDown(KeyboardKey.LeftAlt) || Raylib.IsKeyDown(KeyboardKey.RightAlt)))
        {

            // Check what display were on
            if (Raylib.IsWindowFullscreen())
            {
                // If we are fullscreen, go back to previous size
                Raylib.SetWindowSize(screenWidth, screenHeight);
            }
            else
            {
                // Match the monitor size we're on if not on fullscreen
                Raylib.SetWindowSize(Raylib.GetMonitorWidth(monitordisplay), Raylib.GetMonitorHeight(monitordisplay));

            }

            // Toggle fullscreen state
            Raylib.ToggleFullscreen();
        }
    }

    Raylib.BeginDrawing();
    /*_____                                                       _____ 
    ( ___ )-----------------------------------------------------( ___ )
     |   |                                                       |   | 
     |   |  ____                              _                  |   | 
     |   | |  _ \   _ __    __ _  __      __ (_)  _ __     __ _  |   | 
     |   | | | | | | '__|  / _` | \ \ /\ / / | | | '_ \   / _` | |   | 
     |   | | |_| | | |    | (_| |  \ V  V /  | | | | | | | (_| | |   | 
     |   | |____/  |_|     \__,_|   \_/\_/   |_| |_| |_|  \__, | |   | 
     |   |                                                |___/  |   | 
     |___|                                                       |___| 
    (_____)-----------------------------------------------------(_____)                                                         
    */
    if (currentRoom == 0) // ROOM 0**********************************************************************************************************
    {
        Raylib.DrawTexture(pixelDojo, 0, 0, Color.White);
        Raylib.DrawText("Press Alt + Enter to toggle fullscreen", 100, 100, 30, Color.White);


        Raylib.DrawText("Press [P] to play", screenWidth / 2 + 110, screenHeight, 100, Color.Gold);

        if (Raylib.IsKeyPressed(KeyboardKey.P))
        {
            currentRoom = 1;
        }
    }

    if (currentRoom == 1)  //  ROOM 1*******************************************************************************************************
    {
        Raylib.DrawTexture(pixelDojo, 0, 0, Color.White);
        Raylib.DrawText("Choose your character", screenWidth / 2, screenHeight / 4, 100, Color.RayWhite);
        Raylib.DrawTexture(ladyFighterEat, 300, 400, Color.White);
    }


    static void DrawLadyEat()
    {
        numFrames = 9;
        frameWidth = ladyFighterEat.Width / numFrames;
        frameRect = Raylib.Rectangle(0.0f, 0.0f, (float)frameWidth, (float)ladyFighterEat.height)
        Raylib.DrawTexture(ladyFighterEat, 300, 400, Color.White);

        frameDelay = 5.0f / 60.0f;
        frameDelayCounter = 0;
        frameIndex = 0;
    }


    Raylib.EndDrawing();
}
