using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EAS.Data.Linq;
using EAS.Data.ORM;
using Gas_test2.Entities;
using EAS.Services;
using Gas_test2.DAL;


namespace Gas_test2.BLL
{
    [ServiceObject("数据服务")]
    [ServiceBind(typeof(IGasDAL))]
    public class GasDAL:IGasDAL
    {
    }
}
