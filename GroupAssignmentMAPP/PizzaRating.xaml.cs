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
    public partial class PizzaRating : ContentPage
    {
        private int _rating;

        public PizzaRating()
        {
            InitializeComponent();
        }
        private void OnStarTapped(object sender, EventArgs e)
        {
            var starImage = (Image)sender;
            var starNumber = int.Parse(starImage.ClassId);

            if (_rating == starNumber)
            {
                // If the user taps the same star twice, reset the rating
                _rating = 0;
                UpdateStarImages();
            }
            else
            {
                _rating = starNumber;
                UpdateStarImages();
            }
        }

        private void UpdateStarImages()
        {
            star1.Source = _rating >= 1 ? "star_filled.png" : "star_empty.png";
            star2.Source = _rating >= 2 ? "star_filled.png" : "star_empty.png";
            star3.Source = _rating >= 3 ? "star_filled.png" : "star_empty.png";
            star4.Source = _rating >= 4 ? "star_filled.png" : "star_empty.png";
            star5.Source = _rating >= 5 ? "star_filled.png" : "star_empty.png";
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            var feedback = txtFeedbackEntry.Text;

            // Display a success message to the user
            //await DisplayAlert("Thank you!", "Your rating and feedback have been submitted.", "OK").ConfigureAwait(true);

            // Clear the rating and feedback input field
            _rating = 0;
            txtFeedbackEntry.Text = "";
            UpdateStarImages();
            await Navigation.PushAsync(new MainPage()); //Navigation

        }
    }
}