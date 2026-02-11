using DemWpfFramework21.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для ProductDetailPage.xaml
    /// </summary>
    public partial class ProductDetailPage : Page
    {

        CollectionViewSource products;


        public ProductDetailPage(Product product)
        {
            InitializeComponent();

            products = (CollectionViewSource)FindResource("productViewSource");

            products.Source = Core.Context.Products.Where(x=>x.ProductId == product.ProductId).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var manufacturer = (CollectionViewSource)FindResource("manufacturerViewSource");
            var supplier = (CollectionViewSource)FindResource("supplierViewSource");
            var category = (CollectionViewSource)FindResource("categoryViewSource");

            category.Source = Core.Context.Categories.ToList();
            supplier.Source = Core.Context.Suppliers.ToList();
            manufacturer.Source = Core.Context.Manufacturers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Core.Context.Products.AddOrUpdate(products.View.CurrentItem as Product);
            Core.Context.SaveChanges();
            App.Frame.GoBack();
        }
    }
}
