using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hr_Management.Models
{
    public class LoginModule
    {
        [Key]
        //[ForeignKey("RegisterModule")]
        public int EmpId { get; set; }
        public string Password { get; set; }

        //public RegisterModule Register { get; set; }
    }
}
