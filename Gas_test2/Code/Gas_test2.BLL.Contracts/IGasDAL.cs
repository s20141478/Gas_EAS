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
        DataSet QueryTable(string TableName);
        DataSet QueryTable(string column_name, string table_name);
    }
}
