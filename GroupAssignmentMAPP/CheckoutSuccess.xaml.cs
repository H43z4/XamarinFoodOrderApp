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
	public partial class CheckoutSuccess : ContentPage
	{
		App app = (App)Application.Current;
		public CheckoutSuccess()
		{

			InitializeComponent();

			app.Checkedout = true;

			lblDeliveryType.Text = app.DeliveryType; //Setting label to show selected delivery type
			if(app.DeliveryType == "Delivery Type: Delivery")
			{
				//Generating QR code information if DeliveryType is delivery
				string Names = "Pizzas: ";
				string Sizes = "Size: ";
				foreach (Pizza pizza in app.cart)
				{
					//Getting names and sizes for each pizza
					Names += pizza.Name + ", ";
					Sizes += pizza.Size + ", ";
				}
				string FinalBarcode = Names + "\n" + Sizes + "\n" + "Grand Total: " + app.GrandTotalGlobal; //Adding text data to barcode
				Barcode.BarcodeValue = FinalBarcode;
				//DisplayAlert("Test", FinalBarcode, "Ok"); //Test Code to check barcode
				Barcode.IsVisible = false; //Displaying barcode
			}
			else
			{
				Barcode.IsVisible = false; //Not displaying barcode if DeliveryType is takeaway
			}
			app.cart.Clear(); //Clearing the cart after checkout
		}

		private async void PizzaRating_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PizzaRating()); //Navigation
		}

		private async void btnAbout_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AboutPage()); //Navigation
		}
	}
}