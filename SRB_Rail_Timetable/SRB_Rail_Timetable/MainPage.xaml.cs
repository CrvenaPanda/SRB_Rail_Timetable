using Plugin.Multilingual;
using Rg.Plugins.Popup.Services;
using SRB_Rail_Timetable.Logic;
using SRB_Rail_Timetable.Models;
using SRB_Rail_Timetable.Resources;
using SRB_Rail_Timetable.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
        bool Validate() // FIXME: there is a bug somewhere when using different languages
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

        #region Toolbar

        void ChangeLanguage_Clicked(object sender, EventArgs e)
        {
            var item = sender as ToolbarItem;

            // Change culture info
            if (CrossMultilingual.Current.CurrentCultureInfo.Name == "sr-Latn-RS")
            {
                CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("en");
                AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
                item.Text = "ENG";
            }
            else
            {
                CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("sr-Latn-RS");
                AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
                item.Text = "SRB";
            }

            // Update views language
            UpdateViewsLanguage();
        }

        #endregion
    }
}
