using DemWpfFramework21.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemWpfFramework21.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        CollectionViewSource products;

        public ProductsPage()
        {
            InitializeComponent();

            products = (CollectionViewSource)FindResource("productViewSource");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            products.Source = Core.Context.Products.ToList();

            FilterBox.ItemsSource = Core.Context.Suppliers.Select(x=>x.Name).Prepend("Все поставщики").ToList();

            FilterBox.SelectedIndex = 0;
            SortBox.SelectedIndex = 0;
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            products.View.Filter = x => Search(x) && Filter(x);

            products.View.SortDescriptions.Clear();
            switch (SortBox.SelectedIndex)
            {
                case 1:
                    products.View.SortDescriptions.Add(new SortDescription("Amount", ListSortDirection.Ascending));
                    break;
                case 2:
                    products.View.SortDescriptions.Add(new SortDescription("Amount", ListSortDirection.Descending));
                    break;
                default:
                    break;
            }
        }

        private bool Search(object o)
        {
            Product product = o as Product;

            return product.Name.ToLower().Contains(SearchBox.Text.ToLower())
                || product.Description.ToLower().Contains(SearchBox.Text.ToLower())
                || product.Article.ToLower().Contains(SearchBox.Text.ToLower())
                || product.Category.Name.ToLower().Contains(SearchBox.Text.ToLower())
                || product.Manufacturer.Name.ToLower().Contains(SearchBox.Text.ToLower())
                || product.Supplier.Name.ToLower().Contains(SearchBox.Text.ToLower())
                || product.Unit.ToLower().Contains(SearchBox.Text.ToLower());
        }

        private bool Filter(object o)
        {
            Product product = o as Product;
            if(FilterBox.SelectedIndex == 0)
                return true;
            return product.Supplier.Name == FilterBox.SelectedValue.ToString();
        }

        private void ProductListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            App.Frame.Navigate(new ProductDetailPage(productListView.SelectedItem as Product));
        }
    }
}
