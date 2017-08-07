using System;
using System.Collections.Generic;
using System.Text;

namespace SMT
{
    public class Core : Theory<Bool>
    {
        public static Const<Bool> True = new Const<Bool>(new Core(), "true");
        public Const<Bool> False = new Const<Bool>(new Core(), "false");
    }
}
