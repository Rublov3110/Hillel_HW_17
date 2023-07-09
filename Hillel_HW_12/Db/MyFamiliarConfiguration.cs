using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hillel_HW_12
{
    public class MyFamiliarConfiguration : IEntityTypeConfiguration<MyFamiliar>
    {
        public void Configure(EntityTypeBuilder<MyFamiliar> builder)
        {
            builder
                .ToTable("MyFamiliar")
                .HasKey(p => p.ID);
        }
    }
}
