using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Provider;
using Android.Widget;
using QR_CodeScanner.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using QR_CodeScanner.Model;
using static Xamarin.Essentials.Permissions;
using Java.Util;
using QR_CodeScanner.Views;

namespace QR_CodeScanner.ViewModel
{
    public class ResultViewModel : BaseViewModel
    {
        private readonly DateTime timeStart;
        private readonly DateTime timeEnd;
        private int fontSize;
        private bool isVisEvent, isVis;
        private bool isWlan;
        private bool isWebsite;
        private bool isContact;
        private bool isEvent;
        private bool isPhoneNumber;
        private bool isEmail;
        private bool isSMS;
        private bool isBarcode;
        private bool isBrowser;
        ShareContent shareQR;
        #region ICommand
        public ICommand ButtonAddTo { get; set; }
        public ICommand ButtonLocation { get; set; }

        public ICommand ButtonShare { get; set; }
        #endregion // ICommand
        #region DesignColor Propertys
        Color background, frame;
        public Color Background
        {
            get => background;
            set => SetProperty(ref background, value);
        }
        #endregion // DesignColor Propertys
        #region Propertys
        string text1, location, text2, text3, text4, textINfo;
        string ssid;
        string password;
        string number;
        string labelText, imageTop, imageInfo;
        string resultToAdd;
        string bgColor;
        string tcColor;
        string saveTo, shareTo;
        string titleEvent, dtStartEvent, dtEndEvent, locationEvent, descriptionEvent;
        string vCardName, vCardEmail, vCardAdress, vCardURL, vCardTitle, vCardORG, vCardTel;
        string vcard1, vcard2, vcard3, vcard4, vcard5, vcard6, vcard7, vcard7Link, vcard8;
        string vcard9, vcard9Link, vcard10, vcard11, vcard11Link, vcard12, vcard13;
        public string TextInfo
        {
            get => textINfo;
            set => SetProperty(ref textINfo, value);
        }
        public string ImageTop
        {
            get => imageTop;
            set => SetProperty(ref imageTop, value);
        }
        public string ImageInfo
        {
            get => imageInfo;
            set => SetProperty(ref imageInfo, value);
        }
        public bool IsVisEvent
        {
            get => isVisEvent;
            set => SetProperty(ref isVisEvent, value);
        }
        public bool IsVis
        {
            get => isVis;
            set => SetProperty(ref isVis, value);
        }
        public string Location
        {
            get => location;
            set => SetProperty(ref location, value);
        }
        public string LabelText
        {
            get => labelText;
            set => SetProperty(ref labelText, value);
        }
        public string SaveTo
        {
            get => saveTo;
            set => SetProperty(ref saveTo, value);
        }
        public string ShareTo
        {
            get => shareTo;
            set => SetProperty(ref shareTo, value);
        }
        public int FontSizeQR
        {
            get => fontSize;
            set => SetProperty(ref fontSize, value);
        }
        public string Text1
        {
            get => text1;
            set => SetProperty(ref text1, value);
        }
        public string BGColor
        {
            get => bgColor;
            set => SetProperty(ref bgColor, value);
        }
        public string TCColor
        {
            get => tcColor;
            set => SetProperty(ref tcColor, value);
        }

        public string Text2
        {
            get => text2;
            set => SetProperty(ref text2, value);
        }

        public string Text3
        {
            get => text3;
            set => SetProperty(ref text3, value);
        }
        public string Text4
        {
            get => text4;
            set => SetProperty(ref text4, value);
        }
        public string VCard1
        {
            get => vcard1;
            set => SetProperty(ref vcard1, value);
        }
        public string VCard2
        {
            get => vcard2;
            set => SetProperty(ref vcard2, value);
        }
        public string VCard3
        {
            get => vcard3;
            set => SetProperty(ref vcard3, value);
        }
        public string VCard4
        {
            get => vcard4;
            set => SetProperty(ref vcard4, value);
        }
        public string VCard5
        {
            get => vcard5;
            set => SetProperty(ref vcard5, value);
        }
        public string VCard6
        {
            get => vcard6;
            set => SetProperty(ref vcard6, value);
        }
        public string VCard7
        {
            get => vcard7;
            set => SetProperty(ref vcard7, value);
        }
        public string VCard7Link
        {
            get => vcard7Link;
            set => SetProperty(ref vcard7Link, value);
        }


