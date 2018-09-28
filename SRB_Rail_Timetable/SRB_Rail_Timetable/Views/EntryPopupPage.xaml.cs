using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SRB_Rail_Timetable.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SRB_Rail_Timetable.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntryPopupPage : PopupPage
	{
        #region Constructors

        public EntryPopupPage (TimetableEntry entry, string destinationTitle)
		{
            if (entry == null)
            {
                PopupNavigation.Instance.PopAsync();
                return;
            }

			InitializeComponent ();

            // Set data
            titleLabel.Text = destinationTitle;
            SetEntryData(entry);
            AddTarrifesLabels(entry.Tarrifes);
            SetNote(entry.Note);
		}

        #endregion

        #region Data Methods

        /// <summary>
        /// Add tarrifes labels to page.
        /// </summary>
        void AddTarrifesLabels(Tarrifes tarrifes)
        {
            if (tarrifes.HasFlag(Tarrifes.FirstClass))
            {
                tarrifesLayout.Children.Add(new Label { Text = "FIRST CLASS" });
            }
            if (tarrifes.HasFlag(Tarrifes.SecondClass))
            {
                tarrifesLayout.Children.Add(new Label { Text = "SECOND CLASS" });
            }
            if (tarrifes.HasFlag(Tarrifes.Coushete))
            {
                tarrifesLayout.Children.Add(new Label { Text = "COUSHETE" });
            }
            if (tarrifes.HasFlag(Tarrifes.ObligatoryReservation))
            {
                tarrifesLayout.Children.Add(new Label { Text = "OBLIGATORY RESERVATION" });
            }
            if (tarrifes.HasFlag(Tarrifes.Bicycle))
            {
                tarrifesLayout.Children.Add(new Label { Text = "BICYCLE" });
            }
        }

        /// <summary>
        /// Main method for setting data in view elements.
        /// </summary>
        void SetEntryData(TimetableEntry entry)
        {
            // Date
            dateLabel.Text = entry.Departure.ToString("d MMM, yyyy");

            // Type and Number
            trainLabel.Text = ExtractTrainTypeAndNumber(entry);

            // Time
            timeLabel.Text = "TIME:  " + entry.Departure.ToString("hh\\:mm - ") + entry.Arrival.ToString("hh\\:mm");

            // Late
            ChangeLateLabelColor(entry.Late);
            lateLabel.Text = "LATE:  " + entry.Late.ToString("hh\\:mm");

            // Travel Time
            travelLabel.Text = "TRAVEL:  " + entry.TravelTime.ToString("hh\\:mm");
        }

        /// <summary>
        /// Changes late label color if needed.
        /// </summary>
        void ChangeLateLabelColor(TimeSpan late)
        {
            if (late.TotalMinutes > 0)
            {
                lateLabel.TextColor = (Color)Application.Current.Resources["invalidTextColor"];
            }
        }

        /// <summary>
        /// Extracts string representation of train type and number.
        /// </summary>
        string ExtractTrainTypeAndNumber(TimetableEntry trainEntry)
        {
            string result;
            
            // Set train type
            switch (trainEntry.Type)
            {
                case TrainType.FastTrain: result = "FAST TRAIN"; break;
                case TrainType.InterCity: result = "INTER CITY"; break;
                case TrainType.RegioVoz: result = "REGIO VOZ"; break;
                default: result = "LOCAL"; break;
            }

            // Set train number
            result += (" " + trainEntry.TrainNumber);

            return result;
        }

        /// <summary>
        /// Set 'note' about entry if there is one.
        /// </summary>
        void SetNote(string note)
        {
            if (note.Length > 0)
            {
                noteLabel.Text = "* " + note;
            }
        }

        #endregion
    }
}