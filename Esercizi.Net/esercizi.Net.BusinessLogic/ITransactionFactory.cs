using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizi.Net.BusinessLogic
{
    // sto implementando una factory del tipo ITransazione
    public interface ITransactionFactory : IFactory<ITransazione>
    {
    }

}
