using Newtonsoft.Json;
using System.Net.Http.Headers;
using Test_MauiApp.Models.DTO;

namespace Test_MauiApp.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Test_MauiApp.Services.IMovieService" />
    public class MovieService : IMovieService
    {
        /// <summary>
        /// The HTTP client
        /// </summary>
        private readonly HttpClient _httpClient;
        /// <summary>
        /// The cache service
        /// </summary>
        private readonly ICacheService _cacheService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieService"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service.</param>
        public MovieService(ICacheService cacheService)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJhYzQxMGM5ZTc5ZGI4MWUxMTU0ZmM1YjRkYzIxYjlhNSIsInN1YiI6IjY2MzU1YWQ5OTlkNWMzMDEyMzU3OGNhZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.iQiqnV8yMW12mZZvKUNd1hW_H7eSleCPHOg8O0W_QuI");
            _cacheService = cacheService;
        }

        /// <summary>
        /// Getmovies the list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public async Task<MovieResponse> GetmovieList(int page)
        {
            var cacheKey = $"MoviesPage_{page}";

            // Check if the data exists in the cache and handle nulls
            var cachedData = _cacheService.Get<MovieResponse>(cacheKey);
            if (cachedData != null)
            {
                return cachedData;
            }

            // Fetch data from the API
            var response = await _httpClient.GetAsync($"discover/movie?include_adult=false&include_video=false&language=en-US&page={page}&sort_by=popularity.desc");

            // Ensure response is successful and handle nulls
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Handle nulls in the response content
                var result = !string.IsNullOrEmpty(jsonResponse)
                    ? JsonConvert.DeserializeObject<MovieResponse>(jsonResponse)
                    : null;

                // Only cache non-null data
                if (result != null)
                {
                    _cacheService.Set(cacheKey, result, TimeSpan.FromMinutes(5));
                }

                return result;
            }

            // Handle unsuccessful response
            return default;
        }
    }
}
