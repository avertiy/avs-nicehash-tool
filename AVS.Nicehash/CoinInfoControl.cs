using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AVS.CoreLib.Infrastructure;
using AVS.CoreLib.WinForms.Controls;
using AVS.Nicehash.Api;

namespace AVS.Nicehash
{
    public partial class CoinInfoControl : UserControlEx
    {
        private NiceHashClient Nicehash => Lazy<NiceHashClient>();
        private CoinInfo _data;
        public double ProfitablePrice { get; set; }
        public CoinInfo SampleData => new CoinInfo()
        {
            Algorithm = AlgoEnum.X11,
            BlockCount = 914375,
            BlockReward = 1.67279914,
            CoinName = "DASH",
            Difficulty = 52807113.6514998,
            Price = 0.02786709
        };

        protected override void Initialize()
        {
            InitializeComponent();
        }
        
        public CoinInfo GetData()
        {
            _data = _data ?? SampleData;
            DisplaData();
            return _data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _data = Nicehash.CoinwarzApi.GetCoinInfo("DASH");
        }

        private void DisplaData()
        {
            var info = _data;
            lblBlockCount.Text = info.BlockCount.ToString("D");
            lblBlockReward.Text = info.BlockReward.ToString("0.00000000");
            lblDifficulty.Text = info.Difficulty.ToString("0.000");
            lblPrice.Text = info.Price.ToString("0.0000000") + " BTC";
            ProfitablePrice = info.CalculateProfitability(HashPower.TeraHash);
            lblProfitablePrice.Text = ProfitablePrice.ToString("0.00000") + " BTC";
            pnl.Visible = true;
        }

        
        
    }
}
