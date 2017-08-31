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
    public partial class creditsPage : PhoneApplicationPage
    {
        public creditsPage()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            creditsTextBlock.Text = " Gagan G Reddy\n"+"Nitish S Prabhu\n"+"Prerana T H M\n"+"Shreyas H R\n\n"+		
"This application is a product of the above interns at Student Nokia Developers";
        }
    }
}