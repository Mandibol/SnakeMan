using SnakeMan;
/// <summary>
/// ITS THE PROGRAM
/// </summary>/
class Program
{
    //Settings

    internal static readonly int worldWidth = 32;  // The entire size of the map Width
    internal static readonly int worldHeight = 32; // The entire Size of the map Height
    internal static readonly int marginLeft = 1; // MarginLeft Outside the playing area
    internal static readonly int marginRight = 1; //MarginRight  Outside the playing area
    internal static readonly int marginTop = 3; //marginTop Outside the playing area
    internal static readonly int marginDown = 1; //marginDown Outside the playing area
    internal static readonly int displayWidth = worldWidth * 2 + marginLeft + marginRight; // The size of the Window Width
    internal static readonly int displayHeight = worldHeight + marginTop + marginDown; // The Size of the Window Height
    internal static bool running = true; // Running Checks if the game is still on(True = the game is running) False = Game over))
    internal static int frameRate = 10; //  Adjusting the speed of the game, Defualt 10
    internal static ConsoleKey key; // keyInput from user


    /// <summary>
    /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
    /// </summary>
    static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

    static void Loop()
    {
        // Initializing the game
        GameWorld world = new GameWorld(displayWidth, displayHeight);
        ConsoleRenderer renderer = new ConsoleRenderer(world);

        // Crearing the player and Food object, and setting a defualt spawn position.
        // Adding the objects to the gameObjects List.
        Player player = new Player("██", worldWidth/2, worldHeight/2, world);
        Food food = new Food("@@", 10, 5, world);
        world.gameObjects.Add(player);
        world.gameObjects.Add(food);

        // Mainloop
        while (running)
        {
            // Remembers what the time was at start
            DateTime before = DateTime.Now;

            // Controls/checks the input from the user,
            // To Quit, press Q.
            key = ReadKeyIfExists();
            switch (key)
            {
                case ConsoleKey.Q:
                    running = false;
                    break;
            }

            // Uppdating and rendering the gameworld.
            renderer.RenderBlank();
            world.Update();
            renderer.Render();



     
            // Check how long time it took
            double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
            if (frameTime > 0)
            {
            
                // wait for right milliesecounds before next loop
                Thread.Sleep((int)frameTime);
            }
        }

        Console.SetCursorPosition(displayWidth/2 - 8, displayHeight/2);
        Console.Write("Your Score: " + world.score);

        // Press "Escape" to end the application when promted.
        string message = "Press <Escape> To Exit";
        Console.SetCursorPosition(displayWidth / 2 - message.Length / 2, displayHeight / 2 + 1);
        Console.Write(message);
        while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }

    }

    static void Main(string[] args)
    {
        Loop();
    }
}

