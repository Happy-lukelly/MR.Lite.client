using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.ServiceInstaller;
using Main.WindowsForm;

namespace Main
{
    public class MainProg
    {
        public static void Main(string[] args)
        {
            TipsWindow tipsWindow = new TipsWindow();
            System.Windows.Forms.DialogResult result = tipsWindow.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string ImagePath = @"D:\yanyulong\WorkSpace\MR\MR.Lite.client\MR.Lite.client\TestService\bin\Debug\TestService.exe";
                Service service = new Service();
                service.ImagePath = ImagePath;
                service.DisplayName = "test";
                service.Name = "test";
                service.StartType = StartType.Auto;
                service.ServiceType = ServiceType.Application;
                InstallService(service);
            }
            else
            {

            }
        }

        public static void InstallService(Service service)
        {
            ServiceHelper helper = new ServiceHelper();
            helper.InstallService(service);
        }
    }
}
