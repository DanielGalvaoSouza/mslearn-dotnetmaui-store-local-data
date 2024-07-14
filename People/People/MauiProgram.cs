namespace People;

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

		// TODO: Add statements for adding PersonRepository as a singleton

		builder.Services.AddSingleton<Models.PersonRepository>(
			s => ActivatorUtilities.CreateInstance<Models.PersonRepository>(s, FileAccessHelper.GetLocalFilePath())
		);
			
        return builder.Build();
	}
}
