using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.ContextModel
{
    public partial class Post
    {
        public Post()
        {
            InverseParent = new HashSet<Post>();
            PostCategories = new HashSet<PostCategory>();
            PostComments = new HashSet<PostComment>();
            PostMeta = new HashSet<PostMetum>();
        }

        public long Id { get; set; }
        public long AuthorId { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public bool? Published { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }

        public virtual User Author { get; set; }
        public virtual Post Parent { get; set; }
        public virtual ICollection<Post> InverseParent { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<PostMetum> PostMeta { get; set; }
    }
}
