
# DetailPageViewModel

## Attributes and Base Classes:
- The class inherits from `BaseViewModel`, which likely provides common properties and methods for all ViewModels.
- It implements `IQueryAttributable` to receive data when navigating between pages in a MAUI Shell app.

## Properties:
- **_movie:** Represents the movie currently being displayed.
- **_imageName:** Stores the image source, which toggles between the poster and backdrop image.
- **_toggled:** Indicates whether the toggle switch is on or off.
- **_toggleCommand:** Command used to handle toggle events.

## Constructor:
- Initializes the `Toggled` property by reading the toggle state from preferences.
- Initializes the `ToggleCommand` with a method reference to the `Toggle` method.

## Methods:
- **ApplyQueryAttributes:** This method is called when navigating to the detail page to set the `Movie` property using the query dictionary passed as a parameter. It also sets the `ImageName` based on the toggle state.
- **Toggle:** Updates the `ImageName` property based on the toggle switch state. Saves the state in preferences for persistence.

## Usage
- **ViewModel Initialization:** The ViewModel initializes the `Toggled` property based on saved preferences and sets the command.
- **Toggle Handling:** The `Toggle` method changes the image based on the toggle switch state and saves this state to preferences.
- **Query Attributes:** The `ApplyQueryAttributes` method allows passing data (like the movie object) when navigating to this page.

## Summary
The `DetailPageViewModel` uses `CommunityToolkit.Mvvm` to simplify property and command implementations. It manages the page's state based on query attributes passed from the navigation and toggles between two images based on user interaction, while saving the toggle state to preferences for persistence.

# MainPageViewModel 

## Attributes and Base Classes:
- The class inherits from `BaseViewModel`, which likely provides common properties and methods for all ViewModels.

## Fields:
- **_movieService:** A reference to the movie service used for fetching movie data.
- **_movies:** An observable collection of `Movie` objects to store fetched movies.
- **_currentPage:** The current page of movies being loaded.
- **_totalPages:** The total number of pages available.

## Properties:
- **Movies:** The observable collection of `Movie` objects, which updates the UI when the data changes.
- **RemainingItemsThresholdReachedCommand:** Command to trigger loading more items when reaching the end of the list.
- **AppearingCommand:** Command triggered when the page appears, for initial data loading.
- **OptionSelectedCommand:** Command to handle the selection of a movie from the list.

## Constructor:
- The constructor initializes the `Movies` collection and assigns commands to their corresponding methods. It also sets the `_movieService` to the provided instance.

## Methods:
- **OptionSelected:** Handles movie selection from the list. It navigates to the detail page with the selected movie.
- **Appearing:** Triggered when the page appears, it loads the initial set of movies.
- **RemainingItemsThresholdReached:** Triggered when the user scrolls to the bottom of the list, it loads more items.
- **LoadMoreItems:** Asynchronously loads more movies by fetching from the service and appending to the `Movies` collection. It checks if loading is already in progress or if there are no more pages to load.

## Usage
- **ViewModel Initialization:** The ViewModel initializes the movie collection and sets up commands to handle user interactions.
- **Movie Loading:** The `LoadMoreItems` method loads movies in batches and updates the `Movies` collection.
- **Navigation:** The `OptionSelected` method handles navigation to the detail page when a movie is selected, passing the selected movie as a parameter.

## Summary
The `MainPageViewModel` class uses the movie service to fetch and manage a paginated list of movies. It uses commands to handle appearing, scrolling, and item selection events.
