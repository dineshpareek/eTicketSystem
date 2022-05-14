using System.ComponentModel.DataAnnotations;

namespace eTicketSystem.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Name")]
        public string Name { get; set; }
        [Display(Name = "Profile Pic")] 
        public string ProfilePic { get; set; }
        [Display(Name = "Actor Info")] 
        public string Info { get; set; }
        public List<Actor_Movie> Actor_Movie { get; set; }

    }
}
