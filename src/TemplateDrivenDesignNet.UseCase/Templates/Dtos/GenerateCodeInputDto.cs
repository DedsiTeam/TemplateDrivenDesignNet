using TemplateDrivenDesignNet.DbTableInfos.Dtos;

namespace TemplateDrivenDesignNet.Templates.Dtos;

public class GenerateCodeInputDto
{
    /// <summary>
    /// 
    /// </summary>
    public string TemplateId { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public TableInfoResultDto TableInfo { get; set; }
}