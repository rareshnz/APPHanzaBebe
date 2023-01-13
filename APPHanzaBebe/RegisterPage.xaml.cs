using APPHanzaBebe.ViewModels;


namespace APPHanzaBebe;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel(Navigation);
    }
}