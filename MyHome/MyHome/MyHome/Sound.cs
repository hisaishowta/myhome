using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;
using Microsoft.DirectX.AudioVideoPlayback;

namespace MyHome
{
    class Sound
    {
        Audio[] mWavs;
        static int kJump = 0;
        static int kKira = 1;

        static Sound mInstance = null;
        static public Sound GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new Sound();
            }
            return mInstance;
        }

        private Sound()
        {
            bool Flag = false;
            string cwd = System.IO.Directory.GetCurrentDirectory();
            cwd = System.IO.Directory.GetParent(cwd).ToString();
            mWavs = new Audio[3];
            mWavs[0] = new Microsoft.DirectX.AudioVideoPlayback.Audio(cwd + "\\sound\\ashioto.wav");
            mWavs[1] = new Microsoft.DirectX.AudioVideoPlayback.Audio(cwd + "\\sound\\ashioto.wav");
            mWavs[2] = new Microsoft.DirectX.AudioVideoPlayback.Audio(cwd + "\\sound\\shot3.wav");
            Console.WriteLine("再生開始");
            //wavePlayer.Play();
            int a = 0;
            int mCounter = 0;
        }



        static public void Play(int id)
        {
            Sound instance = Sound.GetInstance();
            instance.mWavs[id].CurrentPosition = 0;
            instance.mWavs[id].Play();
        }
    }
}