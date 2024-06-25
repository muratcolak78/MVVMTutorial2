using _03Product.Model;
using _03Product.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Xml.Linq;

namespace _03Product;

/// <summary>
/// Interaktionslogik für UserControl.xaml
/// </summary>
public partial class UserControl1 : UserControl
{
    private ProductViewModel productViewModel;
    public UserControl1()
    {
        InitializeComponent();
        productViewModel = new ProductViewModel();
        DataContext = productViewModel;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(txtbxprice.Text, out double price))
        {
            var product = new Product
            {
                Name = txtbxname.Text,
                Price = price,
                Category = txtbxCategory.Text,
                Image = txtbxImage.Text,
                Description = txtbxIDescription.Text
            };

            productViewModel.AddProduct(product);

            txtbxname.Clear();
            txtbxprice.Clear();
            txtbxCategory.Clear();
            txtbxImage.Clear();
            txtbxIDescription.Clear();
           }
        else
        {
            MessageBox.Show("Please enter a valid price.");
        }

    }

    private void productDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (productDataGrid.SelectedItem is Product selectedProduct)
        {
            productViewModel.SelectedProduct = selectedProduct;
            txtbxname.Text = selectedProduct.Name;
            txtbxprice.Text = selectedProduct.Price.ToString();
            txtbxCategory.Text=selectedProduct.Category.ToString();
            txtbxImage.Text = selectedProduct.Image.ToString(); 
            txtbxIDescription.Text=selectedProduct.Description.ToString();
        }
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        if (productDataGrid.SelectedItem is Product selectedProduct)
        {
            productViewModel.Products.Remove(selectedProduct);
            JSONHelper.SaveProducts(new List<Product>(productViewModel.Products));
        }
    }

    private void Update_Click(object sender, RoutedEventArgs e)
    {
        if (productDataGrid.SelectedItem is Product selectedProduct)
        {
            // Update işlemini burada gerçekleştirin
            // Örneğin, TextBox'lardaki değerleri seçili ürüne atayabilirsiniz
            selectedProduct.Name = txtbxname.Text;
            selectedProduct.Price = double.TryParse(txtbxprice.Text, out double price) ? price : selectedProduct.Price;
            selectedProduct.Category = txtbxCategory.Text;
            selectedProduct.Image = txtbxImage.Text;
            selectedProduct.Description = txtbxIDescription.Text;

            // JSON dosyasını güncelle
            JSONHelper.SaveProducts(new List<Product>(productViewModel.Products));

            // DataGrid'i yenilemek için
            productViewModel.OnPropertyChanged("Products");
            
        }
    }

    private void btnClear_Click(object sender, RoutedEventArgs e)
    {
        txtbxname.Text = string.Empty;
        txtbxprice.Text = string.Empty;
        txtbxCategory.Text = string.Empty;
        txtbxImage.Text = string.Empty;
        txtbxIDescription.Text = string.Empty;
    }
}
