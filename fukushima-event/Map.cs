using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fukushima_event
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            InitializeMap();

        }

        private void Map_Load(object sender, EventArgs e)
        {

        }
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
                GMapMarker marker1 = new GMarkerGoogle(new PointLatLng(37.050419, 140.887680), GMarkerGoogleType.yellow_small);　//いわき市
                GMapMarker marker2 = new GMarkerGoogle(new PointLatLng(37.400529, 140.3597421), GMarkerGoogleType.purple_small);　//郡山市
                GMapMarker marker3 = new GMarkerGoogle(new PointLatLng(37.7964381, 140.9194475), GMarkerGoogleType.red_small); //相馬市
                GMapMarker marker4 = new GMarkerGoogle(new PointLatLng(37.3439717, 140.96995645), GMarkerGoogleType.blue_small);//富岡町
                GMapMarker marker5 = new GMarkerGoogle(new PointLatLng(37.8005851, 140.4003538), GMarkerGoogleType.white_small); //福島市
                GMapMarker marker6 = new GMarkerGoogle(new PointLatLng(37.1309437, 140.2560466), GMarkerGoogleType.brown_small);　//白河市
                GMapMarker marker7 = new GMarkerGoogle(new PointLatLng(37.4520054, 139.9762868), GMarkerGoogleType.orange_small);　//会津市


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
    }
}
