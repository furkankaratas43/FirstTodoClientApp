using FirstTodoClientApp.DataServices;
using FirstTodoClientApp.Pages;

namespace FirstTodoClientApp;

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

		builder.Services.AddSingleton<IRestDataService, RestDataService>();

		//builder.Services.AddHttpClient<IRestDataService, RestDataService>();

        builder.Services.AddSingleton<MainPage>();

		builder.Services.AddTransient<ManageTodoPage>();

		return builder.Build();
	}
}
