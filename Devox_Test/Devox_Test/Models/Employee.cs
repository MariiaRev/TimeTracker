using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devox_Test.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Sex { get; set; }               //1 - male, 0 - female
        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }
    }
}