using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP_Demo.Models
{
    public class MusicPlayer
    {
        private readonly Dictionary<string, IAudioPlayer> _players;

        public MusicPlayer(Dictionary<string, IAudioPlayer> players)
        {
            _players = players;
        }

        public void Play(string file, string format)
        {
            if (_players.ContainsKey(format))
            {
                _players[format].Play(file);
            }
            else
            {
                Console.WriteLine("Unsupported file format");
            }
        }
    }
}
