using Dedsi.Ddd.CQRS.CommandHandlers;
using TemplateDrivenDesignNet.Templates.Commands;

namespace TemplateDrivenDesignNet.Templates.CommandHandlers;

public class CreateTemplateCommandHandler() : DedsiCommandHandler<CreateTemplateCommand, bool>
{
    public override Task<bool> Handle(CreateTemplateCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}