using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GehirnJogging
{
    class Music
    {
        MediaPlayer player = new MediaPlayer();



        public void playTheme()
        {
            player.Open(new Uri(@"Sounds/Tamilsong.wav", UriKind.Relative));
            player.Play();
        }

        public void resumeTheme()
        {
            player.Play();
        }

        public void stopTheme()
        {
            player.Pause();
        }

        public void decreaseVolume(double Value)
        {
            player.Volume = Value;
        }


    }
}
