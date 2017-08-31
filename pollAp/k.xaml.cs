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

namespace pollAp.Properties
{
   
    public partial class k : PhoneApplicationPage
    {
        string test="0";

        public k()
        {
        
            InitializeComponent();
            myStoryboard.Begin();
            myStoryboard1.Begin();
            myStoryboard2.Begin();
            myStoryboard3.Begin();
            myStoryboard4.Begin();
            myStoryboard5.Begin();
            myStoryboard6.Begin();
            myStoryboard7.Begin();
            myStoryboard8.Begin();
            myStoryboard9.Begin();
            myStoryboard10.Begin();
        }

       protected override void OnBackKeyPress(CancelEventArgs e)
        {
           /* e.Cancel = true;
            NavigationService.RemoveBackEntry();
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
              
                using (StreamReader sr = new StreamReader(store.OpenFile("flag.txt", FileMode.Open, FileAccess.ReadWrite)))
                {

                    if (sr.ReadToEnd() == "2")
                    {
                        sr.Close(); 

                        using (StreamWriter sr1 = new StreamWriter(store.OpenFile("flag.txt", FileMode.Open, FileAccess.Write)))
                        {
                            sr1.Write("1");
                            sr1.Close();
                            e.Cancel = true;

                        }
                        
                    }
                
                         else if (sr.ReadToEnd() == "3")
                    {

                        sr.Close();

                        using (StreamWriter sr1 = new StreamWriter(store.OpenFile("flag.txt", FileMode.Open, FileAccess.Write)))
                        {
                            sr1.Write("0");
                            sr1.Close();
                            e.Cancel = true;

                        }
                    }
                }
            }*/

            NavigationService.RemoveBackEntry();
            NavigationService.RemoveBackEntry();
            e.Cancel = true;
            MessageBoxResult res = MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButton.OKCancel);
            if (res == MessageBoxResult.OK)
            {
                e.Cancel = false;
                base.OnBackKeyPress(e);


            }
        } 

        
        private void doNothing()
        { 
        }

        private void DoubleAnimationUsingKeyFrames_Completed(object sender, EventArgs e)
        {

           
           // NavigationService.Navigate(new Uri("/guestLogin.xaml", UriKind.Relative));

        
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
                            NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
                        }
                        else if (sr.ReadToEnd() == "0")
                        {
                            NavigationService.Navigate(new Uri("/guestLogin.xaml", UriKind.Relative));
                        }
                        else if (sr.ReadToEnd() == "2")
                        {
                            var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
                            string fileName = "flag.txt";
                            using (var file = appStorage.OpenFile(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
                            {
                                using (var writer = new StreamWriter(file))
                                {
                                    writer.Write("1");
                                }
                            }
                            doNothing();
                        }

                        else if (sr.ReadToEnd() == "3")
                        {
                            var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
                            string fileName = "flag.txt";
                            using (var file = appStorage.OpenFile(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
                            {
                                using (var writer = new StreamWriter(file))
                                {
                                    writer.Write("0");
                                }
                            }
                            doNothing();
                        }
                    }
                }
            }

            catch (IsolatedStorageException)
            {
                NavigationService.Navigate(new Uri("/guestLogin.xaml", UriKind.Relative));
            }
          
        }

      
    }
        
 }
    
