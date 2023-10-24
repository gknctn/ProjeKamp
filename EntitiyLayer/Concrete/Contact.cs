﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Contact
    {
        public Guid ContactID{ get; set; }
        public string ContactUserName{ get; set; }
        public string ContactMail { get; set; }
        public string ContactSubject{ get; set; }
        public string ContactMessage{ get; set; }
        public DateTime ContactDate{ get; set; }
        public bool ContactStatus { get; set; }
    }
}
