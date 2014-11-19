using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gas_test2.BLL;
using EAS.Services;

namespace Gas_test2.WinUI.FormView
{
    public partial class AddEquip : Form
    {
        public AddEquip()
        {
            InitializeComponent();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim()!=""&&txtSName.Text.Trim()!="")
                ServiceContainer.GetService<IGasDAL>().AddEquipTypeAbl(txtName.Text.Trim(),txtSName.Text.Trim());
        }
    }
}
