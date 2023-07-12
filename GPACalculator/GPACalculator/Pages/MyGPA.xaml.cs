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
    public partial class MyGPA : ContentPage
    {
        double number=0;
        double grade=0;
        public MyGPA()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            var list = await DataBase.list.Table<Course>().ToListAsync();
            listview.ItemsSource = list;
            grade = 0;
            number = 0;
            for(int i=0;i<list.Count;i++)
            {
                number += Convert.ToDouble(list[i].Hours);
                grade += LettrerGradeToNumber(list[i].Grade, Convert.ToDouble(list[i].Hours));
            }
            lable1.Text = number.ToString();
            lable2.Text = (Math.Round(grade / number, 3)).ToString();
            base.OnAppearing();
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
        private async void Delete_Clicked(object sender, EventArgs e)
        {
            DataBase.Delete(((sender as MenuItem).CommandParameter) as Course);
            double g = LettrerGradeToNumber((((sender as MenuItem).CommandParameter) as Course).Grade, Convert.ToDouble((((sender as MenuItem).CommandParameter) as Course).Hours));
            double n = Convert.ToDouble((((sender as MenuItem).CommandParameter) as Course).Hours);
            grade -= g;
            number -= n;
            lable1.Text = number.ToString();
            lable2.Text = (Math.Round(grade / number, 3)).ToString();
            await DisplayAlert("Warn", "You are about to delete an element", " OK ");
            listview.ItemsSource = await DataBase.list.Table<Course>().ToListAsync();
        }
    }
}