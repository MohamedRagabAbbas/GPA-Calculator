using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GPACalculator.Model
{
    class Course:INotifyPropertyChanged
    {
        [PrimaryKey , AutoIncrement]
        public int Id { get; set; }
        private string hours;
        public string Hours
        {
            get => hours;
            set
            {
                if (hours != value)
                {
                    hours = value;
                    OnPropertyChanged("Hours");
                }
            }
        }

        private string grade;
        public string Grade
        {
            get => grade;
            set
            {
                if (grade != value)
                {
                    grade = value;
                    OnPropertyChanged("Grade");

                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