        public string VCard8
        {
            get => vcard8;
            set => SetProperty(ref vcard8, value);
        }
        public string VCard9
        {
            get => vcard9;
            set => SetProperty(ref vcard9, value);
        }
        public string VCard9Link
        {
            get => vcard9Link;
            set => SetProperty(ref vcard9Link, value);
        }
        public string VCard10
        {
            get => vcard10;
            set => SetProperty(ref vcard10, value);
        }
        public string VCard11
        {
            get => vcard11;
            set => SetProperty(ref vcard11, value);
        }
        public string VCard11Link
        {
            get => vcard11Link;
            set => SetProperty(ref vcard11Link, value);
        }
        public string VCard12
        {
            get => vcard12;
            set => SetProperty(ref vcard12, value);
        }
        public string VCard13
        {
            get => vcard13;
            set => SetProperty(ref vcard13, value);
        }
        #endregion // Propertys

        [Obsolete]
        public ResultViewModel(string qrTxt, bool isWlan, bool isWebsite, bool isContact, bool isEvent, bool isPhoneNumber, bool isEmail, bool isSMS, bool isBarcode, bool isBrowser, string phoneNumberSMS, bool scanHistory, Color background)
        {
            this.Background = background;
            this.frame = Color.White;
            this.isWlan = isWlan;
            this.isWebsite = isWebsite;
            this.isContact = isContact;
            this.isEvent = isEvent;
            this.isPhoneNumber = isPhoneNumber;
            this.isEmail = isEmail;
            this.isSMS = isSMS;
            this.isBarcode = isBarcode;
            this.isBrowser = isBrowser;
            ssid = string.Empty;
            password = string.Empty;
            shareQR = new ShareContent();
            FontSizeQR = 20;
            resultToAdd = qrTxt;
            IsVisEvent = false;
            IsVis = true;
            ImageTop = "TextOR.png";
            timeStart = DateTime.Now;
            timeEnd = DateTime.Now;
            Text1 = qrTxt;
            number = phoneNumberSMS;
            if (CultureLanguage.GetCulture() == "de")
            {
                SaveTo = "Kopieren";
                ShareTo = "Teilen";
            }
            else
            {
                SaveTo = "Copy";
                ShareTo = "Share";
            }
            if (isWlan)
            {
                string manual = string.Empty;
                string info = string.Empty;
                string trimWiFi = resultToAdd.Substring(5);
                string[] splitSSidPass = trimWiFi.Split(';', ' ');
                for (int i = 0; i < splitSSidPass.Length; i++)
                {
                    if (splitSSidPass[i] == string.Empty)
                        continue;
                    else
                    {
                        if (splitSSidPass[i].Substring(0, 2) == "S:")
                        {
                            string subSSID = splitSSidPass[i].Substring(2);
                            ssid = subSSID;
                        }
                        if (splitSSidPass[i].Substring(0, 2) == "P:")
                        {
                            string subPassword = splitSSidPass[i].Substring(2);
                            password = subPassword;
                        }
                    }
                }
                Text1 = ssid;
                Text2 = password;
                ImageInfo = "Info26.png";
                ImageTop = "Wlan.png";
                if (CultureLanguage.GetCulture() == "de")
                {
                    info = "Entschuldigen Sie bitte, Google empfiehlt ab Android 10 manuell eine Verbindung zu einem WLAN-Netzwerk herzustellen, um die Privatsphäre der Nutzer zu schützen.";
                    manual = "- Klicken Sie auf \"Passwort Kopieren\".\n\n- wählen Sie Wifi-Netzwerk \"" + ssid + "\".\n\n- Fügen Sie das Passwort ein und stellen Sie eine Verbindung her.";
                }
                else
                {
                    info = "Sorry, Google recommends manually connecting to \na WiFi network from Android 10 onwards in order to protect user privacy.";
                    manual = "- Click on \"Copy Password \".\n\n- select Wifi Network \"" + ssid + "\". \n\n- Paste the password and connect .";
                }
                LabelText = info;
                TextInfo = manual;
                if (CultureLanguage.GetCulture() == "de")
                {
                    SaveTo = "Passwort\nKopieren";

                    ShareTo = "Passwort\nTeilen";
                }
                else
                {
                    SaveTo = "Copy\npassword";

                    ShareTo = "Share\npassword";
                }
            }
            if (isContact)
            {
                Text1 = "";
                ImageTop = "kontakt40.png";
                SaveTo = "Save\nto Contacts";
                ShareTo = "Share\nContact";
                GetContactsResult(qrTxt);
            }
            if (isBrowser)
            {
                OpenBrowser(qrTxt);
            }
            if (isSMS)
            {
                string[] messageAndNumber = qrTxt.Split(':');
                SendSms(messageAndNumber[2], messageAndNumber[1]);
            }
            if (isBarcode)
            {
                ImageTop = "barcode.png";
                Text1 = qrTxt;
                if (CultureLanguage.GetCulture() == "de")
                {
                    SaveTo = "Kopieren";
                    ShareTo = "Teilen";
                }
                else
                {
                    SaveTo = "Copy";
                    ShareTo = "Share";
                }
            }
            if (isEvent)
            {
                Text1 = "";
                ImageTop = "Ereignis.png";
                SaveTo = "Save\nto Calendar";
                ShareTo = "Share\nEvent";
                GetCalendarResult(qrTxt);
            }

            if (isPhoneNumber)
            {
                Text1 = "TEL: " + qrTxt;
                IsVis = true;
                ImageTop = "Telefon.png";
                if (CultureLanguage.GetCulture() == "de")
                {
                    SaveTo = "Nummer\nKopieren";

                    ShareTo = "Nummer\nTeilen";
                }
                else
                {
                    SaveTo = "Copy\nnumber";

                    ShareTo = "Share\nnumber";
                }

                LabelText = "call: ";
                VCard7 = qrTxt;
                VCard7Link = "tel:" + qrTxt;
            }
            if (isEmail)
            {
                LabelText = "Email: ";
                VCard11 = qrTxt;
                VCard11Link = "mailto:" + qrTxt;

            }
            tcColor = "Black";
            bgColor = "White";


            ButtonLocation = new Command(LaunchingMap);
            ButtonAddTo = new Command(DoNext);
            ButtonShare = new Command(ShareQR);
            if (scanHistory == false)
            {
                GetImageAndTextHistory();
            }
        }

