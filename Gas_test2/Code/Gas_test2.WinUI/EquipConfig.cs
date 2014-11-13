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
        public EquipConfig()
        {
            InitializeComponent();
        }

        [ModuleStart]
        public void StartEx()
        {

        }











    }
}
