using System.ComponentModel.DataAnnotations;

namespace VivesBlog.Model
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }
        [Required]
        public required string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public int AuthorId { get; set; }
        public Person? Author { get; set; }
    }
}
