using System.ComponentModel.DataAnnotations;

namespace CityInfoAPI.Models
{
    public class PointOfInterestForCreatingDto
    {
        [Required(ErrorMessage = "You should provide a name Value")]
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
