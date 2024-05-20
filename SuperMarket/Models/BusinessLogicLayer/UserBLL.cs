using SuperMarket.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.BusinessLogicLayer
{
    public class UserBLL: BasePropertyChanged
    {
        private SupermarketDBContext context = new SupermarketDBContext();
        public ObservableCollection<User> UsersList { get; set; }

        public string ErrorMessage { get; set; }

        public UserBLL()
        {
            UsersList = new ObservableCollection<User>(GetAllUsers());
        }

        public List<User> GetAllUsersList()
        {
            List<User> users = context.Users.ToList();
            var result = users;

            return result;
        }

        public ObservableCollection<User> GetAllUsers()
        {
            List<User> users = context.Users.ToList();
            ObservableCollection<User> result = new ObservableCollection<User>();
            foreach (User user in users)
            {
                if (user.IsActive == true)
                {
                    result.Add(user);
                }
            }
            return result;

        }

        public void AddMethod(object obj)
        {
            //parametrul obj este cel dat prin CommandParameter cu MultipleBinding la Button in xaml
            User user = obj as User;
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.Name))
                {
                    ErrorMessage = "Numele produsului trebuie precizat";
                }
                else if (string.IsNullOrEmpty(user.Password))
                {
                    ErrorMessage = "Parola utilizatorului trebuie precizata";
                }
                else if (user.Type < 0 || user.Type > 1)
                {
                    ErrorMessage = "Tipul utilizatorului trebuie sa fie 0(pentru administrator) sau 1(pentru casier)";
                }
                else if (IsInDataBase(user) == true)
                {
                    ErrorMessage = "Elementul exista deja in baza de date!";
                }
                else
                {
                    context.Users.Add(user);
                   
                    context.SaveChanges();
                    user.Id = context.Users.Max(item => item.Id);
                    UsersList.Add(user);
                    ErrorMessage = "";
                }
            }
        }

        private bool IsInDataBase(User us)
        {
            foreach (User item in UsersList)
            {
                if (item.Name == us.Name)
                {
                    return true;
                }
            }
            return false;
        }

        private bool SamePassowrd(User us)
        {
            foreach (User item in UsersList)
            {
                if (item.Password == us.Password)
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateMethod(object obj)
        {
            User user = obj as User;
            if (user == null)
            {
                ErrorMessage = "Selecteaza un produs";
            }
            else if (string.IsNullOrEmpty(user.Name))
            {
                ErrorMessage = "Numele produsului trebuie precizat";
            }
            // DE REFACUT CA SE ACTUALIZEAZA IN OBSERVABLE SI NU MERGE SA SE ACTUALIZEZE CUM TRB
            //else if (SamePassowrd(user) == false && IsInDataBase(user) == false) 
            //{
            //    ErrorMessage = "Nu s-a modificat nimic pentru a putea face update-ul";
            //}
            else
            {
                User u = context.Users.Find(user.Id);
                u.Name = user.Name;
                u.Password = user.Password;
                u.Type = user.Type;
                context.SaveChanges();
                ErrorMessage = "";
            }
        }


        public void DeleteMethod(object obj)
        {
            User user = obj as User;
            if (user == null)
            {
                ErrorMessage = "Selecteaza un produs";
            }
            else
            {
                User p = context.Users.Where(i => i.Id == user.Id).FirstOrDefault();
                user.IsActive = false;
                context.SaveChanges();
                UsersList.Remove(user);
                ErrorMessage = "";
            }
        }
    }
}
