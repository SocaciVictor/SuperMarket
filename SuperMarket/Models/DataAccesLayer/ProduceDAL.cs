using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.DataAccesLayer
{
    public class ProduceDAL
    {
        public ObservableCollection<Product> GetProductsByProducerId(int producerId)
        {
            ObservableCollection<Product> result = new ObservableCollection<Product>();

            using (SqlConnection con = DBService.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetProductsByProducerId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProducerId", producerId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var product = new Product
                    {
                        Id = (int)reader["ProductId"],
                        Name = (string)reader["ProductName"],
                        ProducerId = (int)reader["ProducerId"],
                        CategoryId = (int)reader["CategoryId"],
                        Barcode = (string)reader["Barcode"],
                        IsActive = (bool)reader["IsActive"],
                    };
                    result.Add(product);
                }
                reader.Close();
            }
            return result;
        }
    }
}
