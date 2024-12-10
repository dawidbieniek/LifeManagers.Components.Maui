namespace LifeManagers.Components.Maui.Initialization;

public abstract partial class InitializationPageBase : ContentPage
{
    private string _loadingDetailsText = "ssaaa";

    public InitializationPageBase()
    {
        InitializeComponent();

        Appearing += async (s, e) => await InitializeApplication();
    }
    public string LoadingDetailsText
    {
        get => _loadingDetailsText;
        set
        {
            if (_loadingDetailsText != value)
            {
                _loadingDetailsText = value;
                OnPropertyChanged(nameof(LoadingDetailsText));
            }
        }
    }

    public void ChangeDetailsText(string value)
    {
        LoadingDetailsText = value;
    }

    protected abstract Task InitializeApplication();

    protected void NavigateToPage(Page page)
    {
        if (Application.Current is null)
            throw new InvalidOperationException($"{nameof(InitializationPageBase)} can only be used in maui application context");

        Application.Current!.Windows[0].Page = page;
    }
}