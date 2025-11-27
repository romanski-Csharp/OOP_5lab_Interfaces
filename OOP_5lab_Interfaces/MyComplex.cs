using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5lab_Interfaces
{
    public class MyComplex : IMyNumber<MyComplex>
    {
        public double Re { get; }

        public double Im { get; }

        public MyComplex(double re, double im)
        {
            this .Re = re;
            this.Im = im;
        }
        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(this.Re + that.Re, this.Im + that.Im);
        }
        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(this.Re - that.Re, this.Im - that.Im);
        }
        public MyComplex Multiply(MyComplex that)
        {
            return new MyComplex(this.Re * that.Re - this.Im * that.Im,
                                 this.Re * that.Im + this.Im * that.Re);
        }
        public MyComplex Divide(MyComplex that)
        {
            double denom = that.Re * that.Re + that.Im * that.Im;
            if (Math.Abs(denom - 0.0) < 1e-15)
            {
                throw new DivideByZeroException("Ділення на нуль: Знаменник комплексного числа дорівнює нулю.");
            }
            return new MyComplex((this.Re * that.Re + this.Im * that.Im) / denom,
                                 (this.Im * that.Re - this.Re * that.Im) / denom);
        }
        public override string ToString() => $"{Re} + {Im}i";
    }
}
