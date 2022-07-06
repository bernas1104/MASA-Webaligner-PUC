using Masa.Webaligner.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Masa.Webaligner.Infrastructure.Mapping
{
    public class NcbiAlignmentMap : IEntityTypeConfiguration<NcbiAlignment>
    {
        public void Configure(EntityTypeBuilder<NcbiAlignment> builder)
        {
            // TODO MS-SQL-Server: 'NcbiAlignment' mappings
            builder.HasBaseType(typeof(Alignment));
        }
    }
}
