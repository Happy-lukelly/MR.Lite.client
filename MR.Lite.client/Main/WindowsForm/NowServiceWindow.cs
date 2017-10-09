using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.ServiceInstaller;

namespace Service.WindowsForm
{
    public partial class NowServiceWindow : Form
    {
        Service.ServiceInstaller.SystemService existsSerivce;
        //卸载事件触发的逻辑委托服务
        Func<bool> OnUnInstall;
        public bool IsUnistall
        {
            get;
            private set;
        }
        public NowServiceWindow(SystemService existsSerivce,Func<bool> OnUnInstall)
        {
            this.existsSerivce = existsSerivce;
            this.OnUnInstall = OnUnInstall;
            InitializeComponent();
        }

        private void btn_UnInstall_Click(object sender, EventArgs e)
        {
            if (OnUnInstall != null)
            {
                try
                {
                    OnUnInstall.Invoke();
                    MessageBox.Show("卸载完成");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "卸载错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
