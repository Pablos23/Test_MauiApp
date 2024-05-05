using System.Windows.Input;
using Test_MauiApp.Models;
using Test_MauiApp.Services;
using Test_MauiApp.Utilities;

namespace Test_MauiApp.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Test_MauiApp.ViewModels.BaseViewModel" />
    public class MainPageViewModel : BaseViewModel
    {
        /// <summary>
        /// The movie service
        /// </summary>
        private readonly IMovieService _movieService;
        /// <summary>
        /// The movies
        /// </summary>
        private ExtendedObservableCollection<Movie> _movies = new ExtendedObservableCollection<Movie>();
        /// <summary>
        /// The current page
        /// </summary>
        private int _currentPage = 1;
        /// <summary>
        /// The total pages
        /// </summary>
        private int _totalPages;

        /// <summary>
        /// Gets or sets the movies.
        /// </summary>
        /// <value>
        /// The movies.
        /// </value>
        public ExtendedObservableCollection<Movie> Movies
        {
            get => _movies;
            set
            {
                SetProperty(ref _movies, value);
            }
        }
        /// <summary>
        /// Gets or sets the remaining items threshold reached command.
        /// </summary>
        /// <value>
        /// The remaining items threshold reached command.
        /// </value>
        public ICommand RemainingItemsThresholdReachedCommand { get; set; }
        /// <summary>
        /// Gets or sets the appearing command.
        /// </summary>
        /// <value>
        /// The appearing command.
        /// </value>
        public ICommand AppearingCommand { get; set; }
        /// <summary>
        /// Gets or sets the option selected command.
        /// </summary>
        /// <value>
        /// The option selected command.
        /// </value>
        public ICommand OptionSelectedCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        /// <param name="movieService">The movie service.</param>
        public MainPageViewModel(IMovieService movieService)
        {
            Movies = new ExtendedObservableCollection<Movie>();
            _movieService = movieService;
            AppearingCommand = new Command(Appearing);
            RemainingItemsThresholdReachedCommand = new Command(RemainingItemsThresholdReached);
            OptionSelectedCommand = new Command(OptionSelected);
        }

        /// <summary>
        /// Options the selected.
        /// </summary>
        /// <param name="obj">The object.</param>
        private async void OptionSelected(object obj)
        {
            if (obj is Movie movie)
            {
                await Shell.Current.GoToAsync($"{nameof(DetailPage)}", true, new Dictionary<string, object>
                {
                    { "Movie", movie }
                });
            }
        }

        /// <summary>
        /// Appearings the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        private async void Appearing(object obj)
        {
            await LoadMoreItems();
        }

        /// <summary>
        /// Remainings the items threshold reached.
        /// </summary>
        /// <param name="obj">The object.</param>
        private async void RemainingItemsThresholdReached(object obj)
        {
            await LoadMoreItems();
        }
        /// <summary>
        /// Loads the more items.
        /// </summary>
        public async Task LoadMoreItems()
        {
            if (IsBusy || _totalPages == _currentPage) return;
            IsBusy = true;

            var movieResponse = await _movieService.GetmovieList(_currentPage);
            _totalPages = movieResponse.TotalPages;
            Movies.AddRange(movieResponse.Results);

            _currentPage++;
            IsBusy = false;
        }
    }
}