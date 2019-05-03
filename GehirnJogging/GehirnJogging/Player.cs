using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GehirnJogging
{
    /// <summary>
    /// 
    /// </summary>
    public class Player
    {

        private static Player _player;

        private Player()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Player GetInstance()
        {
            if(_player == null)
            {
                _player = new Player();
            }
            return _player;
        }

        /// <summary>
        /// 
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Health { get; set; }


    }
}
