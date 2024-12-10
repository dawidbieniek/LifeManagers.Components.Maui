namespace LifeManagers.Components.Maui.Initialization;

/// <summary>
/// Interface for changing loading details text inside other methods. Just pass it as parameter to some method inside <see cref="InitializationPageBase.InitializeApplication"/>
/// </summary>
public interface IInitializationPage
{
    void ChangeDetailsText(string value);
}
