using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SRB_Rail_Timetable.Logic;
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
                var text = new TranslateExtension { Text = "FirstClass" }.ProvideValue() as string;
                tarrifesLayout.Children.Add(new Label { Text = text });
            }
            if (tarrifes.HasFlag(Tarrifes.SecondClass))
            {
                var text = new TranslateExtension { Text = "SecondClass" }.ProvideValue() as string;
                tarrifesLayout.Children.Add(new Label { Text = text });
            }
            if (tarrifes.HasFlag(Tarrifes.Coushete))
            {
                var text = new TranslateExtension { Text = "Coushete" }.ProvideValue() as string;
                tarrifesLayout.Children.Add(new Label { Text = text });
            }
            if (tarrifes.HasFlag(Tarrifes.ObligatoryReservation))
            {
                var text = new TranslateExtension { Text = "ObligatoryReservation" }.ProvideValue() as string;
                tarrifesLayout.Children.Add(new Label { Text = text });
            }
            if (tarrifes.HasFlag(Tarrifes.Bicycle))
            {
                var text = new TranslateExtension { Text = "Bicycle" }.ProvideValue() as string;
                tarrifesLayout.Children.Add(new Label { Text = text });
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
            var timeStr = new TranslateExtension { Text = "Time" }.ProvideValue() as string;
            timeLabel.Text = timeStr + " " + entry.Departure.ToString("hh\\:mm - ") + entry.Arrival.ToString("hh\\:mm");

            // Late
            ChangeLateLabelColor(entry.Late);
            var lateStr = new TranslateExtension { Text = "LatePlus" }.ProvideValue() as string;
            lateLabel.Text = lateStr + " " + entry.Late.ToString("hh\\:mm");

            // Travel Time
            var travelStr = new TranslateExtension { Text = "Travels" }.ProvideValue() as string;
            travelLabel.Text = travelStr + " " + entry.TravelTime.ToString("hh\\:mm");
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
            string stringId;
            
            // Set train type
            switch (trainEntry.Type)
            {
                case TrainType.FastTrain: stringId = "FastTrain"; break;
                case TrainType.InterCity: stringId = "InterCity"; break;
                case TrainType.RegioVoz: stringId = "RegioVoz"; break;
                default: stringId = "LocalTrain"; break;
            }

            // Set train number
            string type = new TranslateExtension { Text = stringId }.ProvideValue() as string;

            return type + " " + trainEntry.TrainNumber;
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