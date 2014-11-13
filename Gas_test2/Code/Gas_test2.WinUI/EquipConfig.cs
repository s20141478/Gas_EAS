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
    [Module("FDF56D48-0A51-43C5-8BC7-C447A5CC2426", "设备节点配置", "FunctionList")]
    
    public partial class EquipConfig : UserControl
    {
        private DataSet dataset = new DataSet();
        
        
        public EquipConfig()
        {
            InitializeComponent();
        }

        [ModuleStart]
        public void StartEx()
        {

        }

        private void EquipConfig_Load(object sender, EventArgs e)
        {
            lbox_Type.Items.Clear();
            dataset.Clear();
            //dataset = DALFunc.QueryTable("EquipName", "EquipTypeAbl");
            dataset = ServiceContainer.GetService<IGasDAL>().QueryTable("EquipName", "EquipTypeAbl");
            lbox_Type.Items.Add(dataset.Tables[0].Rows[1].ToString());

            lbox_Equip.Items.Clear();
            dataset.Clear();
            //dataset = DALFunc.QueryTable("EquipTypeSlet");
            dataset = ServiceContainer.GetService<IGasDAL>().QueryTable("EquipName","EquipTypeSlet");
            //lbox_Type.Items.Add(dataset.Tables[0].Rows[1].ToString());

            txtbox_Num.Text = "";
            lbox_L1.Items.Clear();
            lbox_L2.Items.Clear();
            lbox_L3.Items.Clear();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            
             FormView.AddEquip addequip = new FormView.AddEquip();
            addequip.Show();
            addequip.Dispose();

            dataset.Clear();
            lbox_Type.Items.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryTable("EquipName", "EquipTypeAbl");
            lbox_Type.Items.Add(dataset.Tables[0].Rows[1].ToString());
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            lbox_Type.Items.RemoveAt(lbox_Type.SelectedIndex);
            /////////删除表一行数据

            dataset.Clear();
            lbox_Equip.Items.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryTable("EquipName", "EquipTypeSlet");
            lbox_Type.Items.Add(dataset.Tables[0].Rows[1].ToString());
        }

        private void btn_Left_Click(object sender, EventArgs e)
        {
            lbox_Equip.Items.RemoveAt(lbox_Equip.SelectedIndex);
        }

        private void btn_Right_Click(object sender, EventArgs e)
        {
            lbox_Equip.Items.Add(lbox_Type.SelectedItem);
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            string L1, L2, L3;
            dataset.Clear();
            dataset = ServiceContainer.GetService<IGasDAL>().QueryTable("EquipName", "EquipTypeSlet");
            txtbox_Num.Text = dataset.Tables[0].Rows[3].ToString();

            L1 = dataset.Tables[0].Rows[4].ToString();
            string[] L1D = L1.Split(';');
            lbox_L1.Items.Clear();
            for (int i = 0; i < L1D.Count(); i++)
            {
                lbox_L1.Items.Add(L1D[i]);
            }

            L2 = dataset.Tables[0].Rows[5].ToString();
            string[] L2D = L2.Split(';');
            lbox_L2.Items.Clear();
            for (int i = 0; i < L2D.Count(); i++)
            {
                lbox_L2.Items.Add(L2D[i]);
            }

            L3 = dataset.Tables[0].Rows[6].ToString();
            string[] L3D = L3.Split(';');
            lbox_L3.Items.Clear();
            for (int i = 0; i < L3D.Count(); i++)
            {
                lbox_L3.Items.Add(L3D[i]);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            /////写EquipTypeSlet数据表
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            //////////创建数据表
        }











    }
}
