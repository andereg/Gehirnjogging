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
        /// In der Methode GetInstance wird ein Objekt Player erstellt falls player noch null ist.
        /// </summary>
        /// <returns>Es wird player zurück gegeben</returns>
        public static Player GetInstance()
        {
            if(_player == null)
            {
                _player = new Player();
            }
            return _player;
        }

        /// <summary>
        /// Der getter und setter vom String PlayerName hier
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Der getter und setter vom Double Health sind hier
        /// </summary>
        public double Health { get; set; }


    }
}
