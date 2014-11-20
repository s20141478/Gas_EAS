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

namespace Gas_test2.WinUI
{
    [Module("61E1524D-AAF7-4369-B46F-3D6766226A11", "设置预测算法", "FunctionList")]
    
    public partial class SetAlgorithm : UserControl
    {
        private DataSet dataset = new DataSet();
        
        public SetAlgorithm()
        {
            InitializeComponent();
        }

        [ModuleStart]
        public void StartEx()
        {

        }

        private void SetAlgorithm_Load(object sender, EventArgs e)
        {
            lbox_Equip.Items.Clear();
            FreshLbox("EquipName", "EquipTypeSlet", "lbox_Equip");

            lbox_Alg.Items.Clear();
            FreshLbox("AlgName", "AlgTypeAbl", "lbox_Alg");
            
        }

        private void btn_Left_Click(object sender, EventArgs e)
        {

            if (lbox_Alg.Items.Count != 0)
            {
                if (lbox_Alg.SelectedItems.Count != 0)
                    if (!lbox_UsedAlg.Items.Contains(lbox_Alg.SelectedItem))
                        lbox_UsedAlg.Items.Add(lbox_Alg.SelectedItem);
            }
        }

        private void btn_Right_Click(object sender, EventArgs e)
        {
            if (lbox_UsedAlg.Items.Count != 0)
            {
                if (lbox_UsedAlg.SelectedItems.Count != 0)
                    lbox_UsedAlg.Items.RemoveAt(lbox_UsedAlg.SelectedIndex);
            }
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            string UsedAlg="";
            foreach (string i in lbox_UsedAlg.Items)
            {
                UsedAlg = UsedAlg+i+';';
            }
            /////重置更新表AlgTypeSlet
            ServiceContainer.GetService<IGasDAL>().EditAlgTypeSlet(lbox_Alg.SelectedItem.ToString(),UsedAlg);

            /////创建算法表
            ServiceContainer.GetService<IGasDAL>().CreatAlgTab();
        }




        /// <summary>
        /// 读取数据库数据到listbox
        /// </summary>
        /// <param name="cloum">列名</param>
        /// <param name="tab">表名</param>
        /// <param name="listbox">listbox名</param>
        private void FreshLbox(string cloum, string tab, string listbox)
        {
            dataset.Clear();

            dataset = ServiceContainer.GetService<IGasDAL>().QueryColumn(cloum, tab);

            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                if (listbox == "lbox_Alg")
                    lbox_Alg.Items.Add(dataset.Tables[0].Rows[j][0]);
                else if (listbox == "lbox_Equip")
                    lbox_Equip.Items.Add(dataset.Tables[0].Rows[j][0]);
                j++;
            }
        }










    }
}
