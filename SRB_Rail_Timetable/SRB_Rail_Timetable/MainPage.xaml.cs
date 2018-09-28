using Rg.Plugins.Popup.Services;
using SRB_Rail_Timetable.Logic;
using SRB_Rail_Timetable.Models;
using SRB_Rail_Timetable.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SRB_Rail_Timetable
{
	public partial class MainPage : ContentPage
	{
        #region Constructor

        public MainPage()
		{
			InitializeComponent();
		}

        #endregion

        #region Button Clicked Events

        // Search Button Clicked
        void Search_Clicked(object sender, EventArgs e)
        {
            // Validate Data
            if (!Validate())
            {
                return;
            }

            // Get URL
            var URL = GenerateURL();

            // Get timetable
            var timetable = WebHelper.ScrapTrainsTimetable(URL, datePicker.Date);

            // Create timetable page
            Navigation.PushAsync(new TimetablePage($"{fromLabel.Text} - {toLabel.Text}" , timetable));
        }

        // Reverse Button Clicked
        void ReverseButton_Clicked(object sender, EventArgs e)
        {
            var fromValue = fromLabel.Text;
            fromLabel.Text = toLabel.Text;
            toLabel.Text = fromValue;
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Generates web page url based on user data.
        /// </summary>
        string GenerateURL()
        {
            // Generate URL from data
            var URL = WebHelper.GenerateTimetableUrl
                (
                fromLabel.Text, TimetableEntryHelper.StationsAndIds[fromLabel.Text],
                toLabel.Text, TimetableEntryHelper.StationsAndIds[toLabel.Text],
                new DateTime
                    (
                        datePicker.Date.Year,
                        datePicker.Date.Month,
                        datePicker.Date.Day,
                        timePicker.Time.Hours,
                        timePicker.Time.Minutes,
                        0
                    )
                );

            return URL;
        }

        /// <summary>
        /// Validates data.
        /// </summary>
        /// <returns>Was validation successful</returns>
        bool Validate()
        {
            // Check if user set starting and ending stations
            var placeholder = (string)Application.Current.Resources["stationPlaceholder"];
            if (fromLabel.Text == placeholder || toLabel.Text == placeholder)
            {
                DisplayAlert("", "You have to select stations.", "OK");
                return false;
            }

            // Check if we entered same stations in both fields
            if (fromLabel.Text == toLabel.Text)
            {
                DisplayAlert("", "Start and end station must be different.", "OK");
                return false;
            }

            return true;
        }

        #endregion

        #region Tapped Events (Selector)

        void FromEntry_Tapped(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new StationChooserPopupPage(fromLabel));
        }

        void ToEntry_Tapped(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new StationChooserPopupPage(toLabel));
        }

        #endregion
    }
}
