using System;

namespace SMT.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            BooleanProblem p = new BooleanProblem();
            Function<Bool, Bool> f = p.DeclareFunc<Bool, Bool>("f");
            Console.WriteLine(f.ToString());
        }
    }
}