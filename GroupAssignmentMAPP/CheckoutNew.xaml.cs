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
	public partial class CheckoutNew : TabbedPage
	{
		App app = (App)Application.Current; //Getting global variables from App.cs
		public CheckoutNew()
		{
			InitializeComponent();
			if (app.LoggedIn) //Checking if user is logged in
			{
				//Not displaying fields when user is logged in
				txtFirstname.IsVisible = false;
				txtSurname.IsVisible = false;
				txtAddress.IsVisible = false;
				txtContactNumber.IsVisible = false;
				txtEmail.IsVisible = false;
				txtFirstname2.IsVisible = false;
				txtSurname2.IsVisible = false;
				txtEmail2.IsVisible = false;
				lblDel.IsVisible = false ;
                lblDel2.IsVisible = false;
				frmFirstname.IsVisible = (txtFirstname.IsVisible);
				frmSurname.IsVisible=(txtSurname.IsVisible);
				frmAddress.IsVisible=(txtAddress.IsVisible);
				frmContactNumber.IsVisible = (txtContactNumber.IsVisible);
				frmEmail.IsVisible = (txtEmail.IsVisible);
				frmEmail2.IsVisible = (txtEmail2.IsVisible);
				frmFirstname2.IsVisible = (txtFirstname2.IsVisible);
				frmSurname2.IsVisible =(txtSurname2.IsVisible);
            }
			else
			{
				//Displaying fields when user is logged in
				txtFirstname.IsVisible = true;
				txtSurname.IsVisible = true;
				txtAddress.IsVisible = true;
				txtContactNumber.IsVisible = true;
				txtEmail.IsVisible = true;
				txtFirstname2.IsVisible = true;
				txtSurname2.IsVisible = true;
				txtEmail2.IsVisible = true;
                lblDel.IsVisible = true;
                lblDel2.IsVisible = true;
                frmFirstname.IsVisible = (txtFirstname.IsVisible);
                frmSurname.IsVisible = (txtSurname.IsVisible);
                frmAddress.IsVisible = (txtAddress.IsVisible);
                frmContactNumber.IsVisible = (txtContactNumber.IsVisible);
                frmEmail.IsVisible = (txtEmail.IsVisible);
                frmEmail2.IsVisible = (txtEmail2.IsVisible);
                frmFirstname2.IsVisible = (txtFirstname2.IsVisible);
                frmSurname2.IsVisible = (txtSurname2.IsVisible);
            }

		}

		private async void btnCheckoutTakeaway_Clicked(object sender, EventArgs e)
		{

			if( !app.LoggedIn && (txtEmail2.Text == null || txtFirstname2.Text == null || txtSurname2.Text == null) )
			{
				await DisplayAlert("Invalid Data", "Please enter data in all fields", "Ok");
				return;
			}

			//Setting DeliveryType as Takeaway
			app.DeliveryType = "Delivery Type: Takeaway";
			//Navigation
			await Navigation.PushAsync(new CheckoutSuccess());
		}

		private async void btnCheckoutDelivery_Clicked(object sender, EventArgs e)
		{
			if(!app.LoggedIn && (txtAddress.Text == null || txtContactNumber.Text == null || txtEmail.Text == null || txtFirstname.Text == null || txtSurname.Text == null))
			{
				await DisplayAlert("Invalid Data", "Please enter data in all fields", "Ok");
				return;
			}
			//Setting DeliveryType as Delivery
			app.DeliveryType = "Delivery Type: Delivery";
			//Navigation
			await Navigation.PushAsync(new CheckoutSuccess());
		}

		private  async void btnAbout_Clicked(object sender, EventArgs e)
		{
			//Navigation
			await Navigation.PushAsync(new AboutPage());
		}
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopAsync(true);
        }
    }
}