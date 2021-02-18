using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models
{
    public class BlogModel
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public bool? Published { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }

    public class CategoryModel
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
    }

    public class PostCommentModel
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public bool? Published { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }
    }
}
