using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tinyproject
{
    public class AnswerList : List<Answer>, ICloneable, IComparable<AnswerList>
    {
        public AnswerList() : base()
        {
        }

        public AnswerList(IEnumerable<Answer> answers) : base(answers)
        {
        }

        public object Clone()
        {
            AnswerList cloned = new AnswerList();

            foreach (var answer in this)
            {
                cloned.Add((Answer)answer.Clone());
            }

            return cloned;
        }

        public int CompareTo(AnswerList other)
        {
            if (other == null)
                return 1;

            return this.Count.CompareTo(other.Count);
        }

        public override bool Equals(object obj)
        {
            if (obj is not AnswerList other)
                return false;

            if (this.Count != other.Count)
                return false;

            for (int i = 0; i < this.Count; i++)
            {
                if (!this[i].Equals(other[i]))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            foreach (var answer in this)
            {
                hash.Add(answer);
            }

            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this);
        }
    }
}
