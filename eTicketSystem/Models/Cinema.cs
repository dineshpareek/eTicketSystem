using eTicketSystem.Data.BaseRepo;
using System.ComponentModel.DataAnnotations;

namespace eTicketSystem.Models
{
    public class Cinema : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public List<Movie> movies { get; set; } = new List<Movie>();
    }
}
