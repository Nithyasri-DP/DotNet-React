using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP_Demo.Models
{
    public interface IAudioPlayer
    {
        void Play(string file);
    }

    public class MP3Player : IAudioPlayer
    {
        public void Play(string file)
        {
            Console.WriteLine("MP3 Player is Running");
        }
    }

    public class WAVPlayer : IAudioPlayer
    {
        public void Play(string file)
        {
            Console.WriteLine("WAV Player is Running");
        }
    }
}
