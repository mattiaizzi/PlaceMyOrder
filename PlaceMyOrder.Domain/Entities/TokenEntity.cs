using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Domain.Entities
{
    public class TokenEntity
    {
        public Guid Id { get; set; }
        public String Token { get; set; }
        public Boolean IsRevoked { get; set; }
        public String UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
