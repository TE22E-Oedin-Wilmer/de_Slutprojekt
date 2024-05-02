using Raylib_cs;
using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;


// LadyF ladyFighter = new LadyF();


const int screenWidth = 800;                 //original window size
const int screenHeight = 450;                //original window size

int monitordisplay = Raylib.GetCurrentMonitor();    //get monitor display

Raylib.InitWindow(screenWidth, screenHeight, "VidoGam");    //set window size
Raylib.SetTargetFPS(60);                                   //set target fps for the window

Texture2D pixelDojo = Raylib.LoadTexture("PixelDojo.png");


// ************** LADY     BELOW *******************

Dictionary<string, Texture2D> ladyTextures = new();

ladyTextures.Add("idle", Raylib.LoadTexture(@"Kunoichi\Idle.png"));

ladyTextures.Add("walk", Raylib.LoadTexture(@"Kunoichi\Walk.png"));

ladyTextures.Add("run", Raylib.LoadTexture(@"Kunoichi\Run.png"));

ladyTextures.Add("jump", Raylib.LoadTexture(@"Kunoichi\Jump.png"));

ladyTextures.Add("attack1", Raylib.LoadTexture(@"Kunoichi\Attack_1.png"));

ladyTextures.Add("attack2", Raylib.LoadTexture(@"Kunoichi\Attack_2.png"));

Texture2D ladyFighterEat = Raylib.LoadTexture(@"Kunoichi\Eating.png");


// ************** MONK     BELOW *******************

Dictionary<string, Texture2D> monkTextures = new();

monkTextures.Add("idle", Raylib.LoadTexture(@"Ninja_Monk\Idle.png"));

monkTextures.Add("walk", Raylib.LoadTexture(@"Ninja_Monk\Walk.png"));

monkTextures.Add("run", Raylib.LoadTexture(@"Ninja_Monk\Run.png"));

monkTextures.Add("jump", Raylib.LoadTexture(@"Ninja_Monk\Jump.png"));

monkTextures.Add("attack1", Raylib.LoadTexture(@"Ninja_Monk\Attack_1.png"));

monkTextures.Add("attack2", Raylib.LoadTexture(@"Ninja_Monk\Attack_2.png"));

Texture2D monkFighterIdle1 = Raylib.LoadTexture(@"Ninja_Monk\Idle.png");


// ************** PLEB     BELOW *******************

Dictionary<string, Texture2D> plebTextures = new();

plebTextures.Add("idle", Raylib.LoadTexture(@"Ninja_Peasant\Idle.png"));

plebTextures.Add("walk", Raylib.LoadTexture(@"Ninja_Peasant\Walk.png"));

plebTextures.Add("run", Raylib.LoadTexture(@"Ninja_Peasant\Run.png"));

plebTextures.Add("jump", Raylib.LoadTexture(@"Ninja_Peasant\Jump.png"));

plebTextures.Add("attack1", Raylib.LoadTexture(@"Ninja_Peasant\Attack_1.png"));

plebTextures.Add("attack2", Raylib.LoadTexture(@"Ninja_Peasant\Attack_2.png"));


Texture2D plebFighterIdle1 = Raylib.LoadTexture(@"Ninja_Peasant\Idle.png");



//DOJO FIXES
pixelDojo.Width = Raylib.GetMonitorWidth(monitordisplay);
pixelDojo.Height = Raylib.GetMonitorHeight(monitordisplay);


// ************** LADY     BELOW *******************


ladyFighterEat.Width = 9216;
ladyFighterEat.Height = 1024;

Texture2D idleL = ladyTextures["idle"];
idleL.Width = 5760;
idleL.Height = 640;
ladyTextures["idle"] = idleL;

Texture2D walkL = ladyTextures["walk"];
walkL.Width = 5120;
walkL.Height = 640;
ladyTextures["walk"] = walkL;

Texture2D runL = ladyTextures["run"];
runL.Width = 5120;
runL.Height = 640;
ladyTextures["run"] = runL;

Texture2D jumpL = ladyTextures["jump"];
jumpL.Width = 6400;
jumpL.Height = 640;
ladyTextures["jump"] = jumpL;

Texture2D attack1L = ladyTextures["attack1"];
attack1L.Width = 3840;
attack1L.Height = 640;
ladyTextures["attack1"] = attack1L;

