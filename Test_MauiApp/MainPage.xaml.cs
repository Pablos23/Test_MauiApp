using Test_MauiApp.ViewModels;

namespace Test_MauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void OnRemainingItemsThresholdReached(object sender, EventArgs e)
        {

        }
    }

}
