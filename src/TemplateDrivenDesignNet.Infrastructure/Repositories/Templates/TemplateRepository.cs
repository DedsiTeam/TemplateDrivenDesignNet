using Dedsi.Ddd.Domain.Repositories;
using Dedsi.EntityFrameworkCore.Repositories;
using TemplateDrivenDesignNet.EntityFrameworkCore;
using TemplateDrivenDesignNet.Templates;
using Volo.Abp.EntityFrameworkCore;

namespace TemplateDrivenDesignNet.Repositories.Templates;

public interface ITemplateRepository : IDedsiCqrsRepository<Template, string>;

public class TemplateRepository(IDbContextProvider<TemplateDrivenDesignNetDbContext> dbContextProvider)
    : DedsiCqrsEfCoreRepository<TemplateDrivenDesignNetDbContext, Template, string>(dbContextProvider),
        ITemplateRepository;