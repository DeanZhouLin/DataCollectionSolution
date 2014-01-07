using System;
using System.Windows.Forms;
using HttpCore;

namespace WinTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            string from = tFrom.Text.Trim();
            string to = tTo.Text.Trim();
            QuNarFlightControl quNarFlightControl = new QuNarFlightControl(
                "\"entries\":\\s*(?<Flights>.*)\\s*,\"pageInfo\"",
                "http://api.qunar.com/moreSogouFlightData.jcp?from={0}&to={1}&count={2}&output=json");

            dgvData.DataSource = quNarFlightControl.GetLowestPriceEntity(from, to).GenerateDataTableForQuNarFlightEntity();

        }

        private void btnGetList_Click(object sender, EventArgs e)
        {
            string from = tFrom.Text.Trim();
            string to = tTo.Text.Trim();
            int getCount = int.Parse(tGetCount.Text.Trim());
            if (getCount == 0)
            {
                getCount = 1;
            }

            QuNarFlightControl quNarFlightControl = new QuNarFlightControl(
                "\"entries\":\\s*(?<Flights>.*)\\s*,\"pageInfo\"",
                "http://api.qunar.com/moreSogouFlightData.jcp?from={0}&to={1}&count={2}&output=json");

            dgvData.DataSource = quNarFlightControl.GetPriceEntityList(from, to, getCount).GenerateDataTableForQuNarFlightEntity();



        }
    }
}
