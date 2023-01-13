using APPHanzaBebe.ViewModels;

namespace APPHanzaBebe.Views;

public partial class AddUpdatePacientDetail : ContentPage
{
    public AddUpdatePacientDetail(AddUpdatePacientDetailViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}