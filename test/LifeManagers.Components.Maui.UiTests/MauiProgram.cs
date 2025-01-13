using LifeManagers.Components.Maui.UiTests.Backups;
using LifeManagers.Components.Maui.UiTests.Initialization;

using Microsoft.Extensions.Logging;

namespace LifeManagers.Components.Maui.UiTests
{
    public static class MauiProgram
    {
        public static ServiceProvider ServiceProvider { get; private set; } = default!;

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiComponentsApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Adds initialization page
            //builder.Services.AddSingleton<InitializationPage>();
            builder.Services.AddSingleton<App>(sp => new (sp.GetService<InitializationPage>()));
            builder.Services.AddTransient<BackupPage>();
            builder.Services.RegisterMauiComponentsDataServices(options => options.WithDataDirectoryPath(FileSystem.AppDataDirectory));

            ServiceProvider = builder.Services.BuildServiceProvider();
            return builder.Build();
        }
    }
}