
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KatalogOkienkowy
{
    public partial class MainWindow : Window
    {
        private List<Product> products;

        public MainWindow()
        {
            InitializeComponent();

            products = new List<Product>
            {
                new Product("Jabłka", 4.50, "Owoce", 20),
                new Product("Gruszki", 6.00, "Owoce", 15),
                new Product("Banany", 5.20, "Owoce", 25),
                new Product("Marchew", 3.00, "Warzywa", 30),
                new Product("Ziemniaki", 2.50, "Warzywa", 40)
            };

            EtykietaLiczby.Text =
                $" {products.Count}";

            EtykietaMagazynu.Text =
                $"Wartość magazynu: " +
                $"{Product.ObliczWartoscMagazynu(products):F2} zł";

            TextBlock dopisek = new TextBlock();
            dopisek.Text = "Katalog produktów spożywczych";
            dopisek.FontSize = 14;
            dopisek.Margin = new Thickness(0, 10, 0, 0);

            GlownyStackPanel.Children.Add(dopisek);
        }
    }
}
