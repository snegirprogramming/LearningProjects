using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class WebinarConfiguration : IEntityTypeConfiguration<Webinar>
{
    public void Configure(EntityTypeBuilder<Webinar> builder)
    {
        throw new NotImplementedException();
    }
}

// TODO