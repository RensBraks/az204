using System.Data.SqlClient;

namespace az204first.Services
{
    public class ProductserviceSQL
    {
        private static string db_source = "serv-dbserv.database.windows.net";
        private static string db_user = "thesner";
        private static string db_password = "Motion10RB!@";
        private static string db_database = "db-appdb";


        private SqlConnection GetConnection()
        {
            var sql_connection= new SqlConnectionStringBuilder();
            sql_connection.DataSource= db_source;
            sql_connection.UserID= db_user;
            sql_connection.Password= db_password;
            sql_connection.InitialCatalog= db_database;
            return new SqlConnection(sql_connection.ToString());


        }

        public List<models.Product> GetProducts()
        {
            SqlConnection conn= GetConnection();

            List<models.Product> product_list = new List<models.Product>();



            string statement = "SELECT ProductID, ProductName, Quantity from Products";
            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    models.Product product = new models.Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    product_list.Add(product);
                }
            }
            conn.Close();
            return product_list;
        }

    }
}
