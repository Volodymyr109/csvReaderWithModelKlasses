using System;
using System.Collections.Generic;
using System.IO;

public class ArtikelModel
{
    public int ArtikelNr { get; set; }
    public string Name { get; set; }
    public float Preis { get; set; }   
}

public class Artikel : ArtikelModel
{
    public int ArtikelNr { get; set; }
    public string Name { get; set; }
    public float Preis { get; set; }

    public Artikel(int artikelNr, string name, float preis)
    {
        ArtikelNr = artikelNr;
        Name = name;
        Preis = preis;
    }
    // public string ToCSV()
    // {
    //     return $"{ArtikelNr};{Name};{Preis}";
    // }

    // public static void ToCSV(List<Artikel> artikels)
    // {
    //     using (StreamWriter sw = new StreamWriter("Artikel.csv"))
    //     {
    //         foreach (Artikel artikel in artikels)
    //         {
    //             sw.WriteLine(artikel.ToCSV());
    //         }
    //     }
    // }
    public static List<Artikel> FromCSV()
    {
        List<Artikel> artikels = new List<Artikel>();

        using (StreamReader sr = new StreamReader("ArtikelTEST.csv"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 3 && int.TryParse(parts[0], out int artikelNr) && float.TryParse(parts[2], out float preis))
                {
                    string name = parts[1];

                    artikels.Add(new Artikel(artikelNr, name, preis));
                }
            }
        }

        return artikels;
    }
}