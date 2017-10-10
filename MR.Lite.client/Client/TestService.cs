using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TestService
{
    public class TestService
    {
        static int tick = 100;
        public static void Main(string[] args)
        {
            int i = 0;
            while (true)
            {
                i++;
                WriteFile();
                if (i > tick)
                {
                    break;
                }
                System.Threading.Thread.Sleep(200);
            }
        }

        public static void WriteFile()
        {
            StreamWriter sw = new StreamWriter("E://test.txt",true,Encoding.UTF8,512);

            if (sw != null)
            {
                try
                {
                    sw.WriteLine("Time :" + DateTime.Now.ToLongTimeString());
                }
                finally
                {
                    sw.Close();
                }
            }
        }
    }
}
