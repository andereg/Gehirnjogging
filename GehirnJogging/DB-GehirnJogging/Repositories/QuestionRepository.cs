using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Abstract;

namespace DB_GehirnJogging.Repositories
{
    public class QuestionRepository : AbstractRepository<Question>
    {
        public QuestionRepository(GehirnjoggingEntities context) : base(context) { }


        /// <summary>
        /// Holt alle Fragen aus der Datenbank und schreibt diese in eine Liste
        /// </summary>
        /// <returns>Gibt alle Fragen in einer String-Liste zurück</returns>
        public List<String> getQuestions()
        {
            using (GehirnjoggingEntities context = new GehirnjoggingEntities())
            {
                return context.Questions.Select(s => s.Questions).ToList();
            }
        }

        /// <summary>
        /// Holt alle Antworten aus der Datenbank und schreibt diese in eine Liste
        /// </summary>
        /// <returns>Gibt alle Antworten in einer String-Liste zurück</returns>
        public List<int> getAnswers()
        {
            using (GehirnjoggingEntities context = new GehirnjoggingEntities())
            {
                return context.Questions.Select(s => s.Answer).ToList();
            }
        }

    }
}
