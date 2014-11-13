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
            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryTable("EquipName", "EquipTypeAbl");
            lbox_Equip.Items.Add(dataset.Tables[0].Rows[1]);

            lbox_Alg.Items.Clear();
            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryTable("AlgName", "AlgTypeAbl");
            lbox_Alg.Items.Add(dataset.Tables[0].Rows[1]);
        }

        private void btn_Left_Click(object sender, EventArgs e)
        {
            lbox_UsedAlg.Items.RemoveAt(lbox_UsedAlg.SelectedIndex);
        }

        private void btn_Right_Click(object sender, EventArgs e)
        {
            lbox_UsedAlg.Items.Add(lbox_Alg.SelectedItem);
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            /////更新表AlgTypeSlet
            /////创建算法表
        }














    }
}
