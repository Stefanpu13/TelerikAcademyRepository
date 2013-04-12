using System;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace _1.Events
{
    class EventsList
    {
        static EventHolder events = new EventHolder();       
        
        internal static void ExecuteAllCommands(List<string> commands)
        {
            if (commands == null)
            {
                throw new ArgumentNullException("commands", "Commands list is not initialised.");
            }
            else
            {
                if (commands.Count == 0)
                {
                    string exceptionMessage = "Commands list does no contain any commands";
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    bool commandExecuted;
                    int commandIndex =0;

                    do
                    {
                        commandExecuted = ExecuteNextCommand(commands[commandIndex]);
                        commandIndex++;
                    } while (commandExecuted);
                }
            }
        }

        // TODO: Delete.
        // Should I change the name to "ReadAndExecuteNextCommand" or to 
        // leave the name and create separate functionality for reading commands. 
        private static bool ExecuteNextCommand(string command)
        {
            //string command = Console.ReadLine();
            if (command[0] == 'A')
            {
                AddEvent(command);
                return true;
            }
            if (command[0] == 'D')
            {
                DeleteEvents(command);
                return true;
            }
            if (command[0] == 'L')
            {
                ListEvents(command);
                return true;
            }
            if (command[0] == 'E')
            {
                return false;
            }
            return false;
        }

        private static void ListEvents(string command)
        {
            DateTime date = GetDate(command, "ListEvents");
            int pipeIndex = command.IndexOf('|');            
            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);

            events.ListEvents(date, count);
        }

        private static void DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);
            events.DeleteEvents(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;

            GetParameters(command, "AddEvent", out date, out title, out location);
            events.AddEvent(date, title, location);
        }

        private static void GetParameters(string commandForExecution, string commandType,
            out DateTime dateAndTime, out string eventTitle, out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');

            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.
                    Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }
    }
}

