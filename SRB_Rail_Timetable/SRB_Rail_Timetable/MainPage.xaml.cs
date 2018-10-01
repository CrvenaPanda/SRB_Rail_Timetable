using Plugin.Multilingual;
using Rg.Plugins.Popup.Services;
using SRB_Rail_Timetable.Logic;
using SRB_Rail_Timetable.Models;
using SRB_Rail_Timetable.Resources;
using SRB_Rail_Timetable.Views;
using System;
using System.Globalization;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace SRB_Rail_Timetable
{
	public partial class MainPage : ContentPage
	{
        #region Constructor

        public MainPage()
		{
			InitializeComponent();

            // Change language
            if (App.IsSerbian)
            {
                langToolbarItem.Text = "SRB";
            }
		}

        #endregion

        #region Button Clicked Events

        // Search Button Clicked
        void Search_Clicked(object sender, EventArgs e)
        {
            // Check internet connection
            if (!CrossConnectivity.Current.IsConnected)
            {
                var messsage = new TranslateExtension { Text = "NoInternet" }.ProvideValue() as string;
                DisplayAlert("", messsage, "OK");
                return;
            }

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
            var placeholder = new TranslateExtension { Text = "ClickTo" }.ProvideValue() as string;

            if (fromLabel.Text == placeholder || toLabel.Text == placeholder)
            {
                var translator = new TranslateExtension { Text = "SelectStations" };
                DisplayAlert("", (string)translator.ProvideValue(), "OK");
                return false;
            }

            // Check if we entered same stations in both fields
            if (fromLabel.Text == toLabel.Text)
            {
                var translator = new TranslateExtension { Text = "SelectDiffStations" };
                DisplayAlert("", (string)translator.ProvideValue(), "OK");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Upadates views language based on current culture info.
        /// </summary>
        void UpdateViewsLanguage()
        {
            fromLabelName.Text = new TranslateExtension { Text = "From" }.ProvideValue() as string;
            fromLabel.Text = new TranslateExtension { Text = "ClickTo" }.ProvideValue() as string;
            toLabelName.Text = new TranslateExtension { Text = "To" }.ProvideValue() as string;
            toLabel.Text = new TranslateExtension { Text = "ClickTo" }.ProvideValue() as string;
            
            dateLabel.Text = new TranslateExtension { Text = "Date" }.ProvideValue() as string;
            timeLabel.Text = new TranslateExtension { Text = "Time" }.ProvideValue() as string;

            searchButton.Text = new TranslateExtension { Text = "Search" }.ProvideValue() as string;
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

        #region Toolbar Events

        void ChangeLanguage_Clicked(object sender, EventArgs e)
        {
            var item = sender as ToolbarItem;

            // Change culture info
            if (CrossMultilingual.Current.CurrentCultureInfo.Name == App.Serbian_Language)
            {
                App.IsSerbian = false; // this property will save data
                item.Text = "ENG";
            }
            else
            {
                App.IsSerbian = true;
                item.Text = "SRB";
            }

            // Update views language
            UpdateViewsLanguage();
        }

        void About_Clicked(object sender, EventArgs e)
        {
            // Open About page
            Navigation.PushAsync(new AboutPage());
        }

        #endregion
    }
}
