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
    public partial class askPage : PhoneApplicationPage
    {
        int cq = 0, c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0;

        public askPage()
        {
            InitializeComponent();
        }

        private void enterQuestion(object sender, RoutedEventArgs e)
        {
            if(cq==0)   
            {
            questionTextBox.Text = "";
            cq++;
            }

        }

        private void enterOption1(object sender, RoutedEventArgs e)
        {
            if (c1 == 0)
            {
                option1TextBox.Text = "";
                c1++;
            }
        }

        private void enterOption2(object sender, RoutedEventArgs e)
        {
            if (c2 == 0)
            {
                option2TextBox.Text = "";
                c2++;
            }
        }

        private void enterOption3(object sender, RoutedEventArgs e)
        {
            if (c3 == 0)
            {
                option3TextBox.Text = "";
                c3++;
            }
        }

        private void enterOption4(object sender, RoutedEventArgs e)
        {
            if (c4 == 0)
            {
                option4TextBox.Text = "";
                c4++;
            }
        }
        private void enterOption5(object sender, RoutedEventArgs e)
        {
            if (c5 == 0)
            {
                option5TextBox.Text = "";
                c5++;
            }
        }
    }
}