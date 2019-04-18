using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GehirnJogging
{
    class Sounds
    {

        MediaPlayer player = new MediaPlayer();



        public void playHover()
        {
            player.Open(new Uri(@"D:\Users\bander\IdeaProjects\gehirn-jogging\GehirnJogging\Sounds\Hoversound.wav"));
            player.Play();
        }

        public void playClick()
        {
            player.Open(new Uri(@"D:\Users\bander\IdeaProjects\gehirn-jogging\GehirnJogging\Sounds\Clicksound.wav"));
            player.Play();
        }

    }
}
