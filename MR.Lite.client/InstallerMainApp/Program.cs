using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.ServiceInstaller;
using Service.WindowsForm;



namespace InstallerMainApp
{
    public class Program
    {
        static ServiceHelper helper = new ServiceHelper();
        public static void Main(string[] args)
        {
            Service.ServiceInstaller.SystemService nowService = helper.GetService("test");
            if (nowService != null)
            {
                //显示当前服务
                NowServiceWindow nowSerivceWindow = new NowServiceWindow(nowService, new Func<bool>(() =>
                {
                    bool uninstallResult = false;
                    uninstallResult = helper.RemoveService(nowService.Name);
                    return uninstallResult;
                }));
                nowSerivceWindow.ShowDialog();
            }
            //服务在当前主机不存在
            else
            {
                TipsWindow tipsWindow = new TipsWindow();
                System.Windows.Forms.DialogResult result = tipsWindow.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string ImagePath = @"D:\yanyulong\WorkSpace\MR\MR.Lite.client\MR.Lite.client\TestService\bin\Debug\TestService.exe";
                    SystemService service = new SystemService();
                    service.ImagePath = ImagePath;
                    service.DisplayName = "test";
                    service.Name = "test";
                    service.StartType = StartType.Auto;
                    service.Description = "ttttttt";
                    service.ServiceType = ServiceType.Application;
                    InstallService(service);
                }
                else
                {

                }
            }
        }

        public static void InstallService(SystemService service)
        {
            helper.InstallService(service);
        }
    }
}
