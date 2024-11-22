using Dapper;
using DotNetBath14MTZO.HW02.ConsoleApp.Dapperexamples.BlogDtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace DotNetBath14MTZO.HW02.ConsoleApp.Dapperexamples
{
    public class DapperExample
    {
        private readonly string _connectionString = AppSettings.SqlConnectionStringBuilder.ConnectionString;

        public void Read()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            List<BlogDto>lists=connection.Query<BlogDto>("Select * from Tbl_Blog").ToList();
            foreach (BlogDto item in lists)
            {
                Console.WriteLine("Blog Id is "+ item.BlogId);
                Console.WriteLine("Blog Title is "+ item.BlogTitle);
                Console.WriteLine("Blog Author is "+ item.BlogAuthor);
                Console.WriteLine("Blog Content is "+ item.BlogContent);
            }
        }
        public void Edit(string id)
        {
            using IDbConnection db= new SqlConnection(_connectionString);
            var item = db.Query<BlogDto>("select * from Tbl_Blog").FirstOrDefault(x=> x.BlogId==id);
            if (item is null)
            {
                Console.WriteLine("Data not found");
                return;
            }
            Console.WriteLine("Blog Id is " + item.BlogId);
            Console.WriteLine("Blog Title is " + item.BlogTitle);
            Console.WriteLine("Blog Author is " + item.BlogAuthor);
            Console.WriteLine("Blog Content is " + item.BlogContent);

        }

        public void Create(string title,string author, string content)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}'
           ,'{author}'
           ,'{content}')";

            int result = dbConnection.Execute(query);
            string message = result > 0 ? "Updating Successful!!!!!!!" : "Updating Failed!!!!!!!!!!";
            Console.WriteLine(message);
        }
        public void Update(string id, string title,string author,string content)

        {
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogId] = '{id}'
      ,[BlogTitle] = '{title}'
      ,[BlogAuthor] = '{author}'
      ,[BlogContent] = '{content}'
 WHERE [BlogId]='{id}'";
            using IDbConnection connection = new SqlConnection(_connectionString);
            int result = connection.Execute(query);
            string message = result > 0 ? "Updating Successful !!" : "Updating Failed!!";
            Console.WriteLine(message);
        }

        public void Delete(string id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            int result = db.Execute($"delete from Tbl_Blog where [BlogId]= '{id}'");
            string msg = result > 0 ? "Deleting Successful !!!" : "Deleting Failed";
            Console.WriteLine(msg);
        }

    }
}
