using Dedsi.Ddd.Domain.Queries;
using Dedsi.EntityFrameworkCore.Queries;
using Mapster;
using Microsoft.EntityFrameworkCore;
using TemplateDrivenDesignNet.EntityFrameworkCore;
using TemplateDrivenDesignNet.Templates.Dtos;
using Volo.Abp.EntityFrameworkCore;

namespace TemplateDrivenDesignNet.Templates.Queries;

public interface ITemplateQuery : IDedsiEfCoreQuery
{
    Task<TemplateDto> GetAsync(string templateId);
    
    /// <summary>
    /// 模板下拉框数据源
    /// </summary>
    /// <returns></returns>
    Task<List<TemplateSelectDto>> GetTemplateSelectListAsync();
}

public class TemplateQuery(IDbContextProvider<TemplateDrivenDesignNetDbContext> dbContextProvider)
    : DedsiEfCoreQuery<TemplateDrivenDesignNetDbContext>(dbContextProvider),
        ITemplateQuery
{
    public async Task<TemplateDto> GetAsync(string templateId)
    {
        var template = await GetAsync<Template, string>(templateId);

        return template.Adapt<TemplateDto>();
    }

    public async Task<List<TemplateSelectDto>> GetTemplateSelectListAsync()
    {
        var dbaContext = await GetDbContextAsync();
        return await dbaContext
            .Templates
            .OrderByDescending(a => a.CreationTime).Select(a => new TemplateSelectDto(a.Id,a.Name)
            {
                TemplateInParameters = a.TemplateInParameters
            })
            .ToListAsync();
    }
}