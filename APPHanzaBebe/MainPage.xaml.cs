using APPHanzaBebe.ViewModels;

namespace APPHanzaBebe;

public partial class MainPage : ContentPage
{


	public MainPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel(Navigation);
	}

}

