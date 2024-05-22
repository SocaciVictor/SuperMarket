using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.DataAccesLayer
{
    public class DBService
    {
        private static readonly string connectionString = @"Server=DESKTOP-58SD638;Database=Supermarket2024;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true";
        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
