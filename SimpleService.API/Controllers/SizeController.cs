using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleService.Core;
using System.Threading.Tasks;

namespace SimpleService.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService sizeService;

        public SizeController(ISizeService sizeService)
        {
            this.sizeService = sizeService;
        }

        [HttpGet]
        public async Task<ActionResult<FileStructureSize>> GetSize(string path)
        {
            return await sizeService.GetSizeAsync(path);
        }
    }
}
