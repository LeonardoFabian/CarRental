namespace CarRental.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPerDay { get; set; }
        public int Passengers { get; set; }
        public int Luggages { get; set; }
        public decimal LateFeePerHour { get; set; }
    }
}
