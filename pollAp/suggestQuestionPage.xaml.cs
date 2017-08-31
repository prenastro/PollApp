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
    public partial class suggestQuestionPage : PhoneApplicationPage
    {
        public suggestQuestionPage()
        {
            InitializeComponent();
        }


        private void image1_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/helpPage.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            emailTextBox.Focus();
            sentTextBlock.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            WebClient send = new WebClient();
            send.UploadStringAsync(new Uri("http://buzzinga.xtreemhost.com/mail.php?message" + messageTextBox.Text + "&mail_id=" +emailTextBox.Text), "");
          send.UploadStringCompleted += new UploadStringCompletedEventHandler(send_UploadStringCompleted);
            
        }

        void send_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            string s = e.Result;

            sentTextBlock.Visibility = System.Windows.Visibility.Visible;
            sentTextBlock.Text = s;

            if (s != "Mail Sent.")
            {
                sentTextBlock.Text = "Error! Please enter Again";
                emailTextBox.Text = "";
                messageTextBox.Text = "";
                emailTextBox.Focus();
            }
        }
    }
}