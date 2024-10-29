using Dedsi.Ddd.Domain.Queries;
using Dedsi.EntityFrameworkCore.Queries;
using Dedsi.SqlSugar.Queries;
using Microsoft.EntityFrameworkCore;
using SqlSugar;
using TemplateDrivenDesignNet.DbTableInfos.Dtos;
using TemplateDrivenDesignNet.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TemplateDrivenDesignNet.DbTableInfos.Queries;

public interface IDbTableInfoQuery : IDedsiQuery
{
    /// <summary>
    /// 获得数据库表信息
    /// </summary>
    /// <returns></returns>
    Task<List<TableInfoResultDto>> GetTableInfoAsync();

    /// <summary>
    /// 获得数据库表字段信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<List<DbTableFieldInfoDto>> GetTableFieldInfoAsync(TableInfoResultDto input);
}

public class DbTableInfoQuery(ISqlSugarClient sqlSugarClient): DedsiSqlSugarQuery(sqlSugarClient), IDbTableInfoQuery
{
    /// <summary>
    /// 获得数据库表信息
    /// </summary>
    /// <returns></returns>
    public Task<List<TableInfoResultDto>> GetTableInfoAsync()
    {
        var sql = @"SELECT
                        OBJECT_NAME(t.object_id) AS 'TableName',
                        OBJECT_SCHEMA_NAME(t.object_id) AS 'SchemaName',
                        p.value AS 'Description'
                    FROM sys.tables as t
                    LEFT JOIN sys.extended_properties as p ON p.major_id = t.object_id AND p.minor_id = 0
                    WHERE t.type = 'U'
                    ORDER BY TableName";

        return GetListAsync<TableInfoResultDto>(sql);
    }

    public Task<List<DbTableFieldInfoDto>> GetTableFieldInfoAsync(TableInfoResultDto input)
    {
        var sql = $@"SELECT
                    c.name as 'FieldName',
                    t.name as 'DataType',
                    c.max_length as 'MaxLength',
                    c.is_nullable as 'IsNullable',
                    p.value as 'FieldChinese'
                FROM sys.columns as c
                INNER JOIN sys.types as t ON c.system_type_id = t.system_type_id
                LEFT JOIN sys.extended_properties as p ON c.object_id = p.major_id AND c.column_id = p.minor_id
                WHERE c.object_id = OBJECT_ID('{input.SchemaName}.{input.TableName}') and t.name != 'sysname'
                ORDER BY c.column_id";
        
        return GetListAsync<DbTableFieldInfoDto>(sql);
    }
}