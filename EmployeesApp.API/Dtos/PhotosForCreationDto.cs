using System;
using Microsoft.AspNetCore.Http;

namespace EmployeesApp.API.Dtos
{
    public class PhotosForCreationDto
    {
         public IFormFile File {get;set;}        
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }        
        public string PublicId { get; set; }      
        public PhotosForCreationDto()
        {
            DateAdded = DateTime.Now;
        }
       
    }
}