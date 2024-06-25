using _03Product.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Product.ViewModel
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private Product selectedProduct;
        public ObservableCollection<Product> Products { get; set; }

        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>(JSONHelper.LoadProducts());
        }

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            JSONHelper.SaveProducts(new List<Product>(Products));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
