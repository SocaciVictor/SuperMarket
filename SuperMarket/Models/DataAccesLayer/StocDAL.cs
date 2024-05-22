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
    public class StocDAL
    {
        public ObservableCollection<Stock> SearchStocForCashier(string numeProdus, string codDeBare,
        int? categorieId, int? producatorId, DateTime? dataExpirare)
        {
            using (SqlConnection con = DBService.Connection)
            {
                ObservableCollection<Stock> result = new ObservableCollection<Stock>();
                SqlCommand cmd = new SqlCommand("FiltrareStocuriPentruCasier", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nume_produs", (object)numeProdus ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cod_de_bare", (object)codDeBare ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@categorie_id", (object)categorieId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@producator_id", (object)producatorId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@data_expirare", (object)dataExpirare ?? DBNull.Value);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Stock stoc = new Stock();
                    stoc.Id = (int)(reader[0]);
                    stoc.ProductId = (int)(reader[1]);
                    stoc.Amount = (float)(reader[2]);
                    stoc.Unit = (string)reader[3];
                    stoc.SupplyDate = (DateTime)reader[4];
                    stoc.ExpirationDate = (DateTime)reader[5];
                    stoc.PurchasePrice = (float)reader[6];
                    stoc.SellingAmount = (float)reader[7];
                    result.Add(stoc);
                }
                reader.Close();
                return result;
            }
        }
    }
}
