using System.ComponentModel.DataAnnotations;

namespace Task5._1.Core
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
