using APPHanzaBebe.Services;
using APPHanzaBebe.ViewModels;
using APPHanzaBebe.Views;

namespace APPHanzaBebe;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<IPacientService, PacientService>();


        //Views Registration
        builder.Services.AddSingleton<PacientListPage>();
        builder.Services.AddTransient<AddUpdatePacientDetail>();


        //View Modles 
        builder.Services.AddSingleton<PacientListPageViewModel>();
        builder.Services.AddTransient<AddUpdatePacientDetailViewModel>();


        return builder.Build();
    }
}

