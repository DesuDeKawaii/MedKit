using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using top_medkit_dblayer;

namespace top_medkit_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedKitController : ControllerBase
    {
        private EntityGateway _db = new();

        [HttpGet]
        public IActionResult GetAllMedKits()
        {
            return Ok(new
            {
                status = "ok",
                MedKits = _db.GetMedKits().Select(x => new
                {
                    x.Id,
                    x.Name,
                    DrugCount = x.Drugs.Count
                })
            });
        }

        
    }
}
