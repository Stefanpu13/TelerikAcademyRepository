namespace _1.Events
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class CommandsProvider
    {
        /// <summary>
        /// Gets the commands from a "txt" file located in the current working directory. 
        /// </summary>
        /// <param name="filePath">The name of the txt file. </param>
        /// <returns>A list of string commands.</returns>        
        internal static List<string> GetCommands(string filePath)
        {
            StreamReader commandFileReader;
            string line;
            List<string> allComands = new List<string>();

            try
            {
                using (commandFileReader = new StreamReader(filePath))
                {
                    while ((line = commandFileReader.ReadLine()) != null)
                    {
                        allComands.Add(line);
                    }
                }
            }
            catch (FileNotFoundException)
            { 
                Console.WriteLine("File " + filePath + " was not found.");
            }

            return allComands;
        }
    }
}