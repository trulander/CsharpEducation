using System.Collections;
using System.Collections.Generic;
using ShowCase.Models;

namespace ShowCase.Interfases
{
    public interface IDataBase
    {
        public List<Shop<Case<Product<int>>>> shops { get; set; }

    }
}