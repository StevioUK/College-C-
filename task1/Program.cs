using System;
using System.Collections.Generic;

namespace task1
{
    public class CLIMenu
    {
        List<string> diary = new List<String>();
        public void CLIShow()
        {
            for(int i = 0; i < diary.Count; i++)
            {
                Console.WriteLine(diary[i]);
            }
        }

        public void CLIAdd()
        {
            Console.WriteLine("Enter the note you would like to add: ");
            string appendString = Console.ReadLine();
            diary.Add(appendString);
        }

        public void CLISearch()
        {
            Console.WriteLine("Enter the word you would like to find: ");
            string searchedString = Console.ReadLine();
            bool foundString = false;
            for (int i = 0; i < diary.Count; i++)
            {
                if(diary[i].Contains(searchedString))
                {
                    Console.WriteLine(diary[i]);
                    foundString = true;
                    break;
                }
                if(!foundString)
                {
                    Console.WriteLine("Could not find your word in the diary");
                }
            }
        }

        public void CLIQuit()
        {
            System.Environment.Exit(0);
        }
    }

    class Task1
    {
        static void Main()
        {
            CLIMenu cli = new CLIMenu();
            while (true)
            {
                Console.WriteLine("Enter what action you would like to perform (Add, Search, Show, Quit): ");
                string action = Console.ReadLine();
                action = action.ToLower();

                switch (action) {
                    case "show":
                        cli.CLIShow();
                        break;

                    case "add":
                        cli.CLIAdd();
                        break;

                    case "search":
                        cli.CLISearch();
                        break;

                    case "quit":
                        cli.CLIQuit();
                        break;

                    default:
                        Console.WriteLine("Incorrect");
                        break;
                }
            }
        }
    }
}
