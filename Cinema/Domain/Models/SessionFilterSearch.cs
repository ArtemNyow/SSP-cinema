namespace Domain.Models
{
    public class SessionFilterSearch
    {
        public TimeOnly TimeFrom { get; set; }
        public TimeOnly TimeTo { get; set; }     
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int? HallNumber { get; set; }
        public string[] MovieGenres { get; set; } = Array.Empty<string>();
        public string? MovieTitle { get; set; }

        public SessionFilterSearch() { }

        public SessionFilterSearch(
            TimeOnly timeFrom, 
            TimeOnly timeTo, 
            DateOnly dateFrom, 
            DateOnly dateTo, 
            int minPrice, 
            int maxPrice, 
            int? hallNumber,
            string[] movieGenres, 
            string? movieTitle)
        {
            TimeFrom = timeFrom;
            TimeTo = timeTo;
            DateFrom = dateFrom;
            DateTo = dateTo;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            HallNumber = hallNumber;
            MovieGenres = movieGenres;
            MovieTitle = movieTitle;
        }
    }
}
