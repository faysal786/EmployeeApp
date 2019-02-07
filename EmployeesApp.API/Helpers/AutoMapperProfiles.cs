using System.Linq;
using AutoMapper;
using EmployeesApp.API.Dtos;
using EmployeesApp.API.Models;

namespace EmployeesApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailedDto>()
            .ForMember(dest => dest.PhotoUrl , opt => {
                opt.MapFrom (src => src.Photos.FirstOrDefault( p => p.IsMain).Url);
            })
            .ForMember(dest => dest.Age , opt =>  {
                opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
            });

            CreateMap<User, UserForListDto>()
             .ForMember(dest => dest.PhotoUrl , opt => {
                opt.MapFrom (src => src.Photos.FirstOrDefault( p => p.IsMain).Url);
            }) 
            .ForMember(dest => dest.Age , opt =>  {
                opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
            }); 
            CreateMap<Photo, PhotosForDetailedDto>();     
            CreateMap<UserForUpdateDto,User>();      
        }
    }
}