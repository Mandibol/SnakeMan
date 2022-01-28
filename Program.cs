using SnakeMan;

class Program
{

    /// <summary>
    /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
    /// </summary>
    static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

    static void Loop()
    {
        //Backgrunden och HUD ritas ut.
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║                 LABYRINT                 ║");
        Console.WriteLine("╠══════════════════════════════════════════╣");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("╠══════════════════════════════════════════╣");
        Console.WriteLine("║ Arrows : Move                 Esc : Exit ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
        // Initialisera spelet
        const int frameRate = 6;
        GameWorld world = new GameWorld(50,25);
        ConsoleRenderer renderer = new ConsoleRenderer(world);

        // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
        // ...
        Player player = new Player('■', 25, 10);
        Food food = new Food('@', 10, 5);
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

