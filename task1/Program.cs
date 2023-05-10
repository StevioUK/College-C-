using System;
using System.Collections.Generic;

namespace task1
{
    public class CLIMenu
    {
        List<string> diary = new List<String>(); // List to store diary entries

        // Method to display all diary entries
        public void CLIShow()
        {
            for(int i = 0; i < diary.Count; i++)
            {
                Console.WriteLine(diary[i]); // Print each entry
            }
        }

        // Method to add a new diary entry
        public void CLIAdd()
        {
            Console.WriteLine("Enter the note you would like to add: ");
            string appendString = Console.ReadLine(); // Read input from user
            diary.Add(appendString); // Add the entry to the diary list
        }

        // Method to search for a specific word in the diary entries
        public void CLISearch()
        {
            Console.WriteLine("Enter the word you would like to find: ");
            string searchedString = Console.ReadLine(); // Read input from user
            bool foundString = false;

            for (int i = 0; i < diary.Count; i++)
            {
                if(diary[i].Contains(searchedString)) // Check if the entry contains the searched word
                {
                    Console.WriteLine(diary[i]); // Print the entry if the word is found
                    foundString = true;
                    break;
                }
            }

            if(!foundString)
            {
                Console.WriteLine("Could not find your word in the diary"); // Print a message if the word is not found
            }
        }

        // Method to quit the program
        public void CLIQuit()
        {
            System.Environment.Exit(0); // Exit the program
        }
    }

    class Task1
    {
        static void Main()
        {
            CLIMenu cli = new CLIMenu(); // Create an instance of CLIMenu

            while (true)
            {
                Console.WriteLine("Enter what action you would like to perform (Add, Search, Show, Quit): ");
                string action = Console.ReadLine(); // Read user's action
                action = action.ToLower(); // Convert the action to lowercase for case-insensitive comparison

                switch (action) {
                    case "show":
                        cli.CLIShow(); // Call CLIShow method to display the diary entries
                        break;

                    case "add":
                        cli.CLIAdd(); // Call CLIAdd method to add a new diary entry
                        break;

                    case "search":
                        cli.CLISearch(); // Call CLISearch method to search for a specific word in the diary entries
                        break;

                    case "quit":
                        cli.CLIQuit(); // Call CLIQuit method to quit the program
                        break;

                    default:
                        Console.WriteLine("Incorrect"); // Print a message for incorrect input
                        break;
                }
            }
        }
    }
}
