using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMT
{
    public abstract class Theory<S> where S: Sort
    {
        public abstract Const<S> DeclConst(string name);
    }
}
