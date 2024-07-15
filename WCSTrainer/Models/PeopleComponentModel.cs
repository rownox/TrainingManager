namespace WCSTrainer.Models {
    public class PeopleComponentModel {
        public List<object> Items { get; set; }
        public string DisplayMode { get; set; }
    }

    public class Person {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Groups { get; set; }
        public int Hours { get; set; }
    }

    public class Group {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
