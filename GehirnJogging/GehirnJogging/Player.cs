using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GehirnJogging
{
    public class Player
    {

        private static Player _player;

        private Player()
        {

        }

        public static Player GetInstance()
        {
            if(_player == null)
            {
                _player = new Player();
            }
            return _player;
        }

        public string PlayerName { get; set; }

        public double Health { get; set; }


    }
}
