﻿using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.ContextModel
{
    public partial class Category
    {
        public Category()
        {
            InverseParent = new HashSet<Category>();
            PostCategories = new HashSet<PostCategory>();
        }

        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }

        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> InverseParent { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }
    }
}
