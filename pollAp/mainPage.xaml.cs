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
using System.IO;
using System.IO.IsolatedStorage;

namespace pollAp
{
    public partial class mainPage : PhoneApplicationPage
    {
        public mainPage()
        {
            InitializeComponent();
        }

        void dt_Tick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/guestLogin.xaml", UriKind.Relative));
        }

        void dt_Tick_login(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
        }
     

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
          try
            {
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (StreamReader sr = new StreamReader(store.OpenFile("flag.txt", FileMode.Open, FileAccess.ReadWrite)))
                    {

                        if (sr.ReadToEnd() == "1")
                        {
                           
                            System.Windows.Threading.DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();
                            dt.Interval = new TimeSpan(0, 0, 0, 2, 0); 
                            dt.Tick += new EventHandler(dt_Tick_login);
                            dt.Start();

                        }
                        else if (sr.ReadToEnd() == "0")
                        {
                            NavigationService.Navigate(new Uri("/guestLogin.xaml", UriKind.Relative));
                        }
                      
                        else
                        {
                            // Do Nothing!
                        }
                    }
                }
            }

            catch (IsolatedStorageException)
            {
                System.Windows.Threading.DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();
                dt.Interval = new TimeSpan(0, 0, 0, 2, 0);
                dt.Tick += new EventHandler(dt_Tick);
                dt.Start();

               
            }

           
        }
    }
}