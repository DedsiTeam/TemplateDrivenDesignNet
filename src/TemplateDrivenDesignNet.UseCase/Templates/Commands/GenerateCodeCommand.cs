using Dedsi.Ddd.CQRS.Commands;
using TemplateDrivenDesignNet.DbTableInfos.Dtos;

namespace TemplateDrivenDesignNet.Templates.Commands;

/// <summary>
/// 由模板生成代码
/// </summary>
/// <param name="TemplateId"></param>
/// <param name="TableFieldInfos">数据库表信息</param>
public record GenerateCodeCommand(string TemplateId,List<DbTableFieldInfoDto> TableFieldInfos) : DedsiCommand<GenerateCodeCommandResultDto>;

/// <summary>
/// 命令的结果
/// </summary>
/// <param name="TemplateId"></param>
/// <param name="CodeString"></param>
public record GenerateCodeCommandResultDto(string TemplateId, string CodeString);