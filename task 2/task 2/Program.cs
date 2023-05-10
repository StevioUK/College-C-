using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace task_2
{
    public class MP3Playlist {
        Dictionary<String, String> playlist = new Dictionary<String, String>(); // Dictionary to store song name and duration

        private string playlistFilePath;

        public MP3Playlist(string playlist) {
            playlistFilePath = playlist;
            readFile(playlistFilePath); // Read and parse the playlist file
        }

        private void readFile(string file) {
            var totalLinesRead = File.ReadLines(file);
            string[] info = new string[2];
            foreach (var lineRead in totalLinesRead)
            {
                info = lineRead.Split(','); // Split each line by comma to extract song name and duration
                playlist.Add(info[0], Convert.ToString(TimeSpan.Parse(info[1]).TotalSeconds)); // Add song name and duration to the playlist dictionary
            }
        }

        public void Enqueue() {
            Console.WriteLine("Enter the song name you would like to add: ");
            string songName = Console.ReadLine();
            Console.WriteLine("Enter the duration of the song in minutes: ");
            string songDurationMin = Console.ReadLine();
            Console.WriteLine("Enter the duration of the song in seconds: ");
            string songDurationSec = Console.ReadLine();
            string totalSongDuration = Convert.ToString(TimeSpan.Parse(String.Format("00:0{0}:0{1}",songDurationMin,songDurationSec)).TotalSeconds); // Calculate total song duration in seconds

            playlist.Add(songName, totalSongDuration); // Add the song name and duration to the playlist dictionary
        }

        public void Remove() {
            Console.WriteLine("Enter the name of the song you would like to remove: ");
            string songName = Console.ReadLine();
            playlist.Remove(songName); // Remove the song from the playlist dictionary
        }

        public void Load() {
            Console.WriteLine("Enter the playlist text file path: ");
            playlistFilePath = Console.ReadLine(); // Get the file path of the new playlist
        }

        public void Save() {
            using (StreamWriter file = new StreamWriter("saveFileSongs.txt"))
                foreach (var entry in playlist)
                    file.WriteLine("[Song Name: {0}, Duration: {1} seconds]", entry.Key, entry.Value); // Save the playlist to a file
        }

        public void Shuffle() {
            Random rand = new Random();
            playlist = playlist.OrderBy(x => rand.Next(0, playlist.Count)).ToDictionary(x => x.Key, x => x.Value); // Shuffle the playlist by randomizing the order of the songs
            Console.WriteLine("The playlist is now shuffled");
        }

        public void Display() { 
            foreach (var element in playlist)
            {
                Console.WriteLine(element); // Display each song name and duration in the playlist
            }
        }

        public void Count() {
            Console.WriteLine("There are {0} songs in the playlist",playlist.Count); // Display the number of songs in the playlist
        }

        public void Calculate() {
            float totalSeconds = 0;
            foreach(var element in playlist.Values)
            {
                totalSeconds += Convert.ToInt32(element); // Calculate the total duration of all songs in the playlist
            }
            Console.WriteLine("The total seconds of the playlist are: {0}", totalSeconds);
        }

        public void Reset() {
            playlist.Clear(); // Create a new empty playlist
            Console.WriteLine("The playlist is now empty");
        }

        public void Empty() { 
            if(playlist.Count != 0)
           {
                Console.WriteLine("Not Empty"); // Check if the playlist is empty or not
            }
            else
            {
                Console.WriteLine("Empty");
            }
        }
    }
    class Task2
    {
        static void Main(String[] args)
        {
            bool exit = false;
            MP3Playlist mp3 = new MP3Playlist("C:/Users/Lider/Desktop/Github/College C#/task 2/task 2/songs.txt"); // Create an instance of MP3Playlist and initialize it with a playlist file path

            while (true)
            {
                Console.WriteLine("Available Commands: Enqueue, Remove, Load, Save, Shuffle, Display, Count, Reset, Empty");
                Console.WriteLine("Enter a command: ");
                string command = Console.ReadLine();
                command = command.ToLower();

                switch(command)
                {
                    case "enqueue":
                        {
                            mp3.Enqueue(); // Call the Enqueue method to add a song to the playlist
                            break;
                        };
                    case "remove":
                        {
                            mp3.Remove(); // Call the Remove method to remove a song from the playlist
                            break;
                        };
                    case "load":
                        {
                            mp3.Load(); // Call the Load method to change the playlist file
                            break;
                        };
                    case "save":
                        {
                            mp3.Save(); // Call the Save method to save the playlist to a file
                            break;
                        };
                    case "shuffle":
                        {
                            mp3.Shuffle(); // Call the Shuffle method to shuffle the playlist
                            break;
                        };
                    case "display":
                        {
                            mp3.Display(); // Call the Display method to show the songs in the playlist
                            break;
                        };
                    case "count":
                        {
                            mp3.Count(); // Call the Count method to display the number of songs in the playlist
                            break;
                        };
                    case "calculate":
                        {
                            mp3.Calculate(); // Call the Calculate method to calculate the total duration of the playlist
                            break;
                        };
                    case "reset":
                        {
                            mp3.Reset(); // Call the Reset method to clear the playlist
                            break;
                        };
                    case "empty": 
                        {
                            mp3.Empty(); // Call the Empty method to check if the playlist is empty
                            break;
                        };
                    case "exit":
                        {
                            exit = true;
                            break;
                        };
                    default:
                        {
                            Console.WriteLine("Incorrect Spelling or Wrong Command");
                            Console.WriteLine("If you want to exit type 'exit'");
                            break;
                        }
                }
                if(exit)
                {
                    break;
                }
            }
        }
    }
}
