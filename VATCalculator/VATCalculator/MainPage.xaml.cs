using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace VATCalculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            
            eightPercent.Clicked += (s,e) => CalculateVat(8);
            twelvePercent.Clicked += (s, e) => CalculateVat(12);
            twentyFivePercent.Clicked += (s, e) => CalculateVat(25);
        }

        void CalculateVat(double vat)
        {
            double amount;
            if (!(Double.TryParse(input.Text, out amount) && amount > 0))
            {
                inputError.Text = "Fyll i ett belopp";
                return;
            }
                     
            inputAmount.Text = input.Text + " SEK";
            vatRate.Text = vat + "%";           
            calculatedAmount.Text = CalculateExcludeVat(amount, vat);
            calculatedVat.Text = CalculateVat(amount, vat);
            inputError.Text = string.Empty;
        }

        private string CalculateExcludeVat(double amount, double vat)
        {
            double amountExcludedVat = 100 / (100 + vat) * amount;
            return amountExcludedVat.ToString("0.00") + " SEK";
        }

        private string CalculateVat(double amount, double vat)
        {
            double vatAmount = (1 - 100 / (100 + vat)) * amount;
            return vatAmount.ToString("0.00") + " SEK";
        }
    }
}