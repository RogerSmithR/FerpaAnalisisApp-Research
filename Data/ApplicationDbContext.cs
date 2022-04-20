using FerpaAnalisisApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FerpaAnalisisApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<StatisticDocumentType> StatisticDocumentType { get; set; }
    }
}
