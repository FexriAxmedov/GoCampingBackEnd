using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoCamping.DAL.DBModel
{
    public class PriceFilterModel:BaseEntity
    {
        public List<PriceRange> PriceRanges { get; set; }
        [NotMapped]
        public List<int> SelectedPriceRangeIds { get; set; }
    }
}

