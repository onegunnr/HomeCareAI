namespace HomeCareAI.Views;

public partial class TasksPage : ContentPage
{
	public TasksPage()
	{
		InitializeComponent();
	}

    private async void OnScanStubClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Camera Stub", "Pretend we just scanned a label.", "OK");
    }
}