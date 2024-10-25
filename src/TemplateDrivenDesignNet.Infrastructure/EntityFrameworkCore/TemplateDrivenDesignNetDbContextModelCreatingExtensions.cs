using Microsoft.EntityFrameworkCore;
using TemplateDrivenDesignNet.Templates;
using Volo.Abp;

namespace TemplateDrivenDesignNet.EntityFrameworkCore;

public static class TemplateDrivenDesignNetDbContextModelCreatingExtensions
{
    public static void ConfigureProjectName(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Template>(b =>
        {
            b.ToTable("Templates", TemplateDrivenDesignNetDomainOptions.DbSchemaName);
            b.HasKey(a => a.Id);
        });

    }
}