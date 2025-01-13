using LifeManagers.Components.Maui.Services;
using LifeManagers.Components.Maui.UiTests.Backups;

namespace LifeManagers.Components.Maui.UiTests
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void GotoBackupPage(object sender, EventArgs e)
        {
            Application.Current!.Windows[0].Page = MauiProgram.ServiceProvider.GetRequiredService<BackupPage>();
        }
    }
}