﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vaistine.Areas.Docs.Models;
using Vaistine.Areas.Stores.Models;
using Vaistine.Models;

namespace Vaistine.Areas.Cags.Models
{
    public class Cag : DescrClass
    {
        public ICollection<Store> Stores { get; set; }
        public Guid? ParentId { get; set; }
        public virtual ICollection<Cag> Children { get; set; }
        public virtual Cag Parent { get; set; }
        public virtual ICollection<DocHead> InDocs { get; set; }
        public virtual ICollection<DocHead> OutDocs { get; set; }

    }
}
