using Dedsi.Ddd.CQRS.Commands;
using TemplateDrivenDesignNet.Templates.Dtos;

namespace TemplateDrivenDesignNet.Templates.Commands;

public record UpdateTemplateCommand(string Id,CreateUpdateTemplateInputDto Input) : DedsiCommand<bool>;