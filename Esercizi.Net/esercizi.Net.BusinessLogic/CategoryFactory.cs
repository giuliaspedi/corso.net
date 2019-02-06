using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizi.Net.BusinessLogic
{
    public class CategoryFactory : IFactory<ICategory>
    { 
        public ICategory Create()
        {
            return new Categoria();
        }
       

    }
}
