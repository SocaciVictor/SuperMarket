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
    }
    
}
