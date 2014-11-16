using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EAS.Data.Linq;
using EAS.Data.ORM;
using Gas_test2.Entities;
using EAS.Services;
using Gas_test2.DAL;
using MLApp;

namespace Gas_test2.BLL
{
    [ServiceObject("预测服务")]
    [ServiceBind(typeof(IGasBLL))]
    public  class GasForecast:IGasBLL
    {
        private FileClass fileControl = new FileClass();
        private DataClass dataControl = new DataClass();

        public void Focast()
        {
            
            #region 参数设定
            int i0 = 100;    //输入行
            int i1 = 1;      //输入列
            int o0 = 10;    //输入行
            int o1 = 1;      //输入列
            float[,] w = new float[i0, i1];
            

            string FnameI = @"E:\a.txt";
            string FnameO = @"E:\b.txt";

            DbEntities db = new DbEntities();
            var t = db.CreateTransaction();
            #endregion


            ///////查询数据                   
            

            //数组赋值
            for (int i = 0; i < 100; i++)
            {
                //w[i, 0] = tempList[i].Consumption;
            }

            //数组到txt
            fileControl.saveMatrix(w, FnameO);
            //Matlab运算
            Matlabfunc();
            //读txt到数组
            w = fileControl.readMatrix(o0, o1, FnameI);
            ////////数组到数据库
            


            t.Commit();

        }

        /// <summary>
        /// matlab调用
        /// </summary>
        private void Matlabfunc()
        {
            MLApp.MLAppClass matlab = new MLApp.MLAppClass();//调用matlab引擎
            string command;
            command = "path(path,'E:\\code\\oldGas\\mcd')";
            matlab.Execute(command);
            command = "BFGWAVELET";
            matlab.Visible = 1;
            matlab.Execute(command);     // 执行Matlab命令
        }



    }
}
