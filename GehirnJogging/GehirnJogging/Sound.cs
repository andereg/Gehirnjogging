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


        /// <summary>
        /// Öffnet den Sound und spielt ihn ab
        /// </summary>
        public void playCompleteLevel()
        {
            playerCompleteLevel.Open(new Uri(@"Sounds/CompleteLevel.wav", UriKind.Relative));
            playerCompleteLevel.Play();
        }

        /// <summary>
        /// Spielt und Ladet den Sound CorrectAnswer ab
        /// </summary>
        public void playCorrectAnswer()
        {
            playerEffect.Open(new Uri(@"Sounds/CorrectAnswer.wav", UriKind.Relative));
            playerEffect.Play();
        }

        /// <summary>
        /// Spielt und Ladet den Sound FalseAnswer ab
        /// </summary>
        public void playFalseAnswer()
        {
            playerEffect.Open(new Uri(@"Sounds/FalseAnswer.wav", UriKind.Relative));
            playerEffect.Play();
        }

        /// <summary>
        /// Spielt und ladet den sound Timersound ab, falls dieser beendet ist, wird das Event mediaTimer_ended ausgelöst was den Sound wiederholt  
        /// </summary>
        public void playTimer()
        {
            playerTimer.Open(new Uri(@"Sounds/Timersound.wav", UriKind.Relative));
            playerTimer.Play();
            playerTimer.MediaEnded += new EventHandler(mediaTimer_Ended);
        }

        /// <summary>
        /// Stoppt den playerTimer
        /// </summary>
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
