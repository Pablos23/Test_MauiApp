
# Movie App

## Overview

The Movie App is a cross-platform mobile application developed using .NET MAUI. It allows users to browse and explore a collection of popular movies. Users can view details for each movie, including titles, release dates, overviews, and ratings.

## Features

- Browse through a list of popular movies.
- View detailed information for each movie.
- Toggle between movie posters and backdrop images.
- Persist user preferences between app sessions.

## Project Structure

### **DetailPageViewModel**

This ViewModel manages the state and behavior of the movie detail page.

**Attributes and Base Classes:**
- Inherits from `BaseViewModel`, providing common properties and methods.
- Implements `IQueryAttributable` to receive data when navigating.

**Properties:**
- `_movie`: Represents the movie currently being displayed.
- `_imageName`: Stores the image source for toggling between the poster and backdrop.
- `_toggled`: Indicates if the toggle switch is on or off.
- `_toggleCommand`: Command for handling toggle events.

**Constructor:**
- Initializes the `Toggled` property using preferences.
- Initializes the `ToggleCommand` method.

**Methods:**
- **ApplyQueryAttributes:** Sets the `Movie` property using navigation data and updates the `ImageName`.
- **Toggle:** Updates the `ImageName` based on the toggle state and saves this state to preferences.

### **MainPageViewModel**

Manages the state and behavior of the main movie list page.

**Attributes:**
- `_movieService`: Service for fetching movie data.
- `_movies`: An observable collection of `Movie` objects.
- `_currentPage`: The current page of movies being loaded.
- `_totalPages`: The total number of pages available.

**Properties:**
- **Movies:** Observable collection of movies.
- **RemainingItemsThresholdReachedCommand:** Command to load more movies.
- **AppearingCommand:** Command to load initial data on page appear.
- **OptionSelectedCommand:** Command for selecting a movie.

**Constructor:**
- Initializes the `Movies` collection and assigns commands.
- Sets the `_movieService` to the provided instance.

**Methods:**
- **OptionSelected:** Navigates to the detail page with the selected movie.
- **Appearing:** Loads the initial set of movies on page appear.
- **RemainingItemsThresholdReached:** Loads more movies on scroll.
- **LoadMoreItems:** Fetches and loads more movies.

### **CacheService Class**

Implements caching with an in-memory cache and SQLite database.

**Attributes and Properties:**
- `_defaultExpiration`: Default expiration (10 minutes).
- `_db`: SQLite database connection.
- `_cache`: In-memory cache.
- `DatabasePath`: Path to the SQLite database.
- `DatabaseFilename`: Database file name.
- `Flags`: SQLite open flags.

**Constructor:**
- Initializes SQLite connection and creates cache table.

**Methods:**
- **Set<T>**: Stores data with optional expiration.
- **Get<T>**: Retrieves data from the cache.
- **Exists**: Checks if a non-expired entry exists.
- **UpdateField<T>**: Updates cached data fields.

### **MovieService Class**

Fetches movie data from an API and caches results.

**Attributes:**
- `_httpClient`: HttpClient for API requests.
- `_cacheService`: CacheService for caching data.

**Constructor:**
- Initializes the `HttpClient` with the base address, JSON headers, and token.
- Sets the `_cacheService`.

**Methods:**
- **GetMovieList**: Fetches movies from the API and caches results.
