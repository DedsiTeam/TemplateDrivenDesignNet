using Dedsi.Ddd.CQRS.Commands;

namespace TemplateDrivenDesignNet.Templates.Commands;

public record CreateTemplateCommand: DedsiCommand<bool>;