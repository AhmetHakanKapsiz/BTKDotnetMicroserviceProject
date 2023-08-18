using BtkAkademi.Service.MessageAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BtkAkademi.Service.MessageAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }
    }
}
