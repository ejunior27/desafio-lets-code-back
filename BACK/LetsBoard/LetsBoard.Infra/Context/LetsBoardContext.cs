using LetsAuth.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LetsAuth.Infra.Context
{
    public class LetsBoardContext : DbContext
    {
        public LetsBoardContext(DbContextOptions<LetsBoardContext> options)
          : base(options)
        { }
        public DbSet<Card> Cards { get; set; }
    }
}
