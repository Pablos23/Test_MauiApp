using Test_MauiApp.ViewModels;

namespace Test_MauiApp;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}