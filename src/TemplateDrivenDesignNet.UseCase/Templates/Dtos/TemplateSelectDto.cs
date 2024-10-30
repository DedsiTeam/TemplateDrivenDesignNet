namespace TemplateDrivenDesignNet.Templates.Dtos;

public class TemplateSelectDto
{
    public TemplateSelectDto(string value, string label)
    {
        Value = value;
        Label = label;
    }

    public string Value { get; set; }
    
    public string Label { get; set; }
    
    
    public List<string> TemplateInParameters { get; set; }
}