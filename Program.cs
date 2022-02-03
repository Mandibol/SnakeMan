using SnakeMan;
using System.Runtime.InteropServices;
using System.Media;

/// <summary>
/// ITS THE PROGRAM
/// </summary>/
class Program
{
    const int MF_BYCOMMAND = 0x00000000;
    const int SC_MINIMIZE = 0xF020;
    const int SC_MAXIMIZE = 0xF030;
    const int SC_SIZE = 0xF000;

    [DllImport("user32.dll")]
    static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

    [DllImport("user32.dll")]
    static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

    [DllImport("kernel32.dll", ExactSpelling = true)]
    static extern IntPtr GetConsoleWindow();

    //Settings
    internal static int frameRate = 10; //  Adjusting the speed of the game, Defualt 10
    internal static ConsoleKey key; // keyInput from user
    internal static int GameWidth = 24;
    internal static int GameHeight = 24;


    /// <summary>
    /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
    /// </summary>
    static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

    static void Loop()
    {
        // Initializing the game
        GameWorld world = new GameWorld(GameWidth, GameHeight);
        ConsoleRenderer renderer = new ConsoleRenderer(world);
        bool running = true; // Running Checks if the game is still on(True = the game is running) False = Game over))

    // Crearing the player and Food object, and setting a defualt spawn position.
    // Adding the objects to the gameObjects List.
    Player player = new Player("██", world.width/2, world.height/2, world);
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
            //Running Checks if the game is still on(True = the game is running) False = Game over))
            if (world.running == false)
            {
                running = world.running;
            }
            
        }

        Console.SetCursorPosition(renderer.displayWidth/2 - 8, renderer.displayHeight / 2);
        Console.Write("Your Score: " + world.score);

        // Press "Escape" to end the application when promted.
        string message = "Press <Escape> To Exit";
        Console.SetCursorPosition(renderer.displayWidth / 2 - message.Length / 2, renderer.displayHeight / 2 + 1);
        Console.Write(message);
        while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }

    }

    static void Main(string[] args)
    {
        //Set window Size
        Console.WindowWidth = GameWidth * 2 + 2;
        Console.WindowHeight = GameHeight + 4;

        //Disable Window rezising and lock window size
        DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
        DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
        DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_SIZE, MF_BYCOMMAND);

        // Hide cursor
        Console.CursorVisible = false;

        //Add background Music
        if (OperatingSystem.IsWindows())
        {
            SoundPlayer player = new SoundPlayer("Hero.wav");
            player.Load();
            player.PlayLooping();
        }

        // For-loop for rendering out background and the HUD.
        for (int y = 0; y < Console.WindowHeight; y++)
        {
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                Console.SetCursorPosition(x, y);
                if (x == Console.WindowWidth / 2 - 4 && y == 1) { Console.Write("SNAKEMAN"); }
                else if (x == 0 && y == 0) { Console.Write("╔"); }
                else if (x == Console.WindowWidth - 1 && y == 0) { Console.Write("╗"); }
                else if (x == 0 && y == 2) { Console.Write("╠"); }
                else if (x == Console.WindowWidth - 1 && y == 2) { Console.Write("╣"); }
                else if (x == 0 && y == Console.WindowHeight - 1) { Console.Write("╚"); }
                else if (x == Console.WindowWidth - 1 && y == Console.WindowHeight - 1) { Console.Write("╝"); }
                else if (y == Console.WindowHeight - 1 || y == 0 || y == 2) { Console.Write("═"); }
                else if (x == 0 || x == Console.WindowWidth - 1) { Console.Write("║"); }
            }
        }
        string message = "Press Any Key to Start Game";
        Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2);
        Console.Write(message);
        Console.ReadLine();
        Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2);
        Console.Write("                           ");

        //Start the GameLoop
        Loop();
    }
}

