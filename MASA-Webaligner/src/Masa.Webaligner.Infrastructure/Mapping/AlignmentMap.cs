using Masa.Webaligner.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Masa.Webaligner.Infrastructure.Mapping
{
    public class AlignmentMap : IEntityTypeConfiguration<Alignment>
    {
        public void Configure(EntityTypeBuilder<Alignment> builder)
        {
            // TODO MS-SQL-Server: 'Alignment' mappings
            builder.Property<string>("AlignmentType");
            builder.HasDiscriminator<string>("AlignmentType")
                .HasValue<Alignment>("Alignment")
                .HasValue<NcbiAlignment>("NcbiAlignment");
        }
    }
}
