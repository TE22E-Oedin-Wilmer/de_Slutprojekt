using Raylib_cs;

int display = Raylib.GetCurrentMonitor();    //get monitor display

const int screenWidth = 800;                 //original window size
const int screenHeight = 450;                //original window size

int monitordisplay = Raylib.GetCurrentMonitor();    //get monitor display

Raylib.InitWindow(screenWidth, screenHeight, "VidoGam");    //set window size
Raylib.SetTargetFPS(60);                                   //set target fps for the window

Texture2D PixelDojo = Raylib.LoadTexture("PixelDojo.png");

int currentRoom = 0;

while (!Raylib.WindowShouldClose())
{

    if (currentRoom == 0)
    { }
}
