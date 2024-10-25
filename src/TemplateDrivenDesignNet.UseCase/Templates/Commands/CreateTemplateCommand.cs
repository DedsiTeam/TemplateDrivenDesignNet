using Dedsi.Ddd.CQRS.Commands;
using TemplateDrivenDesignNet.Templates.Dtos;

namespace TemplateDrivenDesignNet.Templates.Commands;

public record CreateTemplateCommand(CreateUpdateTemplateInputDto Input) : DedsiCommand<bool>;