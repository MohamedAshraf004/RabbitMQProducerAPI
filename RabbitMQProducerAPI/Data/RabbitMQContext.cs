using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RabbitMQProducerAPI.Models;

namespace RabbitMQProducerAPI.Data
{
    public class RabbitMQContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public RabbitMQContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Product> Products
        {
            get;
            set;
        }
    }
}
