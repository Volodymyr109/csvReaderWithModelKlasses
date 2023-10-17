using System;
using System.Collections.Generic;
using System.IO;

internal class Program
{
    static void Main(string[] args)
    {
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
}