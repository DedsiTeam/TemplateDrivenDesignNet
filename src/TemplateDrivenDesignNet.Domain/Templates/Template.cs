using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace TemplateDrivenDesignNet.Templates;

/// <summary>
/// 模板信息
/// </summary>
public class Template : Entity<string>,ICreationAuditedObject
{
    protected Template()
    {

    }

    public Template(string id, string name, string intro, string content) : base(id)
    {
        ChangeName(name);
        ChangeIntro(intro);
        ChangeContent(content);
    }
    
    public DateTime CreationTime { get; protected set; }
    
    public Guid? CreatorId { get; protected set; }

    /// <summary>
    /// 模板名称
    /// </summary>
    public string Name { get; private set; }

    public void ChangeName(string newName)
    {
        Name = Check.NotNullOrWhiteSpace(newName, nameof(newName));
    }
    
    /// <summary>
    /// 模板简介
    /// </summary>
    public string Intro { get; private set; }

    public void ChangeIntro(string newIntro)
    {
        Intro = Check.NotNullOrWhiteSpace(newIntro, nameof(newIntro));
    }
    
    /// <summary>
    /// 模板内容
    /// </summary>
    public string Content { get; private set; }

    public void ChangeContent(string newContent)
    {
        Content = Check.NotNullOrWhiteSpace(newContent, nameof(newContent));
    }
    
    /// <summary>
    /// 模板入参
    /// </summary>
    public List<string> TemplateInParameters { get; private set; } = new();

    public void AddTemplateInParameter(string templateInParameter)
    {
        if (TemplateInParameters.Any(a => a == templateInParameter))
        {
            throw new UserFriendlyException( templateInParameter + ": 已存在！");
        }
        TemplateInParameters.Add(templateInParameter);
    }
    
    public void AddTemplateInParameters(List<string> templateInParameters)
    {
        foreach (var templateInParameter in templateInParameters)
        {
            AddTemplateInParameter(templateInParameter);
        }
    }

    public void RemoveTemplateInParameters(string templateInParameter)
    {
        TemplateInParameters.Remove(templateInParameter);
    }

    public void ClearTemplateInParameters()
    {
        TemplateInParameters.Clear();
    }
    
    /// <summary>
    /// 清除后全部添加
    /// </summary>
    public void ClearAndTemplateInParameters(List<string> templateInParameters)
    {
        ClearTemplateInParameters();
        TemplateInParameters = templateInParameters;
    }

}