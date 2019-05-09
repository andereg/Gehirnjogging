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
        /// Öffnet/Loadet den Song und spielt ihn danach ab.
        /// </summary>
        public void playTheme()
        {
            //player.Open(new Uri(@"Sounds/Tamilsong.wav", UriKind.Relative));
            player.Play();
        }
        /// <summary>
        /// Spielt einen bereits geladenen Song/.Wav File ab.
        /// </summary>
        public void resumeTheme()
        {
            player.Play();
        }
        /// <summary>
        /// Pausert einen Song
        /// </summary>
        public void stopTheme()
        {
            player.Pause();
        }
        /// <summary>
        /// Ändert das Volume.
        /// </summary>
        /// <param name="Value"></param>
        public void changeVolume(double Value)
        {
            player.Volume = Value;
        }


    }
}
