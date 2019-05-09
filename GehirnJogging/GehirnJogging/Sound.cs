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

         /// <summary>
         /// 
         /// </summary>
        public void playHover()
        {
            player.Open(new Uri(@"Sounds/Hoversound.wav", UriKind.Relative));
            player.Play();
        }
        /// <summary>
        /// 
        /// </summary>
        public void playClick()
        {
            player.Open(new Uri(@"Sounds/Clicksound.wav", UriKind.Relative));
            player.Play();
        }

        public void playCompleteLevel()
        {
            player.Open(new Uri(@"Sounds/CompleteLevel.wav", UriKind.Relative));
            player.Play();
        }
        /// <summary>
        /// 
        /// </summary>
        public void loadRunning()
        {
            player.Open(new Uri(@"Sounds/Runningsound.wav", UriKind.Relative));
        }

        /// <summary>
        /// 
        /// </summary>
        public void stopRunning()
        {
            player.Pause();
        }
        /// <summary>
        /// 
        /// </summary>
        public void resumeRunning()
        {
            player.Play();
            player.MediaEnded += new EventHandler(Media_Ended);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Media_Ended(object sender, EventArgs e)
        {
            player.Position = TimeSpan.Zero;
            player.Play();
        }
        /// <summary>
        /// 
        /// </summary>
        public void decreaseVolume()
        {
            player.Volume = -10;
        }

    }
}