Texture2D attack2L = ladyTextures["attack2"];
attack2L.Width = 5120;
attack2L.Height = 640;
ladyTextures["attack2"] = attack2L;



// ************** MONK     BELOW *******************



monkFighterIdle1.Width = 4704;
monkFighterIdle1.Height = 672;

Texture2D idleM = monkTextures["idle"];
idleM.Width = 3360;
idleM.Height = 480;
monkTextures["idle"] = idleM;

Texture2D walkM = monkTextures["walk"];
walkM.Width = 3360;
walkM.Height = 480;
monkTextures["walk"] = walkM;

Texture2D runM = monkTextures["run"];
runM.Width = 3840;
runM.Height = 480;
monkTextures["run"] = runM;

Texture2D jumpM = monkTextures["jump"];
jumpM.Width = 4320;
jumpM.Height = 480;
monkTextures["jump"] = jumpM;

Texture2D attack1M = monkTextures["attack1"];
attack1M.Width = 2400;
attack1M.Height = 480;
monkTextures["attack1"] = attack1M;

Texture2D attack2M = monkTextures["attack2"];
attack2M.Width = 2400;
attack2M.Height = 480;
monkTextures["attack2"] = attack2M;



// ************** PLEB     BELOW *******************



plebFighterIdle1.Width = 4608;
plebFighterIdle1.Height = 768;

Texture2D idleP = plebTextures["idle"];
idleP.Width = 2880;
idleP.Height = 480;
plebTextures["idle"] = idleP;

Texture2D walkP = plebTextures["walk"];
walkP.Width = 3840;
walkP.Height = 480;
plebTextures["walk"] = walkP;

Texture2D runP = plebTextures["run"];
runP.Width = 2880;
runP.Height = 480;
plebTextures["run"] = runP;

Texture2D jumpP = plebTextures["jump"];
jumpP.Width = 3840;
jumpP.Height = 480;
plebTextures["jump"] = jumpP;

Texture2D attack1P = plebTextures["attack1"];
attack1P.Width = 2880;
attack1P.Height = 480;
plebTextures["attack1"] = attack1P;

Texture2D attack2P = plebTextures["attack2"];
attack2P.Width = 1920;
attack2P.Height = 480;
plebTextures["attack2"] = attack2P;



//*******CONDITIONS/STATES BELOW**************


string ladyCondition = "idle";

string monkCondition = "idle";

string plebCondition = "idle";



//****************LADY BELOW********************************

int numFramesL = 9;
float frameWidthL = (float)(ladyFighterEat.Width / numFramesL);
float timerL = 0.0f;
int frameL = 0;
int maxFramesL = (int)(ladyFighterEat.Width / (int)frameWidthL);

int numFramesLI = 9;
float frameWidthLI = (float)(ladyTextures["idle"].Width / numFramesLI);
float timerLI = 0.0f;
int frameLI = 0;
int maxFramesLI = (int)(ladyTextures["idle"].Width / (int)frameWidthLI);

int numFramesLW = 8;
float frameWidthLW = (float)(ladyTextures["walk"].Width / numFramesLW);
float timerLW = 0.0f;
int frameLW = 0;
int maxFramesLW = (int)(ladyTextures["walk"].Width / (int)frameWidthLW);

int numFramesLA1 = 6;
float frameWidthLA1 = (float)(ladyTextures["attack1"].Width / numFramesLA1);
float timerLA1 = 0.0f;
int frameLA1 = 0;
int maxFramesLA1 = (int)(ladyTextures["attack1"].Width / (int)frameWidthLA1);

int numFramesLA2 = 8;
float frameWidthLA2 = (float)(ladyTextures["attack2"].Width / numFramesLA2);
float timerLA2 = 0.0f;
int frameLA2 = 0;
int maxFramesLA2 = (int)(ladyTextures["attack2"].Width / (int)frameWidthLA2);

int numFramesLB = 8;
float frameWidthLB = (float)(ladyTextures["walk"].Width / numFramesLB);
float timerLB = 0.0f;
int frameLB = 0;
int maxFramesLB = (int)(ladyTextures["walk"].Width / (int)frameWidthLB);

int numFramesLJ = 10;
float frameWidthLJ = (float)(ladyTextures["jump"].Width / numFramesLJ);
float timerLJ = 0.0f;
int frameLJ = 0;
int maxFramesLJ = (int)(ladyTextures["jump"].Width / (int)frameWidthLJ);




//*********MONK BELOW***********************************





