using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace task_2
{

    public class MP3Playlist {
        Dictionary<String, String> playlist = new Dictionary<String, String>();
        
        private string playlistFilePath;
        public MP3Playlist(string playlist) {
            playlistFilePath = playlist;
            readFile(playlistFilePath);
        }

        private void readFile(string file) {
            var totalLinesRead = File.ReadLines(file);
            string[] info = new string[2];
            foreach (var lineRead in totalLinesRead)
            {
                //Console.WriteLine(lineRead);
                info = lineRead.Split(',');
                playlist.Add(info[0], Convert.ToString(TimeSpan.Parse(info[1]).TotalSeconds));

            }
        }
        public void Enqueue() {
            Console.WriteLine("Enter the song name you would like to add: ");
            string songName = Console.ReadLine();
            Console.WriteLine("Enter the duration of the song in minutes: ");
            string songDurationMin = Console.ReadLine();
            Console.WriteLine("Enter the duration of the song in seconds: ");
            string songDurationSec = Console.ReadLine();
            string totalSongDuration = Convert.ToString(TimeSpan.Parse(String.Format("00:0{0}:0{1}",songDurationMin,songDurationSec)).TotalSeconds);

            playlist.Add(songName, totalSongDuration);
        }
        public void Remove() {
            Console.WriteLine("Enter the name of the song you would like to remove: ");
            string songName = Console.ReadLine();
            playlist.Remove(songName);
        }
        public void Load() {
            Console.WriteLine("Enter the playlist text file path: ");
            playlistFilePath = Console.ReadLine();
        }
        public void Save() {
            using (StreamWriter file = new StreamWriter("saveFileSongs.txt"))
                foreach (var entry in playlist)
                    file.WriteLine("[Song Name: {0}, Duration: {1} seconds]", entry.Key, entry.Value);
        }
        public void Shuffle() {
            Random rand = new Random();
            playlist = playlist.OrderBy(x => rand.Next(0, playlist.Count)).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("The playlist is now shuffled");
        }
        public void Display() { 
            foreach (var element in playlist)
            {
                Console.WriteLine(element);
            }
        }
        public void Count() {
            Console.WriteLine("There are {0} songs in the playlist",playlist.Count);
        }

        public void Calculate()
        {
            float totalSeconds = 0;
            foreach(var element in playlist.Values)
            {
                totalSeconds += Convert.ToInt32(element);
            }
            Console.WriteLine("The total seconds of the playlist are: {0}", totalSeconds);
        }
        public void Reset() {
            Dictionary<String, String> playlist = new Dictionary<String, String>();
            Console.WriteLine("The playlist is now empty");
        }
        public void Empty() { 
            if(playlist.Count != 0)
            {
                Console.WriteLine("Not Empty");
            } else
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
            MP3Playlist mp3 = new MP3Playlist("C:/Users/Lider/Desktop/Github/College C#/task 2/task 2/songs.txt");

            while (true)
            {
                Console.WriteLine("Avaliable Commands: Enqueue, Remove, Load, Save, Shuffle, Display, Count, Reset, Empty");
                Console.WriteLine("Enter a command: ");
                string command = Console.ReadLine();
                command = command.ToLower();

                switch(command)
                {
                    case "enqueue":
                        {
                            mp3.Enqueue();
                            break;
                        };
                    case "remove":
                        {
                            mp3.Remove();
                            break;
                        };
                    case "load":
                        {
                            mp3.Load();
                            break;
                        };
                    case "save":
                        {
                            mp3.Save();
                            break;
                        };
                    case "shuffle":
                        {
                            mp3.Shuffle();
                            break;
                        };
                    case "display":
                        {
                            mp3.Display();
                            break;
                        };
                    case "count":
                        {
                            mp3.Count();
                            break;
                        };
                    case "calculate":
                        {
                            mp3.Calculate();
                            break;
                        };
                    case "reset":
                        {
                            mp3.Reset();
                            break;
                        };
                    case "empty": 
                        {
                            mp3.Empty();
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
