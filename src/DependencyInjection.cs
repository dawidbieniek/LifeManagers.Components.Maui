using CommunityToolkit.Maui;

using LifeManagers.Components.Maui.Services;
using LifeManagers.Data;

namespace LifeManagers.Components.Maui;

public static class DependencyInjection
{
    /// <summary>
    /// Configures the MauiAppBuilder to use the Maui Components setup.
    /// </summary>
    /// <typeparam name="TApp"> The type of the application class. </typeparam>
    /// <param name="builder"> The MauiAppBuilder instance to configure. </param>
    /// <returns> The configured MauiAppBuilder instance. </returns>
    /// <remarks>
    /// This method replaces the default <b> UseMaui&lt;App&gt;() </b> that is commonly present in
    /// the MauiApp class. It sets up the Maui builder with the necessary components for a Maui application.
    /// </remarks>
    public static MauiAppBuilder UseMauiComponentsApp<TApp>(this MauiAppBuilder builder) where TApp : class, IApplication
    {
        builder
            .UseMauiApp<TApp>()
            .UseMauiCommunityToolkit();
        return builder;
    }

    /// <summary>
    /// Registers necessary data services.
    /// </summary>
    /// <remarks>
    /// Don't use when data services are registered through <see
    /// cref="Data.DependencyInjection.RegisterDataServices{T}(IServiceCollection, Action{DataServicesOptionsBuilder})"/>
    /// </remarks>
    public static IServiceCollection RegisterMauiComponentsDataServices(this IServiceCollection services, Action<DataServicesOptionsBuilder> options)
    {
        services
            .RegisterDataBackupServices(options)
            .AddTransient<ManualBackupService>();
        return services;
    }
}