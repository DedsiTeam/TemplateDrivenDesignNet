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
    
    /// <summary>
    /// 模板中所需参数
    /// </summary>
    public Dictionary<string,Object> TemplateDatas  { get; set; }
}