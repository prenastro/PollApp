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
using System.ComponentModel;

namespace pollAp
{
    public partial class guestLogin : PhoneApplicationPage
    {
        public guestLogin()
        {
            InitializeComponent();
           
        }

        private void check()
        {
            try
            {
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (StreamReader sr = new StreamReader(store.OpenFile("flag.txt", FileMode.Open, FileAccess.ReadWrite)))
                    {

                        if (sr.ReadToEnd() == "1")
                        {

                            using (StreamReader sr_un = new StreamReader(store.OpenFile("user_name.txt", FileMode.Open, FileAccess.ReadWrite)))
                            {
                                var queryData = string.Format("?Text={0}", sr_un.ReadToEnd());
                                //user_name.Text = sr_un.ReadToEnd();
                                NavigationService.Navigate(new Uri("/Menu.xaml" + queryData, UriKind.Relative));
                            }

                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (IsolatedStorageException)
            {

            }
        
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
            string fileName = "flag.txt";
            using (var file = appStorage.OpenFile(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
            {
                using (var writer = new StreamWriter(file))
                {
                    writer.Write("0");
                }
            }

            MessageBoxResult res = MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButton.OKCancel);
            if (res == MessageBoxResult.OK)
            {
                e.Cancel = false;
                base.OnBackKeyPress(e);


            }
        }

        private void createAccountButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/createAccount.xaml", UriKind.Relative));
        }



        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            WebClient Aparna = new WebClient();

            Aparna.DownloadStringAsync(new Uri("http://buzzinga.xtreemhost.com/login.php?user_name=" + user_name.Text + "&password=" + passwordBox1.Password, UriKind.Absolute));
            Aparna.DownloadStringCompleted += new DownloadStringCompletedEventHandler(Aparna_DownloadStringCompleted);

        }

        void Aparna_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            lock (this)
            {

                try
                {
                    string s = e.Result;


                    if (s == "login successful")
                    {
                       
  
                      var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
                        string fileName1 = "flag.txt";
                        string fileName2 = "user_name.txt";
                        
                        using (var file = appStorage.OpenFile(fileName1, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
                        {
                            using (var writer = new StreamWriter(file))
                            {
                                writer.Write("1");
                            }
                        }

                        using (var file = appStorage.OpenFile(fileName2, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
                        {
                            using (var writer = new StreamWriter(file))
                            {
                                writer.Write(user_name.Text);
                            }
                        }

                                var queryData = string.Format("?Text={0}", user_name.Text);
                                NavigationService.Navigate(new Uri("/Menu.xaml" + queryData, UriKind.Relative));

                    }

                    else
                    {
                        errorTextBlock.Visibility = System.Windows.Visibility.Visible;
                        user_name.Focus();
                        errorTextBlock.Text = "Please check your username and password";
                    }
                }

                catch (WebException)
                {

                    MessageBox.Show("Please Check The Internet Connectivity");
                    NavigationService.Navigate(new Uri("/guestLogin.xaml", UriKind.Relative));
                }
                
               
            }
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
   
  
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
          
            /*try
            {
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (StreamReader sr = new StreamReader(store.OpenFile("flag.txt", FileMode.Open, FileAccess.ReadWrite)))
                    {

                        if (sr.ReadToEnd() == "1")
                        {
                            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (IsolatedStorageException)
            {

            }*/
            check();
          
        }


    }
}