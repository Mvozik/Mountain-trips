using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WycieczkiGórskie.Shared.Dtos;
using WycieczkiGórskie.Shared.Entities;

namespace WycieczkiGórskie.Shared.Services.IServices
{
    public interface ITourService
    {
        Task<List<Tour>> GetUserTours();
        Task<Tour> GetTourById(int id);
        Task<Tour> PostTour(PostTourDto postTourDto);
        Task<int> DeleteTour(int id);
        Task<bool> PostPhoto(PostPhoto postPhoto);
        Task<bool> PostVideo(PostPhoto postVideo);
    }
}
