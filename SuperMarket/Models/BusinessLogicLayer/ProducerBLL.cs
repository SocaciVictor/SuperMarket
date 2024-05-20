using SuperMarket.Converters;
using SuperMarket.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.BusinessLogicLayer
{
    public class ProducerBLL: BasePropertyChanged
    {
        private SupermarketDBContext context = new SupermarketDBContext();
        public ObservableCollection<Producer>? ProducersList { get; set; }

        public string ErrorMessage { get; set; }

        public ProducerBLL()
        {
            ProducerIntoIdProducer.Producers = new List<Producer>();
            ProducersList = new ObservableCollection<Producer>(GetAllProducers());
        }


        public void AddMethod(object obj)
        {
            //parametrul obj este cel dat prin CommandParameter cu MultipleBinding la Button in xaml
            Producer prod = obj as Producer;
            if (prod != null)
            {
                if (string.IsNullOrEmpty(prod.Name))
                {
                    ErrorMessage = "Numele producatorului trebuie precizat";
                }
                else if (string.IsNullOrEmpty(prod.Country))
                {
                    ErrorMessage = "Tara de origine trebuie precizata";
                }
                else if (IsInDataBase(prod) == true)
                {
                    ErrorMessage = "Elementul exista deja in baza de date!";
                }
                else
                {
                    context.Producers.Add(prod);
                    context.SaveChanges();
                    prod.Id = context.Producers.Max(item => item.Id);
                    ProducersList.Add(prod);
                    ErrorMessage = "";
                }
            }
        }

        private bool IsInDataBase(Producer us)
        {
            foreach (Producer item in ProducersList)
            {
                if (item.Name == us.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateMethod(object obj)
        {
            Producer producer = obj as Producer;
            if (producer == null)
            {
                ErrorMessage = "Selecteaza un produs";
            }
            else if (string.IsNullOrEmpty(producer.Name))
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
                Producer u = context.Producers.Find(producer.Id);
                u.Name = producer.Name;
                u.Country = producer.Country;
                context.SaveChanges();
                ErrorMessage = "";
            }
        }


        public void DeleteMethod(object obj)
        {
            Producer Producer = obj as Producer;
            if (Producer == null)
            {
                ErrorMessage = "Selecteaza un producator";
            }
            else
            {
                User p = context.Users.Where(i => i.Id == Producer.Id).FirstOrDefault();
                Producer.IsActive = false;
                context.SaveChanges();
                ProducersList.Remove(Producer);
                ErrorMessage = "";
            }
        }

        public ObservableCollection<Producer> GetAllProducers()
        {
            List<Producer> producers = context.Producers.ToList();
            ProducerIntoIdProducer.Producers.Clear();
            ObservableCollection<Producer> result = new ObservableCollection<Producer>();
            foreach (Producer prod in producers)
            {
                result.Add(prod);
                
                ProducerIntoIdProducer.Producers.Add(prod);
            }
            return result;

        }

        public string GetProducerName(Product product)
        {
            Producer p = context.Producers.Where(item => item.Id == product.ProducerId).FirstOrDefault();

            return p?.Name;
        }
    }
}
