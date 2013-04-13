namespace _1.Events
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MainClass
    {
        static void Main(string[] args)
        {
            string currentDirectoryPath = Directory.GetCurrentDirectory();
            string filePath = currentDirectoryPath + "/" + "commands.txt";

            List<string> commands = CommandsProvider.GetCommands(filePath);

            EventsList.ExecuteAllCommands(commands);

            Console.WriteLine(EventMessageSubscriber.Output);
        }
    }
}
