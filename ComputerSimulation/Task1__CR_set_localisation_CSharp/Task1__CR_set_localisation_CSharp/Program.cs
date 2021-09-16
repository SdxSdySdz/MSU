using System;
using Task1__CR_set_localisation_CSharp.LinearAlgebra;

namespace Task1__CR_set_localisation_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Vector2 vector = new Vector2(1, 2);

            Console.WriteLine(vector);
            Console.WriteLine(vector * 2);
            Console.WriteLine(0 * vector);
            Console.WriteLine(vector + 3*vector);

        }
    }
}
