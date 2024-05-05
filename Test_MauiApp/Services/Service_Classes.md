
# CacheService

## Attributes and Base Classes:
- Implements the `ICacheService` interface.

## Fields:
- **_defaultExpiration:** Default cache expiration set to 10 minutes.
- **_db:** SQLite database connection object.
- **_cache:** In-memory cache dictionary to hold temporary data.
- **DatabasePath:** Path to the SQLite database file.
- **DatabaseFilename:** SQLite database filename.
- **Flags:** SQLite open flags for read/write and shared cache modes.

## Constructor:
- Initializes the `CacheService`, connects to the database, and creates the cache table if it doesn't exist.

## Methods:
- **Set:** Stores a key-value pair in the cache with an optional expiration.
- **Get:** Retrieves the value associated with the specified key from the cache.
- **Exists:** Checks if the cache contains a non-expired entry for the specified key.
- **UpdateField:** Updates a specific field of the cached data.



# MovieService

## Attributes and Base Classes:
- Implements the `IMovieService` interface.

## Fields:
- **_httpClient:** HttpClient used for API requests.
- **_cacheService:** Service for caching API responses.

## Constructor:
- Initializes the `MovieService`, sets up the HttpClient, and configures the authorization headers.

## Methods:
- **GetmovieList:** Retrieves a paginated list of movies, using the cache if possible.
