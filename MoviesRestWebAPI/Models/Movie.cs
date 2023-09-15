using System.ComponentModel.DataAnnotations;

namespace MoviesRestWebAPI.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int RunningTime { get; set; }
        public string Genre { get; set; }
    }
}
