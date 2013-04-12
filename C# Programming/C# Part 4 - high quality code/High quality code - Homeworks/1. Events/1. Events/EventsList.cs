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
        
        private static bool ExecuteNextCommand(string command)
        {
            string commandAction = GetCommandAction(command);
            // If this row remains,the method makes two things - reads command from the console and 
            // then executes it. Either the method should be renaimed to "ReadAndExecuteNextCommand"
            // or the reading should be moved to different location.
            // I choose to move it to different class.
            //string command = Console.ReadLine();
            if (commandAction == "AddEvent")
            {
                AddEvent(command);
                return true;
            }
            if (commandAction == "DeleteEvents")
            {
                DeleteEvents(command);
                return true;
            }
            if (commandAction == "ListEvents")
            {
                ListEvents(command);
                return true;
            }
            if (commandAction == "End")
            {
                return false;
            }
            return false;
        }

        private static void ListEvents(string command)
        {
            DateTime eventsDate = GetDate(command, "ListEvents");
            int pipeIndex = command.IndexOf('|');            
            string countString = command.Substring(pipeIndex + 1);
            int eventsCount = int.Parse(countString);

            events.ListEvents(eventsDate, eventsCount);
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
            bool eventLocationProvided = (firstPipeIndex != lastPipeIndex);
            
            if (!eventLocationProvided)
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
            int dateFormatLength = 20;
            DateTime date = 
                DateTime.Parse(command.Substring(commandType.Length + 1, dateFormatLength));

            return date;
        }

        private static string GetCommandAction(string commandForExecution)
        {
            string commandAction;
            int actionStringLength = commandForExecution.IndexOf(" ");

            // Command action "End" does not have empty space, 
            if (actionStringLength > 0)
            {
                commandAction = commandForExecution.Substring(0, actionStringLength);
                return commandAction;
            }
            else
            {
                return commandForExecution;
            }
        }
    }
}

