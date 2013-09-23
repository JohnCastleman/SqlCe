using System;
using System.Configuration;
using System.Data.Entity;

namespace UsingSqlCe
{
   class Program
   {
      static void Main(string[] args)
      {
         var cn = ConfigurationManager.ConnectionStrings["DataLayer"].ConnectionString;

         //You can set the DefaultConnectionFactory in code or it can be done in the app.config
         //Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");

         var context = new DataContext(cn);
         if (context.Database.Exists())
            context.Database.Delete();
         context.Database.Create();

         Console.WriteLine("Database Exists: {0}", context.Database.Exists());
                  
         Console.WriteLine("Press enter to exit.");
         Console.ReadLine();

      }
   }

   public class DataContext: DbContext
   {
      public DataContext(string nameOrConnectionString)
         :base(nameOrConnectionString)
      {}
      
      DbSet<Person> People { get; set; }
   }

   public class Person
   {
      public int Id { get; set; }
      public string Name { get; set; }
   }
}
