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

        public bool CharacternameExists(string name)
        {
            using (GehirnjoggingEntities context = new GehirnjoggingEntities())
            {
                return context.Charakters.Any(s => s.Name == name);
            }
        }

        public void incrementStageByName(string charaktername)
        {
            Charakter result = (from p in Context.Charakters
                where p.Name == charaktername
                select p).SingleOrDefault();

            result.Stage = result.Stage + 1;

            Context.SaveChanges();
        }



        //public int takeHPByName(string charaktername)
        //{
        //    int charakterHP;
        //    using (GehirnjoggingEntities context = new GehirnjoggingEntities())
        //    {
        //        IList<Charakter> charakters = context.Charakters.Where(j => j.Name == charaktername).ToList();
        //        foreach (var charakter in charakters)
        //        {
        //            charakterHP = charakter.HP;
        //        }
        //        return charakterHP;
        //    }
        // }

    }
}
