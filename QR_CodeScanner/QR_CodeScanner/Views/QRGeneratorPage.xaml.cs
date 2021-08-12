﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using QR_CodeScanner.ViewModel;
using Xamarin.Forms.Internals;

namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRGeneratorPage : ContentPage
    {
        private double startScale;
        private double currentScale;
        private double xOffset;
        private double yOffset;

        [Obsolete]
        public QRGeneratorPage(string qrCodeText,bool isContact)
        {
            InitializeComponent();

            BindingContext = new QRGeneratorViewModel(qrCodeText, isContact);              
        }

      
    }
}