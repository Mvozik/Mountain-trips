using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WycieczkiGórskie.Shared.Dtos
{
    public class PostTourDto
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public double Days { get; set; }
        public double Distance { get; set; }
        public string StartPlace { get; set; }
        public string EndPlace { get; set; }
    }
}
