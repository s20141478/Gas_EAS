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

        public DataSet QueryTable(string TableName)
        {
            DataSet returndataset = baseClass.getDataSet("select * from " + TableName, TableName);
            return returndataset;

        }

        public DataSet QueryTable(string ClomName, string TableName)
        {
            DataSet returndataset = baseClass.getDataSet("select " + ClomName + " from " + TableName, TableName);
            return returndataset;

        }

    }
}
