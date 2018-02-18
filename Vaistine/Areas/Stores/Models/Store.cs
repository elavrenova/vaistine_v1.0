using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vaistine.Areas.Cags.Models;
using Vaistine.Models;

namespace Vaistine.Areas.Stores.Models
{
    public class Store : DescrClass
    {
        public bool IsAccount { get; set; }
        public Guid OwnerId { get; set; }
        public virtual Cag Owner { get; set; }
    }
}
