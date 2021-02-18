using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.ContextModel
{
    public partial class PostTag
    {
        public long PostId { get; set; }
        public long TagId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
