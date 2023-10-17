using System;
using System.Collections.Generic;
using System.IO;

internal class Program
{
    static void Main(string[] args)
    {
// Main write to csv file        
        // List<Rechnung> rechnungen = new List<Rechnung>()
        // {
        //     new Rechnung(1, 1001, 5.0f),
        //     new Rechnung(3, 1003, 2.0f),
        //     new Rechnung(4, 1002, 6.0f),
        //     new Rechnung(2, 1003, 1.0f),

        // };
        // Rechnung.ToCSV(rechnungen);

        // List<Kunde> kunden = new List<Kunde>()
        // {
        //     new Kunde(1, "Max", "Mozartstr", "Osna"),
        //     new Kunde(2, "Alice", "Musterstr", "DD"),
        //     new Kunde(3, "Bob", "Strassestr", "HH"),
        //     new Kunde(4, "Alex", "Osna.str", "H"),
        // };
        // Kunde.ToCSV(kunden);

        // List<Artikel> artikels = new List<Artikel>()
        // {
        //     new Artikel(1001, "Sony", 130.0f),
        //     new Artikel(1002, "Xbox", 250.0f),
        //     new Artikel(1003, "PC", 1250.0f),
        // };
        // Artikel.ToCSV(artikels);

// Main read from csv file
        Console.WriteLine("-----------------Kunden----------------");
        List<Kunde> kunden = Kunde.FromCSV();
        foreach (Kunde kunde in kunden)
        {
            Console.WriteLine($"KundenNr: {kunde.KundenNr}, Name: {kunde.Name}, Strasse: {kunde.Strasse}, Ort: {kunde.Ort}.");
        }

        Console.WriteLine("-----------------Artikel----------------");
        List<Artikel> artikels = Artikel.FromCSV();
        foreach (Artikel artikel in artikels)
        {
            Console.WriteLine($"ArtikelNr: {artikel.ArtikelNr}, Name: {artikel.Name}, Preis: {artikel.Preis} €");
        }

        Console.WriteLine("-----------------Rechnung----------------");
        List<Rechnung> rechnungen = Rechnung.FromCSV();

        var artikelDictionary = artikels.ToDictionary(a => a.ArtikelNr);

        foreach (Rechnung rechnung in rechnungen)
        {
            Console.WriteLine($"KundenNr: {rechnung.KundenNr}, ArtikelNr: {rechnung.ArtikelNr}, Anzahl: {rechnung.Anzahl}");
        }

        Console.WriteLine("---------------Gesamtbetrag--------------");
        GesamtbetragProKunde(kunden, rechnungen, artikelDictionary);
    }
    //Gesamtbetrage rechnen
    public static void GesamtbetragProKunde(List<Kunde> kunden, List<Rechnung> rechnungen, Dictionary<int, Artikel> artikelDictionary)
    {
        foreach (var kunde in kunden)
        {
            var kundenRechnungen = rechnungen.Where(r => r.KundenNr == kunde.KundenNr).ToList();

            float gesamtbetrag = 0.0f;
            foreach (var rechnung in kundenRechnungen)
            {
                if (artikelDictionary.TryGetValue(rechnung.ArtikelNr, out var artikel))
                {
                    gesamtbetrag += rechnung.Anzahl * artikel.Preis;
                }
            }

            Console.WriteLine($"Kunde: {kunde.Name}, Gesamtbetrag: {gesamtbetrag} €");
        }
    }
    // Alternative kuerzere funktion
// public static void GesamtbetragProKunde(List<Kunde> kunden, List<Rechnung> rechnungen, Dictionary<int, Artikel> artikelDictionary)
// {
//     foreach (var kunde in kunden)
//     {
//         float gesamtbetrag = rechnungen
//             .Where(r => r.KundenNr == kunde.KundenNr)
//             .Sum(r => artikelDictionary.TryGetValue(r.ArtikelNr, out var artikel) ? r.Anzahl * artikel.Preis : 0.0f);

//         Console.WriteLine($"Kunde: {kunde.Name}, Gesamtbetrag: {gesamtbetrag} €");
//     }
// }
}
