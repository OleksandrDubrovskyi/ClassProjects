using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_var_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Abra first = new Abra();
            Abra second = new Abra("second", "student");

            Console.WriteLine(first.name);
            Console.WriteLine(second.name);
            Abra.GetCount();

            Abra third = new Abra("third", "student", 5);
            Console.WriteLine(second.name);
            Abra.GetCount();

            Abra Cadabra = new Abra();

            int num = 5;
            Console.WriteLine(num.square());

            string area = Beta.coolText(hi: " Abracadabra", wid: 4);
            Console.WriteLine(area);
        }
    }

    public static class Beta
    {
        public static int square(this int num)
        {
            return num * num;
        }

        public static string coolText(int wid, string hi)
        {
            string res = (wid.ToString() + hi);
            return res;
        }
    }

    class Abra
    {
        static int count;
        public string name;
        public string surname;
        int grade;

        public Abra(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            count++;
        }

        public Abra(string name, string surname, int grade)
        {
            this.name = name;
            this.surname = surname;
            this.grade = grade;
            count++;
        }

        public Abra()
        {
            count++;
        }

        public static void GetCount()
        {
            Console.WriteLine(count);
        }
    }
}
