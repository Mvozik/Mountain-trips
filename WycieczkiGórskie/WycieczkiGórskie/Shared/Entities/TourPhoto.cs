using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WycieczkiGórskie.Shared.Entities
{
    public class TourPhoto:BaseEntity
    {
        public byte[] Photo { get; set; }

        [ForeignKey("TourId")]
        public Tour Tour { get; set; }
        public int TourId { get; set; }
    }
}
