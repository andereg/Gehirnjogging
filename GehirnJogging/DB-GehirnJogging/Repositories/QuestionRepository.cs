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


        public List<String> getQuestions()
        {
            using (GehirnjoggingEntities context = new GehirnjoggingEntities())
            {
                return context.Questions.Select(s => s.Questions).ToList();
            }
        }

        public List<int> getAnswers()
        {
            using (GehirnjoggingEntities context = new GehirnjoggingEntities())
            {
                return context.Questions.Select(s => s.Answer).ToList();
            }
        }
    }
}
