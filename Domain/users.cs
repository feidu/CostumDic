using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
     public  class users
    {
         public virtual int uid { get; set; }
         public virtual string uname { get; set; }
         public virtual string pwd { get; set; }
         public virtual int power { get; set; }

    }
}
