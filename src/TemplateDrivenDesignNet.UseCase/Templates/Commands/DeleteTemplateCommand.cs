using Dedsi.Ddd.CQRS.Commands;

namespace TemplateDrivenDesignNet.Templates.Commands;

public record DeleteTemplateCommand(string TemplateId): DedsiCommand<bool>;