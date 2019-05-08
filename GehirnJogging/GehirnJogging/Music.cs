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
        public bool musiIscOn = false;

        /// <summary>
        /// 
        /// </summary>
        public void playTheme()
        {
            if (musiIscOn == false)
            {
                musiIscOn = true;
                player.Open(new Uri(@"Sounds/True Faith.wav", UriKind.Relative));
                player.Play();
                player.MediaEnded += new EventHandler(Media_Ended);
            }
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
