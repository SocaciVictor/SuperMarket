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

    }
}
