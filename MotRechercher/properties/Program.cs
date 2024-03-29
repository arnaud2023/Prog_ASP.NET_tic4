using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChercherLeMot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // chercher le mot melangé by Olivia Gamo

            Console.WriteLine("****************** BIENVENU DANS LE CHERCHEUR DE MOTS MELANGES *********************\n");
            Console.WriteLine("***************************************************************************** BY GTOL \n");

            // creation et initialisation d'une liste  avec chaque ligne du fichier Dictionnaire.txt (en minuscule et sans espace blanc de debut ou de fin)
            IList<string> motsDuDictionnaire = File.ReadAllLines("Dictionnaire.txt").Select(item => item.ToLower().Trim()).ToList();

            Console.WriteLine("Entrez les mots melangés  en separant chacun par une virgule \n\n");
            string motMelanger=Console.ReadLine();
            Console.WriteLine("\n");
            // recuperer les entrées et les stockees dans une liste  de chaines de caracteres avec comme delimitateur ","
            IList<string> motsMelanges = motMelanger.Trim().Split(',');

            foreach (var mot in motsMelanges)
            {
               
               // trier (tableau de caractere) les lettre de chaque mot melangé entré par l'utilisateur par ordre alphabetique croissant
                string motMelangerTrier = new string(mot.ToLower().ToCharArray().OrderBy(c => c).ToArray());
                
                bool correspondanceTrouvee = false;
                foreach (var motDuDictionnaire in motsDuDictionnaire)
                {
                    //trier (tableau de caractere) les lettress de chaque mot du dictionnaire par ordre alphabetique croissant
                    string motDicTri = new string(motDuDictionnaire.ToCharArray().OrderBy(c => c).ToArray());
                    if (motMelangerTrier.Equals(motDicTri))
                    {
                        Console.WriteLine($"{mot} : correspond à {motDuDictionnaire}\n");
                        correspondanceTrouvee= true;
                        break;
                    }

                    
                }
                if (!correspondanceTrouvee) {
                    Console.WriteLine($"{mot} : Aucune correspondance trouvée.\n");
                }

            }
        }
    }
}
