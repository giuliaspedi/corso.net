using System;
using System.Collections.Generic;
using esercizi.Net.BusinessLogic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi.Net.ConsoleApp
{
    public class Program
    {
        private static CategoryManager _categoryManager= null;
        public static CategoryManager CategoryManager
        {
            get
            {
                if (_categoryManager == null)
                {
                    _categoryManager = new CategoryManager();
                }
                return _categoryManager;
            }

        }
        private static TransactionManager _transactionManager = null; // la proprety è privata
        public static TransactionManager TransactionManager
        {
            //metto solo il get perché è una property solo in lettura
            get
            {
                if (_transactionManager == null)
                {
                    _transactionManager = new TransactionManager();

                }

                return _transactionManager;
            }

        }
        private static void StampaMenu()
        {
            Console.Clear();
            Console.WriteLine("Opzioni disponibili:");
            Console.WriteLine("m/menu - stampa elenco opzioni (questo elenco)");
            Console.WriteLine("a/aggiungi - aggiungi una nuova transazione");
            Console.WriteLine("c/cancella - cancella una transazione");
            Console.WriteLine("s/stampa - stampa le transazioni esistenti");
            Console.WriteLine("e/esci - esci dal programma");
        }

        //public static void AggiungiCategorie(List<Categoria> Categorie)
        //{
        //    Categoria nuovaCategoria = new Categoria();
        //    Console.Write("Nome: ");
        //    nuovaCategoria.NomeCategoria = Console.ReadLine();

        //    Console.Write("Descrizione: ");
        //    nuovaCategoria.DescrizioneCategoria = Console.ReadLine();
            
        //    Categorie.Add(nuovaCategoria);
        //}

        public static void Main(string[] args)
        {
            string opzione = string.Empty;
            //List<Categoria> Categorie = new List<Categoria>();

            //List<ICategory> Categorie = new List<ICategory>();

            //List<ITransazione> transazioni = new List<ITransazione>();
            //ITransactionFactory factory = new TransactionFactory();



            do
            {
                
                Console.WriteLine("-Per operare sulle Transazioni scrivi: T \n-Per gestire una nuova Categoria scrivi: C \n-Per uscirE dal programma scrivi: E");
                string opzioneT = Console.ReadLine();
                Console.Clear();
                IEnumerable<ICategory> categorie = CategoryManager.GetCategories();


                if (opzioneT == "E" || opzioneT =="e")
                {
                    Console.Write("Sei sicuro di voler uscire? (si/no): ");
                    opzione = Console.ReadLine();
                    if (opzione == "si")
                    {
                        return;
                    }
                    if (opzione != "no")
                    {
                        Console.WriteLine("Opzione non riconosciuta.");
                    }

                }
                if (opzioneT == "T" || opzioneT == "t")
                {
                    StampaMenu();
                    Console.WriteLine();
                    Console.Write("cosa vuoi fare?: ");
                    opzione = Console.ReadLine();
                    Console.Clear();
                    IEnumerable<ITransazione> transazioni = TransactionManager.GetTransaziones();
                    switch (opzione)
                    {
                        case "m":
                        case "menu":
                            StampaMenu();
                            break;
                        case "a":
                        case "aggiungi":
                            try
                            {

                                //ITransazione nuovaTransazione = factory.Create();

                                ITransazione nuovaTransazione = TransactionManager.CreateTransaction();
                                Console.WriteLine();

                                Console.Write("Data transazione (MM/gg/aaaa): ");
                                string dtTransazione = Console.ReadLine();
                                nuovaTransazione.DataTransazione = DateTime.Parse(dtTransazione);

                                Console.Write("Tipo transazione (" + TipoTransazione.Spesa + "/" + TipoTransazione.Ricavo + ") :");
                                //nuovaTransazione.Tipo = Console.ReadLine();
                                string tipo = Console.ReadLine();
                                if(tipo == TipoTransazione.Spesa.ToString())
                                {
                                    nuovaTransazione.Tipo = TipoTransazione.Spesa;

                                }
                                else if (tipo == TipoTransazione.Ricavo.ToString())
                                {
                                    nuovaTransazione.Tipo = TipoTransazione.Ricavo;
                                }
                                else
                                {
                                    Console.WriteLine("Valore non corretto.");
                                }
                                                        

                                if (categorie.Count() == 0)
                                {
                                    Console.Write("          Non esiste una categoria \n");
                                    Console.Write("          Vuoi aggiungere una nuova categoria? si/no: ");
                                    string scelta = Console.ReadLine();
                                    if (scelta == "si")
                                    {
                                        
                                        ICategory NuovaCategoria = CategoryManager.CreateCategory();
                                        Console.Write("          Nome: ");
                                        NuovaCategoria.NomeCategoria = Console.ReadLine();

                                        Console.Write("          Descrizione: ");
                                        NuovaCategoria.DescrizioneCategoria = Console.ReadLine();
                                        CategoryManager.AddCategory(NuovaCategoria);
                                        Console.WriteLine("          Categoria Aggiunta");
                                        nuovaTransazione.Categoria = NuovaCategoria;
                                    }
                                    else if (scelta == "no")
                                    {
                                        Console.WriteLine("Operazione annullata.");
                                        break;
                                    }
                                    
                                }
                                else
                                {
                                    CategoryManager.StampCategory();
                                    //Console.Write("Le categorie esistenti sono: ");

                                    //foreach (Categoria categoria in Categorie)
                                    //{
                                    //    Console.Write(categoria.NomeCategoria + "\n");
                                    //}

                                    Console.Write("Vuoi usare una categoria Vecchia o crearne una Nuova? \nV = Vecchia \nN = Nuova: ");
                                    string nuovaOpzione = Console.ReadLine();
                                    if (nuovaOpzione == "N")
                                    {
                                        ICategory NuovaCategoria = CategoryManager.CreateCategory();
                                        Console.Write("Nome: ");
                                        NuovaCategoria.NomeCategoria = Console.ReadLine();

                                        Console.Write("Descrizione: ");
                                        NuovaCategoria.DescrizioneCategoria = Console.ReadLine();
                                        CategoryManager.AddCategory(NuovaCategoria);
                                        Console.WriteLine("Categoria Aggiunta");

                                    }

                                    else if (nuovaOpzione == "V")
                                    {
                                        Console.Write("Inserisci una vecchia categoria: ");
                                        string nomeCategoria = Console.ReadLine();

                                        foreach (Categoria k in categorie)
                                        {
                                            Console.Write(k + "\n");
                                            if (nomeCategoria == k.NomeCategoria)
                                            {
                                                nuovaTransazione.Categoria = k;
                                                break;
                                            }
                                        }

                                        if (nuovaTransazione.Categoria == null)
                                        {
                                            throw new Exception();
                                        }
                                    }
                                    }

                                Console.Write("Descrizione transazione: ");
                                nuovaTransazione.Descrizione = Console.ReadLine();
                                Console.Write("Importo transazione: ");
                                string impTransazione = Console.ReadLine();
                                nuovaTransazione.Importo = decimal.Parse(impTransazione);

                                //transazioni.Add(nuovaTransazione);
                                TransactionManager.SaveTransaction(nuovaTransazione);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Errore durante l'inserimento della transazione.");
                            }
                            break;
                        case "c":
                        case "cancella":

                            if (transazioni.Count() == 0)
                            {
                                Console.WriteLine("Questa opzione non è disponibile. La lista è vuota.");
                            }
                            else if (transazioni.Count() == 1)
                            {
                                Console.Write("Sei sicuro di voler procedere? (si/no): ");
                                opzione = Console.ReadLine();
                                if (opzione == "si")
                                {
                                    //transazioni.RemoveAt(0);
                                    TransactionManager.DeleteTransaction(0);
                                    Console.WriteLine("Elemento cancellato.");
                                }
                                else if (opzione == "no")
                                {
                                    Console.WriteLine("Operazione annullata.");
                                }
                                else
                                {
                                    Console.WriteLine("Opzione non valida.");
                                }
                            }
                            else
                            {
                                Console.Write("Qual è la posizione della transazione che vuoi cancellare? ");
                                opzione = Console.ReadLine();
                                try
                                {
                                    int posizione = int.Parse(opzione);
                                    if (posizione > 0 && posizione <= transazioni.Count())
                                    {
                                        Console.Write("Sei sicuro di voler procedere? (si/no): ");
                                        opzione = Console.ReadLine();
                                        if (opzione == "si")
                                        {
                                            //transazioni.RemoveAt(posizione - 1);
                                            TransactionManager.DeleteTransaction(posizione - 1);

                                            Console.WriteLine("Elemento cancellato.");
                                        }
                                        else if (opzione == "no")
                                        {
                                            Console.WriteLine("Operazione annullata.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Opzione non valida.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Posizione non valida. Le posizioni valide sono da 1 a " + transazioni.Count() + ".");
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Errore durante la cancellazione.");
                                }
                            }
                            break;
                        case "s":
                        case "stampa":
                            if (transazioni.Count() == 0)
                            {
                                Console.WriteLine("Non ci sono transazioni.");
                            }
                            else
                            {
                                int i = 0;
                                foreach (ITransazione transazione in transazioni)
                                {

                                    Console.WriteLine((i + 1) + ":");
                                    Console.WriteLine(transazione);
                                    Console.WriteLine();
                                    i++;
                                }
                            }
                            break;

                        default:
                            Console.WriteLine("Opzione non riconosciuta. Riprovare.");
                            break;
                    }
                }




                if (opzioneT == "C" || opzioneT == "c")
                {
                    Console.WriteLine();
                    Console.Write("Cosa vuoi fare?: ");
                    Console.WriteLine();
                    Console.WriteLine("A Add \nD Delete \nS Stamp: ");
                    string opzioneC = Console.ReadLine();
                    switch (opzioneC)
                    {
                        case "a":
                        case "A":
                            ICategory NuovaCategoria = CategoryManager.CreateCategory();
                            Console.Write("Nome: ");
                            NuovaCategoria.NomeCategoria = Console.ReadLine();

                            Console.Write("Descrizione: ");
                            NuovaCategoria.DescrizioneCategoria = Console.ReadLine();
                            CategoryManager.AddCategory(NuovaCategoria);
                            Console.WriteLine("Categoria Aggiunta");
                            
                                                        
                            break;



                        case "d":
                        case "D":

                            if (categorie.Count() == 0)
                            {
                                Console.WriteLine("Questa opzione non è disponibile. La lista è vuota.");
                            }
                            else if (categorie.Count() == 1)
                            {
                                Console.Write("Sei sicuro di voler procedere? (si/no): ");
                                opzione = Console.ReadLine();
                                if (opzione == "si")
                                {
                                    CategoryManager.DeleteCategory(0);

                                    Console.WriteLine("Elemento cancellato.");
                                }
                                else if (opzione == "no")
                                {
                                    Console.WriteLine("Operazione annullata.");
                                }
                                else
                                {
                                    Console.WriteLine("Opzione non valida.");
                                }
                            }
                            else
                            {
                                Console.Write("Qual è la posizione della categoria che vuoi cancellare? ");
                                opzione = Console.ReadLine();
                                try
                                {
                                    int posizione = int.Parse(opzione);
                                    if (posizione > 0 && posizione <= categorie.Count())
                                    {
                                        Console.Write("Sei sicuro di voler procedere? (si/no): ");
                                        opzione = Console.ReadLine();
                                        if (opzione == "si")
                                        {
                                            //transazioni.RemoveAt(posizione - 1);
                                            CategoryManager.DeleteCategory(posizione);

                                            Console.WriteLine("Elemento cancellato.");
                                        }
                                        else if (opzione == "no")
                                        {
                                            Console.WriteLine("Operazione annullata.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Opzione non valida.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Posizione non valida. Le posizioni valide sono da 1 a " + categorie.Count() + ".");
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Errore durante la cancellazione.");
                                }
                            }
                            break;



                        case "s":
                        case "S":
                            if (categorie.Count() == 0)
                            {
                                Console.WriteLine("Non ci sono categorie.");
                            }
                            else
                            {
                                CategoryManager.StampCategory();
                            }
                            break;

                    }
                }

            } while (true);
        }

    }
}

