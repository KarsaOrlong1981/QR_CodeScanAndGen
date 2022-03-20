using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using QR_CodeScanner.Views;
using System.Windows.Input;
using System.Threading.Tasks;
using QR_CodeScanner.Model;

namespace QR_CodeScanner.ViewModel
{
    public class EventViewModel : BaseViewModel
    {
        string title, location, description;
        TimeSpan timeStart, timeEnd;
        DateTime dateTime, startDate, endDate;
        Color background, button, txt, frame, border;
        public ICommand ButtonGenerateClicked { get; set; }
        public INavigation Navigation { get; set; }
        public Color Background
        {
            get => background;
            set => SetProperty(ref background, value);
        }
        public Color Button
        {
            get => button;
            set => SetProperty(ref button, value);
        }
        public Color Txt
        {
            get => txt;
            set => SetProperty(ref txt, value);
        }
        public Color Frame
        {
            get => frame;
            set => SetProperty(ref frame, value);
        }
        public Color Border
        {
            get => border;
            set => SetProperty(ref border, value);
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
        public DateTime StartDate
        {
            get => startDate;
            set => SetProperty(ref startDate, value);
        }
        public DateTime EndDate
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
        [Obsolete]
        public EventViewModel(INavigation navigation, Color background, Color button, Color txt, Color frame, Color border)
        {
            this.Navigation = navigation;
            Background = background;
            Button = button;
            Txt = txt;
            Frame = frame;
            Border = border;
            ButtonGenerateClicked = new Command(async () => await CallQRGeneratorPage());
            dateTime = DateTime.Now;

            StartDate = dateTime.Date;
            EndDate = dateTime.Date;
            TimePicker timePicker = new TimePicker
            {
                Time = new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second) // Time set to Now
            };

            TimeStart = timePicker.Time;
            TimeEnd = timePicker.Time;
        }

        [Obsolete]
        async Task CallQRGeneratorPage()
        {

            await Navigation.PushAsync(new QRGeneratorPage(GetEvent(), false, false, false, true, false, false, false, false, false, string.Empty, false, background, frame));

        }
        string GetEvent()
        {
            string startDateG = "";
            string endDateG = "";
            string formatD = "";
            string[] splitDate = Convert.ToString(StartDate).Split('.', ':', ',', '/', ' ');
            string[] splitEndDate = Convert.ToString(EndDate).Split('.', ':', ',', '/', ' ');
            string[] splitTimeStartDate = Convert.ToString(TimeStart).Split('.', ':', ',', '/', ' ');
            string[] splitTimeEndDate = Convert.ToString(TimeEnd).Split('.', ':', ',', '/', ' ');
            if (CultureLanguage.GetCulture() == "de")
            {
                startDateG = splitDate[2] + splitDate[1] + splitDate[0];
                endDateG = splitEndDate[2] + splitEndDate[1] + splitEndDate[0];
            }
            else
            {
                if (splitDate[0].Length < 2)

                    formatD = "0" + splitDate[0];
                else
                    formatD = splitDate[0];

                startDateG = splitDate[2] + formatD + splitDate[1]; //Bei de 0 und 1 tauschen (2,1,0) usEn (2,0,1)
                if (splitEndDate[0].Length < 2)
                    formatD = "0" + splitEndDate[0];
                else
                    formatD = splitEndDate[0];
                endDateG = splitEndDate[2] + formatD + splitEndDate[1];
            }


            string timeStartG = splitTimeStartDate[0] + splitTimeStartDate[1] + splitTimeStartDate[2];
            string timeEndG = splitTimeEndDate[0] + splitTimeEndDate[1] + splitTimeEndDate[2];

            string vCalendar = "BEGIN:VCALENDAR\nVERSION:2.0\nPRODID:-//J.T/Th//EN\nBEGIN:VEVENT\nDTSTART:" + startDateG + "T" + timeStartG + "Z"
                             + "\nDTEND:" + endDateG + "T" + timeEndG + "Z" + "\nSUMMARY:" + Title + "\nDESCRIPTION:" + Description + "\nLOCATION:" + Location + "\nEND:VEVENT\nEND:VCALENDAR";


            return vCalendar;

        }


        
    }
}
