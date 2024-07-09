using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fukushima_event
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //日付け
            dateLabel.Text = DateTime.Now.ToString("D");
            Main();
            
        }
        //データー
        static async Task Main()
        {
           
            string url = "https://www.minpo.jp/pub/dento_gyoji2020/index";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); 

                    string content = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(content);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }
        }

    }
}
