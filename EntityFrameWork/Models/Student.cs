using System.ComponentModel.DataAnnotations;

namespace EntityFrameWork.Models
{
    public class Student
    {
        [Key]
        public int RoleNumber { get; set; }
        public string StudentName { get; set; }

        public string Address { get; set; }
    }
}
