using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GehirnJogging
{
    class Player
    {

        private string _playerName;
        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                _playerName = value;
            }
        }

        private double _health = 100;
        public double Health
        {
            get { return _health; }
            set
            {
                _health = value;
            }
        }

    }
}
