using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    internal class ComplexNumber
    {
        public int Real { get; set; }
        public int Imag { get; set; }

        public override string ToString()
        {
            return $"{Real} + {Imag}i";
        }






        //// operator Overloading : 
        //// must be non_private  static  member function  >> why? >> self

        // Design : 
        // Refactor : 
        // Dereferencing : Access 
        //  Real = Left.Real is not null ? Left.Real : 0;
        public static ComplexNumber operator +(ComplexNumber Left, ComplexNumber Right)
        {
            return new ComplexNumber()
            {
                Real = (Left?.Real ?? 0) + (Right?.Real ?? 0),
                Imag = (Left?.Imag ?? 0) + (Right?.Imag ?? 0),
            };
        }



        public static ComplexNumber operator -(ComplexNumber Left, ComplexNumber Right)
        {
            return new ComplexNumber
            {
                Real = Left.Real - Right.Real,
                Imag = Left.Imag - Right.Imag,
            };
        }

        public static ComplexNumber operator *(ComplexNumber Left, ComplexNumber Right)
        {
            return new ComplexNumber
            {
                Real = (Left.Real * Right.Real) - (Left.Imag * Right.Imag),
                Imag = (Left.Real * Right.Imag) + (Left.Imag * Right.Real)
            };
        }
    }
}
