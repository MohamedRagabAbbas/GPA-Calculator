using GPACalculator.Model;
using GPACalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPACalculator.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSemester : ContentPage
    {
        ObservableCollection<string> Letters = new ObservableCollection<string>();
        ObservableCollection<string> Creditumber = new ObservableCollection<string>();
        ObservableCollection<Course> courses = new ObservableCollection<Course>();
        double number=0;
        double grade=0;
        public AddSemester()
        {
            InitializeComponent();
            Letters.Add("A");
            Letters.Add("A-");
            Letters.Add("B+");
            Letters.Add("B");
            Letters.Add("B-");
            Letters.Add("C+");
            Letters.Add("C");
            Letters.Add("C-");
            Letters.Add("D+");
            Letters.Add("D");
            Letters.Add("F");
            picker1.ItemsSource = Letters;
            picker1.SelectedIndex = 0;

            Creditumber.Add("3");
            Creditumber.Add("2");
            Creditumber.Add("1");
            picker2.ItemsSource = Creditumber;
            picker2.SelectedIndex = 0;
            BindingContext = new Course();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int num = rnd.Next();
            courses.Add(new Course() { Hours = (picker2.SelectedItem).ToString(), Grade = (picker1.SelectedItem).ToString(), Id = num });
            listview.ItemsSource = courses;
            grade += LettrerGradeToNumber((picker1.SelectedItem).ToString(), Convert.ToDouble((picker2.SelectedItem).ToString()));
            number += Convert.ToDouble((picker2.SelectedItem).ToString());
            lable1.Text = number.ToString();
            lable2.Text = (Math.Round(grade / number, 3)).ToString();
        }
        private double LettrerGradeToNumber(string l, double n)
        {
            if (n == 3)
            {
                if (l == "A")
                    return 12;
                else if (l == "A-")
                    return 11.1;
                else if (l == "B+")
                    return 9.9;
                else if (l == "B")
                    return 9;
                else if (l == "B-")
                    return 8.1;
                else if (l == "C+")
                    return 6.9;
                else if (l == "C")
                    return 6;
                else if (l == "C-")
                    return 5.1;
                else if (l == "D+")
                    return 3.9;
                else if (l == "D")
                    return 3;
                else if (l == "F")
                    return 0;
            }
            if (n == 2)
            {
                if (l == "A")
                    return 12 * (2.0 / 3.0);
                else if (l == "A-")
                    return 11.1 * (2.0 / 3.0);
                else if (l == "B+")
                    return 9.9 * (2.0 / 3.0);
                else if (l == "B")
                    return 9 * (2.0 / 3.0);
                else if (l == "B-")
                    return 8.1 * (2.0 / 3.0);
                else if (l == "C+")
                    return 6.9 * (2.0 / 3.0);
                else if (l == "C")
                    return 6 * (2.0 / 3.0);
                else if (l == "C-")
                    return 5.1 * (2.0 / 3.0);
                else if (l == "D+")
                    return 3.9 * (2.0 / 3.0);
                else if (l == "D")
                    return 3 * (2.0 / 3.0);
                else if (l == "F")
                    return 0;
            }
            if (n == 1)
            {
                if (l == "A")
                    return 12 * (1.0 / 3.0);
                else if (l == "A-")
                    return 11.1 * (1.0 / 3.0);
                else if (l == "B+")
                    return 9.9 * (1.0 / 3.0);
                else if (l == "B")
                    return 9 * (1.0 / 3.0);
                else if (l == "B-")
                    return 8.1 * (1.0 / 3.0);
                else if (l == "C+")
                    return 6.9 * (1.0 / 3.0);
                else if (l == "C")
                    return 6 * (1.0 / 3.0);
                else if (l == "C-")
                    return 5.1 * (1.0 / 3.0);
                else if (l == "D+")
                    return 3.9 * (1.0 / 3.0);
                else if (l == "D")
                    return 3 * (1.0 / 3.0);
                else if (l == "F")
                    return 0;
            }

            return -1;
        }
        private void Delete_Clicked(object sender, EventArgs e)
        {
            double g = LettrerGradeToNumber((((sender as MenuItem).CommandParameter) as Course).Grade, Convert.ToDouble((((sender as MenuItem).CommandParameter) as Course).Hours));
            double n = Convert.ToDouble((((sender as MenuItem).CommandParameter) as Course).Hours);
            grade -= g;
            number -= n;
            lable1.Text = number.ToString();
            lable2.Text = (Math.Round(grade / number, 3)).ToString();
            courses.Remove(((sender as MenuItem).CommandParameter) as Course);
        }
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            for(int i=0;i<courses.Count;i++)
            {
                 DataBase.Add(courses[i]);
            }
            (sender as Button).IsEnabled = false;
        }
    }
}