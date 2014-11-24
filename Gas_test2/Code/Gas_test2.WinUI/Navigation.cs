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
using System.Reflection;

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
    [Module("EB3FB755-C566-4558-B026-5DCBF62F7A01", "导航界面", "FunctionList")]
    
    public partial class Navigation : UserControl
    {
        #region UI属性
        public static int flag = 0;
        DataSet dataset = new DataSet();

        #endregion

        
        public Navigation()
        {
            InitializeComponent();
        }

        [ModuleStart]
        public void StartEx()
        {

        }

        private void Navigation_Load(object sender, EventArgs e)
        {
            //Menustripe修改
            dataset = ServiceContainer.GetService<IGasDAL>().QueryColumn("EquipName", "EquipTypeSlet");

            //检查判断DataSet数据是否完整
            if (CheckData(dataset))
            {
                //加载MenuStrip菜单
                //ToolStripMenuItem topMenu = new ToolStripMenuItem();
                LoadSubMenu(ref Menu_Query, "查询");
                LoadSubMenu(ref Menu_Forecast, "预测");
            }

            //treeview
            GetMenu(treeView1, MainMenu1);

        }


        #region 创建menustrip相关
        /// <summary>
        /// 递归创建MenuStrip菜单(模块列表)
        /// </summary>
        /// <param name="topMenu">父菜单项</param>
        /// <param name="FATHER_ID">父菜单的ID</param>
        private void LoadSubMenu(ref ToolStripMenuItem topMenu, String func)
        {
            DataView dvList = new DataView(dataset.Tables[0]);
            //过滤出当前父菜单下在所有子菜单数据(仅为下一层的)
            //dvList.RowFilter = "FATHER_ID='" + inFatherId + "'";
            ToolStripMenuItem subMenu;
            foreach (DataRowView dv in dvList)
            {
                //创建子菜单项
                subMenu = new ToolStripMenuItem();
                subMenu.Name = dv["EquipName"].ToString() + func;
                subMenu.Text = dv["ETabName"].ToString();

                subMenu.Tag = dv["ETabName"].ToString()+"_Click";
                String str = " void " + dv["ETabName"].ToString();
                //给菜单项加事件。
                subMenu.Click += new EventHandler(subMenu_Click);

                topMenu.DropDownItems.Add(subMenu);
                
                //递归调用
                //LoadSubMenu(ref subMenu, func);

            }

        }


        /// <summary>
        /// 菜单单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void subMenu_Click(object sender, EventArgs e)
        {

            try
            {
                //tag属性在这里有用到。
                string acName = ((ToolStripMenuItem)sender).Tag.ToString();

                if (acName != "")
                {
                    string[] strArray = acName.Split(new char[] { ',' });
                    if (strArray.Length > 2)
                    {
                    }
                    else
                    {
                        String str = "void " + acName;
                        foreach (MethodInfo info in base.GetType().GetMethods())
                        {
                            if (str.Trim().ToLower().CompareTo(info.ToString().Trim().ToLower()) == 0)
                            {
                                info.Invoke(this, null);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        //检查判断DataSet数据是否完整
        public static bool CheckData(DataSet inData)
        {
            bool flag = false;
            if (CheckTable(inData))
            {
                for (int i = 0; i < inData.Tables.Count; i++)
                {
                    if (inData.Tables[0].Rows.Count > 0)
                    {
                        flag = true;
                    }
                }
                return flag;
            }
            return false;
        }
        public static bool CheckTable(DataSet inData)
        {
            if (inData == null)
            {
                return false;
            }
            return (inData.Tables.Count > 0);
        }
        #endregion

        #region 由menustripe创建treeview
        /// <summary>
        /// 读取菜单中的信息.
        /// </summary>
        /// <param name="treeV">TreeView控件</param>
        /// <param name="MenuS">MenuStrip控件</param>
        public void GetMenu(TreeView treeV, MenuStrip MenuS)
        {
            for (int i = 0; i < MenuS.Items.Count; i++) //遍历MenuStrip组件中的一级菜单项
            {
                //将一级菜单项的名称添加到TreeView组件的根节点中，并设置当前节点的子节点newNode1
                TreeNode newNode1 = treeV.Nodes.Add(MenuS.Items[i].Text);
                //将当前菜单项的所有相关信息存入到ToolStripDropDownItem对象中
                ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];
                //判断当前菜单项中是否有二级菜单项
                if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)
                    for (int j = 0; j < newmenu.DropDownItems.Count; j++)    //遍历二级菜单项
                    {
                        //将二级菜单名称添加到TreeView组件的子节点newNode1中，并设置当前节点的子节点newNode2
                        TreeNode newNode2 = newNode1.Nodes.Add(newmenu.DropDownItems[j].Text);
                        //将当前菜单项的所有相关信息存入到ToolStripDropDownItem对象中
                        ToolStripDropDownItem newmenu2 = (ToolStripDropDownItem)newmenu.DropDownItems[j];
                        //判断二级菜单项中是否有三级菜单项
                        if (newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count > 0)
                            for (int p = 0; p < newmenu2.DropDownItems.Count; p++)    //遍历三级菜单项
                                //将三级菜单名称添加到TreeView组件的子节点newNode2中
                                newNode2.Nodes.Add(newmenu2.DropDownItems[p].Text);
                    }
            }
        }
        #endregion

        #region  用TreeView控件调用StatusStrip控件下各菜单的单击事件
        /// <summary>
        /// 用TreeView控件调用StatusStrip控件下各菜单的单击事件.
        /// </summary>
        /// <param name="MenuS">MenuStrip控件</param>
        /// <param name="e">TreeView控件的TreeNodeMouseClickEventArgs类</param>
        public void TreeMenuF(MenuStrip MenuS, TreeNodeMouseClickEventArgs e)
        {
            string Men = "";
            for (int i = 0; i < MenuS.Items.Count; i++) //遍历MenuStrip控件中主菜单项
            {
                Men = ((ToolStripDropDownItem)MenuS.Items[i]).Name; //获取主菜单项的名称
                if (Men.IndexOf("Menu") == -1)  //如果MenuStrip控件的菜单项没有子菜单
                {
                    if (((ToolStripDropDownItem)MenuS.Items[i]).Text == e.Node.Text)    //当节点名称与菜单项名称相等时
                        Show_Control(((ToolStripDropDownItem)MenuS.Items[i]).Text.Trim(), 0);  //调用相应的窗体
                }
                ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];
                if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)    //遍历二级菜单项
                    for (int j = 0; j < newmenu.DropDownItems.Count; j++)
                    {
                        Men = newmenu.DropDownItems[j].Name;    //获取二级菜单项的名称
                        if (Men.IndexOf("Menu") == -1)
                        {
                            if ((newmenu.DropDownItems[j]).Text == e.Node.Text)
                                Show_Control((newmenu.DropDownItems[j]).Text.Trim(), 1);
                        }
                        ToolStripDropDownItem newmenu2 = (ToolStripDropDownItem)newmenu.DropDownItems[j];
                        if (newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count > 0)  //遍历三级菜单项
                            for (int p = 0; p < newmenu2.DropDownItems.Count; p++)
                            {
                                if ((newmenu2.DropDownItems[p]).Text == e.Node.Text)
                                        Show_Control((newmenu2.DropDownItems[p]).Text.Trim(), 1);
                            }
                    }
            }

        }
        #endregion

        #region  控件的调用
        /// <summary>
        /// 窗体的调用.
        /// </summary>
        /// <param name="FrmName">调用窗体的Text属性值</param>
        /// <param name="n">标识</param>
        public void Show_Control(string FrmName, int n)
        {

            if (n == 1)
            {
                if (FrmName == "烧结查询")  //判断要打开的窗体
                {
                    CtrlView.Query FrmWordPad = new CtrlView.Query();
                    panel1.Controls.Add(FrmWordPad);
                    flag = 1;

                }

            }
            if (n == 2)
            {
                if (FrmName == "烧结预测")
                {
                    CtrlView.Query FrmWordPad = new CtrlView.Query();
                    panel1.Controls.Add(FrmWordPad);
                    flag = 11;

                }

            }

            if (n == 0)
            {
                if (FrmName == "备份/还原数据库")
                {
                    FormView.HaveBack FrmHaveBack = new FormView.HaveBack();
                    FrmHaveBack.Text = "备份/还原数据库";
                    FrmHaveBack.ShowDialog();
                    FrmHaveBack.Dispose();
                }
                if (FrmName == "清空数据库")
                {
                    FormView.ClearData FrmClearData = new FormView.ClearData();
                    FrmClearData.Text = "清空数据库";
                    FrmClearData.ShowDialog();
                    FrmClearData.Dispose();
                }


                if (FrmName == "计算器")
                {
                    System.Diagnostics.Process.Start("calc.exe");
                }
                if (FrmName == "记事本")
                {
                    System.Diagnostics.Process.Start("notepad.exe");
                }
                if (FrmName == "帮助")
                {
                    System.Diagnostics.Process.Start("readme.doc");
                }
            }


        }
        #endregion






    }
}
