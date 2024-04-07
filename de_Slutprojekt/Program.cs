using Raylib_cs;
using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;


// LadyF ladyFighter = new LadyF();


const int screenWidth = 800;                 //original window size
const int screenHeight = 450;                //original window size

int monitordisplay = Raylib.GetCurrentMonitor();    //get monitor display

Raylib.InitWindow(screenWidth, screenHeight, "VidoGam");    //set window size
Raylib.SetTargetFPS(60);                                   //set target fps for the window

Texture2D pixelDojo = Raylib.LoadTexture("PixelDojo.png");

Texture2D ladyFighterEat = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Kunoichi\Eating.png");

Texture2D ladyFighterIdle = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Kunoichi\Idle.png");

Texture2D ladyFighterWalk = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Kunoichi\Walk.png");

Texture2D ladyFighterRun = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Kunoichi\Run.png");

Texture2D ladyFighterJump = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Kunoichi\Jump.png");

Texture2D ladyFighterAttack1 = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Kunoichi\Attack_1.png");

Texture2D monkFighterIdle1 = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Ninja_Monk\Idle.png");

Texture2D monkFighterIdle = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Ninja_Monk\Idle.png");

Texture2D monkFighterWalk = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Ninja_Monk\Walk.png");

Texture2D plebFighterIdle = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Ninja_Peasant\Idle.png");

Texture2D plebFighterWalk = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Ninja_Peasant\Walk.png");

pixelDojo.Width = Raylib.GetMonitorWidth(monitordisplay);
pixelDojo.Height = Raylib.GetMonitorHeight(monitordisplay);

ladyFighterEat.Width = 9216;
ladyFighterEat.Height = 1024;

ladyFighterIdle.Width = 5760;
ladyFighterIdle.Height = 640;

ladyFighterWalk.Width = 5120;
ladyFighterWalk.Height = 640;

ladyFighterRun.Width = 5120;
ladyFighterRun.Height = 640;

ladyFighterJump.Width = 6400;
ladyFighterJump.Height = 640;

ladyFighterAttack1.Width = 3840;
ladyFighterAttack1.Height = 640;

monkFighterIdle1.Width = 4704;
monkFighterIdle1.Height = 672;

monkFighterIdle.Width = 3360;
monkFighterIdle.Height = 480;

monkFighterWalk.Width = 3360;
monkFighterWalk.Height = 480;

plebFighterIdle.Width = 4608;
plebFighterIdle.Height = 768;

plebFighterWalk.Width = 5120;
plebFighterWalk.Height = 640;

string ladyCondition = "idle";

string monkCondition = "idle";

string plebCondition = "idle";

int numFramesL = 9;
float frameWidthL = (float)(ladyFighterEat.Width / numFramesL);
float timerL = 0.0f;
int frameL = 0;
int maxFramesL = (int)(ladyFighterEat.Width / (int)frameWidthL);

int numFramesLI = 9;
float frameWidthLI = (float)(ladyFighterIdle.Width / numFramesLI);
float timerLI = 0.0f;
int frameLI = 0;
int maxFramesLI = (int)(ladyFighterIdle.Width / (int)frameWidthLI);

int numFramesLW = 8;
float frameWidthLW = (float)(ladyFighterWalk.Width / numFramesLW);
float timerLW = 0.0f;
int frameLW = 0;
int maxFramesLW = (int)(ladyFighterWalk.Width / (int)frameWidthLW);

int numFramesLA1 = 6;
float frameWidthLA1 = (float)(ladyFighterAttack1.Width / numFramesLA1);
float timerLA1 = 0.0f;
int frameLA1 = 0;
int maxFramesLA1 = (int)(ladyFighterAttack1.Width / (int)frameWidthLA1);

int numFramesLB = 8;
float frameWidthLB = (float)(ladyFighterWalk.Width / numFramesLB);
float timerLB = 0.0f;
int frameLB = 0;
int maxFramesLB = (int)(ladyFighterWalk.Width / (int)frameWidthLB);

