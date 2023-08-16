using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroupAssignmentMAPP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountPage : ContentPage
	{
		App app = (App)Application.Current;
		public AccountPage()
		{
			InitializeComponent();
		}

		private async void btnRegister_Clicked(object sender, EventArgs e)
		{
			Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

			if (txtAddress.Text == null || txtConfirmPassword.Text == null || txtContactNumber == null || txtEmail.Text == null || txtFirstname.Text == null || txtPassword.Text == null || txtSurname.Text == null)
			{
				await DisplayAlert("Invalid Data", "Please enter data in all fields", "Ok");
				return;
			}

			if (string.IsNullOrWhiteSpace(txtEmail.Text))
			{
				await DisplayAlert("Invalid Data", "Please enter a corrent email address", "Ok");
				txtEmail.Text = "";
				return;
			}

			if ( txtPassword.Text != txtConfirmPassword.Text ){ //Checking if both passwords match
				await DisplayAlert("Passwords don't match", "Passwords don't match, please try again!", "Ok"); 
			}
			else
			{
				Person newPerson = new Person(); //Creating a Person object
				newPerson.Firstname = txtFirstname.Text; //Assigning object variables with user input
				newPerson.Surname = txtSurname.Text;
				newPerson.Address = txtAddress.Text;
				newPerson.ContactNumber = txtContactNumber.Text;
				newPerson.Password = txtPassword.Text;
				newPerson.Email = txtEmail.Text;

				PeopleDatabase DatabaseInstance = new PeopleDatabase();
				DatabaseInstance.SavePerson(newPerson); //Saving person in database

				await DisplayAlert("Registered!", "You have registered and are successfully logged in!", "Ok");

				app.LoggedIn = true; //Automatically logging in user after registration

				await Navigation.PushAsync(new MainPage()); //Navigating to MainPage



			}
		}
		private async void btnLogin_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new LoginPage()); //Navigating to LoginPage
		}

		private async void btnAbout_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AboutPage()); //Navigating to AboutPage
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