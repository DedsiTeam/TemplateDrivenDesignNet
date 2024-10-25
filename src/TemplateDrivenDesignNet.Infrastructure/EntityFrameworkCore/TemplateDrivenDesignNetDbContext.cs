using Dedsi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TemplateDrivenDesignNet.Templates;
using Volo.Abp.Data;

namespace TemplateDrivenDesignNet.EntityFrameworkCore;

[ConnectionStringName(TemplateDrivenDesignNetDomainOptions.ConnectionStringName)]
public class TemplateDrivenDesignNetDbContext(DbContextOptions<TemplateDrivenDesignNetDbContext> options) 
    : DedsiEfCoreDbContext<TemplateDrivenDesignNetDbContext>(options)
{
    public DbSet<Template> Templates { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureProjectName();
    }

}