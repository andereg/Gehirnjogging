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
            //player.Open(new Uri(@"Sounds/Tamilsong.wav", UriKind.Relative));
            player.Play();
        }
        /// <summary>
        /// 
        /// </summary>
        public void resumeTheme()
        {
            player.Play();
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
