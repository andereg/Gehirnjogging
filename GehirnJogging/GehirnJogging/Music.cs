using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GehirnJogging
{
    /// <summary>
    /// In dieser Klasse sind die Funktionälitäten Hintergrundmusik abzuspielen, die Hintergrundmusik zu stopen, die hintergrundmusik zu starten und die Lautstärke der Hintergrundmsuik zu steuern. 
    /// </summary>
    class Music
    {
        MediaPlayer player = new MediaPlayer();
        private bool isMusicOn = false;


        /// <summary>
        /// Öffnet/Loadet den Song und spielt ihn danach ab.
        /// </summary>
        public void playTheme()
        {

            if (isMusicOn == false)
            {
                isMusicOn = true;
                player.Open(new Uri(@"Sounds/Crow.mp3", UriKind.Relative));
                player.Play();
            }


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
