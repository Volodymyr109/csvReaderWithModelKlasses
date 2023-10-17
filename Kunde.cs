using System;
using System.Collections.Generic;
using System.IO;

public class KundenModel
{
    public int KundenNr { get; set; }
    public string Name { get; set; }
    public string Strasse { get; set; }
    public string Ort { get; set; }
}

public class Kunde : KundenModel
{
    public Kunde(int kundenNr, string name, string strasse, string ort)
    {
        KundenNr = kundenNr;
        Name = name;
        Strasse = strasse;
        Ort = ort;
    }
// Write to csv file
    // public string ToCSV()
    // {
    //     return $"{KundenNr};{Name};{Strasse};{Ort}";
    // }

    // public static void ToCSV(List<Kunde> kunden)
    // {
    //     using (StreamWriter sw = new StreamWriter("Kunden1.csv"))
    //     {
    //         foreach (Kunde kunde in kunden)
    //         {
    //             sw.WriteLine(kunde.ToCSV());
    //         }
    //     }
    // }
// Read from csv    
    public static List<Kunde> FromCSV()
    {
        List<Kunde> kunden = new List<Kunde>();

        using (StreamReader sr = new StreamReader("Kunden1.csv"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 4 && int.TryParse(parts[0], out int kundenNr))
                {
                    string name = parts[1];
                    string strasse = parts[2];
                    string ort = parts[3];

                    kunden.Add(new Kunde(kundenNr, name, strasse, ort));
                }
            }
        }

        return kunden;
    }
}