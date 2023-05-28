using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mi_Macro.model;
using ZXing.Net.Mobile.Forms;

namespace Mi_Macro.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VDetailsMovement : ContentPage
    {
        ZXingBarcodeImageView qr;
        public VDetailsMovement(Movements movements)
        {
            InitializeComponent();
            lbLine.Text = movements.line;
            lbDate.Text = movements.date;
            lbTime.Text = movements.time;
            lbAmount.Text = "$" + movements.amount.ToString();
            generateCode(movements.codeQR);
        }

        private void generateCode(string codeQR)
        {
            qr = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            qr.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            qr.BarcodeOptions.Width = 500;
            qr.BarcodeOptions.Height = 500;
            qr.BarcodeValue = codeQR;
            stkQR.Children.Add(qr);

            fQR.BorderColor = Color.FromHex("#009BAA");
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}