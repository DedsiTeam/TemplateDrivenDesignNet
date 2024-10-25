using Dedsi.Ddd.CQRS.Mediators;
using Microsoft.AspNetCore.Mvc;
using TemplateDrivenDesignNet.DbTableInfos.Queries;
using TemplateDrivenDesignNet.Templates.Commands;
using TemplateDrivenDesignNet.Templates.Dtos;
using TemplateDrivenDesignNet.Templates.Queries;

namespace TemplateDrivenDesignNet.Templates;

/// <summary>
/// 模板
/// </summary>
/// <param name="dedsiMediator"></param>
/// <param name="dbTableInfoQuery"></param>
/// <param name="templateQuery"></param>
public class TemplateController(
    IDedsiMediator dedsiMediator,
    IDbTableInfoQuery dbTableInfoQuery,
    ITemplateQuery templateQuery)
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

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<bool> CreateAsync(CreateUpdateTemplateInputDto input)
    {
        var command = new CreateTemplateCommand(input);
        
        return dedsiMediator.PublishAsync(command);
    }
    
    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="templateId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("{templateId}")]
    public Task<bool> UpdateAsync(string templateId,CreateUpdateTemplateInputDto input)
    {
        var command = new UpdateTemplateCommand(templateId, input);
        
        return dedsiMediator.PublishAsync(command);
    }
    
    
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="templateId"></param>
    /// <returns></returns>
    [HttpPost("{templateId}")]
    public Task<bool> CreateAsync(string templateId)
    {
        var command = new DeleteTemplateCommand(templateId);
        
        return dedsiMediator.PublishAsync(command);
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="templateId"></param>
    /// <returns></returns>
    [HttpGet("{templateId}")]
    public Task GetAsync(string templateId)
    {
        return templateQuery.GetAsync(templateId);
    }
    
}