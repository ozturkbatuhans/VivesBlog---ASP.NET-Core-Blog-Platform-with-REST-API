using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivesBlog.Model.Dto
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;

        public class ArticleCreateDto
        {
            public string Title { get; set; } = string.Empty;
            public string Content { get; set; } = string.Empty;
            public int AuthorId { get; set; }
        }

        public class ArticleUpdateDto
        {
            public string Title { get; set; } = string.Empty;
            public string Content { get; set; } = string.Empty;
            public int AuthorId { get; set; }
        }
    }
}