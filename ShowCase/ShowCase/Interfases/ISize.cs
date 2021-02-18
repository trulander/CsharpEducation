using System;
using System.Collections.Generic;
using System.Text;

namespace ShowCase.Interfases
{
    public interface ISize<T>
    {
        List<T> Storage { get; set; }
        const int maxSize = 5;
        const int minSize = 1;
    }
}
