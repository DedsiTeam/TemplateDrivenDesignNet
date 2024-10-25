using Dedsi.CleanArchitecture.Domain;
using Volo.Abp.Modularity;

namespace TemplateDrivenDesignNet;

[DependsOn(
    typeof(DedsiCleanArchitectureDomainModule)    
)]
public class TemplateDrivenDesignNetDomainModule : AbpModule
{
    
}