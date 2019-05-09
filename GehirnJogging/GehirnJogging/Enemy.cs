using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GehirnJogging
{
    class Enemy
    {

        private static Enemy _enemy;

        private Enemy()
        {

        }

        /// <summary>
        /// wenn _enemy leer ist, wird hier ein neuer Enemy generiert
        /// </summary>
        /// <returns>_enemy</returns>
        public static Enemy GetInstance()
        {
            if (_enemy == null)
            {
                _enemy = new Enemy();
            }
            return _enemy;
        }

        /// <summary>
        /// Hier wird der Name des Enemys definiert
        /// </summary>
        public string enemyName { get; set; }

        /// <summary>
        /// Hier wird das Leben des Enemys gesetzt/geändert
        /// </summary>
        public double Health { get; set; }

    }
}