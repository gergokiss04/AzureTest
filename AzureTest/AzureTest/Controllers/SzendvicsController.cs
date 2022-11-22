using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AzureTest.Models;

namespace AzureTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SzendvicsController : ControllerBase
    {
        public static List<Szendvics> Szendvicsek = new List<Szendvics>();

        [HttpGet]

        public IActionResult GetSzendvicsek()
        {
            Szendvics szendvics1 = new Szendvics();
            szendvics1.ID = 1;
            szendvics1.Nev = "Tojásos";
            szendvics1.Felvagott = "Túrista";
            szendvics1.Vaj = "Tea";
            szendvics1.Zoldseg = "Paradicsom";

            Szendvics szendvics2 = new Szendvics();
            szendvics2.ID = 2;
            szendvics2.Nev = "Párizsis";
            szendvics2.Felvagott = "Zala felvágott";
            szendvics2.Vaj = "Rama";
            szendvics2.Zoldseg = "paprika";

            Szendvicsek.Add(szendvics1);
            Szendvicsek.Add(szendvics2);

            return Ok(Szendvicsek);
            //return StatusCode(200,Szendvicsek);
        }

        [HttpPost]
        public IActionResult PostSzendvicsek()
        {
            Szendvics szendvics = new Szendvics();
            szendvics.ID = 3;
            szendvics.Nev = "Post Test szendvics";
            szendvics.Felvagott = "téli szalámi";
            szendvics.Vaj = "bords eve";
            szendvics.Zoldseg = "Uborka";

            try
            {
                Szendvicsek.Add(szendvics);
                return Ok("A szendvics hozzáadása megtörtént!");
            }
            catch (Exception e)
            {
                return BadRequest("A szendvics hozzáadása sikertelen! "+e.Message);
                //return StatusCode(401,"A szendvics hozzáadása sikertelen!"+e.Message);

            }


        }

        [HttpPut]

        public IActionResult PutSzendvicsek()
        {
            try
            {
                Szendvicsek[0].Nev = "Gőzöm sincs";
                return Ok("Adat módosítás megtörtént !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }

            
        }

        [HttpDelete]

        public IActionResult DeleteSzendvicsek()
        {
            try
            {
                Szendvicsek.RemoveAt(0);

                return Ok("Adat törlése sikeres volt.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
