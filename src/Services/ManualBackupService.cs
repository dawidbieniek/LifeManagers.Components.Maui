using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;

using LifeManagers.Data.Backup;

namespace LifeManagers.Components.Maui.Services;

public class ManualBackupService(BackupManager backupManager)
{
    private readonly BackupManager _backupManager = backupManager;

    private static readonly PickOptions FilePickerOptions = new()
    {
        PickerTitle = "Select database file",
    };

    public async Task LoadBackupFromFileAsyc()
    {
        FileResult? filePickerResult = await FilePicker.Default.PickAsync(FilePickerOptions);

        if (filePickerResult is not null)
        {
            if (filePickerResult.FileName.EndsWith("db3", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    _backupManager.ReplaceDatabaseFile(filePickerResult.FullPath);
                    await Toast.Make($"Backup loaded: {filePickerResult.FileName}").Show();
                }
                catch (Exception e)
                {
                    await Toast.Make($"Cannot load backup file ({e.Message})").Show();
                }
            }
            else
                await Toast.Make("Cannot load backup file").Show();
        }
    }

    public async Task MakeBackupAsync()
    {
        Stream stream = _backupManager.CreateBackupStream();

        FileSaverResult fileSaveResult = await FileSaver.Default.SaveAsync($"backup{DateTime.Today:yy-MM-dd}.db3", stream);
        if (fileSaveResult.IsSuccessful)
            await Toast.Make($"Backup created: {fileSaveResult.FilePath}").Show();
        else
            await Toast.Make($"Backup couldn't be created ({fileSaveResult.Exception.Message})").Show();
    }
}