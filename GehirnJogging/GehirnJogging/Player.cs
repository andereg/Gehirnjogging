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
        /// In der Methode getInstance wird ein Objekt Player erstellt falls player noch null ist.
        /// </summary>
        /// <returns>Es wird player zurück gegeben</returns>
        public static Player getInstance()
        {
            if (_player == null)
            {
                _player = new Player();
                _player.playingLevel = 1;
            }
            return _player;
        }

        /// <summary>
        /// Der getter und setter vom String playerName hier
        /// </summary>
        public string playerName { get; set; }

        /// <summary>
        /// Der getter und setter vom Double health sind hier
        /// </summary>
        public double health { get; set; }

        /// <summary>
        /// Der getter und setter vom int level sind hier
        /// </summary>
        public int level { get; set; }

        /// <summary>
        /// Der getter und setter vom int playingLevel sind hier
        /// dieser int speichert das aktuelle Level, welches der Benutzer am spielen ist. 
        /// </summary>
        public int playingLevel { get; set; }


    }
}
