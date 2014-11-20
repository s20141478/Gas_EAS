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
            FreshLbox("EquipName", "EquipTypeAbl", "lbox_Type");

            lbox_Equip.Items.Clear();
            FreshLbox("EquipName", "EquipTypeSlet", "lbox_Equip");
            
            txtbox_Num.Text = "";
            dgv_L1.Rows.Clear();
            dgv_L2.Rows.Clear();
            dgv_L3.Rows.Clear();
        }


        private void btn_Add_Click(object sender, EventArgs e)
        {
            
            FormView.AddEquip addequip = new FormView.AddEquip();
            addequip.ShowDialog();
            addequip.Dispose();

            FreshLbox("EquipName", "EquipTypeAbl", "lbox_Type");
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            lbox_Type.Items.RemoveAt(lbox_Type.SelectedIndex);
            /////////删除表一行数据
            ServiceContainer.GetService<IGasDAL>().DeletData(lbox_Type.SelectedItem.ToString(), "EquipName", "EquipTypeSlet");
            FreshLbox("EquipName", "EquipTypeAbl", "lbox_Type");
        }

        private void btn_Left_Click(object sender, EventArgs e)
        {
            if (lbox_Type.Items.Count != 0)
            {
                if (lbox_Type.SelectedItems.Count != 0)
                    if (!lbox_Equip.Items.Contains(lbox_Type.SelectedItem))
                        lbox_Equip.Items.Add(lbox_Type.SelectedItem);
            }
            
        }

        private void btn_Right_Click(object sender, EventArgs e)
        {
            if (lbox_Equip.Items.Count != 0)
            {
                if (lbox_Equip.SelectedItems.Count != 0)
                    lbox_Equip.Items.RemoveAt(lbox_Equip.SelectedIndex);
            }
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            if (lbox_Equip.SelectedItems.Count != 0)
            {
                string L1, L2, L3;
                
                dataset.Clear();
                dataset = ServiceContainer.GetService<IGasDAL>().QueryRow(lbox_Equip.SelectedItem.ToString(), "EquipTypeSlet");
                txtbox_Num.Text = dataset.Tables[0].Rows[0]["EquipNum"].ToString();

                L1 = dataset.Tables[0].Rows[0]["L1"].ToString();
                string[] L1D = L1.Split(';');
                dgv_L1.Rows.Clear();
                for (int i = 0; i < L1D.Count(); i++)
                {
                    dgv_L1.Rows.Add(L1D[i]);
                }

                L2 = dataset.Tables[0].Rows[0]["L2"].ToString();
                string[] L2D = L2.Split(';');
                dgv_L2.Rows.Clear();
                for (int i = 0; i < L2D.Count(); i++)
                {
                    dgv_L2.Rows.Add(L2D[i]);
                }

                L3 = dataset.Tables[0].Rows[0]["L3"].ToString();
                string[] L3D = L3.Split(';');
                dgv_L3.Rows.Clear();
                for (int i = 0; i < L3D.Count(); i++)
                {
                    dgv_L3.Rows.Add(L3D[i]);
                }
            }
            else
                MessageBox.Show("选择设备");
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string L1="", L2="", L3="";
            for(int i=0;i<dgv_L1.Rows.Count;i++)
            {
                L1 = L1 + dgv_L1.Rows[i].Cells[0].ToString()+';';
            }
            for (int i = 0; i < dgv_L1.Rows.Count; i++)
            {
                L2 = L2 + dgv_L2.Rows[i].Cells[0].ToString() + ';';
            }
            for (int i = 0; i < dgv_L1.Rows.Count; i++)
            {
                L3 = L2 + dgv_L3.Rows[i].Cells[0].ToString() + ';';
            }
            /////写EquipTypeSlet数据表
            ServiceContainer.GetService<IGasDAL>().UpdateEquipTypeSlet(lbox_Equip.SelectedItem.ToString(), txtbox_Num.Text.Trim(), L1, L2, L3);
            
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            //////////创建数据表
            ServiceContainer.GetService<IGasDAL>().CreatEquipTab();

        }


        /// <summary>
        /// 读取数据库数据到listbox
        /// </summary>
        /// <param name="cloum">列名</param>
        /// <param name="tab">表名</param>
        /// <param name="listbox">listbox名</param>
        private void FreshLbox(string cloum, string tab,string listbox)
        {
            dataset.Clear();

            dataset = ServiceContainer.GetService<IGasDAL>().QueryColumn(cloum, tab);

            int j = 0;
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                if (listbox == "lbox_Type")
                    lbox_Type.Items.Add(dataset.Tables[0].Rows[j][0]);
                else if (listbox == "lbox_Equip")
                    lbox_Equip.Items.Add(dataset.Tables[0].Rows[j][0]);
                j++;
            }
        }









    }
}
