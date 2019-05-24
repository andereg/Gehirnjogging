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
        private MediaPlayer _playerRunning = new MediaPlayer();
        private MediaPlayer _playerTimer = new MediaPlayer();
        private MediaPlayer _playerEffect = new MediaPlayer();


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
            _playerEffect.Open(new Uri(@"Sounds/CorrectAnswer.wav", UriKind.Relative));
            _playerEffect.Play();
        }

        /// <summary>
        /// Spielt und Ladet den Sound FalseAnswer ab
        /// </summary>
        public void playFalseAnswer()
        {
            _playerEffect.Open(new Uri(@"Sounds/FalseAnswer.wav", UriKind.Relative));
            _playerEffect.Play();
        }

        /// <summary>
        /// Spielt und ladet den sound Timersound ab, falls dieser beendet ist, wird das Event media_ended ausgelöst was den Sound wiederholt  
        /// </summary>
        public void playTimer()
        {
            _playerTimer.Open(new Uri(@"Sounds/Timersound.wav", UriKind.Relative));
            _playerTimer.Play();
            _playerTimer.MediaEnded += new EventHandler(media_Ended);
        }

        /// <summary>
        /// Stoppt den _player
        /// </summary>
        public void stopTimer()
        {
            _playerTimer.Pause();
        }
        /// <summary>
        /// Ladet den Sound Runningsound
        /// </summary>
        public void loadRunning()
        {
            _playerRunning.Open(new Uri(@"Sounds/Runningsound.wav", UriKind.Relative));
        }

        /// <summary>
        /// Pausiert den Sound Running
        /// </summary>
        public void stopRunning()
        {
            _playerRunning.Pause();
        }

        /// <summary>
        /// Spielt den Sound Running weiter ab. Wenn der Sound ended wird ein neues Event ausgelöst(media_Ended), welches den Sound neu startet
        /// </summary>
        public void resumeRunning()
        {
            _playerRunning.Play();
            _playerRunning.MediaEnded += new EventHandler(media_Ended);

        }


        private void media_Ended(object sender, EventArgs e)
        {
            _player.Position = TimeSpan.Zero;
            _player.Play();
        }
    }
}
