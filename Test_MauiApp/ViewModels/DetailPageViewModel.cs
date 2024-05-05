using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Test_MauiApp.Models;

namespace Test_MauiApp.ViewModels
{
    /// <summary>
    /// DetailPageViewModel
    /// </summary>
    /// <seealso cref="Test_MauiApp.ViewModels.BaseViewModel" />
    /// <seealso cref="Microsoft.Maui.Controls.IQueryAttributable" />
    public partial class DetailPageViewModel : BaseViewModel, IQueryAttributable
    {
        /// <summary>
        /// The movie
        /// </summary>
        [ObservableProperty]
        private Movie _movie;

        /// <summary>
        /// The image name
        /// </summary>
        [ObservableProperty]
        private string _imageName;

        /// <summary>
        /// The toggled
        /// </summary>
        [ObservableProperty]
        private bool _toggled;

        /// <summary>
        /// The toggle command
        /// </summary>
        [ObservableProperty]
        private ICommand _toggleCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailPageViewModel" /> class.
        /// </summary>
        public DetailPageViewModel()
        {
            Toggled = Preferences.Get("ToggleImage", false);
            ToggleCommand = new Command(Toggle);
        }

        /// <summary>
        /// Applies the query attributes.
        /// </summary>
        /// <param name="query">The query.</param>
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("Movie"))
            {

                Movie = (Movie)query["Movie"];
                ImageName = Toggled ? Movie.BackdropPath : Movie.PosterPath;
            }
        }

        /// <summary>
        /// Toggles the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void Toggle(object obj)
        {
            if (obj is ToggledEventArgs args)
            {
                Preferences.Set("ToggleImage", args.Value);
                ImageName = args.Value ? Movie.BackdropPath : Movie.PosterPath;
            }
        }
    }
}
