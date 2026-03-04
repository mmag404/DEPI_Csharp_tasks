using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinyproject
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList AnswerList { get; set; }

        protected Question() : this(string.Empty, string.Empty, 0, new AnswerList())
        {
        }

        protected Question(string header, string body, int marks)
            : this(header, body, marks, new AnswerList())
        {
        }

        protected Question(string header, string body, int marks, AnswerList answers)
        {
            Header = header;
            Body = body;
            Marks = marks;
            AnswerList = answers ?? new AnswerList();
        }

        public abstract object Clone();

        public int CompareTo(Question other)
        {
            if (other == null)
                return 1;

            return Marks.CompareTo(other.Marks);
        }

        public override string ToString()
        {
            return $"{Header}\n{Body}\nMarks: {Marks}\nAnswers:\n{AnswerList}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not Question other)
                return false;

            return Header == other.Header &&
                   Body == other.Body &&
                   Marks == other.Marks &&
                   AnswerList.Equals(other.AnswerList);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Header, Body, Marks, AnswerList);
        }
    }
}
