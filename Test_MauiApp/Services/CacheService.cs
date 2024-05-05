using Newtonsoft.Json;
using SQLite;
using Test_MauiApp.Models;

namespace Test_MauiApp.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class CacheService : ICacheService
    {
        // Default cache expiration set to 10 minutes
        private readonly TimeSpan _defaultExpiration = TimeSpan.FromMinutes(10);

        // SQLite database connection object
        private readonly SQLiteConnection _db;

        // In-memory cache dictionary to hold temporary data
        private readonly Dictionary<string, (object data, DateTime expiration)> _cache = new();

        // Path to the SQLite database file
        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        // SQLite database filename
        public const string DatabaseFilename = "TodoSQLite.db3";

        // SQLite open flags for read/write and shared cache modes
        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |  // Open in read/write mode
            SQLite.SQLiteOpenFlags.Create |     // Create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.SharedCache; // Enable multi-threaded database access

        // Initialize CacheService and create the table if it doesn't exist
        public CacheService()
        {
            _db = new SQLiteConnection(DatabasePath);
            _db.CreateTable<CacheEntry>();
        }

        /// <summary>
        /// Stores a key-value pair in the cache with an optional expiration.
        /// </summary>
        /// <typeparam name="T">Type of the data to store.</typeparam>
        /// <param name="key">Unique key to identify the data.</param>
        /// <param name="data">Data to store in the cache.</param>
        /// <param name="expiration">Optional expiration time for the data.</param>
        public void Set<T>(string key, T data, TimeSpan? expiration = null)
        {
            var expirationTime = DateTime.UtcNow.Add(expiration ?? _defaultExpiration).Ticks;
            var jsonValue = JsonConvert.SerializeObject(data);

            // Create a new CacheEntry object to store in the database
            var entry = new CacheEntry
            {
                Key = key,
                Value = jsonValue,
                Expiration = expirationTime
            };

            // Insert or replace the entry in the SQLite database
            _db.InsertOrReplace(entry);
        }

        /// <summary>
        /// Retrieves the value associated with the specified key from the cache.
        /// </summary>
        /// <typeparam name="T">Type of the data to retrieve.</typeparam>
        /// <param name="key">Unique key identifying the data.</param>
        /// <returns>The data stored in the cache, or the default value if not found or expired.</returns>
        public T Get<T>(string key)
        {
            var entry = _db.Find<CacheEntry>(key);
            if (entry != null && DateTime.UtcNow.Ticks <= entry.Expiration)
            {
                // Deserialize and return the cached data if it exists and is not expired
                return JsonConvert.DeserializeObject<T>(entry.Value);
            }
            return default(T);
        }

        /// <summary>
        /// Checks if the cache contains a non-expired entry for the specified key.
        /// </summary>
        /// <param name="key">Unique key identifying the data.</param>
        /// <returns>True if a valid entry exists, otherwise false.</returns>
        public bool Exists(string key)
        {
            var entry = _db.Find<CacheEntry>(key);
            return entry != null && DateTime.UtcNow.Ticks <= entry.Expiration;
        }

        /// <summary>
        /// Updates a specific field of the cached data.
        /// </summary>
        /// <typeparam name="T">Type of the data to update.</typeparam>
        /// <param name="key">Unique key identifying the data.</param>
        /// <param name="updateAction">Action that modifies the data.</param>
        public void UpdateField<T>(string key, Action<T> updateAction)
        {
            var existingData = Get<T>(key);

            if (existingData != null)
            {
                // Modify the existing data with the update action
                updateAction(existingData);
                // Store the updated data back in the cache with a new expiration
                Set(key, existingData, TimeSpan.FromMinutes(5));
            }
        }
    }
}
