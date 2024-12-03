public class LocationCategory {
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   public List<Location> Locations { get; set; } = new List<Location>();
}