using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAC.Vuur.Model
{
    public class Query : Parameters
    {
    }

    public class ResourceEntry<T> : Bundle.EntryComponent where T : Resource
    {
        public new T Resource { get; set; }
    }
}