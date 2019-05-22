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
        private MediaPlayer _player = new MediaPlayer();


        /// <summary>
        /// Öffnet den Sound und spielt ihn ab
        /// </summary>
        public void playCompleteLevel()
        {
            _player.Open(new Uri(@"Sounds/CompleteLevel.wav", UriKind.Relative));
            _player.Play();
        }

        /// <summary>
        /// Spielt und Ladet den Sound CorrectAnswer ab
        /// </summary>
        public void playCorrectAnswer()
        {
            _player.Open(new Uri(@"Sounds/CorrectAnswer.wav", UriKind.Relative));
            _player.Play();
        }

        /// <summary>
        /// Spielt und Ladet den Sound FalseAnswer ab
        /// </summary>
        public void playFalseAnswer()
        {
            _player.Open(new Uri(@"Sounds/FalseAnswer.wav", UriKind.Relative));
            _player.Play();
        }

        /// <summary>
        /// Spielt und ladet den sound Timersound ab, falls dieser beendet ist, wird das Event mediaTimer_ended ausgelöst was den Sound wiederholt  
        /// </summary>
        public void playTimer()
        {
            _player.Open(new Uri(@"Sounds/Timersound.wav", UriKind.Relative));
            _player.Play();
            _player.MediaEnded += new EventHandler(mediaTimer_Ended);
        }

        /// <summary>
        /// Stoppt den _player
        /// </summary>
        public void stopTimer()
        {
            _player.Pause();
        }
        /// <summary>
        /// Ladet den Sound Runningsound
        /// </summary>
        public void loadRunning()
        {
            _player.Open(new Uri(@"Sounds/Runningsound.wav", UriKind.Relative));
        }

        /// <summary>
        /// Pausiert den Sound Running
        /// </summary>
        public void stopRunning()
        {
            _player.Pause();
        }

        /// <summary>
        /// Spielt den Sound Running weiter ab. Wenn der Sound ended wird ein neues Event ausgelöst(media_Ended), welches den Sound neu startet
        /// </summary>
        public void resumeRunning()
        {
            _player.Play();
            _player.MediaEnded += new EventHandler(media_Ended);

        }


        private void media_Ended(object sender, EventArgs e)
        {
            _player.Position = TimeSpan.Zero;
            _player.Play();
        }

        private void mediaTimer_Ended(object sender, EventArgs e)
        {
            _player.Position = TimeSpan.Zero;
            _player.Play();
        }
    }
}
