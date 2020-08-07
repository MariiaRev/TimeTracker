using System.ComponentModel.DataAnnotations;

namespace Devox_Test.Models
{
    public class ActivityType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}