using Raylib_cs;
using System.Numerics;

class ladyFighter
{


    public Rectangle Hitbox = new(100, 100, 500, 500);

    public float Speed = 3;
    public void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.A)) Hitbox.X -= Speed;
        if (Raylib.IsKeyDown(KeyboardKey.D)) Hitbox.X += Speed;

    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(Hitbox, Color.White);
    }
}
class monkFighter
{
    public Rectangle Hitbox = new();
}
class plebFighter
{
    public Rectangle Hitbox = new();
}

class Player
{
    public Rectangle Hitbox = new(760, 550, 80, 20);
    public Color Colour = Color.Black;
    public int Hitpoints = 100;
    public int HitpointMax = 100;
    public int Level = 1;
    public int Exp = 0;
    public float Speed = 3;

    public void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.Left)) Hitbox.X -= Speed;
        if (Raylib.IsKeyDown(KeyboardKey.Right)) Hitbox.X += Speed;

    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(Hitbox, Colour);
    }
}