using Dedsi.Ddd.CQRS.Mediators;
using Microsoft.AspNetCore.Mvc;
using TemplateDrivenDesignNet.DbTableInfos.Queries;
using TemplateDrivenDesignNet.Templates.Commands;
using TemplateDrivenDesignNet.Templates.Dtos;

namespace TemplateDrivenDesignNet.Templates;

/// <summary>
/// 模板
/// </summary>
/// <param name="dedsiMediator"></param>
/// <param name="dbTableInfoQuery"></param>
public class TemplateController(
    IDedsiMediator dedsiMediator,
    IDbTableInfoQuery dbTableInfoQuery) 
    : TemplateDrivenDesignNetController
{
    /// <summary>
    /// 由模板生成代码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<GenerateCodeCommandResultDto> GenerateCodeAsync(GenerateCodeInputDto input)
    {
        var tableFieldInfos = await dbTableInfoQuery.GetTableFieldInfoAsync(input.TableInfo);
        
        var command = new GenerateCodeCommand(input.TemplateId, tableFieldInfos);
        
        return await dedsiMediator.PublishAsync(command);
    }
}