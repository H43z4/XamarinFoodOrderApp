using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroupAssignmentMAPP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		App app = (App)Application.Current; //Getting global variables from App.cs
		public LoginPage()
		{
			InitializeComponent();
		}

		private async void btnLogin_Clicked(object sender, EventArgs e)
		{
			PeopleDatabase PPLDB = new PeopleDatabase(); //Creating database connection
			string email = txtEmail.Text;
			string password = txtPassword.Text;
			var success = PPLDB.CheckLogin(email, password); //Checking if email and password match data in database

			if (success != null) //If record is retrieved, user is logged in
			{
				await DisplayAlert("Success", "Successfully Logged In", "Ok"); //DisplayAlert for successful login
				await Navigation.PushAsync(new MainPage()); //Navigation to MainPage
				app.LoggedIn = true; //Setting LoggedIn to true
			}
		}

		private async void btnAbout_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AboutPage()); //Navigation
		}
        private async void btnAccount_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountPage()); //Navigation
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopAsync(true);
        }
        private async void OnCartTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage());
        }
    }
}