int numFramesM1 = 7;
float frameWidthM1 = (float)(monkFighterIdle1.Width / numFramesM1);
float timerM1 = 0.0f;
int frameM1 = 0;
int maxFramesM1 = (int)(monkFighterIdle1.Width / (int)frameWidthM1);

int numFramesM = 7;
float frameWidthM = (float)(monkTextures["idle"].Width / numFramesM);
float timerM = 0.0f;
int frameM = 0;
int maxFramesM = (int)(monkTextures["idle"].Width / (int)frameWidthM);

int numFramesMW = 7;
float frameWidthMW = (float)(monkTextures["walk"].Width / numFramesMW);
float timerMW = 0.0f;
int frameMW = 0;
int maxFramesMW = (int)(monkTextures["walk"].Width / (int)frameWidthMW);

int numFramesMB = 7;
float frameWidthMB = (float)(monkTextures["walk"].Width / numFramesMB);
float timerMB = 0.0f;
int frameMB = 0;
int maxFramesMB = (int)(monkTextures["walk"].Width / (int)frameWidthMB);

int numFramesMR = 8;
float frameWidthMR = (float)(monkTextures["run"].Width / numFramesMR);
float timerMR = 0.0f;
int frameMR = 0;
int maxFramesMR = (int)(monkTextures["run"].Width / (int)frameWidthMR);

int numFramesMJ = 9;
float frameWidthMJ = (float)(monkTextures["jump"].Width / numFramesMJ);
float timerMJ = 0.0f;
int frameMJ = 0;
int maxFramesMJ = (int)(monkTextures["jump"].Width / (int)frameWidthMJ);

int numFramesMA1 = 5;
float frameWidthMA1 = (float)(monkTextures["attack1"].Width / numFramesMA1);
float timerMA1 = 0.0f;
int frameMA1 = 0;
int maxFramesMA1 = (int)(monkTextures["attack1"].Width / (int)frameWidthMA1);




//**********PLEB BELOW**********************************


int numFramesP = 6;
float frameWidthP = (float)(plebFighterIdle1.Width / numFramesP);
float timerP = 0.0f;
int frameP = 0;
int maxFramesP = (int)(plebFighterIdle1.Width / (int)frameWidthP);

int numFramesPI = 6;
float frameWidthPI = (float)(plebTextures["idle"].Width / numFramesPI);
float timerPI = 0.0f;
int framePI = 0;
int maxFramesPI = (int)(plebTextures["idle"].Width / (int)frameWidthPI);

int numFramesPW = 8;
float frameWidthPW = (float)(plebTextures["walk"].Width / numFramesPW);
float timerPW = 0.0f;
int framePW = 0;
int maxFramesPW = (int)(plebTextures["walk"].Width / (int)frameWidthPW);

int numFramesPB = 8;
float frameWidthPB = (float)(plebTextures["walk"].Width / numFramesPB);
float timerPB = 0.0f;
int framePB = 0;
int maxFramesPB = (int)(plebTextures["walk"].Width / (int)frameWidthPB);

int numFramesPR = 6;
float frameWidthPR = (float)(plebTextures["run"].Width / numFramesPR);
float timerPR = 0.0f;
int framePR = 0;
int maxFramesPR = (int)(plebTextures["run"].Width / (int)frameWidthPR);

int numFramesPJ = 8;
float frameWidthPJ = (float)(plebTextures["jump"].Width / numFramesPJ);
float timerPJ = 0.0f;
int framePJ = 0;
int maxFramesPJ = (int)(plebTextures["jump"].Width / (int)frameWidthPJ);

int numFramesPA1 = 6;
float frameWidthPA1 = (float)(plebTextures["attack1"].Width / numFramesPA1);
float timerPA1 = 0.0f;
int framePA1 = 0;
int maxFramesPA1 = (int)(plebTextures["attack1"].Width / (int)frameWidthPA1);

int numFramesPA2 = 4;
float frameWidthPA2 = (float)(plebTextures["attack2"].Width / numFramesPA2);
float timerPA2 = 0.0f;
int framePA2 = 0;
int maxFramesPA2 = (int)(plebTextures["attack2"].Width / (int)frameWidthPA2);




int ladyX = 100;
int ladyY = 330;

int monkX = 100;
int monkY = 500;

int plebX = 100;
int plebY = 500;

string chosenCharacter = "none";

Boolean attack1 = false;

