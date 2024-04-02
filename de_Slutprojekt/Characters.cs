using Raylib_cs;
using System.Numerics;

public class LadyF
{
    public Texture2D ladyFighterWalk;
    public int numFramesLW;
    public float frameWidthLW;
    public int frameLW;
    public int maxFramesLW;

    public LadyF()
    {
        ladyFighterWalk = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Kunoichi\Walk.png");
        numFramesLW = 8;
        frameWidthLW = (float)(ladyFighterWalk.Width / numFramesLW);
        maxFramesLW = (int)(ladyFighterWalk.Width / (int)frameWidthLW);
    }

    public Rectangle Hitbox = new(100, 100, 500, 500);
    public float Speed = 3;

    public void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            Hitbox.X -= Speed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            Hitbox.X += Speed;
        }
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(Hitbox, Color.White);
        Raylib.DrawTextureRec(
            ladyFighterWalk,
            new Rectangle(frameWidthLW * frameLW, 0, frameWidthLW, ladyFighterWalk.Height),
            new Vector2(100, 50),
            Color.White);
    }
}



class MonkF
{
    public Rectangle Hitbox = new();
}
class PlebF
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