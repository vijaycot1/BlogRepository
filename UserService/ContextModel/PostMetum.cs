using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.ContextModel
{
    public partial class PostMetum
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }

        public virtual Post Post { get; set; }
    }
}
