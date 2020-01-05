using LumosService.DAL;
using Microsoft.AspNetCore.Mvc;

namespace LumosService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        protected readonly LumosContext ctx;
        public DefaultController(LumosContext context)
        {
            ctx = context;
        }
    }
}