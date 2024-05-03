namespace Domain.Models
{
    public class Hall : BaseEntity
    {
        public int Number { get; set; }
        public int RowsCount { get; set; }
        public int RowsVipCount { get; set; }
        public int SeatsCountPerRow { get; set; }
        public int SeatsVipCountPerRow { get; set; }
        public List<Session> Sessions { get; set; } = new();
    }
}
