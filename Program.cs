using SnakeMan;

class Program
{
    //Settings
    internal static readonly int worldWidth = 24;
    internal static readonly int worldHeight = 24;
    internal static readonly int marginLeft = 1;
    internal static readonly int marginRight = 1;
    internal static readonly int marginTop = 3;
    internal static readonly int marginDown = 1;
    internal static readonly int displayWidth = worldWidth * 2 + marginLeft + marginRight;
    internal static readonly int displayHeight = worldHeight + marginTop + marginDown;

    /// <summary>
    /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
    /// </summary>
    static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

    static void Loop()
    {
        //Backgrunden och HUD ritas ut.
        for (int y = 0; y < displayHeight; y++)
        {
            for (int x = 0; x < displayWidth; x++)
            {
                Console.SetCursorPosition(x, y);
                if (x == 21 && y == 1) { Console.Write("SNAKEMAN"); }
                else if (x == 0 && y == 0) { Console.Write("╔"); }
                else if (x == displayWidth - 1 && y == 0) { Console.Write("╗"); }
                else if (x == 0 && y == 2) { Console.Write("╠"); }
                else if (x == displayWidth - 1 && y == 2) { Console.Write("╣"); }
                else if (x == 0 && y == displayHeight - 1) { Console.Write("╚"); }
                else if (x == displayWidth - 1 && y == displayHeight - 1) { Console.Write("╝"); }
                else if (y == displayHeight-1 || y == 0 || y == 2) { Console.Write("═"); }
                else if (x == 0 || x == displayWidth-1) { Console.Write("║"); }
            }
        }


        // Initialisera spelet
        const int frameRate = 10;
        GameWorld world = new GameWorld(displayWidth, displayHeight);
        ConsoleRenderer renderer = new ConsoleRenderer(world);

        // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
        // ...
        Player player = new Player("██", 12, 12);
        Food food = new Food("@@", 10, 5);
        world.gameObjects.Add(player);
        world.gameObjects.Add(food);

        // Huvudloopen
        bool running = true;
        while (running)
        {
            // Kom ihåg vad klockan var i början
            DateTime before = DateTime.Now;

            // Hantera knapptryckningar från användaren
            ConsoleKey key = ReadKeyIfExists();
            switch (key)
            {
                case ConsoleKey.Q:
                    running = false;
                    break;
                case ConsoleKey.LeftArrow:
                    player.direction = Player.Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    player.direction = Player.Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    player.direction = Player.Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    player.direction = Player.Direction.Down;
                    break;


                    // TODO Lägg till logik för andra knapptryckningar
                    // ...
            }

            // Uppdatera världen och rendera om
            renderer.RenderBlank();
            world.Update();
            renderer.Render();



            // Mät hur lång tid det tog
            double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
            if (frameTime > 0)
            {
                // Vänta rätt antal millisekunder innan loopens nästa varv
                Thread.Sleep((int)frameTime);
            }
        }
    }

    static void Main(string[] args)
    {
        // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
        Loop();
    }
}

