
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
    new Product("Procesor AMD Ryzen 5", 899.00, "Procesory", 10),
    new Product("Karta graficzna RTX 4060", 1499.00, "Karty graficzne", 5),
    new Product("Płyta główna MSI B550", 499.00, "Płyty główne", 8),
    new Product("Pamięć RAM DDR4 16GB", 199.00, "Pamięci RAM", 15),
    new Product("Dysk SSD 1TB", 299.00, "Dyski SSD", 12)
};
            EtykietaLiczby.Text =
                $" {products.Count}";

            EtykietaMagazynu.Text =
      $"{Product.ObliczWartoscMagazynu(products):F2} zł";


        }
    }
}
