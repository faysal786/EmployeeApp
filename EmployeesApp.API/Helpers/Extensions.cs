using System;
using Microsoft.AspNetCore.Http;

namespace EmployeesApp.API.Helpers
{
    public static class Extensions
    {
        // Add Error Headers to response to capture within app error state
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
        public static int CalculateAge(this DateTime thedatetime) {
            var age = DateTime.Today.Year - thedatetime.Year;
            if(thedatetime.AddYears(age) >  DateTime.Today)
            age--;
            return age; 
        }
    }
}