        async void ShareQR()
        {
            await shareQR.ShareText(resultToAdd);
        }
        [Obsolete]
        async void DoNext()
        {
            if (SaveTo == "Save\nto Contacts")
            {
                await CheckAndRequestContactsPermission();
                //Permisssions must be granted for Contacts
                await GetContactAsync();

            }
            if (SaveTo == "Save\nto Calendar")
            {
                await CheckAndRequestCALENDARPermission();
                //Permisssions must be granted for Calendar
                await GetCalendarAsync();
            }
            if (SaveTo == "Nummer\nKopieren" || SaveTo == "Copy\nnumber" || SaveTo == "Passwort\nKopieren" || SaveTo == "Copy\npassword")
            {
                if (CultureLanguage.GetCulture() == "de")
                {
                    if (SaveTo == "Nummer\nKopieren")
                    {
                        await Clipboard.SetTextAsync(resultToAdd);
                        WriteToast.ShowLongToast("Telefonnummer wurde kopiert.");
                    }
                    else
                    {
                        await Clipboard.SetTextAsync(password);
                        WriteToast.ShowLongToast("Passwort wurde kopiert.");
                    }
                }
                else
                {
                    if (SaveTo == "Copy\nnumber")
                    {
                        await Clipboard.SetTextAsync(resultToAdd);
                        WriteToast.ShowLongToast("Phone number was copied.");
                    }
                    else
                    {
                        await Clipboard.SetTextAsync(password);
                        WriteToast.ShowLongToast("Password was copied.");
                    }
                }
            }
            if (SaveTo == "Kopieren" || SaveTo == "Copy")
            {
                await Clipboard.SetTextAsync(resultToAdd);
                var activity = Android.App.Application.Context as Activity;
                if (CultureLanguage.GetCulture() == "de")
                    WriteToast.ShowLongToast("Text wurde Kopiert");
                else
                    WriteToast.ShowLongToast("Copied Text");
            }

        }

