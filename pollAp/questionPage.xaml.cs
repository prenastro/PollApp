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
using System.Windows.Media.Imaging;

namespace pollAp
{
    public partial class questionPage : PhoneApplicationPage
    {

        BitmapImage sportsWall = new BitmapImage(new Uri("/Images/sportsWall.png", UriKind.Relative));
        BitmapImage entertainmentWall = new BitmapImage(new Uri("/Images/entertainmentWall.jpg", UriKind.Relative));
        BitmapImage restaurantsWall = new BitmapImage(new Uri("/Images/restaurantsWall.jpg", UriKind.Relative));
        BitmapImage gadgetsWall = new BitmapImage(new Uri("/Images/gadgetsWall.jpg", UriKind.Relative));
        BitmapImage healthWall = new BitmapImage(new Uri("/Images/healthWall.jpg", UriKind.Relative));
        BitmapImage scienceWall = new BitmapImage(new Uri("/Images/scienceWall.jpg", UriKind.Relative));
        BitmapImage automobilesWall = new BitmapImage(new Uri("/Images/automobilesWall.jpg", UriKind.Relative));
        BitmapImage shoppingWall = new BitmapImage(new Uri("/Images/shoppingWall.jpg", UriKind.Relative));
        BitmapImage booksWall = new BitmapImage(new Uri("/Images/booksWall.jpg", UriKind.Relative));
        BitmapImage tourismWall = new BitmapImage(new Uri("/Images/tourismWall.jpg", UriKind.Relative));
        BitmapImage societyWall = new BitmapImage(new Uri("/Images/societyWall.jpg", UriKind.Relative));
        BitmapImage businessWall = new BitmapImage(new Uri("/Images/businessWall.jpg", UriKind.Relative));
        BitmapImage webWall = new BitmapImage(new Uri("/Images/webWall.jpg", UriKind.Relative));
        BitmapImage miscellaneousWall = new BitmapImage(new Uri("/Images/miscellaneousWall.jpg", UriKind.Relative));

        string category;
        string user_name;
        string aid = "0";   // Default

        string questionString = "";
        string op1String = "";
        string op2String = "";
        string op3String = "";
        string op4String = "";
        string op5String = "";

        int[] qid = new int[500];
     //   int[] incQid = new int[500];

        int counter = 0;
        int presentCount;
        string order;


        public questionPage()
        {
            InitializeComponent();
        }

        public class Const
        {
            public static string TextTag = "Text";
            public static string TextTag2 = "user_name";
            public static string TextTag3 = "order";
        }

        //Passing the parameter category from the menu page to the questions page
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var data = this.NavigationContext.QueryString;

            if (data.ContainsKey(Const.TextTag))
            //  PageTitle.Text = data[Const.TextTag];
            // category = PageTitle.Text;
            {
                category = data[Const.TextTag];

                if (category == "sports_games")
                {
                    PageTitle.Text = "Sports";
                }
                else if (category == "entertainment")
                {
                    PageTitle.Text = "Entertainment";
                }
                else if (category == "restaurants")
                {
                    PageTitle.Text = "Restaurants";
                }
                else if (category == "gadgets")
                {
                    PageTitle.Text = "Gadgets";
                }
                else if (category == "health_fittness")
                {
                    PageTitle.Text = "Health";
                }
                else if (category == "science")
                {
                    PageTitle.Text = "Science";
                }
                else if (category == "automobiles")
                {
                    PageTitle.Text = "Automobiles";
                }
                else if (category == "shopping")
                {
                    PageTitle.Text = "Shopping";
                }
                else if (category == "books")
                {
                    PageTitle.Text = "Books";
                }
                else if (category == "tourism")
                {
                    PageTitle.Text = "Tourism";
                }
                else if (category == "society")
                {
                    PageTitle.Text = "Society";
                }
                else if (category == "business")
                {
                    PageTitle.Text = "Business";
                }
                else if (category == "web")
                {
                    PageTitle.Text = "Web";
                }
                else if (category == "miscellaneous")
                {
                    PageTitle.Text = "Miscellaneous";
                }

            }
                user_name = data[Const.TextTag2];
                order = data[Const.TextTag3];

            base.OnNavigatedTo(e);
        }

        // Menu bar options and buttons
      
         private void appBarHelp(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/helpPage.xaml", UriKind.Relative));
        }

        private void appBarCredits(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/creditsPage.xaml", UriKind.Relative));
        }

         

      

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            clearAll();
            getQids();

