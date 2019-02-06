using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizi.Net.BusinessLogic
{
    public class Categoria : ICategory
    {
        public string NomeCategoria { get; set; }

        public string DescrizioneCategoria { get; set; }

        public override string ToString()
        {
            return "nome: " + NomeCategoria + " \n" +
                "descrizione: " + DescrizioneCategoria; 
        }
            }
}
