namespace ConsoleMenu
{
    // Example with a Mainmenu & Submenu with 3 and 4 options respectively.
    // menuTag is the caption, this example code outputs "Mainmenu" & "Submenu".
    // The currently marked option in the menues are shown with green text.
    // After executed menu option code the menue always reset to the first menu option in said menu.
    public class Menu
    {
        private delegate void HandleOption(int option);
        private static readonly bool menuInput = true;
        private int option;

        private static string[] MainOptions { get; } = { "Mainmenu option #1", "Mainmenu option #2", "Mainmenu option #2", "Submenu", "Exit program" };
        private static string[] SubOptions { get; } = { "Submenu option #1", "Submenu option #2", "Submenu option #3", "Submenu option #4", "Mainmenu" };

        public void MainMenu()
        {
            option = 1;
            DisplayMenu("Mainmenu", MainOptions, HandleMainOption);
        }

        private void SubMenu()
        {
            option = 1;
            DisplayMenu("Submenu", SubOptions, HandleSubOption);
        }

        private void DisplayMenu(string menuTag, string[] options, HandleOption handler)
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
                        handler(option);
                        return;
                    default:
                        break;
                }

            } while (menuInput);
        }

        private void DisplayMenuOptions(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.ForegroundColor = option == i + 1 ? ConsoleColor.Green : ConsoleColor.Gray;
                Console.WriteLine($"{(i + 1 == option ? "  ► " : "    ")}{options[i]}");
            }
        }
        private void HandleMainOption(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Mainmenu option #1");
                    break;
                case 2:
                    Console.WriteLine("Mainmenu option #2");
                    break;
                case 3:
                    Console.WriteLine("Mainmenu option #3");
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
        }

        private void HandleSubOption(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Sub menu option #1");
                    break;
                case 2:
                    Console.WriteLine("Sub menu option #2");
                    break;
                case 3:
                    Console.WriteLine("Sub menu option #2");
                    break;
                case 4:
                    Console.WriteLine("Sub menu option #4");
                    break;
                case 5:
                    MainMenu();
                    break;
            }
        }
    }
}
