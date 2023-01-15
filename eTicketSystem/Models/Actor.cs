using eTicketSystem.Data.BaseRepo;
using System.ComponentModel.DataAnnotations;

namespace eTicketSystem.Models
{
    public class Actor : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string Name { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePic { get; set; }
        [Display(Name = "Info")]
        [Required(ErrorMessage = "Info is required")]
        public string Info { get; set; }
        public List<Actor_Movie> Actors_Movies { get; set; }= new List<Actor_Movie>();

    }
}
