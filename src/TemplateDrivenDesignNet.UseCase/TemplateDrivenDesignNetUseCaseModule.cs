using System.Reflection;
using Dedsi.Ddd.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace TemplateDrivenDesignNet;

[DependsOn(
    // TemplateDrivenDesignNet
    typeof(TemplateDrivenDesignNetDomainModule),
    typeof(TemplateDrivenDesignNetInfrastructureModule),
    
    typeof(DedsiDddCQRSModule)
)]
public class TemplateDrivenDesignNetUseCaseModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // MediatR
        context.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}