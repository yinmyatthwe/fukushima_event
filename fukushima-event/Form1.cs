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
            InitializeMap();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //日付け
            dateLabel.Text = DateTime.Now.ToString("D");
            //testData.Text =;
            Main();
        }
        //map
        private void InitializeMap()
        {
            try
            {
                gMapControl1.MapProvider = GMapProviders.GoogleMap;
                gMapControl1.Position = new PointLatLng(37.76072260, 140.4733561); // 福島県
                gMapControl1.MinZoom = 2;
                gMapControl1.MaxZoom = 18;
                gMapControl1.Zoom = 10;
                gMapControl1.AutoScroll = true;

                // Add a marker
                GMapMarker marker1 = new GMarkerGoogle(new PointLatLng(37.050419, 140.887680), GMarkerGoogleType.red_dot);　//いわき市
                GMapMarker marker2 = new GMarkerGoogle(new PointLatLng(37.400529, 140.3597421), GMarkerGoogleType.red_dot);　//郡山市
                GMapMarker marker3 = new GMarkerGoogle(new PointLatLng(37.7964381, 140.9194475), GMarkerGoogleType.red_dot); //相馬市
                GMapMarker marker4 = new GMarkerGoogle(new PointLatLng(37.3439717, 140.96995645), GMarkerGoogleType.red_dot);//富岡町
                GMapMarker marker5 = new GMarkerGoogle(new PointLatLng(37.8005851, 140.4003538), GMarkerGoogleType.red_dot); //福島市
                GMapMarker marker6 = new GMarkerGoogle(new PointLatLng(37.1309437, 140.2560466), GMarkerGoogleType.red_dot);　//白河市
                GMapMarker marker7 = new GMarkerGoogle(new PointLatLng(37.4520054, 139.9762868), GMarkerGoogleType.red_dot);　//会津市


                GMapOverlay markers = new GMapOverlay("markers");
                markers.Markers.Add(marker1);
                markers.Markers.Add(marker2);
                markers.Markers.Add(marker3);
                markers.Markers.Add(marker4);
                markers.Markers.Add(marker5);
                markers.Markers.Add(marker6);
                markers.Markers.Add(marker7);


                gMapControl1.Overlays.Add(markers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

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
    }
}
