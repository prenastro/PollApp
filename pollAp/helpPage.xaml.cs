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
    public partial class helpPage : PhoneApplicationPage
    {
        public helpPage()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            helpTextBlock.Text = " Q.What is Buzz?\n A.Buzz is a Windows phone application that is basically used to share views about a topic via the method of VOTING.\n\nQ.How to use Buzz?\nA.Buzz is a very simple self explanatory application the user has to follow the following steps to use the application.\n"+
 "1.Create an account and Login.\n2.Once you are logged in,choose the category of your choice and answer the questions.\n3.View my questions to see the questions answered by you.\n\n"+
"Q.What is my Buzz?\nA.My Buzz is where you can find the questions answered by you earlier.\n\nQ.How do i post a Buzz?\nA.Users who are intrested in posting or suggesting a Buzz can do so by clicking the Suggest a Buzz option,the  will be later reviewed by the administrator and if appropriate will be put up.\n\n"+
"NOTE: Here the user has to enter the Buzz in the message box and must also provide their email id.\n\n"+
"Q.Can we feature a Buzz?\nA.Yes,companies who want to know about their product performance or anysuch thing can contact us at studentnokiadeveloper@gmail.com .\n\n";
        }
    }
}