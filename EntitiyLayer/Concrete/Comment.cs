using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Comment
    {
        public Guid CommentId{ get; set; }
        public string CommentUserName{ get; set; }
        public string CommentTitle{ get; set; }
        public string CommentContent{ get; set; }
        public DateTime CommentDate{ get; set; }
        public bool CommentStatus{ get; set; }
        public Guid BlogID { get; set; }
        public Blog Blog{ get; set; }
    }
}
