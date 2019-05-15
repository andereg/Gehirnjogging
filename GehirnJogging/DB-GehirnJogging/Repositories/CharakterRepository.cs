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
        public bool characternameExists(string name)
        {
            using (GehirnjoggingEntities context = new GehirnjoggingEntities())
            {
                return context.Charakters.Any(s => s.Name == name);
            }
        }

        /// <summary>
        /// Zählt alle Datensätze der Tabelle Charaktere
        /// </summary>
        /// <returns>Gibt die Anzahl der Charaktere zurück</returns>
        public int countCharakters()
        {
            using (GehirnjoggingEntities context = new GehirnjoggingEntities())
            {
                return context.Charakters.Count();
            }
        }

        /// <summary>
        /// Holt alle Namen der Charaktere aus der Datenbank und schreibt diese in eine Liste
        /// </summary>
        /// <returns>Gibt alle Charakternamen in einer String-Liste zurück</returns>
        public List<String> getCharakterNames()
        {
            using (GehirnjoggingEntities context = new GehirnjoggingEntities())
            {
                return context.Charakters.Select(s => s.Name).ToList();
            }
        }

        /// <summary>
        /// Holt alle CharakterStages aus der Datenbank und schreibt diese in eine Liste
        /// </summary>
        /// <returns>Gibt alle Stages in einer int-List zurück</returns>
        public List<int> getCharakterStages()
        {
            using (GehirnjoggingEntities context = new GehirnjoggingEntities())
            {
                return context.Charakters.Select(s => s.Stage.Value).ToList();
            }
        }

        /// <summary>
        /// Holt den Angriffsschaden des Charakters aus der Datenbank mithilfe eines FirstOrDefault-Command 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns>Gibt den Angriffschaden des mitgegebenen Charakters zurück</returns>
        public int getAttackDamageByName(string Name)
        {
            using (GehirnjoggingEntities context = new GehirnjoggingEntities())
            {
                Charakter ctx = context.Charakters.FirstOrDefault(i => i.Name == Name);
                return ctx.Damage.Value;
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
                    HP = 100,
                    Luck = 0,
                    SolveTime = 1,
                    Assets = 1
                };
                gehirnjoggingEntities.Charakters.Add(charakter);
                gehirnjoggingEntities.SaveChanges();
            }
        }
    }
}
