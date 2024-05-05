namespace Test_MauiApp.Controls
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.Maui.Controls.StackLayout" />
    public class StarRating : StackLayout
    {
        /// <summary>
        /// The rating property
        /// </summary>
        public static readonly BindableProperty RatingProperty =
            BindableProperty.Create(nameof(Rating), typeof(double), typeof(StarRating), 0.0, propertyChanged: OnRatingChanged);

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public double Rating
        {
            get => (double)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        /// <summary>
        /// Called when [rating changed].
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        private static void OnRatingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is StarRating starRating)
            {
                starRating.UpdateStars((double)newValue);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StarRating"/> class.
        /// </summary>
        public StarRating()
        {
            Orientation = StackOrientation.Horizontal;
            UpdateStars(Rating);
        }

        /// <summary>
        /// Updates the stars.
        /// </summary>
        /// <param name="rating">The rating.</param>
        private void UpdateStars(double rating)
        {
            Children.Clear();

            var fiveStarRating = rating / 2;
            int fullStars = (int)fiveStarRating;
            bool halfStar = (fiveStarRating - fullStars) >= 0.5;

            for (int i = 0; i < 5; i++)
            {
                if (i < fullStars)
                    Children.Add(CreateStarImage("star_filled.png"));
                else if (i == fullStars && halfStar)
                    Children.Add(CreateStarImage("star_half.png"));
                else
                    Children.Add(CreateStarImage("star_empty.png"));
            }
        }

        /// <summary>
        /// Creates the star image.
        /// </summary>
        /// <param name="imageName">Name of the image.</param>
        /// <returns></returns>
        private Image CreateStarImage(string imageName)
        {
            return new Image
            {
                Source = ImageSource.FromFile(imageName),
                WidthRequest = 20,
                HeightRequest = 20
            };
        }
    }
}
