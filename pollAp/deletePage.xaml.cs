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
    public partial class deletePage : PhoneApplicationPage
    {
        public deletePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            WebClient del = new WebClient();
            del.UploadStringAsync(new Uri("http://buzzinga.xtreemhost.com/delete_acc.php?user_name=" + userNameTextBox.Text), "");
            del.UploadStringCompleted += new UploadStringCompletedEventHandler(del_UploadStringCompleted);
            
        }

        void del_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            string s = e.Result;
            if (s == "account deleted")
            { 
            // Delete account and exit not done!!
            }

        }
    }
}