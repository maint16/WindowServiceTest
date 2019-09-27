using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceTest
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

        }

        protected override void OnStop()
        {
        }

        private void OnElapsendTime(object source, ElapsedEventArgs e)
        {

        }

        public void WriteToFile(string message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" +
                              DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";

            if (!File.Exists(filePath))
            {
                // Create a file to write to.
                using (StreamWriter sw= File.CreateText(filePath))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw= File.AppendText(filePath))
                {
                    sw.WriteLine(message);
                }
            }
        }
    }
}
