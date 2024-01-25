using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
	public class Writer
	{
		public int WriterID { get; set; }
		public string WriterName { get; set; }
		public string WriterSurname { get; set; }
		public string WriterAbout { get; set; }
		public string WriterImage { get; set; }
		public string WriterMail { get; set; }
		public string Writerpassword { get; set; }
		public bool WriterStatus { get; set; }
		public List<Blog> Blogs { get; set; }

		public virtual ICollection<Message2> WriterSender {  get; set; }
		public virtual ICollection<Message2> WriterReceiver {  get; set; }

    }
}
