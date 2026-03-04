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

        public Answer(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public object Clone()
        {
            return new Answer(Id, Text);
        }

        public int CompareTo(Answer other)
        {
            if (other == null)
                return 1;

            return Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return $"{Id}. {Text}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not Answer other)
                return false;

            return Id == other.Id && Text == other.Text;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Text);
        }
    }
}
