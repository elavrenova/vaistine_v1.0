using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vaistine.Areas.Cags.Models;
using Vaistine.Areas.Stores.Models;
using Vaistine.Models;

namespace Vaistine.Areas.Docs.Models
{
    public class DocHead : DescrClass
    {
        public Guid FromStoreId { get; set; }
        public Guid ToStoreId { get; set; }
        public virtual Store FromStore { get; set; }
        public virtual Store ToStore { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public Guid FromCagId { get; set; }
        public Guid ToCagId { get; set; }
        public virtual Cag FromCag { get; set; }
        public virtual Cag ToCag { get; set; }

        public ICollection<DocLine> DocLines { get; set; }
    }
}
