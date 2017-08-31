using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Device.Location;

namespace pollAp
{
    public partial class createAccount : PhoneApplicationPage
    {

        string lattitude;
        string longitude;

        GeoCoordinateWatcher watcher;
        
        public createAccount()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            // The watcher variable was previously declared as type GeoCoordinateWatcher. 
            if (watcher == null)
            {
                watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High); // using high accuracy
                watcher.MovementThreshold = 20; // use MovementThreshold to ignore noise in the signal
                watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
                watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            }
            watcher.Start();


            WebClient Aparna = new WebClient();

            Aparna.DownloadStringAsync(new Uri("http://buzzinga.xtreemhost.com/create_acc.php?user_name=" + user_name.Text + "&password=" +passwordBox1.Password + "&gps_lat=" +lattitude + "&gps_lon=" + longitude, UriKind.Absolute));
            Aparna.DownloadStringCompleted += new DownloadStringCompletedEventHandler(Aparna_DownloadStringCompleted);

        }

        void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    // The Location Service is disabled or unsupported.
                    // Check to see whether the user has disabled the Location Service.
          /*          if (watcher.Permission == GeoPositionPermission.Denied)
                    {
                        // The user has disabled the Location Service on their device.
                    
                        statusTextBlock.Text = "you have this application access to location.";
                    }
                    else
                    {
                        statusTextBlock.Text = "location is not functioning on this device";
                    } */
                    break;

                case GeoPositionStatus.Initializing:
                    // The Location Service is initializing.

                    break;

                case GeoPositionStatus.NoData:
                    // The Location Service is working, but it cannot get location data.

                    break;

                case GeoPositionStatus.Ready:
                    // The Location Service is working and is receiving location data.

                    break;
            }
        }

        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            lattitude= e.Position.Location.Latitude.ToString("0.000");
            longitude = e.Position.Location.Longitude.ToString("0.000");
        }


        void Aparna_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            lock (this)
            {
                try
                {
                    string ret = e.Result;

                    if (ret == "1 record added")
                    {
                        var queryData = string.Format("?Text={0}", user_name.Text);
                        NavigationService.Navigate(new Uri("/Menu.xaml" + queryData, UriKind.Relative));

                    }

                    else
                    {
                        invalidTextBlock.Text = ret;
                        invalidTextBlock.Visibility = System.Windows.Visibility.Visible;

                    }
                }
                catch (WebException)
                {
                    MessageBox.Show("Server Error!");
                    NavigationService.Navigate(new Uri("/createAccount.xaml" , UriKind.Relative));

                }
            }
        }

      


       /* public static int Compare(string strA, string strB)
        {

            return string.Compare(strA, strB);

        }*/
    }
}