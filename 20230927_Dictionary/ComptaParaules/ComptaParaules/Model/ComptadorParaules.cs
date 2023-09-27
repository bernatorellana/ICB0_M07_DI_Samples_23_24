using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Devices.Power;
using Windows.Storage;
using Windows.UI.Popups;

namespace ComptaParaules.Model
{
    internal class ComptadorParaules
    {
        public async Task carregaArxiuAsync(String arxiu)
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(
                new Uri($"ms-appx:///Assets/{arxiu}"));
            using (var inputStream = await file.OpenReadAsync())
            using (var classicStream = inputStream.AsStreamForRead())
            using (var streamReader = new StreamReader(classicStream))
            {
                int numParaules = 0;
                Dictionary<string, int> recompte = new Dictionary<string, int>();
                String frase;
                while (streamReader.Peek() >= 0)
                {
                    frase = streamReader.ReadLine();
                    string[] paraules = frase.Split( 
                            new char[]{ ' ','-'},
                            StringSplitOptions.RemoveEmptyEntries
                            );
                    foreach (string paraula in paraules)
                    {
                        numParaules++;
                        String result = paraula.ToLower();
                        result = Regex.Replace(result, "[^a-z']", "");
                        // Mirem si la paraula està al diccionari
                        bool estaAlDiccionari = recompte.ContainsKey(result);
                        int n = 0;
                        if (estaAlDiccionari)
                        {
                            n = recompte[result];
                        }
                        recompte[result] = n+1;
                        //Debug.WriteLine(result);
                    }
                    //Debug.WriteLine(string.Format("the line is {0}", streamReader.ReadLine()));
                }
                Debug.WriteLine($"Hi ha {numParaules} paraules.");
                Debug.WriteLine($"===============================");
                // Recorrecut per recompte
                //foreach(var e in recompte)
                //{
                //    Debug.WriteLine(e.Key + ": " + e.Value);
                //}
                List<KeyValuePair<string,int>> parellsOrdenats =
                    recompte.ToList().OrderByDescending(parell=>parell.Value).ToList();
                foreach (var e in parellsOrdenats)
                {
                    Debug.WriteLine(e.Key + ": " + e.Value);
                }
                //List<Order> SortedList = objListOrder.OrderBy(o=>o.OrderDate).ToList();
            }
        }
    }
}
