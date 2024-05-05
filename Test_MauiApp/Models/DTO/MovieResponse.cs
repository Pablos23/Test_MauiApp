using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_MauiApp.Models.DTO
{
    /// <summary>
    /// MovieResponse
    /// </summary>
    public partial class MovieResponse : ObservableObject
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        [JsonProperty("page")]
        [ObservableProperty]
        private long _page ;

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        [JsonProperty("results")]
        [ObservableProperty]
        private List<Movie> _results ;

        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        /// <value>
        /// The total pages.
        /// </value>
        [JsonProperty("total_pages")]
        [ObservableProperty]
        private int _totalPages ;

        /// <summary>
        /// Gets or sets the total results.
        /// </summary>
        /// <value>
        /// The total results.
        /// </value>
        [JsonProperty("total_results")]
        [ObservableProperty]
        private long _totalResults ;
    }
}
