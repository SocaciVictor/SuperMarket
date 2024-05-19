using Microsoft.IdentityModel.Tokens;
using SuperMarket.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.BusinessLogicLayer
{
    public class ProductBLL: BasePropertyChanged
    {
        private SupermarketDBContext context = new SupermarketDBContext();
        public ObservableCollection<Product>? ProductsList { get; set; }

        public string ErrorMessage { get; set; }

        public ProductBLL()
        {
            ProductsList = new ObservableCollection<Product>(GetAllProducts());
        }

        public void AddMethod(object obj)
        {
            //parametrul obj este cel dat prin CommandParameter cu MultipleBinding la Button in xaml
            Product product = obj as Product;
            if (product != null)
            {
                if (string.IsNullOrEmpty(product.Name))
                {
                    ErrorMessage = "Numele produsului trebuie precizat";
                }
                else if (string.IsNullOrEmpty(product.Barcode))
                {
                    ErrorMessage = "Codul de pare a produsului trebuie precizat";
                }
                else if (IsInDataBase(product) == true)
                {
                    ErrorMessage = "Elementul exista deja in baza de date!";
                }
                else
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                    product.Id = context.Products.Max(item => item.Id);
                    ProductsList.Add(product);
                    ErrorMessage = "";
                }
            }
        }

        private bool IsInDataBase(Product prod)
        {
            foreach (var item in ProductsList)
            {
                if (item.Barcode == prod.Barcode && item.IsActive == true)
                {
                    return true;
                }
            }
            return false;
        }

        public ObservableCollection<Product> GetAllProducts()
        {
            List<Product> products = context.Products.ToList();
            ObservableCollection<Product> result = new ObservableCollection<Product>();
            foreach (Product prod in products)
            {
                if (prod.IsActive == true) 
                {
                    result.Add(prod); 
                }
            }
            return result;

        }

        public void UpdateMethod(object obj)
        {
            Product product = obj as Product;
            if (product == null)
            {
                ErrorMessage = "Selecteaza un produs";
            }
            else if (string.IsNullOrEmpty(product.Name))
            {
                ErrorMessage = "Numele produsului trebuie precizat";
            }
            else
            {
                Product p = context.Products.Find(product.Id);
                p.Barcode = product.Barcode;
                p.Name = product.Name;
                p.ProducerId = product.ProducerId;
                p.CategoryId = product.CategoryId;
                context.SaveChanges();
                ErrorMessage = "";
            }
        }

        public void DeleteMethod(object obj)
        {
            Product prod = obj as Product;
            if (prod == null)
            {
                ErrorMessage = "Selecteaza un produs";
            }
            else
            {
                Product p = context.Products.Where(i => i.Id == prod.Id).FirstOrDefault();
                prod.IsActive = false;
                context.SaveChanges();
                ProductsList.Remove(prod);
                ErrorMessage = "";
            }
        }

        public ObservableCollection<Product> GetAllPersons()
        {
            List<Product> products = context.Products.ToList();
            ObservableCollection<Product> result = new ObservableCollection<Product>();
            foreach (Product prod in products)
            {
                result.Add(prod);
            }
            return result;
        }

}
}
