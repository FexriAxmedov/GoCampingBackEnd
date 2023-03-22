using GoCamping.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoCamping.DAL.Dtos
{
    public class PriceFilterModelDto:BaseDto
    {
        public List<PriceRange> PriceRanges { get; set; }
        public List<int> SelectedPriceRangeIds { get; set; }
    }
}
