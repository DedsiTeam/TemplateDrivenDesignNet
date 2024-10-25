﻿using Dedsi.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace TemplateDrivenDesignNet;

[DependsOn(
    typeof(TemplateDrivenDesignNetUseCaseModule),
    typeof(DedsiAspNetCoreModule)
)]
public class TemplateDrivenDesignNetHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(TemplateDrivenDesignNetHttpApiModule).Assembly);
        });
    }

}