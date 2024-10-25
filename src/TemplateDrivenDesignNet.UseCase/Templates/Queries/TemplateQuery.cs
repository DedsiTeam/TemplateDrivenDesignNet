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
}