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
    }
}