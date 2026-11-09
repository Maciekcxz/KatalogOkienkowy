
using System;
using System.Collections.Generic;
using System.Linq;

namespace KatalogOkienkowy
{
    internal class Product
    {
        private string _nazwa;
        private double _cena;

        public string Nazwa
        {
            get { return _nazwa; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _nazwa = "Brak nazwy";
                    throw new ArgumentException("Nazwa nie może być pusta.");
                }
                else
                {
                    _nazwa = value;
                }
            }
        }

        public double cena
        {
            get { return _cena; }
            set
            {
                if (value < 0)
                {
                    _cena = 0;
                    throw new ArgumentException("Cena nie może być ujemna.");
                }
                else
                {
                    _cena = value;
                }
            }
        }

        public int MinimalnyStan { get; set; }

        public string Kategoria { get; set; }

        public int Ilosc { get; private set; }

        // Wartość magazynu dla jednego produktu
        public double WartośćMagazynu
        {
            get { return cena * Ilosc; }
        }

        // Konstruktor bez parametrów
        public Product()
        {
            Nazwa = "Brak nazwy";
            cena = 0;
            Kategoria = "Brak kategorii";
            Ilosc = 0;
            MinimalnyStan = 1;
        }

        // Konstruktor z wszystkimi parametrami
        public Product(string nazwa, double cena, string kategoria, int ilosc)
        {
            Nazwa = nazwa;
            this.cena = cena;
            Kategoria = kategoria;
            Ilosc = ilosc;
            MinimalnyStan = 1;
        }

        // Konstruktor tylko z nazwą
        public Product(string nazwa)
        {
            Nazwa = nazwa;
            cena = 0;
            Kategoria = "Brak kategorii";
            Ilosc = 0;
            MinimalnyStan = 1;
        }

        // Wypisuje informacje o produkcie
        public void WypiszProdukt()
        {
            Console.WriteLine(InformacjeOProdukcie());
        }

        // Zwraca informacje o produkcie jako tekst
        public string InformacjeOProdukcie()
        {
            return $"Nazwa: {Nazwa,-15}| Cena: {cena,10:F2} zł | " +
                   $"Kategoria: {Kategoria} | Ilość: {Ilosc,5} | " +
                   $"Wartość magazynu: {WartośćMagazynu,10:F2} zł";
        }

        // Dodatkowa funkcja z drugiego kodu
        public override string ToString()
        {
            return InformacjeOProdukcie();
        }

        // Oblicza wartość magazynu dla tablicy produktów
        public static double ObliczWartoscMagazynu(Product[] produkty)
        {
            double suma = 0;

            foreach (Product produkt in produkty)
            {
                suma += produkt.WartośćMagazynu;
            }

            return suma;
        }

        // Oblicza wartość magazynu dla listy produktów
        public static double ObliczWartoscMagazynu(List<Product> produkty)
        {
            return produkty.Sum(p => p.WartośćMagazynu);
        }

        // Sprawdza, czy można sprzedać produkt
        public bool CzyMoznaZamowic()
        {
            return Ilosc > MinimalnyStan;
        }

        // Sprzedaje jedną sztukę produktu
        public void Sprzedaj()
        {
            if (CzyMoznaZamowic())
            {
                Ilosc--;
                Console.WriteLine(
                    $"Sprzedano produkt: {Nazwa}. Pozostało na stanie: {Ilosc}");
            }
            else
            {
                Console.WriteLine(
                    $"Nie można sprzedać produktu: {Nazwa}. Brak na stanie.");
            }
        }

        // Wyszukuje dokładną nazwę w tablicy
        public static Product ZnajdzPoNazwie(Product[] produkty, string nazwa)
        {
            foreach (Product produkt in produkty)
            {
                if (produkt.Nazwa == nazwa)
                {
                    return produkt;
                }
            }

            return null;
        }

        public bool Dostepny { get; set; } = true;

        // Wyszukuje fragment nazwy na liście
        public static Product ZnajdzPoNazwie(List<Product> produkty, string nazwa)
        {
            return produkty.FirstOrDefault(
                p => p.Nazwa.Contains(
                    nazwa ?? "",
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}
