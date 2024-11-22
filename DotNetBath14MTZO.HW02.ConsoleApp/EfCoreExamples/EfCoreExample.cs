using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DotNetBath14MTZO.HW02.ConsoleApp.EfCoreExamples.AppDbContext;

namespace DotNetBath14MTZO.HW02.ConsoleApp.EfCoreExamples
{
    public class EfCoreExample
    {
        private readonly AppDbContext _dbContext = new AppDbContext();

        public void Read()
        {
            var lists = _dbContext.Blog_Table.ToList();
            foreach (var list in lists)
            {
                Console.WriteLine("Blog Id is - " + list.Id);
                Console.WriteLine("Blog Tilte is - " + list.Title);
                Console.WriteLine("Blog Author is - " + list.Author);
                Console.WriteLine("Blog Content is - " + list.Content);
            }
        }

        public void Edit(string id)
        {
            var item = _dbContext.Blog_Table.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("Data not found!!!!!!!!!!");
                return;
            }
            Console.WriteLine("Blog Id is - " + item.Id);
            Console.WriteLine("Blog Tilte is - " + item.Title);
            Console.WriteLine("Blog Author is - " + item.Author);
            Console.WriteLine("Blog Content is - " + item.Content);

        }
        public void Create(string title, string author, string content)
        {
            var blogTitles = new BlogTable
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Author = author,
                Content = content

            };

            _dbContext.Blog_Table.Add(blogTitles);
            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Creating is successful!" : "Creating is Failed";
            Console.WriteLine(message);
        }

        public void Update(string id, string title, string author, string content)
        {
            var item = _dbContext.Blog_Table.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("No data not found for update!!");
                return;
            }
            item.Id= id;
            item.Title= title;
            item.Author= author;
            item.Content= content; 
            _dbContext.Entry(item).State= EntityState.Modified;
            int result =_dbContext.SaveChanges();
            string message = result > 0 ? "Update is successful" : "Update is Failed";
            Console.WriteLine(message);

        }

        public void Delete(string id)
        {
            var item = _dbContext.Blog_Table.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("Data is not found");
                return;
            }
            _dbContext.Entry(item).State = EntityState.Deleted;
            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Deleting is Successful" : "Deleting is failed";
            Console.WriteLine(message);
        }
    }
}
