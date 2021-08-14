using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using QR_CodeScanner.Views;
using QR_CodeScanner.ViewModel;
using System.Windows.Input;

namespace QR_CodeScanner.ViewModel
{
    public class EventViewModel : BaseViewModel
    {
        string title, startDate, endDate, location, description,dateTimeNow;
        TimeSpan timeStart, timeEnd;
        DateTime dateTime;
      
        public ICommand ButtonGenerateClicked { get; set; }
        public INavigation Navigation { get; set; }
        public EventViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            ButtonGenerateClicked = new Command(Placeholder);
            
            StartDate = "Start date";
            EndDate = "End date";
            dateTime = DateTime.Now;
            DateTimeNow = Convert.ToString(dateTime);
            TimePicker timePicker = new TimePicker
            {
                Time = new TimeSpan(dateTime.Hour, dateTime.Minute,dateTime.Second) // Time set to Now
            };

            TimeStart = timePicker.Time;
            TimeEnd = timePicker.Time;
        }
        void Placeholder()
        {

        }

        public string DateTimeNow
        {
            get => dateTimeNow;
            set => SetProperty(ref dateTimeNow, value);
        }
        public TimeSpan TimeStart
        {
            get => timeStart;
            set => SetProperty(ref timeStart, value);
        }
        public TimeSpan TimeEnd
        {
            get => timeEnd;
            set => SetProperty(ref timeEnd, value);
        }
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string StartDate
        {
            get => startDate;
            set => SetProperty(ref startDate, value);
        }
        public string EndDate
        {
            get => endDate;
            set => SetProperty(ref endDate, value);
        }
        public string Location
        {
            get => location;
            set => SetProperty(ref location, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
       
       
    }
}
