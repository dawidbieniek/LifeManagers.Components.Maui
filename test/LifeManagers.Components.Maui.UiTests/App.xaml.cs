using LifeManagers.Components.Maui.UiTests.Initialization;

namespace LifeManagers.Components.Maui.UiTests;

public partial class App : Application
{
    private readonly Page? _startingPage;

    public App(InitializationPage? startingPage = null)
    {
        InitializeComponent();
        _startingPage = startingPage;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(_startingPage ?? new MainPage());
    }
}