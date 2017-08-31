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

namespace pollAp
{
    public partial class myBuzzPage : PhoneApplicationPage
    {
        string user_name;

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

        public myBuzzPage()
        {
            InitializeComponent();
          
        }

        

        private void Sports_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}", "sports_games", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Entertainment_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}", "entertainment", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));

        }


        private void Health_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}", "health_fittness", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));
        }


        private void Science_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}", "science", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));

        }

        private void Automobiles_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}", "automobiles", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));

        }

        private void Shopping_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}", "shopping", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Books_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}", "books", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Tourism_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}", "tourism", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));

        }

        private void Society_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}", "society", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));

        }

        private void Miscellaneous_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}", "miscellaneous", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Web_Tap(object sender, GestureEventArgs e)
        {

            var queryData = string.Format("?Text={0}&user_name={1}", "web", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Business_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}", "business", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Restaurants_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}", "restaurants", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));
        }

        private void Gadgets_Tap(object sender, GestureEventArgs e)
        {
            var queryData = string.Format("?Text={0}&user_name={1}", "gadgets", user_name);
            NavigationService.Navigate(new Uri("/profileQuestionPage.xaml" + queryData, UriKind.Relative));
        }


    }
}