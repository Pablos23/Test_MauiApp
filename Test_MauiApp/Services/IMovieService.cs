using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_MauiApp.Models.DTO;

namespace Test_MauiApp.Services
{
    public interface IMovieService
    {
        Task<MovieResponse> GetmovieList(int page);
    }
}
