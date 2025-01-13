using LifeManagers.Components.Maui.Services;

namespace LifeManagers.Components.Maui.UiTests.Backups;

public partial class BackupPage : ContentPage
{
    private readonly ManualBackupService _manualBackupService;

    public BackupPage(ManualBackupService manualBackupService)
    {
        _manualBackupService = manualBackupService;

        InitializeComponent();
    }

    private void LoadBackup(object sender, EventArgs e)
    {
        _manualBackupService.LoadBackupFromFileAsyc().Wait();
    }

    private void CreateBackup(object sender, EventArgs e)
    {
        _manualBackupService.MakeBackupAsync().Wait();
    }
}