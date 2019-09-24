using System;
using System.Windows.Forms;
using AVS.Nicehash.Api;

namespace AVS.Nicehash
{
    public partial class Form1 : Form
    {
        private ServersLocation ServersLocation = ServersLocation.Europe;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CoinInfo coin = coinInfoControl1.GetData();
            onlineMarket1.LoadData(ServersLocation, coin.Algorithm, coinInfoControl1.ProfitablePrice);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
