using System.ComponentModel.DataAnnotations;
namespace BookingService.Models
{
    public class BookingServiceItem
    {
        [Key]
        //id, no.of people, fullname, length of stay, destination
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(64, ErrorMessage = "Length of Name cannot be greater than 64 characters")]
        [MinLength(2, ErrorMessage = "Length of Name cannot be less than 2 characters")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Number of people is required")]
        public int? NumberOfPeople { get; set; }
        [Required(ErrorMessage = "Destination is required")]
        public string? Destination { get; set; }
        [Required(ErrorMessage = "Length Of Stay is required")]
        public int? LengthOfStay { get; set; }
    }
}