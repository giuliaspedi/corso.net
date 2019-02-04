using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizi.Net.BusinessLogic
{
    public interface IFactory<T>
    {
        T Create();
    }
}
