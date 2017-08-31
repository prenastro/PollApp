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
using Microsoft.Phone.Tasks;

namespace pollAp
{
    public partial class Menu : PhoneApplicationPage
    {
      
        string user_name;
    
        public Menu()
        {
            InitializeComponent();
         
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.RemoveBackEntry();

            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (StreamReader sr = new StreamReader(store.OpenFile("flag.txt", FileMode.Open, FileAccess.ReadWrite)))
                {
                     MessageBoxResult res;

                    if (sr.ReadToEnd() == "1")
                    {
                        res = MessageBox.Show("Are you sure you want to exit without Logout?", "Exit?", MessageBoxButton.OKCancel);
                    }
                    else
                    {

                        res = MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButton.OKCancel);
                       
                    }
                    e.Cancel = true;
                    if (res == MessageBoxResult.OK)
                    {
                        e.Cancel = false;
                        base.OnBackKeyPress(e);
                    }
                }
            }
        }
                
        public class Const
        {
            public static string TextTag = "Text";
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var data = this.NavigationContext.QueryString;

            if (data.ContainsKey(Const.TextTag))
                   user_name = data[Const.TextTag];

                base.OnNavigatedTo(e);
        }

       

        private void Sports_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "sports_games", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Entertainment_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "entertainment", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }


        private void Health_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "health_fittness", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }


        private void Science_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "science", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void Automobiles_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "automobiles", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void Shopping_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "shopping", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Books_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "books", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Tourism_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "tourism", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void Society_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "society", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void Miscellaneous_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "miscellaneous", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Web_Tap(object sender, GestureEventArgs e)
        {

            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "web", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Business_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "business", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Restaurants_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "restaurants", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Gadgets_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "gadgets", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }







        private void mostPopularSports_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "sports_games", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }


        private void latestSports_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "sports_games", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void mostPopularEntertainment_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "entertainment", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void latestEntertainment_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "entertainment", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void mostPopularRestaurants_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "restaurants", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void latestRestaurants_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "restaurants", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void mostPopularGadgets_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "gadgets", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void latestGadgets_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "gadgets", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void mostPopularHealth_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "health_fittness", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void latestHealth_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "health_fittness", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void mostPopularScience_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "science", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void latestScience_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "science", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void mostPopularAutomobiles_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "automobiles", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void latestAutomobiles_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "automobiles", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void mostPopularShopping_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "shopping", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void latestShopping_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "shopping", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void mostPopularBooks_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "books", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void latestBooks_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "books", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void mostPopularTourism_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "tourism", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void latestTourism_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "tourism", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void mostPopularSociety_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "society", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void latestSociety_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "society", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void mostPopularBusiness_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "business", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void latestBusiness_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "business", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void mostPopularWeb_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "web", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void latestWeb_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "web", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));

        }

        private void mostPopularMiscellaneous_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "miscellaneous", user_name, "most");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        private void latestMiscellaneous_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}&order={2}", "miscellaneous", user_name, "latest");
            NavigationService.Navigate(new Uri("/questionPage.xaml" + queryData, UriKind.Relative));
        }

        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/helpPage.xaml", UriKind.Relative));
        }


   private void image1_Tap(object sender, GestureEventArgs e)
   {
       var queryData = string.Format("?Text={0}", user_name);
       NavigationService.Navigate(new Uri("/myBuzzPage.xaml" + queryData, UriKind.Relative));
   }

   private void answeredTextBlock_Tap(object sender, GestureEventArgs e)
   {
       var queryData = string.Format("?Text={0}", user_name);
       NavigationService.Navigate(new Uri("/myBuzzPage.xaml" + queryData, UriKind.Relative));
   }

   private void suggestTextBlock_Tap(object sender, GestureEventArgs e)
   {
       NavigationService.Navigate(new Uri("/suggestQuestionPage.xaml", UriKind.Relative));
   }

   

   private void image2_Tap(object sender, GestureEventArgs e)
   {
       NavigationService.Navigate(new Uri("/suggestQuestionPage.xaml", UriKind.Relative));
   }

   private void logoutTextBlock_Tap_1(object sender, GestureEventArgs e)
   {
       var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
       string fileName = "flag.txt";
       using (var file = appStorage.OpenFile(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
       {
           using (var writer = new StreamWriter(file))
           {
               writer.Write("2");
           }
       }

       NavigationService.GoBack();

   }

   private void image3_Tap(object sender, GestureEventArgs e)
   {
       var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
       string fileName = "flag.txt";
       using (var file = appStorage.OpenFile(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
       {
           using (var writer = new StreamWriter(file))
           {
               writer.Write("2");
           }
       }

       NavigationService.GoBack();

   }

   private void button2_Click(object sender, RoutedEventArgs e)
   {
       WebBrowserTask wb = new WebBrowserTask();
       wb.URL = "http://studentnokiadeveloper.com/";
       wb.Show();
   }

   private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
   {
       textBlock1.Text = user_name;
   }

 


   }

       



    }
