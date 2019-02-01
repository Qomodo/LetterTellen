using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LetterTellen
{
    public class Program
    {
        string randomString;

        private static string sourceString = File.ReadAllText(@"C:\Users\Dion\Desktop\Programmeren\Text dat je wilt Scannen.txt");         //input
        public static void Main(string[] args)
        {
            //Interface(); //activeren
                //-verbinden met forms voor uploaden text bestand
                //-weergeven letters/woorden/zinnen/etc
                //-Aanpassen wat je wilt zien
                    //lengte weergaveLijst
                    //top 10/5/1
                    //verwijderen count = 0?
                    //Volledige lijst
                    //leestekens???

                //uitprinten resultaten?

        

       
            LettersTellen();   
            WoordenTellen();
            ZinnenTellen();            
            Console.ReadLine();
        }
               
        public static void LettersTellen()
        {
            int a = ((int) 'a')-1;
            int zCharIndex = (int) 'z';
            int charIndexLength = zCharIndex - a;                               //Delta Z-A
            int count = 0;                    

            for (int charIndexLoop = 0; charIndexLoop < charIndexLength; charIndexLoop++)   //charIndexLength = duratie(z-a) loop
            {
                a++;                                            //andereletter ++                            

                foreach (char item in sourceString.ToLower())                   //voor elke char in filepath, in lowercase
                {
                    if (item == Convert.ToChar(a))                // meet of elke (char) Item 'tzelfde is als de letter in a, zo ja count++  
                    {
                        count++;
                    }
                    
                }
                if (count>0)                                       //alleen maar tellen als het nodig is
                {
                char andereLetter = Convert.ToChar(a);                
                Console.WriteLine("I count -{1}- : {0} time!", count, andereLetter);
                count = 0;                                       //reset count
                }
                else
                {
                    break;
                }
            }               
        }
        public static void WoordenTellen()
        {           
            string[] woorden = sourceString.Split(' ');   //scheidt woorden door (' ')            
            List<string>lijstGescandeWoorden = new List<string>();
            List<string> geenDoublesLijstGescandeWoorden = new List<string>();


            foreach (string woord in woorden)
            {
                //woorden kleine letters geven & verwijder interpunctie
                //verwijder: ?!.,\r\n
                string cleanwoord = woord.ToLower().Replace(".", "").Replace("\n", "").Replace("\r", "").Replace(",", "").Replace("?","").Replace("!","").ToString(); 

                lijstGescandeWoorden.Add(cleanwoord);                                 //stopt alle bewerkte woorden in een lijst
                geenDoublesLijstGescandeWoorden = lijstGescandeWoorden.Distinct().ToList(); //verwijdert dubbele woorden & maakt nieuwe lijst                  
            }
            
            int count = 0;
            foreach (var woord in geenDoublesLijstGescandeWoorden)              //voor elke woord in gescande woorden
            {          
                List<string> woordenKopie = new List<string>(woorden);   // kopielijst, die bewerkt mag worden
                
                for (int i = 0; i < woorden.Length; i++)             //loopt tot lengte kopielijst
                {
                    foreach (string item in woorden)
                    {
                        string cleanItem = item.ToLower().Replace(".", "").Replace("\n", "").Replace("\r", "").Replace(",", "").Replace("?", "").Replace("!", "").ToString();

                        if (woordenKopie.First() == cleanItem)              //als woord == gescande woord count+1, 
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }                                        
                    woordenKopie.RemoveAt(0);                       //verwijder woord uit Kopie                                           
                    }
                }
                Console.WriteLine("Woord: {0} {1} keer gebruikt!",woord,count);
                count = 0;
            }            
        }
        public static void ZinnenTellen()
        {
            int AlleHoofdLetters = 0;
            int zinEind = 0;                       

            string copy = String.Copy(sourceString);             //Kopie die je wel mag bewerken
            
            foreach (char item in copy)           //telt hoofdletters
            {
                if (char.IsUpper(item))               
                {
                    AlleHoofdLetters++;
                    copy.Remove(0);
                }                   
                else if (item == '!')             //telt einde zinnen          
                {
                    zinEind++;
                    copy.Remove(0);
                }
                else if (item == '?')
                {
                    zinEind++;
                    copy.Remove(0);
                }
                else if (item == '.')
                {
                    zinEind++;
                    copy.Remove(0);
                }
                else
                {
                    copy.Remove(0);                        
                }                    
            }

            string zinOfZinnen = "";                              //zin of zinnen?
            if (zinEind >1)
            {
                zinOfZinnen = "Zinnen";
            }
            else
            {
                zinOfZinnen = "zin";
            }

            int volledigeZin = zinEind;
            Console.WriteLine("Je hebt {0} {1} gebruikt", volledigeZin,zinOfZinnen);

        }
    }

}
