using APPHanzaBebe.ViewModels;

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
}