using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Movie>> GetMovies()
        {

        }

    }
}
