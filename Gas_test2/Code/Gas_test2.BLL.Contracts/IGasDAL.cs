using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Gas_test2.Entities;

namespace Gas_test2.BLL
{
    public interface IGasDAL
    {
        /// <summary>
        /// 查询整张表
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <returns></returns>
        DataSet QueryTable(string TableName);

        /// <summary>
        /// 查询一张表的整列数据
        /// </summary>
        /// <param name="column_name">列名</param>
        /// <param name="table_name">表名</param>
        /// <returns></returns>
        DataSet QueryColumn(string column_name, string table_name);

        /// <summary>
        /// 查询一张表的一行数据
        /// </summary>
        /// <param name="row_name">主键值</param>
        /// <param name="table_name">表名</param>
        /// <returns></returns>
        DataSet QueryRow(string row_name, string table_name);

        /// <summary>
        /// 删除指定表中某行数据
        /// </summary>
        /// <param name="value">查询值</param>
        /// <param name="column_name">列名</param>
        /// <param name="table_name">表名</param>
        void DeletData(string value,string column_name, string table_name);

        /// <summary>
        /// 添加EquipTypeAbl一行数据
        /// </summary>
        /// <param name="EquipName">设备名称</param>
        /// <param name="ETabName">名称简称</param>
        void AddEquipTypeAbl(string EquipName, string ETabName);

        /// <summary>
        /// 更新UpdateEquipTypeSlet数据
        /// </summary>
        /// <param name="EquipName">指定行名称</param>
        /// <param name="EquipNum">设备数量</param>
        /// <param name="L1">L1因素</param>
        /// <param name="L2">L2因素</param>
        /// <param name="L3">L3因素</param>
        void UpdateEquipTypeSlet(string EquipName,string EquipNum,string L1,string L2,string L3);

        /// <summary>
        /// 添加AlgTypeAbl一行数据
        /// </summary>
        /// <param name="AlgName">算法名称</param>
        /// <param name="ATabName">算法简称</param>
        void AddAlgTypeAbl(string AlgName, string ATabName);

        /// <summary>
        /// 更新算法路径设置
        /// </summary>
        /// <param name="AlgRoute">m文件路径</param>
        /// <param name="AlgParaRoute">算法配置路径</param>
        /// <param name="AlgName">算法名称</param>
        void UpdataAlgTypeAbl(string AlgRoute, string AlgParaRoute, string AlgName);

        /// <summary>
        /// 查询EquipName是否存在，存在则update，否则insert
        /// </summary>
        /// <param name="EquipName">设备名</param>
        /// <param name="Alg">算法名称</param>
        void EditAlgTypeSlet(string EquipName,string Alg);

        void CreatEquipTab();

        void CreatAlgTab();
    }
}
