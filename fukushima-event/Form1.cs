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
using System.Diagnostics;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

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
            //testData.Text =;
            Main();
        }
        //map
        

        //データー
        public static async Task Main()
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


        //fukushima matsuri link 
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.minpo.jp/pub/dento_gyoji2020/unemematuri");
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.minpo.jp/pub/dento_gyoji2020/soumanomaoi");
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.minpo.jp/pub/dento_gyoji2020/hayamanohimaturi");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.minpo.jp/pub/dento_gyoji2020/iwakitanabatamaturi");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.minpo.jp/pub/dento_gyoji2020/fukushimawarajimaturi");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.minpo.jp/pub/dento_gyoji2020/shirakawatyoutinmaturi");
        }
        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.minpo.jp/pub/dento_gyoji2020/aizumaturi");
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.minpo.jp/pub/dento_gyoji2020/aizutajimagionsai");
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void mapBtn_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void fukushimaBtn_Click(object sender, EventArgs e)
        {
            string pdfFilePath = "C:\\Users\\Ma Yin Myat Thwe\\Desktop\\WIZ\\397116.pdf";
            var start = System.Diagnostics.Process.Start(pdfFilePath);
            start.EnableRaisingEvents = true;
           
        }
    }
}
