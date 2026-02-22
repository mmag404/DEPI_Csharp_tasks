using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    class Helper<T>
    {
        public static void Swap(ref T X, ref T Y)
        {
            T Temp = X;
            X = Y;
            Y = Temp;
        }
        public static int SearchArr(T[] Arr, T Value)
        {
            for (int i = 0; i < Arr?.Length; i++)
            {
                if (Value.Equals((Arr[i])))
                    return i;
            }
            return -1;
        }
        #region generic Max method

        public static T Max<T>(T a, T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) > 0)
                return a;
            else
                return b;
        }


        public static void ReplaceArray(T[] array, T oldValue, T newValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(oldValue))
                {
                    array[i] = newValue;
                }
            }
        }

        public static void SwapRectangle(ref Rectangle r1, ref Rectangle r2)
        {
            Rectangle temp = r1;
            r1 = r2;
            r2 = temp;
        }

        #region ReverseArray generic method

        public static T[] ReverseArray<T>(T[] arr)
        {
            T[] result = new T[arr.Length];

            int j = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                result[j] = arr[i];
                j++;
            }

            return result;
        }

        #endregion


        #endregion

        #region Generic Swap Method

        public static void Swap<T>(T[] arr, int index1, int index2)
        {
            T temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        #endregion


        #region Generic Max Element Method

        public static T MaxElement<T>(T[] arr) where T : IComparable<T>
        {
            T max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(max) > 0)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        #endregion

    }
}