int numFramesLJ = 10;
float frameWidthLJ = (float)(ladyFighterJump.Width / numFramesLJ);
float timerLJ = 0.0f;
int frameLJ = 0;
int maxFramesLJ = (int)(ladyFighterJump.Width / (int)frameWidthLJ);

int numFramesM1 = 7;
float frameWidthM1 = (float)(monkFighterIdle1.Width / numFramesM1);
float timerM1 = 0.0f;
int frameM1 = 0;
int maxFramesM1 = (int)(monkFighterIdle1.Width / (int)frameWidthM1);

int numFramesM = 7;
float frameWidthM = (float)(monkFighterIdle.Width / numFramesM);
float timerM = 0.0f;
int frameM = 0;
int maxFramesM = (int)(monkFighterIdle.Width / (int)frameWidthM);

int numFramesMW = 7;
float frameWidthMW = (float)(monkFighterWalk.Width / numFramesMW);
float timerMW = 0.0f;
int frameMW = 0;
int maxFramesMW = (int)(monkFighterWalk.Width / (int)frameWidthMW);

int numFramesMB = 7;
float frameWidthMB = (float)(monkFighterWalk.Width / numFramesMB);
float timerMB = 0.0f;
int frameMB = 0;
int maxFramesMB = (int)(monkFighterWalk.Width / (int)frameWidthMB);

int numFramesP = 6;
float frameWidthP = (float)(plebFighterIdle.Width / numFramesP);
float timerP = 0.0f;
int frameP = 0;
int maxFramesP = (int)(plebFighterIdle.Width / (int)frameWidthP);

int numFramesPW = 8;
float frameWidthPW = (float)(plebFighterIdle.Width / numFramesPW);
float timerPW = 0.0f;
int framePW = 0;
int maxFramesPW = (int)(plebFighterIdle.Width / (int)frameWidthPW);

int numFramesPB = 8;
float frameWidthPB = (float)(plebFighterIdle.Width / numFramesPB);
float timerPB = 0.0f;
int framePB = 0;
int maxFramesPB = (int)(plebFighterIdle.Width / (int)frameWidthPB);

int ladyX = 100;
int ladyY = 330;

int monkX = 100;
int monkY = 500;

int plebX = 100;
int plebY = 330;

string chosenCharacter = "none";

Boolean attack1 = false;

Boolean jump = false;

int currentRoom = 0;

