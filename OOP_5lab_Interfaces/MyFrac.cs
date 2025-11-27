using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOP_5lab_Interfaces
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        public BigInteger Nom { get; private set; }
        public BigInteger Denom { get; private set; }

        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0)
            {
                throw new DivideByZeroException("Denominator can't be zero");
            }

            this.Nom = nom;
            this.Denom = denom;
            Normalize();
        }
        public void Normalize()
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(this.Nom, this.Denom);
            if (this.Denom > 0)
            {
                this.Nom /= gcd;
                this.Denom /= gcd;
            }
            else
            {
                this.Nom /= -gcd;
                this.Denom /= -gcd;
            }
        }
        public MyFrac Add(MyFrac that) => new MyFrac(this.Nom * that.Denom + that.Nom * this.Denom, this.Denom * that.Denom);
        
        public MyFrac Subtract(MyFrac that) => new MyFrac(this.Nom * that.Denom - that.Nom * this.Denom, this.Denom * that.Denom);
        
        public MyFrac Multiply(MyFrac that) => new MyFrac(this.Nom * that.Nom, this.Denom * that.Denom);

        public MyFrac Divide(MyFrac that) => new MyFrac(this.Nom * that.Denom, this.Denom * that.Nom);

        public override string ToString() => $"{Nom} / {Denom}";

        public int CompareTo(MyFrac? other)
        {
            if (other == null) return 1;
            BigInteger left = this.Nom * other.Denom;
            BigInteger right = other.Nom * this.Denom;
            return left.CompareTo(right);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not MyFrac other) 
                return false;

            return this.CompareTo(other) == 0;
        }

        public override int GetHashCode() => HashCode.Combine(Nom, Denom);
    }
}
