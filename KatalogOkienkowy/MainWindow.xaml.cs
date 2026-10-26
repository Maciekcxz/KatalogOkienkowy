
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KatalogOkienkowy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Product> products = new List<Product>
            {
                new Product("Produkt 1", 10.99, "Kategoria A", 5),
                new Product("Produkt 2", 15.49, "Kategoria B", 3),
                new Product("Produkt 3", 7.99, "Kategoria A", 8),
                new Product("Produkt 4", 12.75, "Kategoria C", 2)
            };

            EtykietaLiczby.Text = $"Liczba produktów: {products.Count}";

            List<double> WartośćMagazynu = products
                .Select(p => p.WartośćMagazynu)
                .ToList();

            EtykietaMagazynu.Text = $"Wartość magazynu: {WartośćMagazynu.Sum():F2} zł";
        }
    }
}
