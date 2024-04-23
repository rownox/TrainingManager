namespace WebApplication2.Models
{
    public class TrainingOrder
    {
        public int Id { get; set; }
        public string description { get; set; }
        public List<string> trainers { get; set; }
        public string trainee { get; set; }
        public DateOnly beginDate { get; set; }
        public DateOnly endDate { get; set; }
        public string location { get; set; }
        public string medium { get; set; }
    }
}
