using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Domain.Entities
{
    public class CourseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
    }
}
