using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizi.Net.BusinessLogic
{
    public class CategoryManager
    {
        public IFactory<ICategory> Factory { get; }
        public List<ICategory>  Categorie { get;}
        public CategoryManager() : this(new CategoryFactory()) { }
        public CategoryManager(IFactory<ICategory>  factory)
        {
            Factory = factory;
            Categorie = new List<ICategory>();
        }
        public ICategory CreateCategory()
        {
            return Factory.Create();
        }
        public void AddCategory(ICategory nuovaCategoria)
        {

            Categorie.Add(nuovaCategoria);
        }
        public void DeleteCategory(int index)
        {
            Categorie.RemoveAt(index);
        }
        public void StampCategory()
        {
            if (Categorie.Count == 0)
            {
                Console.WriteLine("Non ci sono categorie salvate");
            }
            else
            {
                foreach (ICategory C in Categorie)
                {
                    Console.WriteLine(C + "\n");
                }
            }
        }
        public List<ICategory> GetCategories()
        {
            return Categorie;
        }

    }

}