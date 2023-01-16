using APPHanzaBebe.Models;
using APPHanzaBebe.ViewModels;
using Plugin.LocalNotification;

namespace APPHanzaBebe.Views;

public partial class PacientListPage : ContentPage
{
    private PacientListPageViewModel _viewMode;
    public PacientListPage(PacientListPageViewModel viewModel)
    {
        InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetPacientListCommand.Execute(null);
    }
    public void ScheduleNotification(PacientModel pacient)
    {
        var time = DateTime.Now;
        if (time == pacient.AppointmentDate.AddHours(-1))
        {
            var request = new NotificationRequest
            {
                Title = "Urmeaza o programare",
                Description = $"Urmeaza o programare cu {pacient.FullName} in o ora",
                Schedule = new NotificationRequestSchedule
                { 
                    NotifyTime = DateTime.Now.AddSeconds(1) 
                }   
            };

            LocalNotificationCenter.Current.Show(request);
        }
    }
}