using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinyproject
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion() : base()
        {
            InitializeAnswers();
        }

        public TrueFalseQuestion(string header, string body, int marks)
            : base(header, body, marks)
        {
            InitializeAnswers();
        }

        public TrueFalseQuestion(string header, string body, int marks, AnswerList answers)
            : base(header, body, marks, answers)
        {
            if (AnswerList.Count != 2)
                InitializeAnswers();
        }

        private void InitializeAnswers()
        {
            AnswerList.Clear();
            AnswerList.Add(new Answer(1, "True"));
            AnswerList.Add(new Answer(2, "False"));
        }

        public override object Clone()
        {
            return new TrueFalseQuestion(
                Header,
                Body,
                Marks,
                (AnswerList)AnswerList.Clone()
            );
        }
    }
}
