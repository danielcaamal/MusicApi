using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Title cannot be null or empty")]
        public string? Title { get; set; }
        public string? Language { get; set; }
        public string? Duration { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
