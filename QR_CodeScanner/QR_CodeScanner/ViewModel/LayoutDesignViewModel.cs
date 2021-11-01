﻿using QR_CodeScanner.Model;
using QR_CodeScanner.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QR_CodeScanner.ViewModel
{
    public class LayoutDesignViewModel
    {
        //Button um zurück zum haupmenü
        public INavigation Navigation { get; set; }
        Grid grid;
        CultureLang culture;
        ScrollView scrollView;
        Page page;
        Color activeJedi, activeCali, activeModern, activeMango, activeAzure, activeDark, activeSpring;
        Color backgroundC, txtC, buttonC, borderC, buttonTxtC;
        string generateIMG, scanHIMG, genHIMG, mainIMG;
        [Obsolete]
        public LayoutDesignViewModel(INavigation navigation, Grid grid, Page page, Color background, string logo)
        {
            this.Navigation = navigation;
            this.page = page;
            culture = new CultureLang();
            scrollView = new ScrollView();
            this.grid = grid;
            string txt;
            if (culture.GetCulture() == "de")
            {
                txt = "Wähle ein neues App Layout Design:";
            }
            else
            {
                txt = "Choose a new App Layout Design:";
            }
            page.Title = txt;
            page.BackgroundColor = background;
            if (logo == "logoJediBlueIrishIR.png")
            {
                activeJedi = Color.Orange;
                activeAzure = Color.Gray;
                activeCali = Color.Gray;
                activeDark = Color.Gray;
                activeMango = Color.Gray;
                activeModern = Color.Gray;
                activeSpring = Color.Gray;
            }
            if (logo == "logoAzureLime.png")
            {
                activeJedi = Color.Gray;
                activeAzure = Color.Orange;
                activeCali = Color.Gray;
                activeDark = Color.Gray;
                activeMango = Color.Gray;
                activeModern = Color.Gray;
                activeSpring = Color.Gray;
            }
            if (logo == "logoCaliforniaHereICome.png")
            {
                activeJedi = Color.Gray;
                activeAzure = Color.Gray;
                activeCali = Color.Orange;
                activeDark = Color.Gray;
                activeMango = Color.Gray;
                activeModern = Color.Gray;
                activeSpring = Color.Gray;
            }
            if (logo == "logoMangoJazzberry.png")
            {
                activeJedi = Color.Gray;
                activeAzure = Color.Gray;
                activeCali = Color.Gray;
                activeDark = Color.Gray;
                activeMango = Color.Cyan;
                activeModern = Color.Gray;
                activeSpring = Color.Gray;
            }
            if (logo == "logoModernPolit.png")
            {
                activeJedi = Color.Gray;
                activeAzure = Color.Gray;
                activeCali = Color.Gray;
                activeDark = Color.Gray;
                activeMango = Color.Gray;
                activeModern = Color.Orange;
                activeSpring = Color.Gray;
            }
            if (logo == "logoSpringGreenWhite.png")
            {
                activeJedi = Color.Gray;
                activeAzure = Color.Gray;
                activeCali = Color.Gray;
                activeDark = Color.Gray;
                activeMango = Color.Gray;
                activeModern = Color.Gray;
                activeSpring = Color.Orange;
            }
            if (logo == "logoDarkMode.png")
            {
                activeJedi = Color.Gray;
                activeAzure = Color.Gray;
                activeCali = Color.Gray;
                activeDark = Color.Orange;
                activeMango = Color.Gray;
                activeModern = Color.Gray;
                activeSpring = Color.Gray;
            }
            SetLayout(this.grid);
        }

        [Obsolete]
        private void SetLayout(Grid gridUse)
        {
            ScrollView scroll = new ScrollView
            {
            };
            scrollView = scroll;
            Grid container = new Grid
            {
                RowDefinitions =
                {
                      new RowDefinition { Height = new GridLength(0, GridUnitType.Auto)},
                       new RowDefinition { Height = new GridLength(0, GridUnitType.Auto)},
                        new RowDefinition { Height = new GridLength(0, GridUnitType.Auto)},
                         new RowDefinition { Height = new GridLength(0, GridUnitType.Auto)},
                          new RowDefinition { Height = new GridLength(0, GridUnitType.Auto)},
                           new RowDefinition { Height = new GridLength(0, GridUnitType.Auto)},
                            new RowDefinition { Height = new GridLength(0, GridUnitType.Auto)},
                }
            };
            Button btn_DesignSpringWhite = new Button
            {
                ImageSource = "logoSpringGreenWhite200.png",
                BackgroundColor = activeSpring,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            btn_DesignSpringWhite.Clicked += Btn_DesignSpringWhite_Clicked;
            container.Children.Add(btn_DesignSpringWhite, 0, 0);
            Button btn_DesignCali = new Button
            {
                ImageSource = "CaliforniaHereICome200.png",
                BackgroundColor = activeCali,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            btn_DesignCali.Clicked += Btn_DesignCali_Clicked;
            container.Children.Add(btn_DesignCali, 0, 1);
            Button btn_DesignModern = new Button
            {
                ImageSource = "ModernPolit200.png",
                BackgroundColor = activeModern,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            btn_DesignModern.Clicked += Btn_DesignModern_Clicked;
            container.Children.Add(btn_DesignModern, 0, 2);
            Button btn_DesignMango = new Button
            {
                ImageSource = "MangoJazzberry200.png",
                BackgroundColor = activeMango,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            btn_DesignMango.Clicked += Btn_DesignMango_Clicked;
            container.Children.Add(btn_DesignMango, 0, 3);
            Button btn_DesignAzure = new Button
            {
                ImageSource = "AzureLime200.png",
                BackgroundColor = activeAzure,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            btn_DesignAzure.Clicked += Btn_DesignAzure_Clicked;
            container.Children.Add(btn_DesignAzure, 0, 4);
            Button btn_DesignJedi = new Button
            {
                ImageSource = "JediBlueIrishIR200.png",
                BackgroundColor = activeJedi,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            btn_DesignJedi.Clicked += Btn_DesignJedi_Clicked;
            container.Children.Add(btn_DesignJedi, 0, 5);
            Button btn_DesignDarkMode = new Button
            {
                ImageSource = "logoDarkMode200.png",
                BackgroundColor = activeDark,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            btn_DesignDarkMode.Clicked += Btn_DesignDarkMode_Clicked;
            container.Children.Add(btn_DesignDarkMode, 0, 6);
            scroll.Content = container;
            gridUse.Children.Add(scroll);
        }

        [Obsolete]
        private void Btn_DesignDarkMode_Clicked(object sender, EventArgs e)
        {
            AddToLayoutDB("logoDarkMode.png");
            backgroundC = Color.FromHex("292929");
            txtC = Color.FromHex("1bd5fa");
            buttonC = Color.Black;
            borderC = Color.FromHex("53a7b8");
            buttonTxtC = Color.FromHex("1bd5fa");
            generateIMG = "Gen24.png";
            scanHIMG = "ScanH.png";
            genHIMG = "verlauf.png";
            mainIMG = "logoDarkMode.png";
            SetNewDesign();
        }

        [Obsolete]
        private void Btn_DesignSpringWhite_Clicked(object sender, EventArgs e)
        {
            AddToLayoutDB("logoSpringGreenWhite.png");
            backgroundC = Color.FromHex("ffffffff");
            txtC = Color.FromHex("ffffffff");
            buttonC = Color.FromHex("556b2f");
            borderC = Color.FromHex("00ff7f");
            buttonTxtC = Color.Black;
            generateIMG = "qrcode24.png";
            scanHIMG = "scanner24.png";
            genHIMG = "verlaufSpring24.png";
            mainIMG = "logoSpringGreenWhite.png";
            SetNewDesign();
        }

        [Obsolete]
        private async void SetNewDesign()
        {
            if (mainIMG == "logoJediBlueIrishIR.png" || mainIMG == "logoModernPolit.png")
                App.NavPage.BarTextColor = txtC;
            else
                App.NavPage.BarTextColor = borderC;
            App.NavPage.BarBackgroundColor = buttonC;
            if (mainIMG == "logoCaliforniaHereICome.png")
            {
                App.NavPage.BarBackgroundColor = Color.FromHex("965345");
                App.NavPage.BarTextColor = Color.White;
            }
            MainPage mainP = new MainPage(backgroundC, txtC, buttonC, borderC, buttonTxtC, generateIMG, scanHIMG, genHIMG, mainIMG);
            await Navigation.PushAsync(mainP);
            Navigation.RemovePage(page);
        }
        [Obsolete]
        private void Btn_DesignJedi_Clicked(object sender, EventArgs e)
        {
            AddToLayoutDB("logoJediBlueIrishIR.png");
            backgroundC = Color.FromHex("678efo");
            txtC = Color.FromHex("c99718");
            buttonC = Color.FromHex("113182");
            borderC = Color.FromHex("1c55e6");
            buttonTxtC = Color.FromHex("ffffffff");
            generateIMG = "Gen24C99.png";
            scanHIMG = "ScanHC99.png";
            genHIMG = "verlaufC99.png";
            mainIMG = "logoJediBlueIrishIR.png";
            SetNewDesign();
        }

        [Obsolete]
        private void Btn_DesignAzure_Clicked(object sender, EventArgs e)
        {
            AddToLayoutDB("logoAzureLime.png");
            backgroundC = Color.FromHex("3a86ff");
            txtC = Color.FromHex("fa2878");
            buttonC = Color.FromHex("064ab8");
            borderC = Color.FromHex("56de02");
            buttonTxtC = Color.FromHex("56e600");
            generateIMG = "generateLime24.png";
            scanHIMG = "scanHistLime24.png";
            genHIMG = "verlaufLime24.png";
            mainIMG = "logoAzureLime.png";
            SetNewDesign();
        }

        [Obsolete]
        private void Btn_DesignMango_Clicked(object sender, EventArgs e)
        {
            AddToLayoutDB("logoMangoJazzberry.png");
            backgroundC = Color.FromHex("ffbd00");
            txtC = Color.FromHex("ff5400");
            buttonC = Color.FromHex("390099");
            borderC = Color.FromHex("ff0054");
            buttonTxtC = Color.FromHex("390099");
            generateIMG = "generateJazzberry24.png";
            scanHIMG = "scanHistJazzberry24.png";
            genHIMG = "verlaufJazzberry24.png";
            mainIMG = "logoMangoJazzberry.png";
            SetNewDesign();
        }

        [Obsolete]
        private void Btn_DesignModern_Clicked(object sender, EventArgs e)
        {
            AddToLayoutDB("logoModernPolit.png");
            backgroundC = Color.FromHex("defc44");
            txtC = Color.FromHex("defc44");
            buttonC = Color.FromHex("9f09bd");
            borderC = Color.FromHex("364ec7");
            buttonTxtC = Color.FromHex("364ec7");
            generateIMG = "generateModern24.png";
            scanHIMG = "scanHistModern24.png";
            genHIMG = "verlaufModern24.png";
            mainIMG = "logoModernPolit.png";
            SetNewDesign();
        }

        [Obsolete]
        private void Btn_DesignCali_Clicked(object sender, EventArgs e)
        {
            AddToLayoutDB("logoCaliforniaHereICome.png");
            backgroundC = Color.FromHex("53a7b8");
            txtC = Color.Black;
            buttonC = Color.FromHex("88e9fc");
            borderC = Color.FromHex("1bd5fa");
            buttonTxtC = Color.FromHex("ffffffff");
            generateIMG = "generateCali24.png";
            scanHIMG = "scanHistCali24.png";
            genHIMG = "verlaufCali24.png";
            mainIMG = "logoCaliforniaHereICome.png";
            SetNewDesign();
        }
        private async void AddToLayoutDB(string logo)
        {
            await App.DatabaseLayout.DeleteAllLayoutItems<SaveLayoutModel>();
            if (!string.IsNullOrWhiteSpace(logo))
            {

                await App.DatabaseLayout.SaveLayoutAsync(new SaveLayoutModel
                {

                    LayoutDesign = logo

                });
            }
        }
    }
}
