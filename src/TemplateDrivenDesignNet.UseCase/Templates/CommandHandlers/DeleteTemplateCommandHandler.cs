using Dedsi.Ddd.CQRS.CommandHandlers;
using TemplateDrivenDesignNet.Repositories.Templates;
using TemplateDrivenDesignNet.Templates.Commands;

namespace TemplateDrivenDesignNet.Templates.CommandHandlers;

public class DeleteTemplateCommandHandler(ITemplateRepository templateRepository) : DedsiCommandHandler<DeleteTemplateCommand, bool>
{
    public override async Task<bool> Handle(DeleteTemplateCommand command, CancellationToken cancellationToken)
    {
        await templateRepository.DeleteAsync(a => a.Id == command.TemplateId, cancellationToken: cancellationToken);

        return true;
    }
}