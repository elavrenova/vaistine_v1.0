using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vaistine.Models;

namespace Vaistine.Areas.Docs.Models
{
    public class GoodDoc : BaseClass
    {
        public Guid FromStore { get; set; }
        public Guid ToStore { get; set; }
        public DateTime Date { get; set; }
        public Guid FromCag { get; set; }
        public Guid ToCag { get; set; }
    }
}
