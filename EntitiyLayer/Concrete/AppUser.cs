using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }
        public bool Status { get; set; }

        public List<Blog> Blogs { get; set; }

        public virtual ICollection<Message2> MessageSender { get; set; }
        public virtual ICollection<Message2> MessageReceiver { get; set; }

    }
}
