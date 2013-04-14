namespace MinesSweeper
{
    using System;

    public class Messages
    {
        public static void PrintGreetingMessage()
        {
            Console.WriteLine("Let`s play minesweeper”. Find empty fields.");
        }

        public static void PrintInstructions()
        {
            Console.WriteLine(" 'top' - Shows rankings\n 'restart' -" +
                "Restarts the current game\n 'exit' - Exits the game\n");
        }

        public static void PrintYouDiedMessage(GameMetrics metrics)
        {
            Console.Write("\nHrrrrrr!You died. You opened {0} fields. ", metrics.OpenedEmptyFields);
        }

        public static void PrintYouOpenedAllFieldsMessage()
        {
            Console.WriteLine("\nBRAVOO!You opened all fields!!.");
        }
    }
}
