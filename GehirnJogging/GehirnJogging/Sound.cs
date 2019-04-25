using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GehirnJogging
{
    class Sound
    {
        MediaPlayer player = new MediaPlayer();
               
        public void playHover()
        {
            player.Open(new Uri("@Sounds/Hoversound.wav"));
            player.Play();
        }

        public void playClick()
        {
            player.Open(new Uri("Sounds/Clicksound.wav"));
            player.Play();
        }

        public void loadRunning()
        {
            player.Open(new Uri(@"Sounds/Runningsound.wav", UriKind.Relative));
        }


        public void stopRunning()
        {
            player.Pause();
        }
        public void resumeRunning()
        {
            player.Play();
            player.MediaEnded += new EventHandler(Media_Ended);

        }

        private void Media_Ended(object sender, EventArgs e)
        {
            player.Position = TimeSpan.Zero;
            player.Play();
        }

        public void decreaseVolume()
        {
            player.Volume = -10;
        }

    }
}
