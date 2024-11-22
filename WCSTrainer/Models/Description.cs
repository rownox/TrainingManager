using Microsoft.AspNetCore.Mvc;

namespace WCSTrainer.Models {
   public class Description {
      public int Id { get; set; }
      public int PageId { get; set; }
      public Lesson? Page { get; set; }
      public ContentType Type { get; set; }
      public string Content { get; set; } = string.Empty;
      public byte[]? Data { get; set; }
      public string? ContentType { get; set; } 
      public int Row { get; set; }
      public int Column { get; set; }
   }
}

public enum ContentType {
   Text,
   Image,
   Video
}