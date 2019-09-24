using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AVS.CoreLib.Infrastructure;
using AVS.CoreLib.Infrastructure.Config;
using AVS.CoreLib.Services.Tasks;
using AVS.Nicehash.Api.Tasks;

namespace AVS.Nicehash
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = ConfigurationManager.GetSection("AppConfig") as AppConfig;
            if (config == null)
            {
                return;
            }
            try
            {
                EngineContext.Initialize(false, config);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " \r\n" + ex.ToString(), @"Application start failed");
                return;
            }

            TaskManager.Instance.RegisterTasks(config, OrderAdjustmentTask.DefaultScheduleTask);
            TaskManager.Instance.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
