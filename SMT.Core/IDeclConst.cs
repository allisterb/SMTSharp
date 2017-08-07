using System;
using System.Collections.Generic;
using System.Text;

namespace SMT
{
    public interface IDeclConst<TSort> where TSort : Sort
    {
        Const<TSort> DeclConst(string name);
    }
}
