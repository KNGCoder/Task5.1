using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5._1.Core
{
    public class User
    {
        [Key]
        public string UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Role> Roles { get; private set; } = new ObservableCollection<Role>();

    }
}
