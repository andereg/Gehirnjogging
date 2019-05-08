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


        /// <summary>
        /// 
        /// </summary>
        public void playTheme()
        {
            player.Open(new Uri(@"Sounds/Speed_Kills_1.wav", UriKind.Relative));
            player.Play();
            player.MediaEnded += new EventHandler(Media_Ended);

        }
   
        private void Media_Ended(object sender, EventArgs e)
        {
            player.Position = TimeSpan.Zero;
            player.Play();
        }
        /// <summary>
        /// 
        /// </summary>
        public void resumeTheme()
        {
            player.Play();
            player.MediaEnded += new EventHandler(Media_Ended);
        }
        /// <summary>
        /// 
        /// </summary>
        public void stopTheme()
        {
            player.Pause();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        public void decreaseVolume(double Value)
        {
            player.Volume = Value;
        }


    }
}
