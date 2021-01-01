using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WycieczkiGórskie.Shared.Data;
using WycieczkiGórskie.Shared.Dtos;
using WycieczkiGórskie.Shared.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WycieczkiGórskie.Shared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
public class TourController : ControllerBase
{
        private readonly ITourService tourService;
        private readonly DataContext _dataContext;
        public TourController(ITourService tourService, DataContext dataContext)
        {
            this.tourService = tourService;
            _dataContext = dataContext;
        }

        [HttpGet]
         public async Task<IActionResult> GetAll()
         {
            var response = await tourService.GetUserTours();
            return Ok(response);
         }

         [HttpGet("{id}")]
         public async Task<IActionResult> Get(int id)
         {
            var response = await tourService.GetTourById(id);
            return Ok(response);

        }

        [HttpPost]
         public async Task<IActionResult> Post(PostTourDto postTourDto)
         {

            var response = await tourService.PostTour(postTourDto);
            return Ok(response.Id);

         }

        [HttpPost("photo")]
        public async Task<IActionResult> PostFile([FromForm] PostPhoto postPhoto)
        {

            var response = await tourService.PostPhoto(postPhoto);
            return Ok(response);

        }
        [HttpPost("video")]
        public async Task<IActionResult> PostVideoFile([FromForm] PostPhoto postPhoto)
        {

            var response = await tourService.PostVideo(postPhoto);
            return Ok(response);

        }

        [HttpGet("video")]
        public async Task<IActionResult> GetVideo(int id)
        {
            var entity = await _dataContext.TourVideo.FirstOrDefaultAsync(x => x.TourId == id);
            if(entity!=null)
            {
                var path = entity.Path;
                var memory = new MemoryStream();
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, "video/mp4", Path.GetFileName(path));
            }
            return Ok(null);

        }
        [HttpPut("{id}")]
         public async Task<IActionResult> Put()
         {
            return Ok("ok");

        }

        [HttpDelete("{id}")]
         public async Task<IActionResult> Delete(int id)
         {

            var response = tourService.DeleteTour(id);
            return Ok(response);

        }
    }
}
