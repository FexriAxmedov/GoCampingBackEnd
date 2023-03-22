using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoCamping.DAL.DBModel
{
    public class PriceFilterModel:BaseEntity
    {
        public List<PriceRange> PriceRanges { get; set; }
        public List<int> SelectedPriceRangeIds { get; set; }
    }
}

