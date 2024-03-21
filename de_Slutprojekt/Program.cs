using Raylib_cs;
using System.Numerics;


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

ladyFighterEat.Width = 9216;
ladyFighterEat.Height = 1024;

ladyFighterIdle.Width = 100;
ladyFighterIdle.Height = 100;

monkFighterIdle.Width = 4704;
monkFighterIdle.Height = 672;

plebFighterIdle.Width = 4608;
plebFighterIdle.Height = 768;


int numFramesL = 9;
float frameWidthL = (float)(ladyFighterEat.Width / numFramesL);
float timerL = 0.0f;
int frameL = 0;
int maxFramesL = (int)(ladyFighterEat.Width / (int)frameWidthL);

int numFramesM = 7;
float frameWidthM = (float)(monkFighterIdle.Width / numFramesM);
float timerM = 0.0f;
int frameM = 0;
int maxFramesM = (int)(monkFighterIdle.Width / (int)frameWidthM);

int numFramesP = 6;
float frameWidthP = (float)(plebFighterIdle.Width / numFramesP);
float timerP = 0.0f;
int frameP = 0;
int maxFramesP = (int)(plebFighterIdle.Width / (int)frameWidthP);


int currentRoom = 0;

while (!Raylib.WindowShouldClose())
{

    if (currentRoom == 0)    // ROOM 0 *************************************************************************************************************
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
        if (Raylib.IsKeyPressed(KeyboardKey.P))
        {
            currentRoom = 1;
        }
    }

    if (currentRoom == 1)
    {
        timerL += Raylib.GetFrameTime();
        if (timerL >= 0.2f)
        {
            timerL = 0.0f;
            frameL += 1;
        }

        frameL = frameL % maxFramesL;

        timerM += Raylib.GetFrameTime();
        if (timerM >= 0.2f)
        {
            timerM = 0.0f;
            frameM += 1;
        }

        frameM = frameM % maxFramesM;

        timerP += Raylib.GetFrameTime();
        if (timerP >= 0.2f)
        {
            timerP = 0.0f;
            frameP += 1;
        }

        frameP = frameP % maxFramesP;

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

    }

    if (currentRoom == 1)  //  ROOM 1*******************************************************************************************************
    {
        Raylib.DrawTexture(pixelDojo, 0, 0, Color.White);

        Raylib.DrawText("Choose your character", screenWidth / 2, screenHeight / 4, 100, Color.RayWhite);
        Raylib.DrawTextureRec(
                ladyFighterEat,
                new Rectangle((frameWidthL * frameL), 0, frameWidthL, (float)ladyFighterEat.Height),
                new Vector2(100, 50),
                Color.White);

        Raylib.DrawTextureRec(
                monkFighterIdle,
                new Rectangle((frameWidthM * frameM), 0, frameWidthM, (float)monkFighterIdle.Height),
                new Vector2(600, 400),
                Color.White);

        Raylib.DrawTextureRec(
                plebFighterIdle,
                new Rectangle((frameWidthP * frameP), 0, frameWidthP, (float)plebFighterIdle.Height),
                new Vector2(900, 350),
                Color.White);

        if (Raylib.GetMouseX() >= 500 && Raylib.GetMouseX() <= 700 && Raylib.GetMouseY() >= 500 && Raylib.GetMouseY() <= 1074)
        {
        Raylib.DrawText("->", 400, 600, 100, Color.Gold);
        }

        else if (Raylib.GetMouseX() >= 500 && Raylib.GetMouseX() <= 700 && Raylib.GetMouseY() >= 500 && Raylib.GetMouseY() <= 1074)
        {
        Raylib.DrawText("->", 400, 600, 100, Color.Gold);
        }

        else if (Raylib.GetMouseX() >= 500 && Raylib.GetMouseX() <= 700 && Raylib.GetMouseY() >= 500 && Raylib.GetMouseY() <= 1074)
        {
        Raylib.DrawText("->", 400, 600, 100, Color.Gold);
        }

    }




    Raylib.EndDrawing();
}
