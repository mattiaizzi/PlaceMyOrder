using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Domain.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }
        public String Email { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Password { get; set; }
        public int RoleId { get; set; }
        public virtual RoleEntity Role { get; set; }
    }
}
