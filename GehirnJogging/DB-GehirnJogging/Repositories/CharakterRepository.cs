using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Abstract;

namespace DB_GehirnJogging.Repositories
{
    public class CharakterRepository : AbstractRepository<Charakter>
    {

        public CharakterRepository(GehirnjoggingEntities context) : base(context) { }

        /// <summary>
        /// Prüft ob der Name bereits in der Datenbank vorhanden ist
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True wenn der Name bereits vorhanden ist, falls wenn nicht</returns>
        public bool CharacternameExists(string name)
        {
            using (GehirnjoggingEntities context = new GehirnjoggingEntities())
            {
                return context.Charakters.Any(s => s.Name == name);
            }
        }

        /// <summary>
        /// Erhöht die Stage des mitgegebenen Charakters um 1
        /// </summary>
        /// <param name="charaktername"></param>
        public void incrementStageByName(string charaktername)
        {
            Charakter result = (from p in Context.Charakters
                where p.Name == charaktername
                select p).SingleOrDefault();

            result.Stage = result.Stage + 1;

            Context.SaveChanges();
        }

        /// <summary>
        /// Erstellt einen neuen User mit default Werten und dem mitgegebenem Namen
        /// </summary>
        /// <param name="charaktername"></param>
        public void createNewUser(string charaktername)
        {
            using (GehirnjoggingEntities gehirnjoggingEntities = new GehirnjoggingEntities())
            {
                Charakter charakter = new Charakter()
                {
                    Name = charaktername,
                    Stage = 1, 
                    Damage = 15,
                    HP = 100
                };
                gehirnjoggingEntities.Charakters.Add(charakter);
                gehirnjoggingEntities.SaveChanges();
            }
        }
    }
}
