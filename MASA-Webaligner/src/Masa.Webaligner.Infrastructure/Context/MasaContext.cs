using Masa.Webaligner.Core.Entities;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace Masa.Webaligner.Infrastructure.Context
{
    public class MasaContext : DbContext
    {
        public MasaContext(DbContextOptions<MasaContext> options)
            : base(options)
        {
            //
        }

        #region AlignmentsHierarchy
            public DbSet<Alignment> Alignments { get; set; }
            public DbSet<NcbiAlignment> NcbiAlignments { get; set; }
        #endregion
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO MS-SQL-Server: add mappings
        }
    }
}
