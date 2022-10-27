using System.ComponentModel.DataAnnotations;

namespace OrderTestWPF.DB
{
    public class Users
    { 
        [Key]
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
    }
}
