﻿public class Location {
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   public ICollection<TrainingOrder> TrainingOrders { get; set; } = [];
   public int CategoryId { get; set; }
   public LocationCategory? Category { get; set; }
}