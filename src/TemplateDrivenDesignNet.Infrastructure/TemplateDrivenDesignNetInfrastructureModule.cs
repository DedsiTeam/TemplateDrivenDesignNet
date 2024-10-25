using Dedsi.CleanArchitecture.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using TemplateDrivenDesignNet.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TemplateDrivenDesignNet;

[DependsOn(
    typeof(DedsiCleanArchitectureInfrastructureModule)
)]
public class TemplateDrivenDesignNetInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // EntityFrameworkCore
        context.Services.AddAbpDbContext<TemplateDrivenDesignNetDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
    }
}