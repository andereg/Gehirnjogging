using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GehirnJogging
{
    /// <summary>
    /// 
    /// </summary>
    class Sound
    {
        MediaPlayer playerCompleteLevel = new MediaPlayer();
        MediaPlayer playerRunning = new MediaPlayer();
        MediaPlayer playerTimer = new MediaPlayer();
        MediaPlayer playerEffect = new MediaPlayer();


        //public void playHover()
        //{
        //    player.Open(new Uri(@"Sounds/Hoversound.wav", UriKind.Relative));
        //    player.Play();
        //}
        //public void playClick()
        //{
        //    player.Open(new Uri(@"Sounds/Clicksound.wav", UriKind.Relative));
        //    player.Play();
        //}

        /// <summary>
        /// Öffnet den Sound und spielt ihn ab
        /// </summary>
        public void playCompleteLevel()
        {
            playerCompleteLevel.Open(new Uri(@"Sounds/CompleteLevel.wav", UriKind.Relative));
            playerCompleteLevel.Play();
        }

        public void playCorrectAnswer()
        {
            playerEffect.Open(new Uri(@"Sounds/CorrectAnswer.wav", UriKind.Relative));
            playerEffect.Play();
        }

        public void playFalseAnswer()
        {
            playerEffect.Open(new Uri(@"Sounds/FalseAnswer.wav", UriKind.Relative));
            playerEffect.Play();
        }

        public void playTimer()
        {
            playerTimer.Open(new Uri(@"Sounds/Timersound.wav", UriKind.Relative));
            playerTimer.Play();
            playerTimer.MediaEnded += new EventHandler(mediaTimer_Ended);
        }

        public void stopTimer()
        {
            playerTimer.Pause();
        }
        /// <summary>
        /// Ladet den Sound Runningsound
        /// </summary>
        public void loadRunning()
        {
            playerRunning.Open(new Uri(@"Sounds/Runningsound.wav", UriKind.Relative));
        }

        /// <summary>
        /// Pausiert den Sound Running
        /// </summary>
        public void stopRunning()
        {
            playerRunning.Pause();
        }

        /// <summary>
        /// Spielt den Sound Running weiter ab. Wenn der Sound ended wird ein neues Event ausgelöst(media_Ended), welches den Sound neu startet
        /// </summary>
        public void resumeRunning()
        {
            playerRunning.Play();
            playerRunning.MediaEnded += new EventHandler(media_Ended);

        }
        /// <summary>
        /// Spielt den Sound nochmal von Anfang an ab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void media_Ended(object sender, EventArgs e)
        {
            playerRunning.Position = TimeSpan.Zero;
            playerRunning.Play();
        }
        private void mediaTimer_Ended(object sender, EventArgs e)
        {
            playerTimer.Position = TimeSpan.Zero;
            playerTimer.Play();
        }
    }
}
