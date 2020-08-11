# How to work with EventToCommandBehavior in Xamarin.Forms (SfSchedule)

You can turn the Event to Command in Xamarin.Forms [SfSchedule](https://help.syncfusion.com/xamarin/scheduler/getting-started) by using [Behaviours](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/behaviors/).

Refer to the [online user guide documentation](https://docs.microsoft.com/en-us/samples/xamarin/xamarin-forms-samples/behaviors-eventtocommandbehavior/) for converting the Event to Command in Schedule for[MonthInlineAppointmentTapped](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.MonthInlineAppointmentTappedEventArgs.html)event.

You can also refer the following article.

https://www.syncfusion.com/kb/11860/how-to-work-with-eventtocommandbehavior-in-xamarin-forms-sfschedule


**C#**

Command for the **MonthInlineAppointmentTapped**  event of  **SfSchedule**  defined in  **ViewModel**.

``` c#
public class SchedulerViewModel : INotifyPropertyChanged
{
    private Command<MonthInlineAppointmentTappedEventArgs> monthInlineAppointmentTappedCommand;
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
        MonthInlineAppointmentTappedCommand = new Command<MonthInlineAppointmentTappedEventArgs>(OnMonthInlineAppointmentTapped);
    }
   private void OnMonthInlineAppointmentTapped(MonthInlineAppointmentTappedEventArgs obj)
    {
        if(obj.Appointment != null)
        App.Current.MainPage.DisplayAlert("", (obj.Appointment as Meeting).EventName.ToString(), "OK");
        else
            App.Current.MainPage.DisplayAlert("","No Event", "OK");
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```
**XAML**

Setting the **EventToCommandBehaviour** class to the **SfSchedule.Behaviours**.

``` xml
<syncfusion:SfSchedule x:Name="schedule" ScheduleView="MonthView" DataSource="{Binding Meetings}" ShowAppointmentsInline="true" >
    <syncfusion:SfSchedule.Behaviors>
        <local:EventToCommandBehavior EventName="MonthInlineAppointmentTapped" Command="{Binding MonthInlineAppointmentTappedCommand}" />
    </syncfusion:SfSchedule.Behaviors>
    <syncfusion:SfSchedule.AppointmentMapping>
        <syncfusion:ScheduleAppointmentMapping
	SubjectMapping="EventName" 
	ColorMapping="Color"
	StartTimeMapping="From"
	EndTimeMapping="To">
        </syncfusion:ScheduleAppointmentMapping>
    </syncfusion:SfSchedule.AppointmentMapping>
</syncfusion:SfSchedule>
```
**Output**

![EventToCommandSchedule](https://github.com/SyncfusionExamples/eventtocommand-behavior-schedule-xamarin/blob/master/ScreenShot/EventToCommandSchedule.gif)
