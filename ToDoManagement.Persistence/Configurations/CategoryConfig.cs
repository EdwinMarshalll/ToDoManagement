using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoManagement.Domain.Entities;

namespace ToDoManagement.Persistence.Configurations;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(prop => prop.Name)
            .HasMaxLength(150)
            .IsRequired();
    }
}
