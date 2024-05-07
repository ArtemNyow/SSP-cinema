namespace Domain.Models
{
    public class SessionFilterSearch
    {
        public TimeOnly? TimeFrom { get; set; }
        public TimeOnly? TimeTo { get; set; }     
        public DateOnly? DateFrom { get; set; }
        public DateOnly? DateTo { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? HallNumber { get; set; }
        public string? MovieGenre { get; set; }
        public string? MovieTitle { get; set; }

        public SessionFilterSearch() { }

        public SessionFilterSearch(
            TimeOnly? timeFrom, 
            TimeOnly? timeTo, 
            DateOnly? dateFrom, 
            DateOnly? dateTo, 
            int? minPrice, 
            int? maxPrice, 
            int hallNumber, 
            string movieGenre, 
            string movieTitle)
        {
            TimeFrom = timeFrom;
            TimeTo = timeTo;
            DateFrom = dateFrom;
            DateTo = dateTo;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            HallNumber = hallNumber;
            MovieGenre = movieGenre;
            MovieTitle = movieTitle;
        }
    }
}
