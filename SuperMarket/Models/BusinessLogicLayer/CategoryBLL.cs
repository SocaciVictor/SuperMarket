using SuperMarket.Converters;
using SuperMarket.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.BusinessLogicLayer
{
    public class CategoryBLL : BasePropertyChanged
    {
        private SupermarketDBContext context = new SupermarketDBContext();
        public ObservableCollection<Category>? CategoriesList { get; set; }

        public string ErrorMessage { get; set; }

        public CategoryBLL()
        {
            CategoryIntoIdCategory.Categories = new List<Category>();
            CategoriesList = new ObservableCollection<Category>(GetAllCategories());
        }

        public void AddMethod(object obj)
        {
            //parametrul obj este cel dat prin CommandParameter cu MultipleBinding la Button in xaml
            Category category = obj as Category;
            if (category != null)
            {
                if (string.IsNullOrEmpty(category.CategoryName))
                {
                    ErrorMessage = "Numele categoriei trebuie precizat";
                }
                else if (IsInDataBase(category) == true)
                {
                    ErrorMessage = "Categoria exista deja in baza de date!";
                }
                else
                {
                    context.Categories.Add(category);

                    context.SaveChanges();
                    category.Id = context.Users.Max(item => item.Id);
                    CategoriesList.Add(category);   
                    ErrorMessage = "";
                }
            }
        }

        private bool IsInDataBase(Category us)
        {
            foreach (Category item in CategoriesList)
            {
                if (item.CategoryName == us.CategoryName)
                {
                    return true;
                }
            }
            return false;
        }


        public void UpdateMethod(object obj)
        {
            Category category = obj as Category;
            if (category == null)
            {
                ErrorMessage = "Selecteaza o categorie";
            }
            else if (string.IsNullOrEmpty(category.CategoryName))
            {
                ErrorMessage = "Numele categoriei trebuie precizat";
            }
            // DE REFACUT CA SE ACTUALIZEAZA IN OBSERVABLE SI NU MERGE SA SE ACTUALIZEZE CUM TRB
            //else if (SamePassowrd(user) == false && IsInDataBase(user) == false) 
            //{
            //    ErrorMessage = "Nu s-a modificat nimic pentru a putea face update-ul";
            //}
            else
            {
                Category u = context.Categories.Find(category.Id);
                u.CategoryName = category.CategoryName;
                context.SaveChanges();
                ErrorMessage = "";
            }
        }


        public void DeleteMethod(object obj)
        {
            Category cat = obj as Category;
            if (cat == null)
            {
                ErrorMessage = "Selecteaza o categorie";
            }
            else
            {
                Category p = context.Categories.Where(i => i.Id == cat.Id).FirstOrDefault();
                cat.IsActive = false;
                context.SaveChanges();
                CategoriesList.Remove(cat);
                ErrorMessage = "";
            }
        }


        public ObservableCollection<Category> GetAllCategories()
        {
            List<Category> categories = context.Categories.ToList();
            CategoryIntoIdCategory.Categories.Clear();
            ObservableCollection<Category> result = new ObservableCollection<Category>();
            foreach (Category cat in categories)
            {
                result.Add(cat);
                CategoryIntoIdCategory.Categories.Add(cat);
            }
            return result;

        }

        public void CategoryNameFromDB()
        {
            
        }
        public void SelectNameFromDB(object obj)
        {
            Category category = obj as Category;
            List<Category> categories = context.Categories.Where(item => item.Id == category.Id).ToList();
        }

        public string GetCategoryName(Product product)
        {
            Category c = context.Categories.Where(item => item.Id == product.CategoryId).FirstOrDefault();

            return c?.CategoryName;
        }
    }
    
}
