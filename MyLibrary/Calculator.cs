using System;

namespace MyLibrary
{
    public class Calculator : ICalculator
    {
        public double Add(double  x, double y) => x + y;
        
        public double Subtract(double  x, double y) => x - y;
    }
}