using Dedsi.Ddd.CQRS.CommandHandlers;
using TemplateDrivenDesignNet.Templates.Commands;

namespace TemplateDrivenDesignNet.Templates.CommandHandlers;

public class UpdateTemplateCommandHandler() : DedsiCommandHandler<UpdateTemplateCommand, bool>
{
    public override Task<bool> Handle(UpdateTemplateCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}