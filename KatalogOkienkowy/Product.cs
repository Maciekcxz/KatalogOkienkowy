using System;

namespace KatalogOkienkowy { 
    internal class Product
    {
        public string Nazwa;

        private double _cena;

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

        public string Kategoria;

        public int Ilosc;

        // Konstruktor bez parametrów
        public Product()
        {
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

        public double WartośćMagazynu
        {
            get { return cena * Ilosc; }
        }

        public void WypiszProdukt()
        {
            Console.WriteLine($"Nazwa: {Nazwa,-15}| Cena: {cena,10:F2} zł | " +
                $"Kategoria: {Kategoria} | Ilość: {Ilosc,5} | " +
                $"Wartość magazynu: {WartośćMagazynu,10:F2} zł");
        }

        public string InformacjeOProdukcie()
        {
            return $"Nazwa: {Nazwa,-15}| Cena: {cena,10:F2} zł | " +
                $"Kategoria: {Kategoria} | Ilość: {Ilosc,5} | " +
                $"Wartość magazynu: {WartośćMagazynu,10:F2} zł";
        }

        // Liczy sumę wartości magazynu
        public static double ObliczWartoscMagazynu(Product[] produkty)
        {
            double suma = 0;

            foreach (Product produkt in produkty)
            {
                suma += produkt.WartośćMagazynu;
            }

            return suma;
        }

        // Sprawdza, czy można sprzedać produkt
        public bool CzyMoznaZamowic()
        {
            return Ilosc > MinimalnyStan;
        }

        // Sprzedaje produkt
        public void Sprzedaj()
        {
            if (CzyMoznaZamowic())
            {
                Ilosc--;
                Console.WriteLine($"Sprzedano produkt: {Nazwa}. Pozostało na stanie: {Ilosc}");
            }
            else
            {
                Console.WriteLine($"Nie można sprzedać produktu: {Nazwa}. Brak na stanie.");
            }
        }

        // Wyszukuje produkt po nazwie
        public static Product ZnajdzPoNazwie(Product[] products, string nazwa)
        {
            foreach (Product produkt in products)
            {
                if (produkt.Nazwa == nazwa)
                {
                    return produkt;
                }
            }

            return null;
        }
    }
}