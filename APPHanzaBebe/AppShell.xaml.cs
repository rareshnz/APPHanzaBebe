using APPHanzaBebe.Views;


namespace APPHanzaBebe;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AddUpdatePacientDetail), typeof(AddUpdatePacientDetail));
    }
}