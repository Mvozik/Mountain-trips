using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WycieczkiGórskie.Shared.Entities;

namespace WycieczkiGórskie.Shared.Entities
{
    public class Tour:BaseEntity
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public double Days { get; set; }
        public double Distance { get; set; }
        public string StartPlace { get; set; }
        public string EndPlace { get; set; }
        public List<TourPhoto> tourPhotos { get; set; }
        public List<TourVideo> TourVideos { get; set; }
    }
}
