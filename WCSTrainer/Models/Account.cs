namespace WCSTrainer.Models {
    public class Account {
        public int Id { get; set; }
        public int EmployeeID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PermissionLevel { get; set; }
    }
}