while (!Raylib.WindowShouldClose()) // MAIN GAME WHILE LOOP __----____----_--__---__---__--__--
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

    else if (currentRoom == 1)
    {
        timerL += Raylib.GetFrameTime();
        if (timerL >= 0.2f)
        {
            timerL = 0.0f;
            frameL += 1;
        }

        frameL = frameL % maxFramesL;


        timerM1 += Raylib.GetFrameTime();
        if (timerM1 >= 0.2f)
        {
            timerM1 = 0.0f;
            frameM1 += 1;
        }

        frameM1 = frameM1 % maxFramesM1;


        timerP += Raylib.GetFrameTime();
        if (timerP >= 0.2f)
        {
            timerP = 0.0f;
            frameP += 1;
        }

        frameP = frameP % maxFramesP;

        if (Raylib.GetMouseX() >= 500 && Raylib.GetMouseX() <= 700 && Raylib.GetMouseY() >= 500 && Raylib.GetMouseY() <= 1074 && Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            currentRoom = 2;
            chosenCharacter = "ladyFighter";
        }

        else if (Raylib.GetMouseX() >= 800 && Raylib.GetMouseX() <= 1000 && Raylib.GetMouseY() >= 500 && Raylib.GetMouseY() <= 1074 && Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            currentRoom = 2;
            chosenCharacter = "monkFighter";
        }

        else if (Raylib.GetMouseX() >= 1100 && Raylib.GetMouseX() <= 1300 && Raylib.GetMouseY() >= 500 && Raylib.GetMouseY() <= 1074 && Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            currentRoom = 2;
            chosenCharacter = "plebFighter";
        }

    }
    else if (currentRoom == 2)
    {



        if (chosenCharacter == "ladyFighter")
        {

            timerLI += Raylib.GetFrameTime();
            if (timerLI >= 0.2f)
            {
                timerLI = 0.0f;
                frameLI += 1;
            }

            frameLI = frameLI % maxFramesLI;

            timerLW += Raylib.GetFrameTime();
            if (timerLW >= 0.2f)
            {
                timerLW = 0.0f;
                frameLW += 1;
            }

            frameLW = frameLW % maxFramesLW;

            timerLB -= Raylib.GetFrameTime();
            if (timerLB <= 0.0f)
            {
                timerLB = 0.2f;
                frameLB -= 1;
            }

            frameLB = frameLB % maxFramesLB;

            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                ladyCondition = "walk";
                ladyX += 2;
            }

            else if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                ladyCondition = "back";
                ladyX -= 2;
            }

            if (Raylib.IsKeyDown(KeyboardKey.LeftShift) && Raylib.IsKeyDown(KeyboardKey.D))
            {
                ladyCondition = "run";
                ladyX += 4;
            }


            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                jump = true;
            }

            if (jump == true)
            {
                ladyCondition = "jump";

                timerLJ += Raylib.GetFrameTime();
                if (timerLJ >= 0.2f)
                {
                    timerLJ = 0.0f;
                    frameLJ += 1;
                }



                frameLJ = frameLJ % maxFramesLJ;

                if (frameLJ > 1 && frameLJ < 5)
                {

                    ladyY -= 1;
                }

                else if (frameLJ == 5)
                {
                    ladyY -= 0;
                    ladyY += 0;
                }

                else if (frameLJ > 5)
                {
                    ladyY += 1;
                }

                if (frameLJ == 9)
                {
                    jump = false;
                    ladyCondition = "idle";
                    ladyY = 330;
                    frameLJ = 0;
                }
            }

            else if (Raylib.IsKeyUp(KeyboardKey.A) && Raylib.IsKeyUp(KeyboardKey.D))
            {
                ladyCondition = "idle";
            }

            if (Raylib.IsKeyPressed(KeyboardKey.F))
            {
                attack1 = true;
            }

            if (attack1 == true)
            {
                ladyCondition = "attack1";

                timerLA1 += Raylib.GetFrameTime();
                if (timerLA1 >= 0.2f)
                {
                    timerLA1 = 0.0f;
                    frameLA1 += 1;
                }

                frameLA1 = frameLA1 % maxFramesLA1;

                if (frameLA1 == 5)
                {
                    attack1 = false;
                    ladyCondition = "idle";
                    frameLA1 = 0;
                }
            }




        }

        else if (chosenCharacter == "monkFighter")
        {

            timerM += Raylib.GetFrameTime();
            if (timerM >= 0.2f)
            {
                timerM = 0.0f;
                frameM += 1;
            }

            frameM = frameM % maxFramesM;

            timerMW += Raylib.GetFrameTime();
            if (timerMW >= 0.2f)
            {
                timerMW = 0.0f;
                frameMW += 1;
            }

            frameMW = frameMW % maxFramesMW;

            timerMB -= Raylib.GetFrameTime();
            if (timerMB <= 0.0f)
            {
                timerMB = 0.2f;
                frameMB -= 1;
            }

            frameMB = frameMB % maxFramesMB;

            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                monkCondition = "walk";
                monkX += 2;
            }

            else if (Raylib.IsKeyDown(KeyboardKey.A))
            {

                monkCondition = "back";
                monkX -= 2;
            }

            else if (Raylib.IsKeyUp(KeyboardKey.A) && Raylib.IsKeyUp(KeyboardKey.A))
            {
                monkCondition = "idle";
            }

        }


        else if (chosenCharacter == "plebFighter")
        {

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

    }

    else if (currentRoom == 1)  //  ROOM 1*******************************************************************************************************
    {
        Raylib.DrawTexture(pixelDojo, 0, 0, Color.White);

        Raylib.DrawText("Choose your character", screenWidth / 2, screenHeight / 4, 100, Color.RayWhite);
        Raylib.DrawTextureRec(
                ladyFighterEat,
                new Rectangle((frameWidthL * frameL), 0, frameWidthL, (float)ladyFighterEat.Height),
                new Vector2(100, 50),
                Color.White);

        Raylib.DrawTextureRec(
                monkFighterIdle1,
                new Rectangle((frameWidthM1 * frameM1), 0, frameWidthM1, (float)monkFighterIdle1.Height),
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

        else if (Raylib.GetMouseX() >= 800 && Raylib.GetMouseX() <= 1000 && Raylib.GetMouseY() >= 500 && Raylib.GetMouseY() <= 1074)
        {
            Raylib.DrawText("->", 740, 600, 100, Color.Gold);
        }

        else if (Raylib.GetMouseX() >= 1100 && Raylib.GetMouseX() <= 1300 && Raylib.GetMouseY() >= 500 && Raylib.GetMouseY() <= 1074)
        {
            Raylib.DrawText("->", 1050, 600, 100, Color.Gold);
        }



    }

    else if (currentRoom == 2)
    {
        Raylib.DrawTexture(pixelDojo, 0, 0, Color.White);

        if (chosenCharacter == "ladyFighter")
        {
            if (ladyCondition == "idle")
            {
                Raylib.DrawTextureRec(
                                ladyFighterIdle,
                                new Rectangle((frameWidthLI * frameLI), 0, frameWidthLI, (float)ladyFighterIdle.Height),
                                new Vector2(ladyX, ladyY),
                                Color.White);
            }

            else if (ladyCondition == "walk")
            {
                Raylib.DrawTextureRec(
                                ladyFighterWalk,
                                new Rectangle((frameWidthLW * frameLW), 0, frameWidthLW, (float)ladyFighterWalk.Height),
                                new Vector2(ladyX, ladyY),
                                Color.White);
            }

            else if (ladyCondition == "back")
            {
                Raylib.DrawTextureRec(
                                ladyFighterWalk,
                                new Rectangle((frameWidthLB * frameLB), 0, frameWidthLB, (float)ladyFighterWalk.Height),
                                new Vector2(ladyX, ladyY),
                                Color.White);
            }

            else if (ladyCondition == "run")
            {
                Raylib.DrawTextureRec(
                                ladyFighterRun,
                                new Rectangle((frameWidthLW * frameLW), 0, frameWidthLW, (float)ladyFighterRun.Height),
                                new Vector2(ladyX, ladyY),
                                Color.White);
            }

            else if (ladyCondition == "jump")
            {
                Raylib.DrawTextureRec(
                                ladyFighterJump,
                                new Rectangle((frameWidthLJ * frameLJ), 0, frameWidthLJ, (float)ladyFighterJump.Height),
                                new Vector2(ladyX, ladyY),
                                Color.White);
            }

            else if (ladyCondition == "attack1")
            {
                Raylib.DrawTextureRec(
                                ladyFighterAttack1,
                                new Rectangle((frameWidthLA1 * frameLA1) + 20, 0, frameWidthLA1, (float)ladyFighterAttack1.Height),
                                new Vector2(ladyX, ladyY),
                                Color.White);
            }

        }

        else if (chosenCharacter == "monkFighter")
        {

            if (monkCondition == "idle")
            {
                Raylib.DrawTextureRec(
                                monkFighterIdle,
                                new Rectangle((frameWidthM * frameM), 0, frameWidthM, (float)monkFighterIdle.Height),
                                new Vector2(monkX, monkY),
                                Color.White);
            }

            else if (monkCondition == "walk")
            {
                Raylib.DrawTextureRec(
                                monkFighterWalk,
                                new Rectangle((frameWidthMW * frameMW), 0, frameWidthMW, (float)monkFighterWalk.Height),
                                new Vector2(monkX, monkY),
                                Color.White);
            }

            else if (monkCondition == "back")
            {
                Raylib.DrawTextureRec(
                                monkFighterWalk,
                                new Rectangle((frameWidthMB * frameMB), 0, frameWidthMB, (float)monkFighterWalk.Height),
                                new Vector2(monkX, monkY),
                                Color.White);
            }

        }

        else if (chosenCharacter == "plebFighter")
        {

        }

    }




    Raylib.EndDrawing();
}
