using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareAPI.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 characters.")]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
