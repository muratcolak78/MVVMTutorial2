using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace _03Product.Model
{
    public static class JSONHelper
    {
        private static string filePath = "products.json";

        public static void SaveProducts(List<Product> products)
        {
            try
            {
                var json = JsonConvert.SerializeObject(products, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler bei der Speicherung des Jsons"+ex.Message);
            }
            
        }

        public static List<Product> LoadProducts()
        {
            if (!File.Exists(filePath))
            {
                return new List<Product>();
            }
            try
            {
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Product>>(json);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fehler bei Loading Json "+ ex.Message);
                return new List<Product>();// hata olabilir
            }
           
        }
    }
}
