﻿using QR_CodeScanner.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodPage : ContentPage
    {
        [Obsolete]
        public FoodPage()
        {
            InitializeComponent();
            BindingContext = new FoodViewModel(Navigation,grid);
        }
    }
}