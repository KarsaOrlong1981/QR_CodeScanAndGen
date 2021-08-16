using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using QR_CodeScanner.Views;
using QR_CodeScanner.ViewModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace QR_CodeScanner.ViewModel
{
    public class EventViewModel : BaseViewModel
    {
        string title, startDate, endDate, location, description;
        TimeSpan timeStart, timeEnd;
        DateTime dateTime;
      
        public ICommand ButtonGenerateClicked { get; set; }
        public INavigation Navigation { get; set; }
        public EventViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            ButtonGenerateClicked = new Command(async () => await CallQRGeneratorPage());

            
            
            dateTime = DateTime.Now;
            StartDate = Convert.ToString(dateTime.ToString("d"));

            EndDate = Convert.ToString(dateTime.ToString("d"));
            TimePicker timePicker = new TimePicker
            {
                Time = new TimeSpan(dateTime.Hour, dateTime.Minute,dateTime.Second) // Time set to Now
            };

            TimeStart = timePicker.Time;
            TimeEnd = timePicker.Time;
        }

        [Obsolete]
        async Task CallQRGeneratorPage()
        {
            bool isContact = false;
            bool isEvent = true;
            
            await Navigation.PushAsync(new QRGeneratorPage(GetEvent(), isContact,isEvent));

        }
        string GetEvent()
        {
            string vCalendar = "BEGIN:VCALENDAR\nVERSION:2.0\nPRODID:-//hacksw/handcal//NONSGML v1.0//EN\nBEGIN:VEVENT\nDTSTART:" + StartDate + "T" + TimeStart + "Z"
                             + "\nDTEND:" + EndDate + "T" + TimeEnd + "Z" + "\nSUMMARY:" + Title + "\nDESCRIPTION:" + Description + "\nLOCATION:" + Location + "\nEND:VEVENT\nEND:VCALENDAR";
            return vCalendar;

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
