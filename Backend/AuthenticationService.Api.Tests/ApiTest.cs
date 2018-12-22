using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Api.Tests
{
    public abstract class ApiTests
    {
        protected T GetResult<T>(ActionResult<T> response) where T : class
        {
            var result = (response.Result as OkObjectResult);
            var data = result.Value as T;
            return data;
        }
    }
}
