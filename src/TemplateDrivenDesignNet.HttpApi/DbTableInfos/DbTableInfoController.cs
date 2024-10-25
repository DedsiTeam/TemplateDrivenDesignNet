using Microsoft.AspNetCore.Mvc;
using TemplateDrivenDesignNet.DbTableInfos.Dtos;
using TemplateDrivenDesignNet.DbTableInfos.Queries;

namespace TemplateDrivenDesignNet.DbTableInfos;

/// <summary>
/// 数据库表信息
/// </summary>
/// <param name="dbTableInfoQuery"></param>
public class DbTableInfoController(IDbTableInfoQuery dbTableInfoQuery) : TemplateDrivenDesignNetController
{
    /// <summary>
    /// 获得数据库表信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Task<List<TableInfoResultDto>> GetTableInfoAsync()
    {
        return dbTableInfoQuery.GetTableInfoAsync();
    }
}