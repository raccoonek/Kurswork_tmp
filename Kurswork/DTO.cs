using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.EntityFrameworkCore.SqlServer;

using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;




namespace Kurswork
{
    public class FlowChart
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Jsonstring { get; set; }
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<FlowChart> FlowChart { get; set; } = null!;

        public FlowChart FlowChart1
        {
            get => default;
            set{}
        }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            //MessageBox.Show(Directory.GetCurrentDirectory());
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("jsonconfigconnection.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения

            string connectionString = config.GetConnectionString("DefaultConnection");

            // optionsBuilder.UseSqlServer("Server=DESKTOP-PS969HM; Database=well; Trusted_Connection=True; ");
            optionsBuilder.UseSqlServer(connectionString);

        }
    }

}
