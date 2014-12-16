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

        // 创建一个有两个字段的数据表
        public DataSet CreateTable(string tableName,string colum_name1,string colum_name2,string datatype1,string datatype2 )
        {
            DataSet returndataset = baseClass.getDataSet("create table " + tableName + "(" + colum_name1 + datatype1 + "," + colum_name2 + datatype2  + ")" + ";", tableName);
            return returndataset;
        }

        //在其他文件组上创建两个字段的数据表
        public DataSet CreateTable(string tableName, string colum_name1, string colum_name2, string file_name,string datatype1,string datatype2)
        {
            DataSet returndataset = baseClass.getDataSet("create table " + tableName + "(" + colum_name1 + datatype1 + "," + colum_name2 + datatype2 + ")" + "on" + file_name + ";", tableName);
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
