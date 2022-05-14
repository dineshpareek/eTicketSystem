using eTicketSystem.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTicketSystem.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string RefId { get; set; }
        public string ImageURL { get; set; }

        public string Title { get; set; }
        
        public string fullTitle { get; set; }
        public string Description { get; set; }
        public string crew { get; set; }
        public int Year { get; set; }
        public int ImDbRatingCount { get; set; }
        public double ImDbRating { get; set; }
        public double Price { get; set; }
        
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

        //Cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
