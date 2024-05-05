using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Test_MauiApp.Models
{
    /// <summary>
    /// Movie
    /// </summary>
    public partial class Movie : ObservableObject
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Movie"/> is adult.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adult; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("adult")]
        [ObservableProperty]
        private bool _adult;

        /// <summary>
        /// Gets or sets the backdrop path.
        /// </summary>
        /// <value>
        /// The backdrop path.
        /// </value>
        [JsonProperty("backdrop_path")]
        [ObservableProperty]
        private string _backdropPath;

        /// <summary>
        /// Gets or sets the genre ids.
        /// </summary>
        /// <value>
        /// The genre ids.
        /// </value>
        [JsonProperty("genre_ids")]
        [ObservableProperty]
        private List<long> _genreIds;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        [ObservableProperty]
        private long _id;

        /// <summary>
        /// Gets or sets the original language.
        /// </summary>
        /// <value>
        /// The original language.
        /// </value>
        [JsonProperty("original_language")]
        [ObservableProperty]
        private string _originalLanguage;

        /// <summary>
        /// Gets or sets the original title.
        /// </summary>
        /// <value>
        /// The original title.
        /// </value>
        [JsonProperty("original_title")]
        [ObservableProperty]
        private string _originalTitle;

        /// <summary>
        /// Gets or sets the overview.
        /// </summary>
        /// <value>
        /// The overview.
        /// </value>
        [JsonProperty("overview")]
        [ObservableProperty]
        private string _overview;

        /// <summary>
        /// Gets or sets the popularity.
        /// </summary>
        /// <value>
        /// The popularity.
        /// </value>
        [JsonProperty("popularity")]
        [ObservableProperty]
        private double _popularity;

        /// <summary>
        /// Gets or sets the poster path.
        /// </summary>
        /// <value>
        /// The poster path.
        /// </value>
        [JsonProperty("poster_path")]
        [ObservableProperty]
        private string _posterPath;

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        /// <value>
        /// The release date.
        /// </value>
        [JsonProperty("release_date")]
        [ObservableProperty]
        private DateTimeOffset _releaseDate;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [JsonProperty("title")]
        [ObservableProperty]
        private string _title;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Movie"/> is video.
        /// </summary>
        /// <value>
        ///   <c>true</c> if video; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("video")]
        [ObservableProperty]
        private bool _video;

        /// <summary>
        /// Gets or sets the vote average.
        /// </summary>
        /// <value>
        /// The vote average.
        /// </value>
        [JsonProperty("vote_average")]
        [ObservableProperty]
        private double _voteAverage;

        /// <summary>
        /// Gets or sets the vote count.
        /// </summary>
        /// <value>
        /// The vote count.
        /// </value>
        [JsonProperty("vote_count")]
        [ObservableProperty]
        private long _voteCount;
    }
}
