using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hillel_HW_12
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
    {
            builder
                .ToTable("Status")
                .HasKey(p => p.ID);
        }
}
}

  
