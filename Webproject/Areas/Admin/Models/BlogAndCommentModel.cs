using EntitiyLayer.Concrete;
using System.Collections.Generic;

namespace Webproject.Areas.Admin.Models
{
    public class BlogAndCommentModel
    {
        public Blog blog{ get; set; }
        public List<Comment> comments{ get; set; }
        public Comment comment { get; set; }

    }
}
