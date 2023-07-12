using GPACalculator.Model;
using GPACalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPACalculator.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        protected async override void OnAppearing()
        {
            await DataBase.list.CreateTableAsync<Course>();
            base.OnAppearing();
        }
    }
}