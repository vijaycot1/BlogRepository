using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.ContextModel
{
    public partial class Tag
    {
        public Tag()
        {
            PostTags = new HashSet<PostTag>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
