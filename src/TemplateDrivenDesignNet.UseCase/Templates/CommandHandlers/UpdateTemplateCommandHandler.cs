using Dedsi.Ddd.CQRS.CommandHandlers;
using TemplateDrivenDesignNet.Repositories.Templates;
using TemplateDrivenDesignNet.Templates.Commands;

namespace TemplateDrivenDesignNet.Templates.CommandHandlers;

public class UpdateTemplateCommandHandler(ITemplateRepository templateRepository) : DedsiCommandHandler<UpdateTemplateCommand, bool>
{
    public override async Task<bool> Handle(UpdateTemplateCommand command, CancellationToken cancellationToken)
    {
        var template = await templateRepository.GetAsync(command.Id, cancellationToken: cancellationToken);
        
        template.ChangeName(command.Input.Name);
        template.ChangeIntro(command.Input.Intro);
        template.ChangeContent(command.Input.Content);
        
        template.ClearAndTemplateInParameters(command.Input.TemplateInParameters);
        
        await templateRepository.UpdateAsync(template, cancellationToken: cancellationToken);

        return true;
    }
}