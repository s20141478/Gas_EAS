using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Gas_test2.DAL
{
    public class TabClass
    {  
        #region 定义与实例化
        BaseClass baseClass = new BaseClass();
        #endregion

        #region 创建，删除，修改

        // 创建一个有五个字段的数据表
        public DataSet CreateTable1(string tableName, string colum_name1, string colum_name2, string colum_name3, string colum_name4, string colum_name5, string datatype1, string datatype2, string datatype3, string datatype4, string datatype5)
        {
            DataSet returndataset = baseClass.getDataSet("create table " + tableName + "(" + colum_name1 + datatype1 + "primary key" + "," + colum_name2 + datatype2 + "," + colum_name3 + datatype3 + colum_name4 + datatype4 + "," + colum_name5 + datatype5 + ")" + ";", tableName);
            return returndataset;
        }

        // 创建一个有四个字段的数据表
        public DataSet CreateTable1(string tableName, string colum_name1, string colum_name2, string colum_name3, string colum_name4, string datatype1, string datatype2, string datatype3, string datatype4)
        {
            DataSet returndataset = baseClass.getDataSet("create table " + tableName + "(" + colum_name1 + datatype1 + "primary key" + "," + colum_name2 + datatype2 + "," + colum_name3 + datatype3 + colum_name4 + datatype4 + ")" + ";", tableName);
            return returndataset;
        }

        // 创建一个有七个字段的数据表
        public DataSet CreateTable1(string tableName, string colum_name1, string colum_name2, string colum_name3, string colum_name4, string colum_name5,string colum_name6, string colum_name7, string datatype1, string datatype2, string datatype3, string datatype4, string datatype5, string datatype6, string datatype7)
        {
            DataSet returndataset = baseClass.getDataSet("create table " + tableName + "(" + colum_name1 + datatype1 + "primary key" + "," + colum_name2 + datatype2 + "," + colum_name3 + datatype3 + colum_name4 + datatype4 + "," + colum_name5 + datatype5 + colum_name6 + datatype6 + "," + colum_name7 + datatype7 + ")" + ";", tableName);
            return returndataset;
        }

        //更改数据表中一列的数据类型     
        public DataSet UpdateTable(string tableName, string column_name1,string datatype)
        {
            DataSet returndataset = baseClass.getDataSet("alter table " + tableName + " alter column " + column_name1 + datatype + ";", tableName);
            return returndataset;
        }

        //向数据表中添加一个字段    
        public DataSet AddTable(string tableName, string column_name1,string datatype)
        {
            DataSet returndataset = baseClass.getDataSet("alter table" + tableName + " add " + column_name1 + datatype + ";", tableName);
            return returndataset;
        }

        //删除数据表中一个字段     
        public DataSet DropTable(string tableName, string column_name1)
        {
            DataSet returndataset = baseClass.getDataSet("alter table " + tableName + " drop column " + column_name1 + ";", tableName);
            return returndataset;
        }

        //删除一个数据表;
        public DataSet DropTable(string tableName)
        {
            DataSet returndataset = baseClass.getDataSet("drop table " + tableName + ";", tableName);
            return returndataset;
        }

        

        #endregion
    }
}
