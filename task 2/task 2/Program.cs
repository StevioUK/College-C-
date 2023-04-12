using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
Enqueue an MP3 to the playlist, Add
Remove an MP3 from the playlist, Remove
Load a playlist from a text file, Load
Save a playlist on a text file, Save
Shuffle all the songs in the playlist,
Display all the tracks from the playlist,
Count the number of tracks in the playlist,
Calculate the total duration of the playlist,
Empty/Reset the playlist,
Check if the playlist is empty.
*/
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
                playlist.Add(info[0], System.Convert.ToString(TimeSpan.Parse(info[1]).TotalSeconds));

            }
        }
        public void Enqueue() {
            Console.WriteLine("Enter the song name you would like to add: ");
            string songName = Console.ReadLine();
            Console.WriteLine("Enter the duration of the song in minutes: ");
            string songDurationMin = Console.ReadLine();
            Console.WriteLine("Enter the duration of the song in seconds: ");
            string songDurationSec = Console.ReadLine();
            string totalSongDuration = String.Format("00:@1:@2",songDurationMin,songDurationSec);

            playlist.Add(songName, System.Convert.ToString(TimeSpan.Parse(totalSongDuration)));
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
    class programMain
    {
        static void Main(String[] args)
        {
            MP3Playlist mp3 = new MP3Playlist("C:/Users/Lider/Desktop/Github/College C#/task 2/task 2/songs.txt");
            mp3.Count();

            Console.ReadKey();
        }
    }
}
