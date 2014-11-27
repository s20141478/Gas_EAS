using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

using EAS.Data;
using EAS.Data.ORM;
using EAS.Data.Access;
using EAS.Modularization;

using EAS;
using EAS.Services;
using EAS.Data.Linq;

using Gas_test2.Entities;
using Gas_test2.BLL;

using ZedGraph;

namespace Gas_test2.WinUI.CtrlView
{
    //[Module("EAF11A66-CAEB-4101-BCCE-61AE01CE9152", "导航界面", "FunctionList")]
    
    public partial class Query : UserControl
    {
        private DataSet dataset = new DataSet();
        
        public Query()
        {
            InitializeComponent();
        }

        //[ModuleStart]
        //public void StartEx()
        //{

        //}

        private void Query_Load(object sender, EventArgs e)
        {

            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryTable("EquipTypeAbl");
            DataView dvList = new DataView(dataset.Tables[0]);
            
            foreach (DataRowView dv in dvList)
            {
                
                if (ModuleClass.FuncClass.ActivContrl[0].ToString()==dv["EquipName"].ToString())
                {
                    lab_Eq.Text ="选择"+ dv["EquipName"].ToString()+"设备号";
                    for (int i = 0; i < int.Parse(dv["EquipNum"].ToString()); i++)
                    {
                        cbox1.Items.Add(i + "#设备");
                    }
                }
            }



            

            SetSize();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            //////查询
            dataset.Clear();
            if(CkListBox1.GetItemChecked(0))
            {
                dataset = ServiceContainer.GetService<IGasDAL>().QueryTable(ModuleClass.FuncClass.ActivContrl[1].ToString() + cbox1.Text + "REAL");
            }
            if (CkListBox1.GetItemChecked(1))
            {
                dataset = ServiceContainer.GetService<IGasDAL>().QueryTable(ModuleClass.FuncClass.ActivContrl[1].ToString() + cbox1.Text + "FCST");
            }
            if (CkListBox1.GetItemChecked(2))
            {
                dataset = ServiceContainer.GetService<IGasDAL>().QueryTable(ModuleClass.FuncClass.ActivContrl[1].ToString() + cbox1.Text + "REAL");
            }

            DG1.DataSource = dataset.Tables[0];
            SetGragh(zg1);
        }

        /// <summary>
        /// zedgragh作图
        /// </summary>
        /// <param name="zg"></param>
        private void SetGragh(ZedGraph.ZedGraphControl zg)
        {
            GraphPane myPane = zg.GraphPane;
            //Set labels
            myPane.Title.Text = "煤气实绩";// 表头
            myPane.XAxis.Title.Text = "时间";// 横坐标lable
            myPane.YAxis.Title.Text = "煤气量";// 纵坐标label
            //Set list
            PointPairList list = new PointPairList();

            DataView dvList = new DataView(dataset.Tables[0]);
            foreach (DataRowView dv in dvList)
            {
                for (int i = 0; i < 100; i++)
                {

                    double x = Convert.ToDouble(dv["TIME"]);
                    double y = Convert.ToDouble(dv["FLOW"]);
                    list.Add(x, y);
                }

            }            
            /*            List<HRGasReal> tempList = vList.ToList();
            
                        for (int i = 0; i < 100; i++)
                        {
                            double C = tempList[i].Consumption;
                            DateTime T = tempList[i].Time;

                            double x = Convert.ToDouble(i);
                            double y = Convert.ToDouble(C);
                            list.Add(x, y);
                        }
            */
            /*//DateTime m = Convert.ToDateTime(DG1.Columns[1]);
            Double n = Convert.ToDouble( DG1.Columns[2]);
            list.Add(m, n);
            for (int i = 0; i < 100; i++)
            {
                double x = (double)new XDate(2013, 6,11,i,0,0);
                
                double y = Math.Sin((double)i * Math.PI / 15.0); 

                list.Add(x, y);
            }*/

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve = myPane.AddCurve("煤气量", list, Color.Blue, SymbolType.Circle);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            //Calculate the Axis Scale Ranges
            //myPane.XAxis.Type = AxisType.Date;

            myPane.AxisChange();
        }


        /// <summary>
        /// zedgragh大小设置
        /// </summary>
        private void SetSize()
        {
            zg1.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            zg1.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20);
        }



        private void CkListBox1_ItemCheck(object sender,ItemCheckEventArgs e)
        {

            if (CkListBox1.CheckedItems.Count > 0)
            {

                for (int i = 0; i < CkListBox1.Items.Count; i++)
                {

                    if (i != e.Index)
                    {

                        this.CkListBox1.SetItemCheckState(i,System.Windows.Forms.CheckState.Unchecked);

                    }

                }

            }

        }









    }
}
