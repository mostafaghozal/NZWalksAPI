using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalkTutorial.DTO;
using NZWalkTutorial.Repositories;

namespace NZWalkTutorial.Controllers
{
    [ApiController]
    [Route("Walks")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var walks = await walkRepository.GetAllAsync();
            var walksDTO = mapper.Map<List<DTO.Walk>>(walks);
            //Automapper maps DTO with model automatic
            return Ok(walksDTO);
        }


        /*
         * 
         * 
         *      [HttpGet]
        [Route("{Id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid Id)
        {
           var region = await regionRepository.GetAsync(Id);
           var regionDTO= mapper.Map<DTO.Region>(region);

            if (region == null)
            {
                return NotFound();
            }
             return Ok(regionDTO);  
        }

         */

        [HttpGet]
        [Route("{Id:guid}")]
        [ActionName("GetWalkasync")]
        public async Task<IActionResult> GetWalkasync(Guid Id)
        {
            var walkdomain = await walkRepository.GetAsync(Id);


            // convert domain to dto 

            var walkDTO = mapper.Map<DTO.Walk>(walkdomain);


            // return response
            if (walkdomain == null)
            {
                return NotFound();
            }
            return Ok(walkdomain);


        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] DTO.AddWalkRequest addWalkRequest)
        {
            // Convert DTO to domain obj

            var walkDomain = new Models.Domains.Walk
            {

                Length = addWalkRequest.Length,
                Name = addWalkRequest.Name,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkdifficulityId


            };
            //Pass domain obj to repo

            await walkRepository.AddAsync(walkDomain);

            //Convert domain obj to DTO

            var walkDTO = mapper.Map<DTO.Walk>(walkDomain);
            //Send DTO response back to client

            return CreatedAtAction(nameof(GetWalkasync), new { id = walkDTO.Id }, walkDTO);
        }




        [HttpPut]
        [Route("{Id:guid}")]

        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid Id, [FromBody] DTO.UpdateWalkReq updateWalkReq)
        {
            //Convert DTO to model

            var walkdomain = new Models.Domains.Walk()
            {

                Name = updateWalkReq.Name,
                Length = updateWalkReq.Length,
                WalkDifficultyId = updateWalkReq.WalkdifficulityId,
                RegionId = updateWalkReq.RegionId
            };



            //update region using repo

            walkdomain = await walkRepository.UpdateAsync(Id, walkdomain);
            //if null not found
            if (walkdomain == null) { return NotFound(); }
            //if ok convert model to DTO

            var walkDTO = new DTO.Walk
            {
                Id = walkdomain.Id,
                Length = walkdomain.Length,
                Name = walkdomain.Name,
                RegionId = walkdomain.RegionId,
                WalkdifficulityId = walkdomain.WalkDifficultyId
            };
            //return OK
            return Ok(walkDTO);

        }



        [HttpDelete]
        [Route("{Id:guid}")]

        public async Task<IActionResult> DeleteWalkAsync(Guid Id)
        {
            //get region from db
            var walk = await walkRepository.DeleteAsync(Id);


            // if not found

            if (walk == null) return NotFound();

            // if found
            else
            {
                var walkDTO = new DTO.Walk
                {
                    Id = walk.Id,
                    Length = walk.Length,
                    Name = walk.Name,
                    RegionId = walk.RegionId,
                    WalkdifficulityId = walk.WalkDifficultyId
                };
                return Ok(walkDTO);

            }
        }


    }
}

