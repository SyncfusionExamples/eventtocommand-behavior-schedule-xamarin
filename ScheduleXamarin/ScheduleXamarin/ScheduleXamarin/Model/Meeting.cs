using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ScheduleXamarin
{
    public class Meeting : INotifyPropertyChanged
    {
        private string eventName;
        private Color color;
        private DateTime to;
        private DateTime from;

        public event PropertyChangedEventHandler PropertyChanged;

        public string EventName
        {
            get
            {
                return eventName;
            }

            set
            {
                eventName = value;
                this.OnPropertyChanged("EventName");
            }
        }
        public DateTime From
        {
            get
            {
                return from;
            }

            set
            {
                from = value;
                this.OnPropertyChanged("From");
            }
        }
        public DateTime To
        {
            get
            {
                return to;
            }

            set
            {
                to = value;
                this.OnPropertyChanged("To");
            }
        }
        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
                this.OnPropertyChanged("Color");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
