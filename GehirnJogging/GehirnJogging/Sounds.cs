using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GehirnJogging
{
    class Sounds
    {
        MediaPlayer player = new MediaPlayer();
               
        public void playHover()
        {
            player.Open(new Uri("@Sounds/Hoversound.wav"));
            player.Play();
        }

        public void playClick()
        {
            player.Open(new Uri("@Sounds/Clicksound.wav"));
            player.Play();
        }

        public void decreaseVolume()
        {
            player.Volume = -10;
        }

    }
}