        [Obsolete]
        private async void SendSms(string messageText, string recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, recipient);
                await Xamarin.Essentials.Sms.ComposeAsync(message);
            }
            catch
            {
                // Sms is not supported on this device.
                if (CultureLanguage.GetCulture() == "de")
                    WriteToast.ShowShortToast("SMS wird auf diesem Gerät nicht unterstützt.");
                else
                    WriteToast.ShowShortToast("Sms is not supported on this device.");
            }
        }
        //If Scanner recognizes an Website open Browser
        private async void OpenBrowser(string uri)
        {
            await Xamarin.Essentials.Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        [Obsolete]
        public async Task<PermissionStatus> CheckAndRequestContactsPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.ContactsWrite>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                if (CultureLanguage.GetCulture() == "de")
                    WriteToast.ShowShortToast("Bitte schalten Sie die Berechtigung für Ihre Kontakte ein, damit diese App das ergebnis zu Ihren kontakten hnzufügen kann.");
                else
                    WriteToast.ShowShortToast("Turn on the Contacts permission that the App can write a new Contact from QR-Code result.");
                // Prompt the user with additional information as to why the permission is needed
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.ContactsWrite>())
            {
                if (CultureLanguage.GetCulture() == "de")
                    WriteToast.ShowLongToast("Die Berechtigung auf Kontakte zugreifen zu dürfen wird benötigt um das ergebnis ihren Kontakten hinzuzufügen ");
                else
                    WriteToast.ShowLongToast("Needed your permission to write a new Contact from QR-Code result.");
            }

            status = await Permissions.RequestAsync<Permissions.ContactsWrite>();

            return status;
        }

        [Obsolete]
        public async Task GetContactAsync()
        {
            var status = await CheckAndRequestPermissionAsync(new Permissions.ContactsWrite());
            if (status != PermissionStatus.Granted)
            {
                if (CultureLanguage.GetCulture() == "de")
                    WriteToast.ShowLongToast("Beim letzten mal haben Sie den zugriff auf Ihre Kontake abgelehnt. Geben Sie dieser App die Berechtigung auf Ihre Kontakte zuzugreifen um das ergebnis direkt zu Ihren Kontakten hinzuzufügen. ");
                else
                    WriteToast.ShowLongToast("The last time you refused the authorization to access the Contacts.Give this App the authorization for your Contacts to add Contacts directly via a QR-Code.");
                return;
            }

            //Add vcard to contacts
            SaveContacts(vCardName, vCardTel, vCardEmail, vCardORG, vCardTitle, vCardAdress, vCardURL);
        }
        [Obsolete]
        public void SaveContacts(string name, string number, string email, string company, string jobtitle, string postal, string website)
        {

            try
            {
                Context context = Android.App.Application.Context;
                var intent = new Intent(Intent.ActionInsert);
                intent.SetType(ContactsContract.Contacts.ContentType);
                intent.PutExtra(ContactsContract.Intents.Insert.Name, name);
                intent.PutExtra(ContactsContract.Intents.Insert.Phone, number);
                intent.PutExtra(ContactsContract.Intents.Insert.Email, email);
                intent.PutExtra(ContactsContract.Intents.Insert.Company, company);
                intent.PutExtra(ContactsContract.Intents.Insert.JobTitle, jobtitle);
                intent.PutExtra(ContactsContract.Intents.Insert.Postal, postal);
                intent.PutExtra(ContactsContract.Intents.Insert.Notes, website);
                context.StartActivity(intent);
                if (CultureLanguage.GetCulture() == "de")
                    Toast.MakeText(context, "Zu Kontakten hinzufügen", ToastLength.Short).Show();
                else
                    Toast.MakeText(context, "Add to Contacts", ToastLength.Short).Show();
            }
            catch
            {
                if (CultureLanguage.GetCulture() == "de")
                    WriteToast.ShowShortToast("Kann nicht zu den Kontakten hinzugefügt werden");
                else
                    WriteToast.ShowShortToast("Can not Add to Contacts");
            }

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

        [Obsolete]
        void GetContactsResult(string result)
        {
            string resultString = Convert.ToString(result);

            IsVis = true;

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
                    string[] splitVcard = result.Split('\n');

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
                                    Text1 = splitVcardName[1] + "\n\n";
                                }
                                if (splitVcard[i].Substring(0, 3) == "ORG")
                                {
                                    splitVcardORG = splitVcard[i].Split(':');
                                    vCardORG = splitVcardORG[1];
                                    VCard4 = ", " + splitVcardORG[1] + "\n";
                                }

                                if (splitVcard[i].Substring(0, 4) == "TITL")
                                {
                                    splitVcardTitle = splitVcard[i].Split(':');
                                    vCardTitle = splitVcardTitle[1];
                                    VCard3 = splitVcardTitle[1];
                                }
                                if (splitVcard[i].Substring(0, 3) == "TEL")
                                {
                                    splitVcardTEL = splitVcard[i].Split(':');
                                    vCardTel = splitVcardTEL[1];
                                    VCard6 = "Tel : ";
                                    VCard7 = splitVcardTEL[1] + "\n";
                                    VCard7Link = "tel:" + splitVcardTEL[1];
                                }
                                if (splitVcard[i].Substring(0, 3) == "URL")
                                {
                                    splitVcardURL = splitVcard[i].Split(':');
                                    if (splitVcardURL[1] == "https" || splitVcardURL[1] == "http")
                                    {
                                        vCardURL = splitVcardURL[1] + ":" + splitVcardURL[2];
                                        VCard8 = "Web: ";
                                        VCard9 = splitVcardURL[2] + "\n";
                                        VCard9Link = "https://" + splitVcardURL[2];
                                    }
                                    else
                                    {
                                        vCardURL = splitVcardURL[1];
                                        VCard8 = "Web: ";
                                        VCard9 = splitVcardURL[1] + "\n";
                                        VCard9Link = "https://" + splitVcardURL[1];
                                    }
                                }
                                if (splitVcard[i].Substring(0, 4) == "EMAI")
                                {
                                    splitVcardEMAIL = splitVcard[i].Split(':');
                                    vCardEmail = splitVcardEMAIL[1];
                                    VCard10 = "Email: ";
                                    VCard11 = splitVcardEMAIL[1] + "\n";
                                    VCard11Link = "mailto:" + splitVcardEMAIL[1];
                                }
                                if (splitVcard[i].Substring(0, 3) == "ADR")
                                {
                                    splitVcardADR = splitVcard[i].Split(':');
                                    vCardAdress = splitVcardADR[1];
                                    VCard12 = splitVcardADR[1];
                                }

                            }
                            catch
                            {
                                WriteToast.ShowLongToast("QR-Code not readable !");
                            }

                        }

                    }
                }
            }
        }

        [Obsolete]
        void GetCalendarResult(string result)
        {
            string[] splitDTStart;
            string[] splitDTEnd;
            string[] splitSummary;
            string[] splitDescription;
            string[] splitLocation;

            IsVisEvent = true;

            try
            {
                string[] splitVcal = result.Split('\n');

                for (int i = 0; i < splitVcal.Length; i++)
                {
                    if (splitVcal[i] == "")
                    {
                        continue;
                    }
                    else
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
                            Location = locationEvent;

                        }





                    }

                }
                string[] splitToSubStart = dtStartEvent.Split('T');
                string[] splitToSubEnd = dtEndEvent.Split('T');
                string txt = "";
                Text1 = titleEvent;
                Text2 = descriptionEvent;
                if (CultureLanguage.GetCulture() == "de")
                {
                    Text3 = "Start: " + Convert.ToString(BuildNewDateTime(splitToSubStart, timeStart));
                    Text4 = "Ende:  " + Convert.ToString(BuildNewDateTime(splitToSubEnd, timeEnd));
                    txt = "Ein neues Event steht an: ";
                }
                else
                {
                    Text3 = "Start: " + Convert.ToString(BuildNewDateTime(splitToSubStart, timeStart));
                    Text4 = "End:   " + Convert.ToString(BuildNewDateTime(splitToSubEnd, timeEnd));
                    txt = "There is a new Event: ";
                }

                resultToAdd = txt + "\n\n" + Text1 + "\n\n" + Text2 + "\n" + Text3 + "\n" + Text4 + "\n" + "Location: " + Location;
            }
            catch
            {
                if (CultureLanguage.GetCulture() == "de")
                    WriteToast.ShowLongToast("Der QR-Code wird nicht erkannt.");
                else
                    WriteToast.ShowLongToast("QR-Code not readable.");
            }
        }

        //Get the Location of the Users Entry
        [Obsolete]
        public async void LaunchingMap()
        {
            try
            {
                var placemark = new Placemark
                {
                    CountryName = Location

                };
                var options = new MapLaunchOptions { NavigationMode = NavigationMode.None };
                await Xamarin.Essentials.Map.OpenAsync(placemark, options);
            }
            catch
            {
                WriteToast.ShowShortToast("Dont find this Place.");
            }
        }
        [Obsolete]
        public async Task<PermissionStatus> CheckAndRequestCALENDARPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.CalendarWrite>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                var activity = Android.App.Application.Context as Activity;
                Toast.MakeText(activity, "Turn on the Calendar permission that the App can write a new Event from QR-Code result.", ToastLength.Long).Show();
                // Prompt the user with additional information as to why the permission is needed
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.CalendarWrite>())
            {
                WriteToast.ShowLongToast("Needed your permission to write a new Event in Calendar from QR-Code result.");
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.CalendarWrite>();

            return status;
        }

        DateTime BuildNewDateTime(string[] splitArray, DateTime newDate)
        {
            string startHour = splitArray[1].Substring(0, 2);
            string startMin = splitArray[1].Substring(2, 2);
            string startSec = splitArray[1].Substring(4, 2);
            string timeNew = startHour + ":" + startMin + ":" + startSec;

            string getNewDTStart = splitArray[0] + "T" + timeNew + "Z";
            newDate = DateTime.ParseExact(getNewDTStart, "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture);
            return newDate;
        }
        [Obsolete]
        public async Task GetCalendarAsync()
        {
            var status = await CheckAndRequestPermissionAsync(new Permissions.CalendarWrite());
            if (status != PermissionStatus.Granted)
            {
                WriteToast.ShowLongToast("The last time you refused the authorization to access the Calendar.Give this App the authorization for your Calendar to add Calendar directly via a QR-Code.");
                return;
            }

            // Add vcalendar to contacts
            SaveEvents(titleEvent, descriptionEvent, dtStartEvent, dtEndEvent, locationEvent);
        }

        [Obsolete]
        void SaveEvents(string title, string description, string dtStart, string dtEnd, string location)
        {

            try
            {
                string[] splitDTStart = dtStart.Split('T', 'Z');
                string startDateYear = splitDTStart[0].Substring(0, 4);
                string startDateMonth = splitDTStart[0].Substring(4, 2);
                string startDateDay = splitDTStart[0].Substring(6, 2);
                string timeStartHour = splitDTStart[1].Substring(0, 2);
                string timeStartMin = splitDTStart[1].Substring(2, 2);
                string[] splitDTEnd = dtEnd.Split('T', 'Z');
                string endDateYear = splitDTEnd[0].Substring(0, 4);
                string endDateMonth = splitDTEnd[0].Substring(4, 2);
                string endDateDay = splitDTEnd[0].Substring(6, 2);
                string timeEndHour = splitDTEnd[1].Substring(0, 2);
                string timeEndMin = splitDTEnd[1].Substring(2, 2);

                var activity = Android.App.Application.Context as Activity;
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
                WriteToast.ShowShortToast("Can not Save");
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

        private void GetImageAndTextHistory()
        {
            string eventQRString = string.Empty;
            string text = resultToAdd;
            if (isWlan == true)
                eventQRString = "Wlan";
            if (isWebsite == true)
                eventQRString = "Website";
            if (isContact == true)
                eventQRString = "Contact";
            if (isEvent == true)
                eventQRString = "Event";
            if (isPhoneNumber == true)
                eventQRString = "Phonenumber";
            if (isEmail == true)
                eventQRString = "Email";
            if (isSMS == true)
            {
                eventQRString = "SMS";
                text = "smsto:" + number + ":" + resultToAdd;
            }
            if (isBarcode == true)
                eventQRString = "Barcode";
            if (isBrowser == true)
                eventQRString = "Browser";
            if (eventQRString != "Wlan" && eventQRString != "Website" && eventQRString != "Contact" && eventQRString != "Event" && eventQRString != "Phonenumber" &&
               eventQRString != "Email" && eventQRString != "SMS" && eventQRString != "Barcode" && eventQRString != "Browser")
            {
                eventQRString = "Text";
            }
            new ScanHistory(text, eventQRString, true, background, frame);
        }
    }
}
