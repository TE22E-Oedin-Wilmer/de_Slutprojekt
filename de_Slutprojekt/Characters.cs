// using Raylib_cs;
// using System;
// using System.Numerics;
// using System.Security.Cryptography.X509Certificates;

// public class LadyF
// {
//     public Texture2D ladyFighterWalk;
//     public int numFramesLW;
//     public float frameWidthLW;
//     public int frameLW;
//     public int maxFramesLW;
//     public float timerLW;

//     public LadyF()
//     {
//         ladyFighterWalk = Raylib.LoadTexture(@"C:\Users\wilmer.odin\Documents\ProgrammeringKurs\de_Slutprojekt\de_Slutprojekt\Kunoichi\Walk.png");
//         numFramesLW = 8;
//         frameWidthLW = (float)(ladyFighterWalk.Width / numFramesLW);
//         maxFramesLW = (int)(ladyFighterWalk.Width / (int)frameWidthLW);
//         timerLW = 0.0f;
//     }

//     public Rectangle Hitbox = new(100, 100, 500, 500);
//     public float Speed = 3;

//     public void Update()
//     {
//         // Uppdatera animationstimer
//         timerLW += Raylib.GetFrameTime();
//         if (timerLW >= 0.2f)
//         {
//             timerLW = 0.0f;
//             frameLW += 1;
//         }

//         frameLW = frameLW % maxFramesLW;

//         if (Raylib.IsKeyDown(KeyboardKey.A))
//         {
//             Hitbox.X -= Speed;
//         }

//         if (Raylib.IsKeyDown(KeyboardKey.D))
//         {
//             Hitbox.X += Speed;
//         }
//     }

//     public void Draw()
//     {
//         Raylib.DrawRectangleRec(Hitbox, Color.White);
//         Raylib.DrawTextureRec(
//             ladyFighterWalk,
//             new Rectangle(frameWidthLW * frameLW, 0, frameWidthLW, ladyFighterWalk.Height),
//             new Vector2(100, 50),
//             Color.White);
//     }
// }




// class MonkF
// {
//     public Rectangle Hitbox = new();
// }
// class PlebF
// {
//     public Rectangle Hitbox = new();
// }
