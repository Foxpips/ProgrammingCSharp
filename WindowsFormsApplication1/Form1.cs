using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var result = await DownloadContent().ConfigureAwait(false);
            label1.Text = result;
        }

        private static async Task<string> DownloadContent()
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync("http://www.mywelfare.ie").ConfigureAwait(false);
            }
        }
    }
}