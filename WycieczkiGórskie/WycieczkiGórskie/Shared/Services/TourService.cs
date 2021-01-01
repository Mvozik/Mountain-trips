using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WycieczkiGórskie.Shared.Data;
using WycieczkiGórskie.Shared.Dtos;
using WycieczkiGórskie.Shared.Entities;
using WycieczkiGórskie.Shared.Services.IServices;

namespace WycieczkiGórskie.Shared.Services
{
    public class TourService : ITourService
    {
        private IWebHostEnvironment _env;
        private readonly DataContext _dataContext;
        private readonly IUserService _userService;
        public TourService(DataContext dataContext, IUserService userService, IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _userService = userService;
            _env = env;
        }
        public async Task<int> DeleteTour(int id)
        {
            var entity = await _dataContext.Tours.FirstOrDefaultAsync(x => x.Id == id);
            if(entity==null)
            {
                return 0;
            }
            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
            return id;
        }

        public async Task<Tour> GetTourById(int id)
        {
            var tour = await _dataContext.Tours.Include(p => p.tourPhotos).FirstOrDefaultAsync(x => x.Id == id);
            return tour;
        }

        public async Task<List<Tour>> GetUserTours()
        {
            var user = await _userService.GetCurrentUserAsync();
            return await _dataContext.Tours.Where(x => x.UserId == user.Id).ToListAsync();
        }

        public async Task<bool> PostPhoto(PostPhoto postPhoto)
        {
            var tour = await _dataContext.Tours.FirstOrDefaultAsync(x => x.Id == postPhoto.TourId);
            if(tour==null)
            {
                return false;
            }

            var newEntity = new TourPhoto
            {
                TourId = tour.Id,
                Photo = await GetFileAsByteArrayAsync(postPhoto.TourPhoto),
                Tour = tour
            };

            var tourPhoto = await _dataContext.TourPhotos.AddAsync(newEntity);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Tour> PostTour(PostTourDto postTourDto)
        {
            var startDate = postTourDto.StartDate.Split("T"); ;
            var endDate = postTourDto.EndDate.Split("T"); ;

            var user = await _userService.GetCurrentUserAsync();
            var tour = new Tour
            {
                Days = postTourDto.Days,
                Distance = postTourDto.Distance,
                StartDate = startDate[0],
                EndDate = endDate[0],
                EndPlace = postTourDto.EndPlace,
                StartPlace = postTourDto.StartPlace,
                Name = postTourDto.Name,
                User = user
            };

            var entity = await _dataContext.Tours.AddAsync(tour);
            await _dataContext.SaveChangesAsync();
            return entity.Entity;
        }



        public async Task<bool> PostVideo(PostPhoto postVideo)
        {
            var tour = await _dataContext.Tours.FirstOrDefaultAsync(x => x.Id == postVideo.TourId);
            var pathName = Guid.NewGuid();
            var dir = _env.ContentRootPath;
            var fullPath = Path.Combine(dir, pathName + ".mp4");

            using (var filestream = new FileStream(fullPath,FileMode.Create,FileAccess.Write))
            {
                await postVideo.TourPhoto.CopyToAsync(filestream);
            }

            await _dataContext.TourVideo.AddAsync(new TourVideo { Tour = tour, Path = fullPath });

            await _dataContext.SaveChangesAsync();
            return true;
        }



        private async Task<byte[]> GetFileAsByteArrayAsync(IFormFile ProductPhoto)
        {
            if (ProductPhoto != null)
            {
                if (ProductPhoto.Length > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = ProductPhoto.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        await fs1.CopyToAsync(ms1);
                        p1 = ms1.ToArray();
                    }
                    return p1;
                }

            }
            return null;
        }

      
    }
}
