using QR_CodeScanner.Model;
using QR_CodeScanner.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QR_CodeScanner.ViewModel
{
    public class FoodViewModel : BaseViewModel
    {
        CultureLang culture;
        Grid container;
        public INavigation Navigation { get; set; }
        public ICommand ButtonGeneratorPageClicked { get; set; }
        public ICommand ButtonPackagedFoodClicked { get; set; }
        public ICommand ButtonUnpackagedFoodClicked { get; set; }
        string packagedFood, unPackagedFood, labText;
        string add;
        bool isVisPF, isVisUPF, isVisLab;
        public string ADD
        {
            get => add;
            set => SetProperty(ref add, value);
        }
        public string LabText
        {
            get => labText;
            set => SetProperty(ref labText, value);
        }
        public string PackagedFood
        {
            get => packagedFood;
            set => SetProperty(ref packagedFood, value);
        }
        public string UnpackagedFood
        {
            get => unPackagedFood;
            set => SetProperty(ref unPackagedFood, value);
        }

        public bool IsVisPF
        {
            get => isVisPF;
            set => SetProperty(ref isVisPF, value);
        }
        public bool IsVisUPF
        {
            get => isVisUPF;
            set => SetProperty(ref isVisUPF, value);
        }
        public bool IsVisLab
        {
            get => isVisLab;
            set => SetProperty(ref isVisLab, value);
        }

        [Obsolete]
        public FoodViewModel(INavigation navigation, Grid grid)
        {
            this.Navigation = navigation;
            container = new Grid();
            ButtonGeneratorPageClicked = new Command(async () => await CallQRGeneratorPage());
            ButtonPackagedFoodClicked = new Command(TreatPackagedFood);
            ButtonUnpackagedFoodClicked = new Command(TreatUnPackagedFood);
            culture = new CultureLang();
            container = grid;
            if (culture.GetCulture() == "de")
            {
                PackagedFood = "Verpackte Lebensmittel";
                UnpackagedFood = "Unverpackte Lebensmittel";
                LabText = "Wähle:";
            }
            else
            {
                PackagedFood = "Packaged Food";
                UnpackagedFood = "Unpackaged Food";
                LabText = "Choose:";
            }
            IsVisPF = true;
            isVisUPF = true;
            isVisLab = true;
        }

        private void TreatUnPackagedFood(object obj)
        {
            IsVisLab = false;
            IsVisPF = false;
            IsVisUPF = false;

        }

        private void TreatPackagedFood(object obj)
        {
            IsVisLab = false;
            IsVisPF = false;
            IsVisUPF = false;
        }

        [Obsolete]
        private async Task CallQRGeneratorPage()
        {
            await Navigation.PushAsync(new QRGeneratorPage(ADD, false, false, false, false, false, false, false, true, false, string.Empty, false));
        }

    }
}
