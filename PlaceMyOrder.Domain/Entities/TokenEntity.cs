using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Domain.Entities
{
    public class TokenEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public String Token { get; set; }
        [Required]
        public Boolean IsRevoked { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
