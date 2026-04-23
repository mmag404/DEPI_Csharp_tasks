using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinyproject
{
    public class Answer : ICloneable, IComparable<Answer>
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public Answer() : this(0, string.Empty, false)
        {
        }

        public Answer(int id, string text) : this(id, text, false)
        {
        }

        public Answer(int id, string text, bool isCorrect)
        {
            Id = id;
            Text = text;
            IsCorrect = isCorrect;
        }

        public object Clone()
        {
            return new Answer(Id, Text, IsCorrect);
        }

        public int CompareTo(Answer other)
        {
            if (other == null) return 1;
            return Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return $"{Id}. {Text}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Answer other)
                return Id == other.Id && Text == other.Text;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Text);
        }
    }
}
