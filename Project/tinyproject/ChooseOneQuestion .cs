using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinyproject
{
    public class ChooseOneQuestion : Question
    {
        public ChooseOneQuestion() : base()
        {
        }

        public ChooseOneQuestion(string header, string body, int marks)
            : base(header, body, marks)
        {
        }

        public ChooseOneQuestion(string header, string body, int marks, AnswerList answers)
            : base(header, body, marks, answers)
        {
        }

        public override object Clone()
        {
            return new ChooseOneQuestion(
                Header,
                Body,
                Marks,
                (AnswerList)AnswerList.Clone()
            );
        }
    }
}
