using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _1.Events
{
    class MainClass
    {
        static void Main(string[] args)
        {

            
            string currentDirectoryPath = Directory.GetCurrentDirectory();
            string filePath = currentDirectoryPath + "/" +"commands.txt";

            List<string> commands = CommandsProvider.GetCommands(filePath);

            EventsList.ExecuteAllCommands(commands);

            Console.WriteLine(EventMessageSubscriber.Output);
        }
    }
}
