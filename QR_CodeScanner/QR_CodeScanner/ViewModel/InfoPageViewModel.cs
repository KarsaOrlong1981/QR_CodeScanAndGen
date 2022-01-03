using QR_CodeScanner.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QR_CodeScanner.ViewModel
{
    public class InfoPageViewModel : BaseViewModel
    {
        string licenseApache, licenseApacheLINK, licenseXam, licenseXamFat, developer, developerLINK, developerADD, icons, photo, iconsLINK, photoLINK;
        public INavigation Navigation { get; set; }
        public string LicenseApache
        {
            get => licenseApache;
            set => SetProperty(ref licenseApache, value);
        }
        public string LicenseApacheLINK
        {
            get => licenseApacheLINK;
            set => SetProperty(ref licenseApacheLINK, value);
        }
        public string LicenseXam
        {
            get => licenseXam;
            set => SetProperty(ref licenseXam, value);
        }
        public string LicenseXamFat
        {
            get => licenseXamFat;
            set => SetProperty(ref licenseXamFat, value);
        }
        public string Developer
        {
            get => developer;
            set => SetProperty(ref developer, value);
        }
        public string DeveloperADD
        {
            get => developerADD;
            set => SetProperty(ref developerADD, value);
        }
        public string DeveloperLINK
        {
            get => developerLINK;
            set => SetProperty(ref developerLINK, value);
        }
        public string Icons
        {
            get => icons;
            set => SetProperty(ref icons, value);
        }
        public string Photo
        {
            get => photo;
            set => SetProperty(ref photo, value);
        }
        public string PhotoLINK
        {
            get => photoLINK;
            set => SetProperty(ref photoLINK, value);
        }
        public string IconsLINK
        {
            get => iconsLINK;
            set => SetProperty(ref iconsLINK, value);
        }
        CultureLang culture;
        public InfoPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            culture = new CultureLang();
            Developer = "Developer: J.Thomas Germany 2021\n\nContact me at ";
            DeveloperADD = "J1981Thomas@gmail.com";
            DeveloperLINK = "mailto:" + DeveloperADD;
            Icons = "\n\n\nAll Icons from Icons8 visit at ";
            Photo = "\n\n\nMain page image from OpenClipart-Vectors at Pixabay ";
            IconsLINK = "https://icons8.de/";
            PhotoLINK = "https://pixabay.com/de/";
            LicenseApache = "\n\n\nCopyright _____\n\nLicensed under the Apache License, Version 2.0 ";
            LicenseApacheLINK = "http://www.apache.org/licenses/LICENSE-2.0";

            if (culture.GetCulture() == "de")
            {
                LicenseXamFat = "\n\n\nQR-Code Scan&Gen - Datenschutzrichtlinie für QR-Code-Scanner";
                LicenseXam = "\n\n\nIch(J. Thomas) habe die QR-Code-Scanner-App als kostenlose App entwickelt. Dieser DIENST wird von mir kostenlos zur Verfügung gestellt und ist für die Nutzung bestimmt.\n\nDiese Seite wird verwendet, um Website - Besucher über meine Richtlinien zur Erfassung, Verwendung und Offenlegung personenbezogener Daten zu informieren, falls sich jemand für die Nutzung meines Dienstes entschieden hat.\n\nWenn Sie sich für die Nutzung meines Dienstes entscheiden, stimmen Sie der Erfassung und Verwendung von Informationen in Bezug auf diese Richtlinie zu.Die von mir erfassten personenbezogenen Daten werden zur Bereitstellung und Verbesserung des Dienstes verwendet. Ich werde Ihre Daten nicht verwenden oder an Dritte weitergeben, außer wie in dieser Datenschutzrichtlinie beschrieben.\n\nDie in dieser Datenschutzrichtlinie verwendeten Begriffe haben die gleiche Bedeutung wie in unseren Allgemeinen Geschäftsbedingungen, die unter QR - und Barcode - Reader zugänglich sind, sofern in dieser Datenschutzrichtlinie nicht anders definiert.\n\nInformationssammlung und -nutzung\n\nIch garantiere, Ihre persönlichen Daten in keiner Weise zu sammeln oder zu verkaufen.Die von mir erstellte App erfordert keine besondere Erlaubnis, um Ihre persönlichen Daten zu sammeln.\n\nFür ein besseres Erlebnis verwende ich bei der Nutzung unseres Dienstes einige Dienste, bei denen Sie möglicherweise bestimmte personenbezogene Daten angeben müssen.Die von mir angeforderten Informationen werden auf Ihrem Gerät gespeichert und in keiner Weise von mir erfasst.\n\nDie App verwendet die Kamera Ihres Telefons und greift auf Ihre Fotos zu, um QR-Codes und Barcodes von ihr zu erkennen.\n\nDie App verwendet Dienste von Drittanbietern, die möglicherweise Informationen sammeln, die verwendet werden, um Sie zu identifizieren.";
            }
            else

            {
                LicenseXamFat = "\n\n\nQR-Code Scan&Gen - QR-Code-Scanner's Privacy Policy";
                LicenseXam = "\n\nI(J.Thomas) built the QR-Code-Scanner app as a Free app. This SERVICE is provided by me at no cost and is intended for use as is.\n\nThis page is used to inform website visitors regarding my policies with the collection, use, and disclosure of Personal Information if anyone decided to use my Service.\n\nIf you choose to use my Service, then you agree to the collection and use of information in relation to this policy.The Personal Information that I collect is used for providing and improving the Service.I will not use or share your information with anyone except as described in this Privacy Policy.\n\nThe terms used in this Privacy Policy have the same meanings as in our Terms and Conditions, which is accessible at QR & Barcode reader unless otherwise defined in this Privacy Policy.\n\nInformation Collection and Use\n\nI guarantee to NOT collect or sell your personal information in any way.The app I built doesn't require any special permission to collect your personal information.\n\nFor a better experience, while using our Service, I use some services that may require you to provide them with certain personally identifiable information.The information that I request is retained on your device and is not collected by me in any way.\n\nThe app dose use your phone 's Camera and access your Photos to recognize QR codes and Barcodes from its.\n\nThe app does use third party services that may collect information used to identify you.";
            }
        }
    }
}
