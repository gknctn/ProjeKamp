using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Blog
    {
        public Guid BlogID { get; set; }
        public string BlogName { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
		public Guid? WriterID { get; set; }
		public Writer Writer{ get; set; }
		public List<Comment> Comments { get; set; }
    }
}
