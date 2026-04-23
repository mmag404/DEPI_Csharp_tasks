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
        public AnswerList Answers { get; set; }

        public Question() : this("", "", 0, new AnswerList())
        {
        }

        public Question(string header, string body, int marks)
            : this(header, body, marks, new AnswerList())
        {
        }

        public Question(string header, string body, int marks, AnswerList answers)
        {
            Header = header;
            Body = body;
            Marks = marks;
            Answers = answers;
        }

        public abstract void Display();

        public object Clone()
        {
            AnswerList clonedAnswers = new AnswerList();

            foreach (var a in Answers)
                clonedAnswers.Add((Answer)a.Clone());

            return this.MemberwiseClone();
        }

        public int CompareTo(Question other)
        {
            if (other == null) return 1;
            return Marks.CompareTo(other.Marks);
        }

        public override string ToString()
        {
            return $"{Header}\n{Body}\nMarks: {Marks}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Question q)
                return Header == q.Header && Body == q.Body;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Header, Body);
        }
    }
}
