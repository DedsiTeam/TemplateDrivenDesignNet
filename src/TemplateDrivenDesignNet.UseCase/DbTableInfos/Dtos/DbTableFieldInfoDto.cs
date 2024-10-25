namespace TemplateDrivenDesignNet.DbTableInfos.Dtos;

public class DbTableFieldInfoDto
{

    public string FieldName { get; set; }
    
    public string DataType { get; set; }
    
    public Int16 MaxLength { get; set; }
    
    public bool IsNullable { get; set; }
    
    public string FieldChinese { get; set; }
}