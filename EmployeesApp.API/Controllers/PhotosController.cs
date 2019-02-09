using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EmployeesApp.API.Data;
using EmployeesApp.API.Dtos;
using EmployeesApp.API.Helpers;
using EmployeesApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EmployeesApp.API.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/photos")]
    [ApiController]

    public class PhotosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeAppRepository _repo;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly Cloudinary _cloudinary;
        public PhotosController(IMapper mapper, IEmployeeAppRepository repo, IOptions<CloudinarySettings>
        cloudinaryConfig)
        {
            _repo = repo;
            _mapper = mapper;
            _cloudinaryConfig = cloudinaryConfig;

            Account acc = new Account(

                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);

        }

        [HttpGet("{id}", Name ="GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id) {

            var photoFromRepo = _repo.GetPhoto(id);
            var photo = _mapper.Map<PhotoForReturnDto>(photoFromRepo);            

        }

        [HttpPost]
        public async Task<IActionResult> AddPhotosForUser(int userId, PhotosForCreationDto photosForCreationDto)
        {

            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(userId);
            var file = photosForCreationDto.File;
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {

                using (var stream = file.OpenReadStream())
                {
                    var uploadParam = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                    };
                    uploadResult = _cloudinary.Upload(uploadParam);
                }

            }
            photosForCreationDto.PublicId = uploadResult.PublicId;
            photosForCreationDto.Url = uploadResult.Uri.ToString();
            var photo = _mapper.Map<Photo>(photosForCreationDto);

            if (!userFromRepo.Photos.Any(u => u.IsMain))
                photo.IsMain = true;

            userFromRepo.Photos.Add(photo);
            if (await _repo.SaveAll())
            {
                return Ok();
            }
            return BadRequest("Could not add the photo");
        }
    }
}