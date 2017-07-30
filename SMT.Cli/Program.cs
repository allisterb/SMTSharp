using System;

namespace SMT.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Theorem t = new Theorem();
            Function<Bool, Bool> f = t.DeclareFunc<Bool, Bool>("f");
            Console.WriteLine(f.ToString());
        }
    }
}