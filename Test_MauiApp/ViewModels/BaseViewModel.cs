using CommunityToolkit.Mvvm.ComponentModel;

namespace Test_MauiApp.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CommunityToolkit.Mvvm.ComponentModel.ObservableObject" />
    public partial class BaseViewModel :  ObservableObject
    {
        /// <summary>
        /// The is busy
        /// </summary>
        [ObservableProperty]
        private bool _isBusy;
    }

}
