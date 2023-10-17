using System;
using System.Collections.Generic;
using System.IO;

public class RechnungModel
{
    public int KundenNr { get; set; }
    public int ArtikelNr { get; set; }
    public float Anzahl { get; set; }
}
public class Rechnung : RechnungModel
{
    public Rechnung(int kundenNr, int artikelNr, float anzahl)
    {
        KundenNr = kundenNr;
        ArtikelNr = artikelNr;
        Anzahl = anzahl;
    }
// Write to csv file
    // public string ToCSV()
    // {
    //     return KundenNr + ";" + ArtikelNr + ";" + Anzahl;
    // }

    // public static void ToCSV(List<Rechnung> rechnungen)
    // {
    //     using (StreamWriter sw = new StreamWriter("Rechnung1.csv"))
    //     {
    //         foreach (Rechnung rechnung in rechnungen)
    //         {
    //             sw.WriteLine(rechnung.ToCSV());
    //         }
    //     }
    // }
// Read from csv
    public static List<Rechnung> FromCSV()
    {
        List<Rechnung> rechnungen = new List<Rechnung>();

        using (StreamReader sr = new StreamReader("Rechnung1.csv"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 3 && int.TryParse(parts[0], out int kundenNr) && int.TryParse(parts[1], out int artikelNr) && float.TryParse(parts[2], out float anzahl))
                {
                    rechnungen.Add(new Rechnung(kundenNr, artikelNr, anzahl));
                }
            }
        }

        return rechnungen;
    }
}