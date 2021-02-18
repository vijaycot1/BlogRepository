using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.ContextModel
{
    public partial class PostComment
    {
        public PostComment()
        {
            InverseParent = new HashSet<PostComment>();
        }

        public long Id { get; set; }
        public long PostId { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public bool? Published { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }

        public virtual PostComment Parent { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<PostComment> InverseParent { get; set; }
    }
}
