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
    public partial class profileQuestionPage : PhoneApplicationPage
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
        int counter = 0;
        int presentCount;

        public profileQuestionPage()
        {
            InitializeComponent();
        }


          public class Const
        {
            public static string TextTag = "Text";
            public static string TextTag2 = "user_name";
        }

        //Passing the parameter category from the menu page to the questions page
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var data = this.NavigationContext.QueryString;

            if (data.ContainsKey(Const.TextTag))
            {
                //PageTitle.Text = data[Const.TextTag];
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
            if (data.ContainsKey(Const.TextTag2))
            {
                user_name = data[Const.TextTag2];
            }
            base.OnNavigatedTo(e);
        }


        

        private void appBarHelp(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/helpPage.xaml", UriKind.Relative));
        }

        private void appBarCredits(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/creditsPage.xaml", UriKind.Relative));
        }

        private void appBarNext(object sender, EventArgs e)
        {
            if (presentCount < (counter-1))
            {
                presentCount++;
                clearAll();
                display(qid[presentCount].ToString());
            }
            else
            {
                clearAll();
                mainTextBlock.Text = "Cant Go any Further This way!";
                presentCount = counter;
            }
          
        }

        private void appBarBack(object sender, EventArgs e)
        {
            if (presentCount > 0 )
            {
                presentCount--;
                clearAll();
                display(qid[presentCount].ToString());
            }
            else
            {
                clearAll();
                mainTextBlock.Text = "Cant Go any Further This way!";
                presentCount = -1;
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

        }


        public void getQids()
        {
            WebClient getIt = new WebClient();
            getIt.UploadStringAsync(new Uri("http://buzzinga.xtreemhost.com/profile_new.php?user_name=" + user_name + "&cata=" + category ), "");
            getIt.UploadStringCompleted += new UploadStringCompletedEventHandler(getIt_UploadStringCompleted);
            
        }

        void getIt_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            try
            {
                string s = e.Result;
                storeArray(s);
            }
            catch (WebException)
            {
                MessageBox.Show("Server Error!");
                NavigationService.Navigate(new Uri("/myBuzzPage.xaml", UriKind.Relative));
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
                    NavigationService.Navigate(new Uri("/myBuzz.xaml", UriKind.Relative));
                    }
                }
            }
           
            if (counter != 0)
            {
                displayAll();
            }
            else
            {
                mainTextBlock.Text = "Sorry, You haven't answered any question in this category.";
            }
        }

        public void displayAll()
        {
            display(qid[0].ToString());
            presentCount = 0;
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
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

        public void display(string questionId)
        {
            
            WebClient displayAll = new WebClient();
            displayAll.UploadStringAsync(new Uri("http://buzzinga.xtreemhost.com/displayans.php?cata=" + category + "&qid=" + questionId), "");
            displayAll.UploadStringCompleted += new UploadStringCompletedEventHandler(display_UploadStringCompleted);
        }

        void display_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            lock (this)
            {
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


                if (s[i] == '\0')
                {
                    goto end;
                }

                for (; s[i] != '\n'; i++)
                {
                    op2String += s[i];
                }

                i++;


                if (s[i] == '\0')
                {
                    goto end;
                }


                for (; s[i] != '\n'; i++)
                {
                    op3String += s[i];
                }


                i++;


                if (s[i] == '\0')
                {
                    goto end;
                }


                for (; s[i] != '\n'; i++)
                {
                    op4String += s[i];
                }

                i++;


                if (s[i] == '\0')
                {
                    goto end;
                }


                for (; s[i] != '\n'; i++)
                {
                    op5String += s[i];
                }



            end:

                mainTextBlock.Text = questionString;
                ans1TextBlock.Text = op1String;
                ans2TextBlock.Text = op2String;
                ans3TextBlock.Text = op3String;
                ans4TextBlock.Text = op4String;
                ans5TextBlock.Text = op5String;

            }
        }

       
    }
}