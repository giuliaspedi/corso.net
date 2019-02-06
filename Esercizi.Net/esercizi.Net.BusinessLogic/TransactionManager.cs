using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizi.Net.BusinessLogic
{

    public class TransactionManager
    {
         
        public ITransactionFactory Factory { get; } //se una funzione ha solo il metodo get si può definire nel costruttore
        public List<ITransazione> Transazioni { get; }
        public TransactionManager() : this(new TransactionFactory()) { }
        public TransactionManager(ITransactionFactory factory)
        {
            Factory = factory;
            Transazioni = new List<ITransazione>();
        }

        public ITransazione CreateTransaction()
        {
            return Factory.Create();
        }

        public void SaveTransaction (ITransazione transazione)
        {
            Transazioni.Add(transazione);
        }

        public ITransazione DeleteTransaction (int index)
        {
            Transazioni.RemoveAt(index);
            return null;
        }

        public IEnumerable<ITransazione> GetTransaziones()
        {
            return Transazioni;
        }
    }
}
