using System.ComponentModel.DataAnnotations;

namespace Hr_Management.Models
{
    public class LoginModule
    {
        [Key]
        public int EmpId { get; set; }
        public string Password { get; set; }
    }
}
