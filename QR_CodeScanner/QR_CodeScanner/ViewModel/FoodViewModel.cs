using Android.App;
using Android.Widget;
using QR_CodeScanner.Model;
using QR_CodeScanner.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ListView = Xamarin.Forms.ListView;

namespace QR_CodeScanner.ViewModel
{
    public class FoodViewModel : BaseViewModel
    {
        CultureLang culture;
        Grid container;
        ListView saveListView;
        Frame saveListIngredFrame, saveWeiIngredFrame;
        Entry saveIngreEntry, saveWeigthIngredEntry, saveAllergEntry, saveDesignEntry, saveNutriEntry;
        List<Ingredients> listIngredArray;
        public INavigation Navigation { get; set; }
        public ICommand ButtonGeneratorPageClicked { get; set; }
        public ICommand ButtonPackagedFoodClicked { get; set; }
        public ICommand ButtonUnpackagedFoodClicked { get; set; }
        string packagedFood, unPackagedFood, labText;
        string add, desigPlaceholder, allergPlaceholder, ingredPlaceholder, gramPlaceholder;
        string designation, allergens, ingredients, weightIngredString, nutritionalValues;
        string gram;
        int counter = 0;
        
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
            saveListView = new ListView();
            saveIngreEntry = new Entry();
            saveWeigthIngredEntry = new Entry();
            saveAllergEntry = new Entry();
            saveDesignEntry = new Entry();
            saveNutriEntry = new Entry();
            saveListIngredFrame = new Frame();
            listIngredArray = new List<Ingredients>();
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
                desigPlaceholder = "Bezeichnung";
                ingredPlaceholder = "Zutaten";
                allergPlaceholder = "Allergene";
                gramPlaceholder = "Anteil in Gramm";

            }
            else
            {
                PackagedFood = "Packaged Food";
                UnpackagedFood = "Unpackaged Food";
                LabText = "Choose:";
                desigPlaceholder = "Designation";
                ingredPlaceholder = "Ingredients";
                allergPlaceholder = "Allergens";
                gramPlaceholder = "Portion in Gram";
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

        [Obsolete]
        private void TreatPackagedFood(object obj)
        {
            IsVisLab = false;
            IsVisPF = false;
            IsVisUPF = false;
            Grid grid = new Grid
            {
                RowDefinitions =
                {
                      new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                      new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                      new RowDefinition { Height = new GridLength(2, GridUnitType.Auto)},
                      new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                      new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                      new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                      new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                      new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                      new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                      new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                      new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)}
                }
            };
            container.Children.Add(grid);
            Frame desingFrame = new Frame
            {
                BackgroundColor = Color.SteelBlue,
                HasShadow = true,
                CornerRadius = 20,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            Entry itemDesignation = new Entry
            {
                PlaceholderColor = Color.White,
                Placeholder = desigPlaceholder,
                WidthRequest = 300,
                IsTextPredictionEnabled = true,
                TextColor = Color.Black,
                BackgroundColor = Color.SteelBlue,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            saveDesignEntry = itemDesignation;
            desingFrame.Content = saveDesignEntry;
            grid.Children.Add(desingFrame);
            itemDesignation.TextChanged += Designation_TextChanged;
            Frame allergFrame = new Frame
            {
                BackgroundColor = Color.SteelBlue,
                HasShadow = true,
                CornerRadius = 20,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            Entry itemAllergens = new Entry
            {
                PlaceholderColor = Color.White,
                Placeholder = allergPlaceholder,
                WidthRequest = 300,
                IsTextPredictionEnabled = true,
                TextColor = Color.Yellow,
                BackgroundColor = Color.SteelBlue,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            saveAllergEntry = itemAllergens;
            allergFrame.Content = saveAllergEntry;
            grid.Children.Add(allergFrame, 0, 1);

            Frame ingredFrame = new Frame
            {
                BackgroundColor = Color.SteelBlue,
                HasShadow = true,
                CornerRadius = 20,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            StackLayout stack = new StackLayout
            {

            };
            Entry itemIngredients = new Entry
            {
                PlaceholderColor = Color.White,
                Placeholder = ingredPlaceholder,
                WidthRequest = 300,
                IsTextPredictionEnabled = true,
                TextColor = Color.Yellow,
                BackgroundColor = Color.SteelBlue,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            Frame weiIngredFrame = new Frame
            {
                IsVisible = false,
                BackgroundColor = Color.SteelBlue,
                HasShadow = true,
                CornerRadius = 20,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            saveWeiIngredFrame = weiIngredFrame;
            Entry weigthIngredients = new Entry
            {
                Placeholder = gramPlaceholder,
                PlaceholderColor = Color.White,
                Keyboard = Keyboard.Numeric,
                WidthRequest = 100,
                IsTextPredictionEnabled = true,
                TextColor = Color.Yellow,
                BackgroundColor = Color.SteelBlue,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            saveWeigthIngredEntry = weigthIngredients;
            weiIngredFrame.Content = saveWeigthIngredEntry;
            weigthIngredients.Focused += WeigthIngredients_Focused;
            weigthIngredients.Completed += WeigthIngredients_Completed;

            saveIngreEntry = itemIngredients;
            stack.Children.Add(saveIngreEntry);
            stack.Children.Add(weiIngredFrame);
            itemIngredients.Focused += ItemIngredients_Focused;
            itemIngredients.Completed += ItemIngredients_Completed;
            ingredFrame.Content = stack;
            grid.Children.Add(ingredFrame, 0, 2);
            Frame listInFrame = new Frame
            {
                IsVisible = false,
                BackgroundColor = Color.SteelBlue,
                HasShadow = true,
                CornerRadius = 20,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            saveListIngredFrame = listInFrame;
            ListView listIngredients = new ListView
            {
                WidthRequest = 300,
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                BackgroundColor = Color.SteelBlue,
                SeparatorColor = Color.White,
            };
            saveListView = listIngredients;
            saveListIngredFrame.Content = saveListView;
            saveListView.ItemTapped += SaveListView_ItemTapped;
            grid.Children.Add(saveListIngredFrame, 1, 2);
            //this is for NutritionalValues
            Frame nutri = new Frame
            {

            };
            Grid nutriGrid = new Grid
            {

            };
            Label nutriLab = new Label
            {

            };
            Entry fat = new Entry
            {

            };
            Entry sownFattyAcids = new Entry
            {

            };
            Entry carbohydrates = new Entry
            {

            };
            Entry sugar = new Entry
            {

            };
            Entry protein = new Entry
            {

            };
            Entry salt = new Entry
            {

            };
            itemDesignation.Focus();
            //********************************************


        }

        private void SaveListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            listIngredArray.Remove((Ingredients)e.Item);
            saveListView.IsRefreshing = true;
            var template = new DataTemplate(typeof(TextCell));
            template.SetBinding(TextCell.TextProperty, "Ingredient");
            template.SetBinding(TextCell.DetailProperty, "Gram");
            template.SetValue(TextCell.TextColorProperty, Color.Yellow);
            template.SetValue(TextCell.DetailColorProperty, Color.Orange);
            saveListView.ItemTemplate = template;
            saveListView.ItemsSource = listIngredArray;
            saveListView.SelectedItem = null;
            if (listIngredArray.Count == 0)
                saveListIngredFrame.IsVisible = false;
            saveListView.IsRefreshing = false;
        }

        [Obsolete]
        private void WeigthIngredients_Focused(object sender, FocusEventArgs e)
        {
            if (counter <= 1)
            {
                var activity = Forms.Context as Activity;
                if (culture.GetCulture() == "de")
                    Toast.MakeText(activity, "Return drücken um Zutat hinzuzufügen.", ToastLength.Long).Show();
                else
                    Toast.MakeText(activity, "Press Return to add Ingredient.", ToastLength.Long).Show();
            }
            counter++;
        }

        [Obsolete]
        private void ItemIngredients_Focused(object sender, FocusEventArgs e)
        {
            if (counter <= 1)
            {
                var activity = Forms.Context as Activity;
                if (culture.GetCulture() == "de")
                    Toast.MakeText(activity, "Return drückem um Zutat hinzuzufügen.", ToastLength.Long).Show();
                else
                    Toast.MakeText(activity, "Press Return to add Ingredient.", ToastLength.Long).Show();
            }
            counter++;
        }

        private void WeigthIngredients_Completed(object sender, EventArgs e)
        {
            gram = saveWeigthIngredEntry.Text + " g";
            listIngredArray.Add(new Ingredients() { Ingredient = ingredients, Gram = gram });
            var template = new DataTemplate(typeof(TextCell));
            template.SetBinding(TextCell.TextProperty, "Ingredient");
            template.SetBinding(TextCell.DetailProperty, "Gram");
            template.SetValue(TextCell.TextColorProperty, Color.Yellow);
            template.SetValue(TextCell.DetailColorProperty, Color.Orange);
            saveListView.ItemTemplate = template;
            saveListView.ItemsSource = listIngredArray;
            saveIngreEntry.IsEnabled = true;
            saveAllergEntry.IsEnabled = true;
            saveDesignEntry.IsEnabled = true;
            saveNutriEntry.IsEnabled = true;
            saveWeigthIngredEntry.Text = string.Empty;
            saveIngreEntry.Text = string.Empty;
            saveListIngredFrame.IsVisible = true;
            saveWeiIngredFrame.IsVisible = false;
            saveIngreEntry.Focus();
        }

        private void ItemIngredients_Completed(object sender, EventArgs e)
        {
            saveWeiIngredFrame.IsVisible = true;
            ingredients = saveIngreEntry.Text;
            saveIngreEntry.IsEnabled = false;
            saveAllergEntry.IsEnabled = false;
            saveDesignEntry.IsEnabled = false;
            saveNutriEntry.IsEnabled = false;
            saveWeigthIngredEntry.Focus();
        }

        private void Designation_TextChanged(object sender, TextChangedEventArgs e)
        {
            designation = e.NewTextValue;
            Debug.WriteLine(designation);
        }

        [Obsolete]
        private async Task CallQRGeneratorPage()
        {

            await Navigation.PushAsync(new QRGeneratorPage(ADD, false, false, false, false, false, false, false, true, false, string.Empty, false));
        }

    }
}
