using eTicketSystem.Data.BaseRepo;
using System.ComponentModel.DataAnnotations;

namespace eTicketSystem.Models
{
    public class Producer : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePic { get; set; }
        public string Info { get; set; }
        public List<Movie> movies { get; set; } = new List<Movie>();
    }
}
