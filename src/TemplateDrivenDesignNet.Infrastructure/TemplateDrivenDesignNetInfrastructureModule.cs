using Dedsi.CleanArchitecture.Infrastructure;
using Dedsi.SqlSugar;
using Dedsi.SqlSugar.Extensions;
using Microsoft.Extensions.DependencyInjection;
using TemplateDrivenDesignNet.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TemplateDrivenDesignNet;

[DependsOn(
    typeof(DedsiSqlSugarModule),
    typeof(DedsiCleanArchitectureInfrastructureModule)
)]
public class TemplateDrivenDesignNetInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.ConfigureSqlSugarBySqlServer("Default");
        
        // EntityFrameworkCore
        context.Services.AddAbpDbContext<TemplateDrivenDesignNetDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
    }
}