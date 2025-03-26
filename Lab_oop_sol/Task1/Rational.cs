using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Rational
    {
        private int Numerator; // типа числитель 
        private int Denominator; //типа знаменатель

        public Rational(int a, int b)
        {

            if (b == 0)
                throw new ArgumentException("Почему знаменатель ноль");

            if (a == 0)
            {
                Numerator = 0;
                Denominator = 1;
                return;
            }

            int nod = NOD(Math.Abs(a), Math.Abs(b));
            a /= nod;
            b /= nod;

            if ((a < 0) & (b < 0))
            {
                a = (-1) * a; b = (-1) * b;
            }

            Numerator = a; Denominator = b;
        }

        private static int NOD(int a, int b)
        {
            while (b != 0)
            {
                int c = b;
                b = a % b;
                a = c;
            }
            return a;
        }

        public override string ToString()
        {
            string str = string.Empty;
            if (Math.Abs(Denominator) == 1) // для случая со знаменателем = 1
                str = "" + Math.Abs(Numerator);
            else str = "" + Math.Abs(Numerator) + "/" + Math.Abs(Denominator);

            if ((Denominator < 0) || (Numerator < 0)) // когда и то и то отрицательное
            {
                str = "-" + str;
            }
            if (Numerator == 0)
                str = "0";

            return str;
        }

        public static Rational operator +(Rational one, Rational two)
        {
            int new_num = one.Numerator * two.Denominator + two.Numerator * one.Denominator;
            int new_det = one.Denominator * two.Denominator;
            return new Rational(new_num, new_det);
        }
        public static Rational operator -(Rational one, Rational two)
        {
            int new_num = one.Numerator * two.Denominator - two.Numerator * one.Denominator;
            int new_det = one.Denominator * two.Denominator;
            return new Rational(new_num, new_det);
        }
        public static Rational operator *(Rational one, Rational two)
        {
            int new_num = one.Numerator * two.Numerator;
            int new_det = one.Denominator * two.Denominator;
            return new Rational(new_num, new_det);
        }
        public static Rational operator /(Rational one, Rational two)
        {
            if (two.Numerator == 0)
                throw new ArgumentException("На ноль делить нельзя"); //узнай заканчивается прога после исключения или нет
            int new_num = one.Numerator * two.Denominator;
            int new_det = one.Denominator * two.Numerator;
            return new Rational(new_num, new_det);
        }
        public static Rational operator -(Rational one)
        {
            int new_num = one.Numerator * (-1);
            return new Rational(new_num, one.Denominator);
        }
        public static bool operator ==(Rational one, Rational two)
        {
            int new_first_num = one.Numerator * two.Denominator;
            int new_second_num = two.Numerator * one.Denominator;
            return (new_first_num == new_second_num);
        }
        public static bool operator !=(Rational one, Rational two)
        {
            int new_first_num = one.Numerator * two.Denominator;
            int new_second_num = two.Numerator * one.Denominator;
            return (new_first_num != new_second_num);
        }
        public static bool operator >=(Rational one, Rational two)
        {
            int new_first_num = one.Numerator * two.Denominator;
            int new_second_num = two.Numerator * one.Denominator;
            return (new_first_num >= new_second_num);
        }
        public static bool operator <=(Rational one, Rational two)
        {
            int new_first_num = one.Numerator * two.Denominator;
            int new_second_num = two.Numerator * one.Denominator;
            return (new_first_num <= new_second_num);
        }
    
        public static bool operator >(Rational one, Rational two)
        {
            int new_first_num = one.Numerator * two.Denominator;
            int new_second_num = two.Numerator * one.Denominator;
            return (new_first_num > new_second_num);
        }
        public static bool operator <(Rational one, Rational two)
        {
            int new_first_num = one.Numerator * two.Denominator;
            int new_second_num = two.Numerator * one.Denominator;
            return (new_first_num < new_second_num);
        }
    }
}
