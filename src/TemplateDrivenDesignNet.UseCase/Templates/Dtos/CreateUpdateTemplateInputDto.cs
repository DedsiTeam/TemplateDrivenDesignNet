namespace TemplateDrivenDesignNet.Templates.Dtos;

public class CreateUpdateTemplateInputDto
{
    /// <summary>
    /// 模板名称
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 模板简介
    /// </summary>
    public string Intro { get; set; }
    
    /// <summary>
    /// 模板内容
    /// </summary>
    public string Content { get; set; }
}