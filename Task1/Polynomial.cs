using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Polynomial
    {
        private double[] elements;

        public Polynomial(params double[] elements)
        {
            int i = elements.Length - 1;
            while (elements[i] == 0 && i > 0) { i--; }
            this.elements = CopyToMod(elements, i);
        }

        public static Polynomial operator + (Polynomial valueFirst, Polynomial valueSecond)
        {
            int newLength = Math.Max(valueFirst.elements.Length, valueSecond.elements.Length);
            double[] newElements = new double[newLength];
            for (int i = 0; i < newLength; ++i)
            {
                if (i < valueFirst.elements.Length)
                {
                    newElements[i] += valueFirst.elements[i];
                }
                if (i < valueSecond.elements.Length)
                {
                    newElements[i] += valueSecond.elements[i];
                }
            }
            return new Polynomial(newElements);
        }
        public static Polynomial operator - (Polynomial valueFirst, Polynomial valueSecond)
        {
            int newLength = Math.Max(valueFirst.elements.Length, valueSecond.elements.Length);
            double[] newElements = new double[newLength];
            for (int i = 0; i < newLength; ++i)
            {
                if (i < valueFirst.elements.Length)
                {
                    newElements[i] += valueFirst.elements[i];
                }
                if (i < valueSecond.elements.Length)
                {
                    newElements[i] -= valueSecond.elements[i];
                }
            }
            return new Polynomial(newElements);
        }
        public static Polynomial operator * (Polynomial valueFirst, Polynomial valueSecond)
        {
            int newLength = valueFirst.elements.Length + valueSecond.elements.Length;
            double[] newElements = new double[newLength];
            for (int i = 0; i < valueFirst.elements.Length; ++i)
            {
                for (int j = 0; j < valueSecond.elements.Length; ++j)
                {
                    newElements[i + j] += valueFirst.elements[i] * valueSecond.elements[j];
                }
            }
            return new Polynomial(newElements);
        }
        public override String ToString()
        {
            StringBuilder s = new StringBuilder();
            for (int i = this.elements.Length - 1; i >= 0; --i)
            {
                if (this.elements[i] != 0)
                {
                    s.Append(this.elements[i]);
                    if (i != 0)
                        s.Append("*" + "x^" + i + " + ");
                }
                
            }
            if (s.Length == 0) s.Append('0');
            return s.ToString().Trim('+', ' ');
        }
        public double Calculate(double value)
        {
            double answer = 0;
            for (int i = 0; i < this.elements.Length; ++i)
            {
                answer += this.elements[i] * Math.Pow(value, i);
            }
            return answer;
        }
        public double this[int i]
        {
            get { return elements[i]; }
            set { elements[i] = value; }
        }
        private double[] CopyToMod(double[] oldArray, int lastIndex)
        {
            double[] newArray = new double[lastIndex + 1];
            for (int i = 0; i <= lastIndex; ++i)
            {
                newArray[i] = oldArray[i];
            }
            return newArray;
        }
    }
}
