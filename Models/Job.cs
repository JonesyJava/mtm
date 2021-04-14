namespace mtm.Models
{
    public class Job
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double? Price { get; set; }

        public string Name { get; set; }
    }
    public class BidViewModel : Job
    {
        public int BidId { get; set; }
    }
}