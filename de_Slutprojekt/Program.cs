using Raylib_cs;

int display = Raylib.GetCurrentMonitor();    //get monitor display

const int screenWidth = 800;                 //original window size
const int screenHeight = 450;                //original window size

int monitordisplay = Raylib.GetCurrentMonitor();    //get monitor display

Raylib.InitWindow(screenWidth, screenHeight, "VidoGam");    //set window size
Raylib.SetTargetFPS(60);                                   //set target fps for the window

Texture2D pixelDojo = Raylib.LoadTexture("PixelDojo.png");

pixelDojo.Width = Raylib.GetMonitorWidth(monitordisplay);
pixelDojo.Height = Raylib.GetMonitorHeight(monitordisplay);

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

    if (currentRoom == 0) // ROOM 0**********************************************************************************************************
    {
        Raylib.DrawTexture(pixelDojo, 0, 0, Color.White);
        Raylib.DrawText("Press Alt + Enter to toggle fullscreen", 100, 100, 30, Color.White);


        Raylib.DrawText("Press [P] to play", screenWidth / 2 + 110, screenHeight, 100, Color.Gold);

        if (Raylib.IsKeyPressed(KeyboardKey.P))
        {
            currentRoom = 1;
        }
    }             //*************************************************************************************************************

    if (currentRoom == 1) {

        
    }

    Raylib.EndDrawing();
}
