using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.HW02.ConsoleApp.DotNetExamples
{
    public class DotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStrinBulider = new SqlConnectionStringBuilder(){ 
            DataSource = ".",
            InitialCatalog = "WalletDB",
            UserID = "sa",
            Password = "mtzoo@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStrinBulider.ConnectionString);
            connection.Open();
            
            SqlCommand command = new SqlCommand("select * from Tbl_Blog",connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            foreach(DataRow dr in dt.Rows)
            {
                Console.WriteLine("Id***" + dr["BlogId"]);
                Console.WriteLine("Title****" + dr["BlogTitle"]);
                Console.WriteLine("Author***"+ dr["BlogAuthor"]);
                Console.WriteLine("Content***"+ dr["BlogContent"]);
            }
        }
        public void Edit(string id)
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStrinBulider.ConnectionString);
            sqlConnection.Open();
            string query = $"select * from Tbl_Blog where [BlogId]='{id}'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            sqlConnection.Close();
            
            if(dataTable.Rows.Count == 0)
            {
                Console.WriteLine("Data not found");
                return;
            }
            DataRow dataRow = dataTable.Rows[0];
            Console.WriteLine("Id***" + dataRow["BlogId"]);
            Console.WriteLine("Title****" + dataRow["BlogTitle"]);
            Console.WriteLine("Author***" + dataRow["BlogAuthor"]);
            Console.WriteLine("Content***" + dataRow["BlogContent"]);
        
        }

        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStrinBulider.ConnectionString);
            connection.Open();
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}'
           ,'{author}'
           ,'{content}')";

            SqlCommand cmd = new SqlCommand(query,connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Create Successful!!!":"Create Failed!!!";
            Console.WriteLine(message);

        }
        public void Update(string id, string title,string author,string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStrinBulider.ConnectionString);
            connection.Open();
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogId] = '{id}'
      ,[BlogTitle] = '{title}'
      ,[BlogAuthor] = '{author}'
      ,[BlogContent] = '{content}'
 WHERE [BlogId]='{id}'";
            
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string rstMessage = result > 0 ? "Updating Successful!!!!!!!!!!!" : "Updating Failed!!!!!!!";
            Console.WriteLine(rstMessage);
        }
        public void Delete(string id) {
            SqlConnection connect = new SqlConnection(_sqlConnectionStrinBulider.ConnectionString);
            connect.Open();
            SqlCommand command = new SqlCommand($"delete from Tbl_Blog where [BlogId]='{id}'",connect);
            SqlDataAdapter adapter = new SqlDataAdapter();
            int result = command.ExecuteNonQuery();
            connect.Close();
            string resultmess = result > 0 ? "Delete Successful " : "Delete Failed ";
            Console.WriteLine(resultmess);
        }
    }

}
