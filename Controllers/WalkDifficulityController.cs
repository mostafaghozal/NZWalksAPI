using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalkTutorial.DTO;
using NZWalkTutorial.Repositories;

namespace NZWalkTutorial.Controllers
{
    [ApiController]
    [Route ("WalkDifficulityController")]
    public class WalkDifficulityController : Controller
    {
        private readonly IWalkDifficulityRepository walkdifficulityrepository;
        private readonly IMapper mapper;

        public WalkDifficulityController(IWalkDifficulityRepository walkdifficulityrepository , IMapper mapper)
        {
            this.walkdifficulityrepository = walkdifficulityrepository;
            this.mapper = mapper;
        }

  

        [HttpGet]
        public async Task<IActionResult> GetAllWalkDifficulties()
        {

            var difficultiy = await walkdifficulityrepository.GetAllAsync();
            var diffDTO = mapper.Map < List<DTO.WalkDifficulity>>(difficultiy) ;

            return Ok(diffDTO);
            
        }


        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficulityById")]

        public async Task<IActionResult> GetWalkDifficulityById(Guid Id)
        {
            var diff= await walkdifficulityrepository.GetAsync(Id);
            if (diff == null) return NotFound();

            var walkDifficulityDTO= mapper.Map<DTO.WalkDifficulity>(diff);


            return Ok(walkDifficulityDTO);

        }


        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] DTO.AddWalkDiffReq addWalkdiffRequest)
        {
            // Convert DTO to domain obj

            var walkdiffDomain = new Models.Domains.WalkDifficulity
            {

                code = addWalkdiffRequest.code


            };
            //Pass domain obj to repo

            await walkdifficulityrepository.AddAsync(walkdiffDomain);

            //Convert domain obj to DTO

            var walkdiffDTO = mapper.Map<DTO.WalkDifficulity>(walkdiffDomain);
            //Send DTO response back to client

            return CreatedAtAction(nameof(GetWalkDifficulityById), new { id = walkdiffDTO.Id }, walkdiffDTO);
        }

        [HttpDelete]
        [Route("{Id:guid}")]

        public async Task<IActionResult> DeleteWalkDiffAsync(Guid Id)
        {
            //get region from db
            var walkdiff = await walkdifficulityrepository.DeleteAsync(Id);


            // if not found

            if (walkdiff == null) return NotFound();

            // if found
            else
            {
                var walkdiffDTO = new DTO.WalkDifficulity
                {
                    code = walkdiff.code
                };
                return Ok(walkdiffDTO);

            }
        }



        [HttpPut]
        [Route("{Id:guid}")]

        public async Task<IActionResult> UpdateWalkDiffAsync([FromRoute] Guid Id, [FromBody] DTO.UpdateWalkDiffReq updateWalkDiffReq)
        {
            //Convert DTO to model

            var walkdiffdomain = new Models.Domains.WalkDifficulity()
            {

                code = updateWalkDiffReq.code
            };



            //update region using repo

            walkdiffdomain = await walkdifficulityrepository.UpdateAsync(Id, walkdiffdomain);
            //if null not found
            if (walkdiffdomain == null) { return NotFound(); }
            //if ok convert model to DTO

            var walkdiffDTO = new DTO.WalkDifficulity
            {
                code = walkdiffdomain.code
            };
            //return OK
            return Ok(walkdiffDTO);

        }


    }
}
