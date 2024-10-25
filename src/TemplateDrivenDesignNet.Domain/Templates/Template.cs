using Volo.Abp.Domain.Entities;

namespace TemplateDrivenDesignNet.Templates;

/// <summary>
/// 模板信息
/// </summary>
public class Template : Entity<string>
{
    protected Template()
    {

    }

    public Template(string id, string name, string intro, string content) : base(id)
    {
        Name = name;
        Intro = intro;
        Content = content;
    }

    /// <summary>
    /// 模板名称
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// 模板简介
    /// </summary>
    public string Intro { get; private set; }
    
    /// <summary>
    /// 模板内容
    /// </summary>
    public string Content { get; private set; }
}