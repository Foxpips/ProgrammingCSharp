using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsAsyncFormTester
{
    public partial class Form1 : Form
    {
        private int _count;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _count++;

            var jsonAsync = GetJsonAsync();
            var message = await jsonAsync;
            label1.Text = message;
        }

        public async Task<string> GetJsonAsync()
        {
            using (var client = new HttpClientCustom())
            {
                return await client.Save(true) +_count; 
            }
        }
    }
}