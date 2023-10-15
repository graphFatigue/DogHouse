using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse.Domain.Entity
{
    public class Dog: BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public string Color { get; set; }
        [Range(0, 50,
        ErrorMessage = "Please enter valid int Number")]
        public int TailLength { get; set; }
        [Range(0, 100,
        ErrorMessage = "Please enter valid int Number")]
        public int Weight { get; set; }
    }
}