            if (category == "sports_games")
            {
                CategoryImage.Source = sportsWall;
            }
            else if (category == "entertainment")
            {
                CategoryImage.Source = entertainmentWall;
            }
            else if (category == "restaurants")
            {
                CategoryImage.Source = restaurantsWall;
            }
            else if (category == "gadgets")
            {
                CategoryImage.Source = gadgetsWall;
            }
            else if (category == "health_fittness")
            {
                CategoryImage.Source = healthWall;
            }
            else if (category == "science")
            {
                CategoryImage.Source = scienceWall;
            }
            else if (category == "automobiles")
            {
                CategoryImage.Source = automobilesWall;
            }
            else if (category == "shopping")
            {
                CategoryImage.Source = shoppingWall;
            }
            else if (category == "books")
            {
                CategoryImage.Source = booksWall;
            }
            else if (category == "tourism")
            {
                CategoryImage.Source = tourismWall;
            }
            else if (category == "society")
            {
                CategoryImage.Source = societyWall;
            }
            else if (category == "business")
            {
                CategoryImage.Source = businessWall;
            }
            else if (category == "web")
            {
                CategoryImage.Source = webWall;
            }
            else if (category == "miscellaneous")
            {
                CategoryImage.Source = miscellaneousWall;
            }
        }


        public void displayAll()
        {
            if (order == "most")
            {
                try
                {
                    display(qid[counter - 1].ToString());
                    presentCount = counter - 1;
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Server Error!");
                    NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
                }
                
            }
            else
            {
                display(qid[0].ToString());
                presentCount = 0;
                
            }
        }


        public void clearAll()
        {
            questionString = "";
            op1String = "";
            op2String = "";
            op3String = "";
            op4String = "";
            op5String = "";

            mainTextBlock.Text = "";
            ans1TextBlock.Text = "";
            ans2TextBlock.Text = "";
            ans3TextBlock.Text = "";
            ans4TextBlock.Text = "";
            ans5TextBlock.Text = "";

            ans1RadioButton.Visibility = System.Windows.Visibility.Collapsed;
            ans2RadioButton.Visibility = System.Windows.Visibility.Collapsed;
            ans3RadioButton.Visibility = System.Windows.Visibility.Collapsed;
            ans4RadioButton.Visibility = System.Windows.Visibility.Collapsed;
            ans5RadioButton.Visibility = System.Windows.Visibility.Collapsed;

            ans1RadioButton.IsEnabled = true;
            ans2RadioButton.IsEnabled = true;
            ans3RadioButton.IsEnabled = true;
            ans4RadioButton.IsEnabled = true;
            ans5RadioButton.IsEnabled = true;

            ans1RadioButton.IsChecked = false;
            ans2RadioButton.IsChecked = false;
            ans3RadioButton.IsChecked = false;
            ans4RadioButton.IsChecked = false;
            ans5RadioButton.IsChecked = false;
        }
       
        // Get the question id's that havent been answered in a single string
        // Eg. 11 21 32 40

        public void getQids()
        {
            WebClient get = new WebClient();
            get.UploadStringAsync(new Uri("http://buzzinga.xtreemhost.com/qandan_new.php?user_name=" + user_name + "&cata=" + category), "");
            get.UploadStringCompleted += new UploadStringCompletedEventHandler(get_UploadStringCompleted);
        }


        void get_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            try
            {
                string s = e.Result;
                storeArray(s);
            }
            catch (WebException)
            {
                MessageBox.Show("Server Error!");
                NavigationService.Navigate(new Uri("/Menu.xaml",UriKind.Relative));
            }
        }

        public void storeArray(string allQids)
        {

            string selectedQid = "0";
            counter = 0;

            for (int i = 0; allQids[i] != '\0'; i++)
            {
                if (allQids[i] != '\n')
                {
                    selectedQid += allQids[i];
                }
                else
                {
                    try
                    {
                        qid[counter] = int.Parse(selectedQid);
                        selectedQid = "0";
                        counter++;
                    }

                    catch (FormatException)
                    {
                        MessageBox.Show("Server Error!");
                        NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
                    }
                
                }
            }
            displayAll();
        }
  


        // Display the required question and answer.
        public void display(string questionId)
        {
          
            WebClient displayAll = new WebClient();
            displayAll.UploadStringAsync(new Uri("http://buzzinga.xtreemhost.com/displayans_prof.php?cata=" + category + "&qid=" + questionId), "");
            displayAll.UploadStringCompleted += new UploadStringCompletedEventHandler(display_UploadStringCompleted);
        }

        void display_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            lock (this)
            {
                try{
                string s = e.Result;
                // **** split into different sub strings
                int i = 0;


                for (i = 0; s[i] != '\n'; i++)
                {
                    questionString += s[i];
                }

                i++;

                if (s[i] == '\0')
                {
                    goto end;
                }


                for (; s[i] != '\n'; i++)
                {
                    op1String += s[i];
                }
                i++;
                ans1RadioButton.Visibility = System.Windows.Visibility.Visible;

                if (s[i] == '\0')
                {
                    goto end;
                }

                for (; s[i] != '\n'; i++)
                {
                    op2String += s[i];
                }

                i++;
                ans2RadioButton.Visibility = System.Windows.Visibility.Visible;

                if (s[i] == '\0')
                {
                    goto end;
                }


                for (; s[i] != '\n'; i++)
                {
                    op3String += s[i];
                }


                i++;
                ans3RadioButton.Visibility = System.Windows.Visibility.Visible;

                if (s[i] == '\0')
                {
                    goto end;
                }


                for (; s[i] != '\n'; i++)
                {
                    op4String += s[i];
                }

                i++;
                ans4RadioButton.Visibility = System.Windows.Visibility.Visible;

                if (s[i] == '\0')
                {
                    goto end;
                }


                for (; s[i] != '\n'; i++)
                {
                    op5String += s[i];
                }

                ans5RadioButton.Visibility = System.Windows.Visibility.Visible;

            end:

                mainTextBlock.Text = questionString;
                ans1TextBlock.Text = op1String;
                ans2TextBlock.Text = op2String;
                ans3TextBlock.Text = op3String;
                ans4TextBlock.Text = op4String;
                ans5TextBlock.Text = op5String;

                }
                catch(WebException)
                {
                    MessageBox.Show("Server Error!");
                    NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
                
                }
            }
        }


       // Answering and updating the count
        public void updateAns(string aid)
        {
            WebClient update = new WebClient();
            update.UploadStringAsync(new Uri("http://buzzinga.xtreemhost.com/updating.php?cata=" + category + "&qno=" + qid[presentCount].ToString() + "&aid=" + aid + "&latitude=" + 10 + "&longitude=" + 5 + "&user_name=" + user_name), "");
            update.UploadStringCompleted += new UploadStringCompletedEventHandler(update_UploadStringCompleted);  
        }

        public void update_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            // **** Go to next question after showing the result *****
            // ***** Show result not done ********//
            if (order == "most")
            {
                if (presentCount >= 0)
                {
                    presentCount--;
                    clearAll();
                    display(qid[presentCount].ToString());
                }
            }
            else if (order == "latest")
            {
                if (presentCount < counter)
                {
                    presentCount++;
                    clearAll();
                    display(qid[presentCount].ToString());
                }
                
            
            }
        }


        private void ans1RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ans2RadioButton.IsEnabled = false;
            ans3RadioButton.IsEnabled = false;
            ans4RadioButton.IsEnabled = false;
            ans5RadioButton.IsEnabled = false;
            updateAns("1");
        }



        private void ans2RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ans1RadioButton.IsEnabled = false;
            ans3RadioButton.IsEnabled = false;
            ans4RadioButton.IsEnabled = false;
            ans5RadioButton.IsEnabled = false;
            aid = "2";
            updateAns("2");
        }


        private void ans3RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ans1RadioButton.IsEnabled = false;
            ans2RadioButton.IsEnabled = false;
            ans4RadioButton.IsEnabled = false;
            ans5RadioButton.IsEnabled = false;
            aid = "3";
            updateAns("3");
        }

        private void ans4RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ans1RadioButton.IsEnabled = false;
            ans2RadioButton.IsEnabled = false;
            ans3RadioButton.IsEnabled = false;
            ans5RadioButton.IsEnabled = false;
            aid = "4";
            updateAns("4");
        }

        private void ans5RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ans1RadioButton.IsEnabled = false;
            ans2RadioButton.IsEnabled = false;
            ans4RadioButton.IsEnabled = false;
            ans3RadioButton.IsEnabled = false;
            aid = "5";
            updateAns("5");
        }

        private void ans1TextBlock_Tap(object sender, GestureEventArgs e)
        {
            ans1RadioButton.IsChecked = true;
            ans2RadioButton.IsEnabled = false;
            ans3RadioButton.IsEnabled = false;
            ans4RadioButton.IsEnabled = false;
            ans5RadioButton.IsEnabled = false;
            updateAns("1");
        }

        private void ans2TextBlock_Tap(object sender, GestureEventArgs e)
        {
            ans2RadioButton.IsChecked = true;
            ans1RadioButton.IsEnabled = false;
            ans3RadioButton.IsEnabled = false;
            ans4RadioButton.IsEnabled = false;
            ans5RadioButton.IsEnabled = false;
            aid = "2";
            updateAns("2");
        }

        private void ans3TextBlock_Tap(object sender, GestureEventArgs e)
        {
            ans3RadioButton.IsChecked = true;
            ans1RadioButton.IsEnabled = false;
            ans2RadioButton.IsEnabled = false;
            ans4RadioButton.IsEnabled = false;
            ans5RadioButton.IsEnabled = false;
            aid = "3";
            updateAns("3");
        }

        private void ans4TextBlock_Tap(object sender, GestureEventArgs e)
        {
            ans4RadioButton.IsChecked = true;
            ans1RadioButton.IsEnabled = false;
            ans2RadioButton.IsEnabled = false;
            ans3RadioButton.IsEnabled = false;
            ans5RadioButton.IsEnabled = false;
            aid = "4";
            updateAns("4");
        }

        private void ans5TextBlock_Tap(object sender, GestureEventArgs e)
        {
            ans5RadioButton.IsChecked = true;
            ans1RadioButton.IsEnabled = false;
            ans2RadioButton.IsEnabled = false;
            ans4RadioButton.IsEnabled = false;
            ans3RadioButton.IsEnabled = false;
            aid = "5";
            updateAns("5");
        }

       

    }
}