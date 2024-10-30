using Dedsi.Ddd.CQRS.CommandHandlers;
using TemplateDrivenDesignNet.Repositories.Templates;
using TemplateDrivenDesignNet.Templates.Commands;

namespace TemplateDrivenDesignNet.Templates.CommandHandlers;

public class CreateTemplateCommandHandler(ITemplateRepository templateRepository) : DedsiCommandHandler<CreateTemplateCommand, bool>
{
    public override async Task<bool> Handle(CreateTemplateCommand command, CancellationToken cancellationToken)
    {
        var template = new Template(Ulid.NewUlid().ToString(), command.Input.Name, command.Input.Intro, command.Input.Content);

        template.AddTemplateInParameters(command.Input.TemplateInParameters);
        
        await templateRepository.InsertAsync(template, cancellationToken: cancellationToken);
        
        return true;
    }
}