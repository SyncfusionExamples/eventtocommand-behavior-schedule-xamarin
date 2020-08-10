using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ScheduleXamarin
{
    public class SchedulerViewModel : INotifyPropertyChanged
    {
        private Command<MonthInlineAppointmentTappedEventArgs> monthInlineAppointmentTappedCommand;
        private ObservableCollection<Meeting> meetings;

        public ObservableCollection<Meeting> Meetings
        {
            get
            {
                return meetings;
            }

            set
            {
                meetings = value;
                this.OnPropertyChanged("Meetings");
            }
        }
       
        public Command<MonthInlineAppointmentTappedEventArgs> MonthInlineAppointmentTappedCommand
        {
            get { return monthInlineAppointmentTappedCommand; }
            set
            {
                monthInlineAppointmentTappedCommand = value;
                this.OnPropertyChanged("MonthInlineAppointmentTappedCommand");
            }
        }
        public SchedulerViewModel ()
        {
            Meetings = new ObservableCollection<Meeting>();
            MonthInlineAppointmentTappedCommand = new Command<MonthInlineAppointmentTappedEventArgs>(OnMonthInlineAppointmentTapped);
            Meeting meeting = new Meeting();
            meeting.From = DateTime.Now.Date;
            meeting.To = meeting.From.AddHours(1);
            meeting.EventName = "Anniversary";
            meeting.Color = Color.Green;
            Meetings.Add(meeting);
        }
        private void OnMonthInlineAppointmentTapped(MonthInlineAppointmentTappedEventArgs obj)
        {
            if(obj.Appointment != null)
				App.Current.MainPage.DisplayAlert("", (obj.Appointment as Meeting).EventName.ToString(), "OK");
			else
				App.Current.MainPage.DisplayAlert("","No Event", "OK");
        }
        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Invoke method when property changed.
        /// </summary>
        /// <param name="propertyName">property name</param>
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