Boolean attack2 = false;

Boolean jump = false;

int frameWidth = 0;

Rectangle HitboxL = new Rectangle(ladyX, ladyY, frameWidth, 640);

Rectangle HitboxM = new Rectangle(monkX, monkY, frameWidth, 480);

Rectangle HitboxP = new Rectangle(plebX, plebY, frameWidth, 480);


int currentRoom = 0;

string currentBackground = "dojo";

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
        for (int i = 0; i < 1.2; i++)
        {
            timerL += Raylib.GetFrameTime();
            if (timerL >= 0.2f)
            {
                timerL = 0.0f;
                frameL += 1;
            }

            frameL = frameL % maxFramesL;
        }

        for (int i = 0; i < 1.2; i++)
        {
            timerM1 += Raylib.GetFrameTime();
            if (timerM1 >= 0.2f)
            {
                timerM1 = 0.0f;
                frameM1 += 1;
            }

            frameM1 = frameM1 % maxFramesM1;
        }

        for (int i = 0; i < 1.2; i++)
        {
            timerP += Raylib.GetFrameTime();
            if (timerP >= 0.2f)
            {
                timerP = 0.0f;
                frameP += 1;
            }

            frameP = frameP % maxFramesP;
        }

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
        if (ladyX >= screenWidth || monkX >= screenWidth || plebX >= screenWidth)
        {
            currentBackground = "castle";
        }


        if (chosenCharacter == "ladyFighter") //****LADYFIGHTER***************************************************************
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

            if (Raylib.IsKeyPressed(KeyboardKey.E))
            {
                attack2 = true;
            }

            if (attack2 == true)
            {
                ladyCondition = "attack2";

                timerLA2 += Raylib.GetFrameTime();
                if (timerLA2 >= 0.2f)
                {
                    timerLA2 = 0.0f;
                    frameLA2 += 1;
                }

                frameLA2 = frameLA2 % maxFramesLA2;

                if (frameLA2 == 7)
                {
                    attack2 = false;
                    ladyCondition = "idle";
                    frameLA2 = 0;
                }
            }




        }

        else if (chosenCharacter == "monkFighter") //***** MONKFIGHTER*******************************************************************************
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

            timerMR += Raylib.GetFrameTime();
            if (timerMR >= 0.2f)
            {
                timerMR = 0.0f;
                frameMR += 1;
            }

            frameMR = frameMR % maxFramesMR;

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

            if (Raylib.IsKeyDown(KeyboardKey.LeftShift) && Raylib.IsKeyDown(KeyboardKey.D))
            {
                monkCondition = "run";
                monkX += 4;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                jump = true;
            }

            if (jump == true)
            {
                monkCondition = "jump";

                timerMJ += Raylib.GetFrameTime();
                if (timerMJ >= 0.2f)
                {
                    timerMJ = 0.0f;
                    frameMJ += 1;
                }



                frameMJ = frameMJ % maxFramesMJ;

                if (frameMJ > 1 && frameMJ < 4)
                {

                    monkY -= 1;
                }

                else if (frameMJ == 4)
                {
                    monkY -= 0;
                    monkY += 0;
                }

                else if (frameMJ > 4)
                {
                    monkY += 1;
                }

                if (frameMJ == 8)
                {
                    jump = false;
                    monkCondition = "idle";
                    monkY = 500;
                    frameMJ = 0;
                }
            }

            else if (Raylib.IsKeyUp(KeyboardKey.A) && Raylib.IsKeyUp(KeyboardKey.D))
            {
                monkCondition = "idle";
            }

            if (Raylib.IsKeyPressed(KeyboardKey.F))
            {
                attack1 = true;
            }

            if (attack1 == true)
            {
                monkCondition = "attack1";

                timerMA1 += Raylib.GetFrameTime();
                if (timerMA1 >= 0.2f)
                {
                    timerMA1 = 0.0f;
                    frameMA1 += 1;
                }

                frameMA1 = frameMA1 % maxFramesMA1;

                if (frameMA1 == 4)
                {
                    attack1 = false;
                    monkCondition = "idle";
                    frameMA1 = 0;
                }
            }

            if (Raylib.IsKeyPressed(KeyboardKey.E))
            {
                attack2 = true;
            }

            if (attack2 == true)
            {
                monkCondition = "attack2";

                timerMA1 += Raylib.GetFrameTime();
                if (timerMA1 >= 0.2f)
                {
                    timerMA1 = 0.0f;
                    frameMA1 += 1;
                }

                frameMA1 = frameMA1 % maxFramesMA1;

                if (frameMA1 == 4)
                {
                    attack2 = false;
                    monkCondition = "idle";
                    frameMA1 = 0;
                }
            }

        }


        else if (chosenCharacter == "plebFighter")  //******PLEBFIGHTER**************************************************************
        {
            timerPI += Raylib.GetFrameTime();
            if (timerPI >= 0.2f)
            {
                timerPI = 0.0f;
                framePI += 1;
            }

            framePI = framePI % maxFramesPI;

            timerPW += Raylib.GetFrameTime();
            if (timerPW >= 0.2f)
            {
                timerPW = 0.0f;
                framePW += 1;
            }

            framePW = framePW % maxFramesPW;

            timerPB -= Raylib.GetFrameTime();
            if (timerPB <= 0.0f)
            {
                timerPB = 0.2f;
                framePB -= 1;
            }

            framePB = framePB % maxFramesPB;

            timerPR += Raylib.GetFrameTime();
            if (timerPR >= 0.2f)
            {
                timerPR = 0.0f;
                framePR += 1;
            }

            framePR = framePR % maxFramesPR;

            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                plebCondition = "walk";
                plebX += 2;
            }

            else if (Raylib.IsKeyDown(KeyboardKey.A))
            {

                plebCondition = "back";
                plebX -= 2;
            }

            if (Raylib.IsKeyDown(KeyboardKey.LeftShift) && Raylib.IsKeyDown(KeyboardKey.D))
            {
                plebCondition = "run";
                plebX += 4;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                jump = true;
            }

            if (jump == true)
            {
                plebCondition = "jump";

                timerPJ += Raylib.GetFrameTime();
                if (timerPJ >= 0.2f)
                {
                    timerPJ = 0.0f;
                    framePJ += 1;
                }



                framePJ = framePJ % maxFramesPJ;

                if (framePJ > 1 && framePJ < 3)
                {

                    plebY -= 1;
                }

                else if (framePJ == 4)
                {
                    plebY -= 0;
                    plebY += 0;
                }

                else if (framePJ > 4)
                {
                    plebY += 1;
                }

                if (framePJ == 7)
                {
                    jump = false;
                    plebCondition = "idle";
                    plebY = 500;
                    framePJ = 0;
                }
            }

            else if (Raylib.IsKeyUp(KeyboardKey.A) && Raylib.IsKeyUp(KeyboardKey.D))
            {
                plebCondition = "idle";
            }

            if (Raylib.IsKeyPressed(KeyboardKey.F))
            {
                attack1 = true;
            }

            if (attack1 == true)
            {
                plebCondition = "attack1";

                timerPA1 += Raylib.GetFrameTime();
                if (timerPA1 >= 0.2f)
                {
                    timerPA1 = 0.0f;
                    framePA1 += 1;
                }

                framePA1 = framePA1 % maxFramesPA1;

                if (framePA1 == 5)
                {
                    attack1 = false;
                    plebCondition = "idle";
                    framePA1 = 0;
                }
            }

            if (Raylib.IsKeyPressed(KeyboardKey.E))
            {
                attack2 = true;
            }

            if (attack2 == true)
            {
                plebCondition = "attack2";

                timerPA2 += Raylib.GetFrameTime();
                if (timerPA2 >= 0.2f)
                {
                    timerPA2 = 0.0f;
                    framePA2 += 1;
                }

                framePA2 = framePA2 % maxFramesPA2;

                if (framePA2 == 3)
                {
                    attack2 = false;
                    plebCondition = "idle";
                    framePA2 = 0;
                }
            }



        }

    }

    void animation(float frameWidthHere, int frame, int x, int y, Texture2D texture)
    {
        frameWidth = (int)frameWidthHere;
        Raylib.DrawTextureRec(
                        texture,
                        new Rectangle((frameWidthHere * frame), 0, frameWidthHere, (float)texture.Height),
                        new Vector2(x, y),
                        Color.White);
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

        animation(frameWidthL, frameL, 100, 50, ladyFighterEat);

        animation(frameWidthM1, frameM1, 600, 400, monkFighterIdle1);

        animation(frameWidthP, frameP, 900, 350, plebFighterIdle1);


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

    else if (currentRoom == 2)  //************** ROOM 2 ***************
    {
        Raylib.DrawTexture(pixelDojo, 0, 0, Color.White);
        Raylib.DrawText("Controls:", 100, 100, 42, Color.White);
        Raylib.DrawText("Movement: A, D, SPACE, SHIFT + D", 100, 200, 40, Color.White);
        Raylib.DrawText("Combat: F, E", 100, 300, 40, Color.White);
        if (chosenCharacter == "ladyFighter")     //******* LADY BELOW******************************
        {

            if (ladyCondition == "idle")
            {
                animation(frameWidthLI, frameLI, ladyX, ladyY, ladyTextures["idle"]);
            }

            else if (ladyCondition == "walk")
            {
                animation(frameWidthLW, frameLW, ladyX, ladyY, ladyTextures["walk"]);
            }

            else if (ladyCondition == "back")
            {
                animation(frameWidthLB, frameLB, ladyX, ladyY, ladyTextures["walk"]);
            }

            else if (ladyCondition == "run")
            {
                animation(frameWidthLW, frameLW, ladyX, ladyY, ladyTextures["run"]);
            }

            else if (ladyCondition == "jump")
            {
                animation(frameWidthLJ, frameLJ, ladyX, ladyY, ladyTextures["jump"]);
            }

            else if (ladyCondition == "attack1")
            {
                frameWidth = (int)frameWidthLA1;
                Raylib.DrawTextureRec(
                                ladyTextures["attack1"],
                                new Rectangle((frameWidthLA1 * frameLA1) + 20, 0, frameWidthLA1, (float)ladyTextures["attack1"].Height),
                                new Vector2(ladyX, ladyY),
                                Color.White);
            }

            else if (ladyCondition == "attack2")
            {
                frameWidth = (int)frameWidthLA2;
                Raylib.DrawTextureRec(
                                ladyTextures["attack2"],
                                new Rectangle((frameWidthLA2 * frameLA2) + 20, 0, frameWidthLA2, (float)ladyTextures["attack2"].Height),
                                new Vector2(ladyX, ladyY),
                                Color.White);
            }

        }

        else if (chosenCharacter == "monkFighter")    //************** MONK BELOW ****************************
        {

            if (monkCondition == "idle")
            {
                animation(frameWidthM, frameM, monkX, monkY, monkTextures["idle"]);
            }

            else if (monkCondition == "walk")
            {
                animation(frameWidthMW, frameMW, monkX, monkY, monkTextures["walk"]);
            }

            else if (monkCondition == "back")
            {
                animation(frameWidthMB, frameMB, monkX, monkY, monkTextures["walk"]);
            }

            else if (monkCondition == "run")
            {
                animation(frameWidthMR, frameMR, monkX, monkY, monkTextures["run"]);
            }

            else if (monkCondition == "jump")
            {
                animation(frameWidthMJ, frameMJ, monkX, monkY, monkTextures["jump"]);
            }

            else if (monkCondition == "attack1")
            {
                animation(frameWidthMA1, frameMA1, monkX, monkY, monkTextures["attack1"]);
            }

            else if (monkCondition == "attack2")
            {
                animation(frameWidthMA1, frameMA1, monkX, monkY, monkTextures["attack2"]);
            }

        }

        else if (chosenCharacter == "plebFighter")    // ******************** PLEB BELOW ***************************
        {

            if (plebCondition == "idle")
            {
                animation(frameWidthPI, framePI, plebX, plebY, plebTextures["idle"]);
            }

            else if (plebCondition == "walk")
            {
                animation(frameWidthPW, framePW, plebX, plebY, plebTextures["walk"]);
            }

            else if (plebCondition == "back")
            {
                animation(frameWidthPB, framePB, plebX, plebY, plebTextures["walk"]);
            }

            else if (plebCondition == "run")
            {
                animation(frameWidthPR, framePR, plebX, plebY, plebTextures["run"]);
            }

            else if (plebCondition == "jump")
            {
                animation(frameWidthPJ, framePJ, plebX, plebY, plebTextures["jump"]);
            }

            else if (plebCondition == "attack1")
            {
                animation(frameWidthPA1, framePA1, plebX, plebY, plebTextures["attack1"]);
            }

            else if (plebCondition == "attack2")
            {
                animation(frameWidthPA2, framePA2, plebX, plebY, plebTextures["attack2"]);
            }

        }

    }



    Raylib.EndDrawing();
}
