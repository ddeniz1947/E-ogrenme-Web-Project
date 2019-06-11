using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.Models
{
    public class checkFile
    {
        public bool isChecked { get; set; }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}