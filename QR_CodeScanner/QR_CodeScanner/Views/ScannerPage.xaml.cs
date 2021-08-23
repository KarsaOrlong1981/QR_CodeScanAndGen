using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using Xamarin.Essentials;
using Android.Content;
using Android.Provider;
using Android.App;
using Android.Widget;
using Result = ZXing.Result;
using QR_CodeScanner.ViewModel;
using QR_CodeScanner.Model;
using Java.Util;
using Android.OS;
using static Xamarin.Essentials.Permissions;


namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   
    public partial class ScannerPage : ContentPage
    {
        string titleEvent, dtStartEvent, dtEndEvent, locationEvent, descriptionEvent;
        string vCardName, vCardEmail, vCardAdress, vCardURL, vCardTitle, vCardORG,vCardTel;
        public ScannerPage()
        {
            InitializeComponent();
           
            
        }
        //If the Scanner recognizes an QR-Code
        [Obsolete]
        public void scanView_OnScanResult(Result result)
        {
           

            Device.BeginInvokeOnMainThread(async () =>
            {
              
               
                string resultString = Convert.ToString(result);

                if (resultString.Length >= 11)
                {
                    //To recognize an VCard and read the Vcard
                    if (resultString.Substring(0, 11) == "BEGIN:VCARD")
                    {
                        string[] splitVcardADR;
                        string[] splitVcardEMAIL;
                        string[] splitVcardURL;
                        string[] splitVcardTEL;
                        string[] splitVcardTitle;
                        string[] splitVcardORG;
                        string[] splitVcardName;
                        string[] splitVcard = result.Text.Split('\n');

                        for (int i = 0; i < splitVcard.Length; i++)
                        {
                            if (splitVcard[i] == "")
                            {
                                continue;
                            }
                            else
                            {
                                try
                                {


                                    if (splitVcard[i].Substring(0, 1) == "N")
                                    {
                                        splitVcardName = splitVcard[i].Split(':');
                                        vCardName = splitVcardName[1];
                                    }
                                    if (splitVcard[i].Substring(0, 3) == "ORG")
                                    {
                                        splitVcardORG = splitVcard[i].Split(':');
                                        vCardORG = splitVcardORG[1];
                                    }

                                    if (splitVcard[i].Substring(0, 4) == "TITL")
                                    {
                                        splitVcardTitle = splitVcard[i].Split(':');
                                        vCardTitle = splitVcardTitle[1];
                                    }
                                    if (splitVcard[i].Substring(0, 3) == "TEL")
                                    {
                                        splitVcardTEL = splitVcard[i].Split(':');
                                        vCardTel = splitVcardTEL[1];
                                    }
                                    if (splitVcard[i].Substring(0, 3) == "URL")
                                    {
                                        splitVcardURL = splitVcard[i].Split(':');
                                        if (splitVcardURL[1] == "https" || splitVcardURL[1] == "http")
                                            vCardURL = splitVcardURL[1] + ":" + splitVcardURL[2];
                                        else
                                            vCardURL = splitVcardURL[1];
                                    }
                                    if (splitVcard[i].Substring(0, 4) == "EMAI")
                                    {
                                        splitVcardEMAIL = splitVcard[i].Split(':');
                                        vCardEmail = splitVcardEMAIL[1];
                                    }
                                    if (splitVcard[i].Substring(0, 3) == "ADR")
                                    {
                                        splitVcardADR = splitVcard[i].Split(':');
                                        vCardAdress = splitVcardADR[1];
                                    }

                                }
                                catch
                                {
                                    var activity = Forms.Context as Activity;
                                    Toast.MakeText(activity, "QR-Code not readable !", ToastLength.Long).Show();
                                }

                            }

                        }
                        await CheckAndRequestContactsPermission();
                        //Permisssions must be granted for Contacts
                        await GetContactAsync();
                        


                       



                    }
                }
                else
                {
                    lab_Label.Text = resultString;
                }
                 
                
                    if(resultString.Length >= 15)
                    {
                        //To recognizes an VCalendar and read Vcalendar
                        if (resultString.Substring(0, 15) == "BEGIN:VCALENDAR")
                        {

                            string[] splitDTStart;
                            string[] splitDTEnd;
                            string[] splitSummary;
                            string[] splitDescription;
                            string[] splitLocation;

                            string[] splitVcal = result.Text.Split('\n');

                            for (int i = 0; i < splitVcal.Length; i++)
                            {
                                if (splitVcal[i] == "")
                                {
                                    continue;
                                }
                                else
                                {
                                    try
                                    {


                                        if (splitVcal[i].Substring(0, 4) == "DTST")
                                        {
                                            splitDTStart = splitVcal[i].Split(':');
                                            dtStartEvent = splitDTStart[1];
                                        }
                                        if (splitVcal[i].Substring(0, 4) == "DTEN")
                                        {
                                            splitDTEnd = splitVcal[i].Split(':');
                                            dtEndEvent = splitDTEnd[1];
                                        }

                                        if (splitVcal[i].Substring(0, 4) == "SUMM")
                                        {
                                            splitSummary = splitVcal[i].Split(':');
                                            titleEvent = splitSummary[1];
                                        }
                                        if (splitVcal[i].Substring(0, 4) == "DESC")
                                        {
                                            splitDescription = splitVcal[i].Split(':');
                                            descriptionEvent = splitDescription[1];
                                        }
                                        if (splitVcal[i].Substring(0, 4) == "LOCA")
                                        {
                                            splitLocation = splitVcal[i].Split(':');
                                            locationEvent = splitLocation[1];
                                        }
                                    }
                                    catch
                                    {
                                        var activity = Forms.Context as Activity;
                                        Toast.MakeText(activity, "QR-Code not readable !", ToastLength.Long).Show();
                                    }

                                }

                            }

                        await CheckAndRequestCALENDARPermission();
                        //Permisssions must be granted for Calendar
                        await GetCalendarAsync();

                        }

                    }
                else
                {
                    lab_Label.Text = resultString;
                }
                    
                        
                    

                
                try
                {
                    await OpenBrowser(result.Text);
                }
                catch
                {

                }
                
               
          
            });
        }

       
        //If Scanner recognizes an Website open Browser
        public async Task OpenBrowser(string uri)
        {
            try
            {
                await Xamarin.Essentials.Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch(Exception)
            {
               
            }

                
        }
       
        
        [Obsolete]
        public void SaveContacts(string name, string number, string email,string company,string jobtitle,string postal,string website)
        {
           
            try
            {
                var activity = Forms.Context as Activity;
                var intent = new Intent(Intent.ActionInsert);
                intent.SetType(ContactsContract.Contacts.ContentType);
                intent.PutExtra(ContactsContract.Intents.Insert.Name, name);
                intent.PutExtra(ContactsContract.Intents.Insert.Phone, number);
                intent.PutExtra(ContactsContract.Intents.Insert.Email, email);
                intent.PutExtra(ContactsContract.Intents.Insert.Company, company);
                intent.PutExtra(ContactsContract.Intents.Insert.JobTitle, jobtitle);
                intent.PutExtra(ContactsContract.Intents.Insert.Postal, postal);
                intent.PutExtra(ContactsContract.Intents.Insert.Notes, website);



                activity.StartActivity(intent);
                Toast.MakeText(activity, "ContactSaved", ToastLength.Short).Show();
            }
            catch
            {
                var activity = Forms.Context as Activity;
                Toast.MakeText(activity, "Can not Save", ToastLength.Long).Show();
            }
            
        }
       
            [Obsolete]
        void SaveEvents(string title,string description,string dtStart,string dtEnd,string location)
        {
           
            try
            {
                string[] splitDTStart = dtStart.Split('T', 'Z');
                string startDateDay = splitDTStart[0].Substring(0, 2);
                string startDateMonth = splitDTStart[0].Substring(2, 2);
                string startDateYear = splitDTStart[0].Substring(4, 4);
                string timeStartHour = splitDTStart[1].Substring(0, 2);
                string timeStartMin = splitDTStart[1].Substring(2, 2);
                string[] splitDTEnd = dtEnd.Split('T', 'Z');
                string endDateDay = splitDTEnd[0].Substring(0, 2);
                string endDateMonth = splitDTEnd[0].Substring(2, 2);
                string endDateYear = splitDTEnd[0].Substring(4, 4);
                string timeEndHour = splitDTEnd[1].Substring(0, 2);
                string timeEndMin = splitDTEnd[1].Substring(2, 2);

                var activity = Forms.Context as Activity;
                Intent calIntent = new Intent(Intent.ActionInsert);
                calIntent.SetData(CalendarContract.Events.ContentUri);
                calIntent.SetType("vnd.android.cursor.item/event");
                calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Title, title);
                calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Description, description);
                calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.EventLocation, location);


                long lDtStart = GetDateTimeMS(Convert.ToInt32(startDateYear), Convert.ToInt32(startDateMonth), Convert.ToInt32(startDateDay), Convert.ToInt32(timeStartHour), Convert.ToInt32(timeStartMin));
                long lDtEnd = GetDateTimeMS(Convert.ToInt32(endDateYear), Convert.ToInt32(endDateMonth), Convert.ToInt32(endDateDay), Convert.ToInt32(timeEndHour), Convert.ToInt32(timeEndMin));
                calIntent.PutExtra(CalendarContract.ExtraEventBeginTime, lDtStart);
                calIntent.PutExtra(CalendarContract.ExtraEventEndTime, lDtEnd);

                calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC");
                calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC");

                activity.StartActivity(calIntent);
            }
            catch
            {
                var activity = Forms.Context as Activity;
                Toast.MakeText(activity, "Can not Save", ToastLength.Long).Show();
            }
           


        }
        long GetDateTimeMS(int yr, int month, int day, int hr, int min)
        {
            Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);

            c.Set(Java.Util.CalendarField.DayOfMonth, day);
            c.Set(Java.Util.CalendarField.HourOfDay, hr);
            c.Set(Java.Util.CalendarField.Minute, min);
            c.Set(Java.Util.CalendarField.Month, month);
            c.Set(Java.Util.CalendarField.Year, yr);

            return c.TimeInMillis;
        }


        private void ZXingDefaultOverlay_FlashButtonClicked(Xamarin.Forms.Button sender, EventArgs e)
        {
            scanView.ToggleTorch();
        }

        [Obsolete]
        public async Task<PermissionStatus> CheckAndRequestContactsPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.ContactsWrite>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                var activity = Forms.Context as Activity;
                Toast.MakeText(activity, "Turn on the Contacts permission that the App can write a new Contact from QR-Code result.", ToastLength.Long).Show();
                // Prompt the user with additional information as to why the permission is needed
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.ContactsWrite>())
            {
                var activity = Forms.Context as Activity;
                Toast.MakeText(activity, "Needed your permission to write a new Contact from QR-Code result.", ToastLength.Long).Show();
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.ContactsWrite>();

            return status;
        }

        [Obsolete]
        public async Task<PermissionStatus> CheckAndRequestCALENDARPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.CalendarWrite>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                var activity = Forms.Context as Activity;
                Toast.MakeText(activity, "Turn on the Calendar permission that the App can write a new Event from QR-Code result.", ToastLength.Long).Show();
                // Prompt the user with additional information as to why the permission is needed
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.CalendarWrite>())
            {
                var activity = Forms.Context as Activity;
                Toast.MakeText(activity, "Needed your permission to write a new Event in Calendar from QR-Code result.", ToastLength.Long).Show();
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.CalendarWrite>();

            return status;
        }
        [Obsolete]
        public async Task GetContactAsync()
        {
            var status = await CheckAndRequestPermissionAsync(new Permissions.ContactsWrite());
            if (status != PermissionStatus.Granted)
            {
                await DisplayAlert("Permission for Contacts denied.", "The last time you refused the authorization to access the Contacts.Give this App the authorization for your Contacts to add Contacts directly via a QR-Code.", "OK.");
                Navigation.RemovePage(this);
                return;
            }

            //Add vcard to contacts
            SaveContacts(vCardName, vCardTel, vCardEmail, vCardORG, vCardTitle, vCardAdress, vCardURL);
            Navigation.RemovePage(this);
        }

        [Obsolete]
        public async Task GetCalendarAsync()
        {
            var status = await CheckAndRequestPermissionAsync(new Permissions.CalendarWrite());
            if (status != PermissionStatus.Granted)
            {
                await DisplayAlert("Permission for Calendar denied.", "The last time you refused the authorization to access the Calendar.Give this App the authorization for your Calendar to add Calendar directly via a QR-Code.", "OK.");
                Navigation.RemovePage(this);
                return;
            }

            // Add vcalendar to contacts
            SaveEvents(titleEvent, descriptionEvent, dtStartEvent, dtEndEvent, locationEvent);
            Navigation.RemovePage(this);
        }

        public async Task<PermissionStatus> CheckAndRequestPermissionAsync<T>(T permission)
                    where T : BasePermission
        {
            var status = await permission.CheckStatusAsync();
            if (status != PermissionStatus.Granted)
            {
                status = await permission.RequestAsync();
            }

            return status;
        }
    }
}