using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Gas_test2.Entities;
using EAS.Data.ORM;

namespace Gas_test2.DAL
{
    public class DataClass
    {
        #region 定义与实例化
        BaseClass baseClass = new BaseClass();
        #endregion

        #region 查询，插入，删除，修改

        // 查询，查询表的全部内容
        public DataSet QueryTable(string TableName)
        {
            DataSet returndataset = baseClass.getDataSet("select * from " + TableName, TableName);
            return returndataset;
        }

        //查询，查询表的一列
        public DataSet QueryTable(string Clom, string TableName)
        {
            DataSet returndataset = baseClass.getDataSet("select " + Clom + " from " + TableName, TableName);
            return returndataset;
        }

        //查询，查询表里符合条件的元组      
        public DataSet QueryTable(string TableName, string Clom1, string str1)
        {
            DataSet returndataset = baseClass.getDataSet("select * from " + TableName + " where " + Clom1 + "=" + str1, TableName);
            return returndataset;
        }

        //查询，查询表里符合条件的元组的某个列值      
        public DataSet QueryTable(string Clom, string TableName, string Clom1, string str1)
        {
            DataSet returndataset = baseClass.getDataSet("select " + Clom + " from " + TableName + " where " + Clom1 + "=" + str1, TableName);
            return returndataset;
        }

        // 插入, 插入元组,1个列值
        public DataSet InsertTable(string TableName, string Clom1, string str1)
        {
            DataSet returndataset = baseClass.getDataSet("insert into " + TableName + "(" + Clom1 + ")" + " values " + "(" + str1 + ")", TableName);
            return returndataset;
        }

        // 插入, 插入元组,2个列值
        public DataSet InsertTable(string TableName, string Clom1, string str1, string Clom2, string str2)
        {
            DataSet returndataset = baseClass.getDataSet("insert into " + TableName + "(" + Clom1 + "," + Clom2 + ")" + " values " + "(" + str1 + "," + str2 + ")", TableName);
            return returndataset;
        }

        // 插入, 插入元组,3个列值
        public DataSet InsertTable(string TableName, string Clom1, string str1, string Clom2, string str2, string Clom3, string str3)
        {
            DataSet returndataset = baseClass.getDataSet("insert into " + TableName + "(" + Clom1 + "," + Clom2 + "," + Clom3 + ")" + " values " + "(" + str1 + "," + str2 + "," + str3 + ")", TableName);
            return returndataset;
        }

        // 删除，从表中删除符合条件的元组，1个条件
        public DataSet DeleteTable(string TableName, string Clom1, string str1)
        {
            DataSet returndataset = baseClass.getDataSet("delete from " + TableName + " where " + Clom1 + "=" + str1, TableName);
            return returndataset;
        }

        // 删除，从表中删除符合条件的元组，2个条件
        public DataSet DeleteTable(string TableName, string Clom1, string str1, string Clom2, string str2)
        {
            DataSet returndataset = baseClass.getDataSet("delete from " + TableName + " where " + Clom1 + "=" + str1 + " and " + Clom2 + "=" + str2, TableName);
            return returndataset;
        }

        // 删除，从表中删除符合条件的元组，3个条件
        public DataSet DeleteTable(string TableName, string Clom1, string str1, string Clom2, string str2, string Clom3, string str3)
        {
            DataSet returndataset = baseClass.getDataSet("delete from " + TableName + " where " + Clom1 + " = " + str1 + " and " + Clom2 + "=" + str2 + " and " + Clom3 + "=" + str3, TableName);
            return returndataset;
        }

        // 修改，1个条件
        public DataSet UpdateTable(string TableName, string Clom, string str, string Clom1, string str1)
        {
            DataSet returndataset = baseClass.getDataSet("update " + TableName + " set " + Clom + "=" + str + " where " + Clom1 + "=" + str1, TableName);
            return returndataset;
        }

        // 修改，2个条件
        public DataSet UpdateTable(string TableName, string Clom, string str, string Clom1, string str1, string Clom2, string str2)
        {
            DataSet returndataset = baseClass.getDataSet("update " + TableName + " set " + Clom + "=" + str + " where " + Clom1 + "=" + str1 + " and " + Clom2 + "=" + str2, TableName);
            return returndataset;
        }

        // 修改，3个条件
        public DataSet UpdateTable(string TableName, string Clom, string str, string Clom1, string str1, string Clom2, string str2, string Clom3, string str3)
        {
            DataSet returndataset = baseClass.getDataSet("update " + TableName + " set " + Clom + "=" + str + " where " + Clom1 + "=" + str1 + " and " + Clom2 + "=" + str2 + " and " + Clom3 + "=" + str3, TableName);
            return returndataset;
        }

        #endregion
    }
}
