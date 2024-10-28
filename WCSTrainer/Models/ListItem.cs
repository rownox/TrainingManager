namespace WCSTrainer.Models {
   public class ListItem {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
   }

   public class ListPartialModel {
      public List<ListItem> Items { get; set; }
      public int MaxCount { get; set; }
   }
}
