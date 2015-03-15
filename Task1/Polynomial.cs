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
            this.elements = CopyArrayToIndex(elements, i);
        }
        public Polynomial(Polynomial value)
        {
            int i = value.elements.Length - 1;
            while (value.elements[i] == 0 && i > 0) { i--; }
            this.elements = CopyArrayToIndex(value.elements, i);
        }
        public Polynomial(int elementsCount)
        {
            this.elements = new double[elementsCount];
        }

        public static Polynomial operator + (Polynomial valueFirst, Polynomial valueSecond)
        {
            int newLength = Math.Max(valueFirst.elements.Length, valueSecond.elements.Length);
            Polynomial newPolynom = new Polynomial(newLength);
            for (int i = 0; i < newLength; ++i)
            {
                if (i < valueFirst.elements.Length)
                {
                    newPolynom[i] += valueFirst[i];
                }
                if (i < valueSecond.elements.Length)
                {
                    newPolynom[i] += valueSecond[i];
                }
            }
            return new Polynomial(newPolynom);
        }
        public static Polynomial operator -(Polynomial valueFirst)
        {
            Polynomial newElement = new Polynomial(-1.0);
            return valueFirst * newElement;
        }
        public static Polynomial operator - (Polynomial valueFirst, Polynomial valueSecond)
        {
            return valueFirst + (-valueSecond);
        }
        public static Polynomial operator * (Polynomial valueFirst, Polynomial valueSecond)
        {
            int newLength = valueFirst.elements.Length * valueSecond.elements.Length;
            Polynomial newPolynom = new Polynomial(newLength);
            for (int i = 0; i < valueFirst.elements.Length; ++i)
            {
                for (int j = 0; j < valueSecond.elements.Length; ++j)
                {
                    newPolynom[i + j] += valueFirst[i] * valueSecond[j];
                }
            }
            return new Polynomial(newPolynom);
        }
        public override String ToString()
        {
            StringBuilder s = new StringBuilder();
            for (int i = this.elements.Length - 1; i >= 0; --i)
            {
                if (this[i] != 0)
                {
                    s.Append(this[i]);
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
                answer += this[i] * Math.Pow(value, i);
            }
            return answer;
        }
        public double this[int i]
        {
            get { return elements[i]; }
            set { elements[i] = value; }
        }
        private double[] CopyArrayToIndex(double[] oldArray, int lastIndex)
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
