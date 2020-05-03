using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using Good_Car.Models;
using Good_Car.ViewModels;
using System.Threading.Tasks;

namespace Good_Car.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        /*private int thePrice;

        public int ThePrice
        {
            get { return thePrice; }
            set
            {
                thePrice = value;
                OnPropertyChanged(nameof(ThePrice)); // Notify that there was a change on this property
            }
        }
        private bool going = true;*/


        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            /*BindingContext = this;
            ThePrice = 0;*/
        }
        protected override async void OnAppearing()
        {
            ((NewItemViewModel)this.BindingContext).Calculate = true;
            try
            {
                var lastlocation = await Geolocation.GetLastKnownLocationAsync();
                var distance = 0.0544;
                //Location sanFrancisco = new Location(37.783333, -122.416667);

                if (lastlocation != null)
                {
                    while (((NewItemViewModel)this.BindingContext).Calculate == true)
                    {
                        await Task.Delay(1000);
                        var currentlocation = await Geolocation.GetLastKnownLocationAsync();
                        //distance += 1;
                        distance += Location.CalculateDistance(lastlocation, currentlocation, DistanceUnits.Kilometers);
                        var distanceRound = Math.Round(distance, 2);
                        string distanceString = distanceRound.ToString();
                        //string distanceString = String.Format("{0:0.00}", distance.ToString());
                        ((NewItemViewModel)this.BindingContext).Name = distanceString;
                        lastlocation = currentlocation;
                    }
                    //double miles = Location.CalculateDistance(location, sanFrancisco, DistanceUnits.Kilometers);

                    //Console.WriteLine(miles);
                    //string miles2 = miles.ToString();
                    //((NewItemViewModel)this.BindingContext).Name = miles2;
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        async void OnEndClicked(object sender, EventArgs e)
        {
            //((NewItemViewModel)this.BindingContext).Calculate == false;
            await Navigation.PopModalAsync();
            //await Navigation.PopModalAsync(new NavigationPage(new NewItemPage()));
        }

        /*async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }*/

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}