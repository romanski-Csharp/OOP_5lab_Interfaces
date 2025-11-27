using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5lab_Interfaces
{
    interface IMyNumber<T> where T : IMyNumber<T>
    {
        T Add(T that);
        T Subtract(T that);
        T Multiply(T that);
        T Divide(T that);
    }
}
