using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ToHBL;
using ToHModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToHREST.Controllers
{
    //we're using attribute routing to specify what pattern to access for our route
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroBL _heroBL;
        private readonly IAmazonS3 _amazonS3;
        private readonly string bucketName = "uploaded-music-revmixer";
        private readonly string URLPath = "https://uploaded-music-revmixer.s3.amazonaws.com/";

        public HeroController(IHeroBL heroBL, IAmazonS3 amazonS3)
        {
            _heroBL = heroBL;
            _amazonS3 = amazonS3;
        }

        [HttpGet("{music}")]
        //[Route("GetFile/{uploaded-music-revmixer}")]
        public async Task<IActionResult> GetUploadedSongAsync(string music)
        {

            return Ok(URLPath + music);

            //now you process the response body

            //FileStream mp3File = new FileStream(music, FileMode.OpenOrCreate, FileAccess.ReadWrite);


        }




        /*

                    FileStream mp3File = new FileStream(music, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                    var br = new BinaryReader(mp3File);


                    var objResp = await _amazonS3.GetObjectAsync(bucketName, music);




                    await objResp.ResponseStream.CopyToAsync(mp3File);



                    return Ok(File(buff, "audio/mp3", $"{music}.mp3"));
        */







        // GET: api/<HeroController>
        [HttpGet]
        public async Task<IActionResult> GetHeroesAsync()
        {
            //we use status codes like OK to wrap our code
            return Ok(await _heroBL.GetHeroesAsync());
        }

        /*        // GET api/<HeroController>/Spiderman
                [HttpGet("{name}")]
                [Produces("application/json")]
                public async Task<IActionResult> GetHeroByNameAsync(string name)
                {
                    var hero = await _heroBL.GetHeroByNameAsync(name);
                    if (hero == null) return NotFound();
                    return Ok(hero);
                }
        */
        // POST api/<HeroController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddAHeroAsync([FromBody] Hero hero)
        {
            try
            {
                await _heroBL.AddHeroAsync(hero);
                return CreatedAtAction("AddAHero", hero);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHeroAsync([FromBody] Hero hero)
        {
            try
            {
                await _heroBL.UpdateHeroAsync(hero);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<HeroController>/Thanos
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteAsync(string name)
        {
            try
            {
                await _heroBL.DeleteHeroAsync(await _heroBL.GetHeroByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
