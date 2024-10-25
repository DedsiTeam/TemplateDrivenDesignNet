using Dedsi.Ddd.Domain.Queries;
using Dedsi.EntityFrameworkCore.Queries;
using TemplateDrivenDesignNet.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TemplateDrivenDesignNet.Templates.Queries;

public interface ITemplateQuery : IDedsiEfCoreQuery;

public class TemplateQuery(IDbContextProvider<TemplateDrivenDesignNetDbContext> dbContextProvider)
    : DedsiEfCoreQuery<TemplateDrivenDesignNetDbContext>(dbContextProvider), 
        ITemplateQuery;