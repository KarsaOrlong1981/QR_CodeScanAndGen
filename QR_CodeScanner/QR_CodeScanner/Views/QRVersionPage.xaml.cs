using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QR_CodeScanner.ViewModel;
namespace QR_CodeScanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRVersionPage : ContentPage
    {
        [Obsolete]
        public QRVersionPage(Color background, Color button, Color txt, Color frame, Color border)
        {
            InitializeComponent();
            BindingContext = new QRVersionViewModel(Navigation, background, button, txt, frame, border);
        }

    }
}