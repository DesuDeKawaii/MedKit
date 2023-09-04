using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using top_medkit_dblayer;
using top_medkit_models.Models;

namespace top_medkit_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private EntityGateway _db = new();

        [HttpGet]
        public IActionResult GetAllDrugs()
        {
            return Ok(new
            {
                status = "ok",
                MedKits = _db.GetDrugs().Select(x => new
                {
                    x.Id,
                    Name = x.DrugInfo.Name,
                    x.ExpirationDate,
                    AcceptanceMethod = x.AcceptanceMethod.Name,
                    x.Quantity,
                })
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetDrugById(Guid id)
        {
            var potentialDrug = _db.GetDrugs().FirstOrDefault(x => x.Id == id);
            if (potentialDrug != null)
                return NotFound(new
                {
                    status = "Fail",
                    message = $"Book with id {id} is not found!"
                });
            else
                return Ok(new
                {
                    status = "Ok",
                    dug = potentialDrug
                });
        }
        [HttpPost]
        public IActionResult PostDrug([FromBody] JObject drugJson)
        {
            try 
            {
                var drug = drugJson.ToObject<Drug>() ??
                    throw new Exception("Could not deserialize your object");
                _db.AddOrUpdate(drug);
                return Ok(new
                {
                    status = "Ok",
                    id = drug.Id
                });
            }
            catch (Exception E)
            {
                return BadRequest(new  
                {
                    status = "Fail",
                    message = E.Message
                });
            }
        }
    }
}
