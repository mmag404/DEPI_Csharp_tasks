using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinyproject
{
    public class AnswerList : List<Answer>
    {
        public AnswerList() : base()
        {
        }

        public List<Answer> GetCorrectAnswers()
        {
            return this.Where(a => a.IsCorrect).ToList();
        }

        public void DisplayAnswers()
        {
            foreach (var answer in this)
            {
                System.Console.WriteLine(answer);
            }
        }
    }

}
