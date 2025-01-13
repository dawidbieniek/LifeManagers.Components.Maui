using LifeManagers.Components.Maui.Initialization;

namespace LifeManagers.Components.Maui.UiTests.Initialization;

public class InitializationPage : InitializationPageBase
{
    protected override async Task InitializeApplication()
    {
        for (int i = 5; i > 0; i--)
            await WaitAndDisplayWaitingMessage(i);

        NavigateToPage(new MainPage());
    }

    private async Task WaitAndDisplayWaitingMessage(int remaining)
    {
        LoadingDetailsText = $"waiting for something {remaining}s";
        await Task.Delay(1000);
    }
}