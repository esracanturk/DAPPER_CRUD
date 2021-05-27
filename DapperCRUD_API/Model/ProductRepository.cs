using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUD_API.Model
{
    public class ProductRepository
    {
        private string connectionString;
        public ProductRepository()
        {
            connectionString = "Server=DESKTOP-REC6226;Database=DapperDB;Integrated Security=true;Pooling=true;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(Product prod)
        {
            using (IDbConnection dbConnection=Connection)
            {
                string sQuery = @"INSERT INTO Products (Name,Quantity,Price) VALUES(@Name,@Quantity,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery,prod);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Products";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }
        }

        public Product GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Products WHERE ProductId=@Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery,new { Id=id}).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Products WHERE ProductId=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Products SET Name=@Name,Quantity=@Quantity, Price=@Price 
                                WHERE ProductId=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, prod);
            }
        }
    }
}
