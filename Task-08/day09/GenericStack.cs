using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    #region Generic Stack Class

    public class GenericStack<T>
    {
        private T[] items;
        private int top;
        private int capacity;

        public GenericStack(int size)
        {
            capacity = size;
            items = new T[capacity];
            top = -1;
        }

        public void Push(T value)
        {
            if (top == capacity - 1)
            {
                Console.WriteLine("Stack is full");
                return;
            }

            top++;
            items[top] = value;
        }

        public T Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }

            T value = items[top];
            top--;
            return value;
        }

        public T Peek()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }

            return items[top];
        }

        public bool IsEmpty()
        {
            return top == -1;
        }
    }

    #endregion
}
