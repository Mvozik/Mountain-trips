using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WycieczkiGórskie.Shared.Dtos
{
    public class PostPhoto
    {
       public int TourId { get; set; }
       public IFormFile TourPhoto { get; set; }

    }
}
