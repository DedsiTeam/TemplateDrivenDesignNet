using Dedsi.Ddd.CQRS.CommandHandlers;
using JinianNet.JNTemplate;
using TemplateDrivenDesignNet.DbTableInfos.Dtos;
using TemplateDrivenDesignNet.Repositories.Templates;
using TemplateDrivenDesignNet.Templates.Commands;

namespace TemplateDrivenDesignNet.Templates.CommandHandlers;

public class GenerateCodeCommandHandler(ITemplateRepository templateRepository) : DedsiCommandHandler<GenerateCodeCommand, GenerateCodeCommandResultDto>
{
    public override async Task<GenerateCodeCommandResultDto> Handle(GenerateCodeCommand command, CancellationToken cancellationToken)
    {
        var templateDomain = await templateRepository.GetAsync(command.TemplateId, cancellationToken: cancellationToken);
        
        // 查询模板数据
        var template = Engine.CreateTemplate(templateDomain.Content);

        var dbTableFieldInfoCSharpData = await DbTableFieldToCSharpAsync(command.TableFieldInfos);
        template.Set("TableFieldInfos", dbTableFieldInfoCSharpData);
        var render = await template.RenderAsync();
        
        return new GenerateCodeCommandResultDto(command.TemplateId,render);
    }

    /// <summary>
    /// 转 C# 的数据类型
    /// </summary>
    /// <param name="tableFieldInfos"></param>
    /// <returns></returns>
    private ValueTask<List<DbTableFieldInfoCSharpDto>> DbTableFieldToCSharpAsync(List<DbTableFieldInfoDto> tableFieldInfos)
    {
        var list = tableFieldInfos
            .Select(a => new DbTableFieldInfoCSharpDto()
            {
                FieldName = a.FieldName,
                CSharpDataType = SqlToCSharpTypeMapper.GetCSharpType(a.DataType),
                IsNullable = a.IsNullable,
                FieldChinese = a.FieldChinese
            })
            .ToList();
        
        return ValueTask.FromResult(list);
    }
    
}


/// <summary>
/// C# 数据格式
/// </summary>
public class DbTableFieldInfoCSharpDto
{
    /// <summary>
    /// 字段名称
    /// </summary>
    public string FieldName { get; set; }
    
    /// <summary>
    /// 数据类型
    /// </summary>
    public string CSharpDataType { get; set; }
    
    /// <summary>
    /// 可为空
    /// </summary>
    public bool IsNullable { get; set; }
    
    /// <summary>
    /// 字段说明
    /// </summary>
    public string? FieldChinese { get; set; }
}

public class SqlToCSharpTypeMapper
{
    private static readonly Dictionary<string, string> SqlToCSharpTypeMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "int", "int" },
        { "bigint", "long" },
        { "smallint", "short" },
        { "tinyint", "byte" },
        { "bit", "bool" },
        { "decimal", "decimal" },
        { "numeric", "decimal" },
        { "money", "decimal" },
        { "smallmoney", "decimal" },
        { "float", "double" },
        { "real", "float" },
        { "date", "DateTime" },
        { "datetime", "DateTime" },
        { "datetime2", "DateTime" },
        { "smalldatetime", "DateTime" },
        { "time", "TimeSpan" },
        { "char", "string" },
        { "varchar", "string" },
        { "text", "string" },
        { "nchar", "string" },
        { "nvarchar", "string" },
        { "ntext", "string" },
        { "binary", "byte[]" },
        { "varbinary", "byte[]" },
        { "image", "byte[]" },
        { "uniqueidentifier", "Guid" },
        { "xml", "string" }
    };

    public static string GetCSharpType(string sqlType)
    {
        return SqlToCSharpTypeMap.GetValueOrDefault(sqlType, "string");
    }
}


public class SqlToTsTypeMapper
{
    private static readonly Dictionary<string, string> SqlToTsTypeMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "int", "number" },
        { "bigint", "number" },
        { "smallint", "number" },
        { "tinyint", "number" },
        { "bit", "boolean" },
        { "decimal", "number" },
        { "numeric", "number" },
        { "money", "number" },
        { "smallmoney", "number" },
        { "float", "number" },
        { "real", "number" },
        { "date", "Date" },
        { "datetime", "Date" },
        { "datetime2", "Date" },
        { "smalldatetime", "Date" },
        { "time", "string" },
        { "char", "string" },
        { "varchar", "string" },
        { "text", "string" },
        { "nchar", "string" },
        { "nvarchar", "string" },
        { "ntext", "string" },
        { "binary", "Buffer" },
        { "varbinary", "Buffer" },
        { "image", "Buffer" },
        { "uniqueidentifier", "string" },
        { "xml", "string" }
    };

    public static string GetTsType(string sqlType)
    {
        return SqlToTsTypeMap.GetValueOrDefault(sqlType, "string");
    }
}