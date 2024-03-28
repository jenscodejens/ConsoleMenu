namespace ConsoleMenu
{
    public static class Menu
    {
        // TODO: Centrering av meny tag vs längden på options
        // TODO: Inramning

        private delegate void HandleOption(int option);
        private static readonly bool menuInput = true;
        private static int option = 1;

        private static string[] MainOptions { get; } = ["Menu item #1", "Menu item #2", "Menu item #3", "Submenu", "Exit program"];
        private static string[] SubOptions { get; } = ["Submenu item #1", "Submenu item #2", "Submenu item #3", "Submenu item #4", "Mainmenu"];

        public static void MainMenu()
        {
            DisplayMenu("Mainmenu", MainOptions, HandleMainOption);
        }

        private static void SubMenu()
        {
            DisplayMenu("Submenu", SubOptions, HandleSubOption);
        }
        private static void DisplayMenu(string menuTag, string[] options, HandleOption handleOption)
        {
            do
            {
                Console.Clear();
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"    {menuTag}\n");
                Console.ResetColor();

                DisplayMenuOptions(options);

                ConsoleKeyInfo key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? options.Length : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == options.Length ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        handleOption(option);
                        break;
                    default:
                        break;
                }

            } while (menuInput);
        }

        private static void DisplayMenuOptions(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.ForegroundColor = option == i + 1 ? ConsoleColor.Green : ConsoleColor.Gray;
                Console.WriteLine($"{(i + 1 == option ? "  ► " : "    ")}{options[i]}");
            }
        }

        private static void HandleMainOption(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Menu item #1");
                    break;
                case 2:
                    Console.WriteLine("Menu item #2");
                    break;
                case 3:
                    Console.WriteLine("Menu item #3");
                    break;
                case 4:
                    SubMenu();
                    break;
                case 5:
                    Console.ResetColor();
                    Console.WriteLine("\nClosing the application");
                    Environment.Exit(0);
                    break;
            }

            Console.ReadKey();
        }

        private static void HandleSubOption(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Submenu item #1");
                    break;
                case 2:
                    Console.WriteLine("Submenu item #2");
                    break;
                case 3:
                    Console.WriteLine("Submenu item #3");
                    break;
                case 4:
                    Console.WriteLine("Submenu item #4");
                    break;
                case 5:
                    MainMenu();
                    break;
            }
            Console.ReadKey();
        }
    }
}
