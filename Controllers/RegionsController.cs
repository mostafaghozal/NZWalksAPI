using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalkTutorial.Repositories;

namespace NZWalkTutorial.Controllers
{

    [ApiController]
    [Route("Regions")]
    public class RegionsController : Controller
    {

        // steps for dependcy injetion 
        //1 - privat readonly repo
        //2-ctor and inject
        //use function from repo that uses it's inner implemtation to call from dbcontext


        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;


        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles ="reader")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllAsync();
            var regionsDTO = mapper.Map<List<DTO.Region>>(regions);
            //Automapper maps DTO with model automatic
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        [ActionName("GetRegionAsync")]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetRegionAsync(Guid Id)
        {
            var region = await regionRepository.GetAsync(Id);
            var regionDTO = mapper.Map<DTO.Region>(region);

            if (region == null)
            {
                return NotFound(); //404
            }
            return Ok(regionDTO);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> AddRegionAsync(DTO.AddRegionReq addRegionReq)
        {
            //if (!ValidateAddRegionAsync(addRegionReq)) { return BadRequest(ModelState); }
            //Validate the request


            // 1- req DTO to model
            var region = new Models.Domains.Region()
            {
                Code = addRegionReq.Code,
                Name = addRegionReq.Name,
                Lat = addRegionReq.Lat,
                Long = addRegionReq.Long,
                Area = addRegionReq.Area,
                Population = addRegionReq.Population
            };

            //2- Pass details to Repository

            region = await regionRepository.AddAsync(region);



            //3-Convert back to DTO

            var regionsDTO = new DTO.Region
            {
                Id = region.Id,
                Code = addRegionReq.Code,
                Name = addRegionReq.Name,
                Lat = addRegionReq.Lat,
                Long = addRegionReq.Long,
                Area = addRegionReq.Area,
                Population = addRegionReq.Population
            };
            // gives http 201 status to let client know
            return CreatedAtAction(nameof(GetRegionAsync), new { Id = regionsDTO.Id }, regionsDTO);


        }


        [HttpDelete]
        [Route("{Id:guid}")]
        [Authorize]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> DeleteRegionAsync(Guid Id)
        {
            //get region from db
            var region = await regionRepository.DeleteAsync(Id);


            // if not found

            if (region == null) return NotFound();

            // if found
            else
            {
                var regionsDTO = new DTO.Region
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    Lat = region.Lat,
                    Long = region.Long,
                    Area = region.Area,
                    Population = region.Population
                };
                return Ok(regionsDTO);

            }
        }

        [HttpPut]
        [Route("{Id:guid}")]
        [Authorize]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid Id, [FromBody] DTO.UpdateRegionReq updateRegionReq)
        {
            //Convert DTO to model
            if (!ValidateUpdateRegionAsync(updateRegionReq)) { return BadRequest(ModelState); }
            var region = new Models.Domains.Region()
            {
                Code = updateRegionReq.Code,
                Name = updateRegionReq.Name,
                Lat = updateRegionReq.Lat,
                Long = updateRegionReq.Long,
                Area = updateRegionReq.Area,
                Population = updateRegionReq.Population
            };



            //update region using repo

            region = await regionRepository.UpdateAsync(Id, region);
            //if null not found
            if (region == null) return NotFound();
            //if ok convert model to DTO
            var regionsDTO = new DTO.Region
            {
                Id = region.Id,
                Code = updateRegionReq.Code,
                Name = updateRegionReq.Name,
                Lat = updateRegionReq.Lat,
                Long = updateRegionReq.Long,
                Area = updateRegionReq.Area,
                Population = updateRegionReq.Population
            };
            //return OK
            return Ok(regionsDTO);

        }




        #region Private Methods
        
        private bool ValidateAddRegionAsync(DTO.AddRegionReq addRegionReq)
        {
            if (addRegionReq == null)
            {
                ModelState.AddModelError(nameof(addRegionReq), $"{nameof(addRegionReq)} Region Cannot be null or empty or white space.");
            }

            if (string.IsNullOrWhiteSpace(addRegionReq.Code))
            {
                ModelState.AddModelError(nameof(addRegionReq.Code),$"{nameof(addRegionReq.Code)} Cannot be null or empty or white space.");
            }

            if (string.IsNullOrWhiteSpace(addRegionReq.Name))
            {
                ModelState.AddModelError(nameof(addRegionReq.Name), $"{nameof(addRegionReq.Code)} Cannot be null or empty or white space.");
            }
            if (addRegionReq.Area<=0)
            {
                ModelState.AddModelError(nameof(addRegionReq.Area), $"{nameof(addRegionReq.Area)} Cannot be less than or equal 0.");
            }
  
            if (ModelState.ErrorCount > 0)
                return false;
            else return true;
        }


        private bool ValidateUpdateRegionAsync(DTO.UpdateRegionReq updateRegionReq)
        {
            if (updateRegionReq == null)
            {
                ModelState.AddModelError(nameof(updateRegionReq), $"{nameof(updateRegionReq)} Region Cannot be null or empty or white space.");
            }

            if (string.IsNullOrWhiteSpace(updateRegionReq.Code))
            {
                ModelState.AddModelError(nameof(updateRegionReq.Code), $"{nameof(updateRegionReq.Code)} Cannot be null or empty or white space.");
            }

            if (string.IsNullOrWhiteSpace(updateRegionReq.Name))
            {
                ModelState.AddModelError(nameof(updateRegionReq.Name), $"{nameof(updateRegionReq.Name)} Cannot be null or empty or white space.");
            }
            if (updateRegionReq.Area <= 0)
            {
                ModelState.AddModelError(nameof(updateRegionReq.Area), $"{nameof(updateRegionReq.Area)} Cannot be less than or equal 0.");
            }

            if (ModelState.ErrorCount > 0)
                return false;
            else return true;
        }

        #endregion
    }
}
