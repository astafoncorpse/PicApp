using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp.Pages
{

    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            EntryPinMessage.Text = Preferences.ContainsKey("Pin") ? "Введите PIN" : "Придумайте PIN";

        }
        private async void OnEnterPinAsync(object sender, EventArgs e)
        {
            // нехорошо запихивать сюда логику, стоит перенести ее в другое место. но пусть пока будет так.. 
            if (!Preferences.ContainsKey("Pin"))
            {
                //Не будем проверять ПИН на пустоту и выполнять прочие проверки
                Preferences.Set("Pin", EnteredPin.Text);
                await DisplayAlert("Saved", "PIN " + EnteredPin.Text + " saved", "OK");
                EntryPinMessage.Text = "Введите PIN";
            }
            else if (Preferences.Get("Pin", "") == EnteredPin.Text)
            {
                EnteredPin.Text = "";
                await Navigation.PushAsync(new ImageList());
            }
            else
            {
                if (EnteredPin.Text == "resetpin" + DateTime.Now.ToString("MM"))
                {
                    await DisplayAlert("PIN Reset", "Create a new PIN", "OK");
                    Preferences.Remove("Pin");
                    EntryPinMessage.Text = "Создайте PIN";
                }
                else
                {
                    await DisplayAlert("Incorrect", "Incorrect PIN Entered", "OK");
                }
            }
            EnteredPin.Text = "";
        }
    }
}
