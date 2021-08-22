using Microsoft.EntityFrameworkCore;
using pr.models;
using pr.Models;

namespace pr.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Character> characters { get; set; }

    }
}