using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HW1_EnesBayramAfsar1.Controllers
{
    [Route("api/phonebooks")]
    [ApiController]
    public class PhonebookController : ControllerBase
    {
        private static List<PhonebookModel> PhonebookList = new List<PhonebookModel>()
        {

            new PhonebookModel() { Id = 1, İsim = "Enes", Soyisim = "Afsar", Cinsiyet = "E", Telefon = "0553-853-18-03" },
            new PhonebookModel() { Id = 2, İsim = "Deneme", Soyisim = "Deneme", Cinsiyet = "K", Telefon = "0553-853-18-03" },
            new PhonebookModel() { Id = 3, İsim = "Deneme2", Soyisim = "Deneme2", Cinsiyet = "E", Telefon = "0553-853-18-03" }
        };


        private bool Compare(string? pattern, string property)
        {
            if (pattern == null || pattern.Length == 0)
            {
                return true;
            }
            return property.ToLower().Contains(pattern.ToLower());
        }

        private bool Compare(int? number, int property)
        {
            if (number == null)
            {
                return true;
            }
            return number == property;
        }
        [HttpGet]
        public IActionResult GetPhonebooks()
        {
            return Ok(PhonebookList);
        }
        [HttpGet("list")]
        public IActionResult GetPhonebooksFromQuery([FromQuery] int? id,  string isim, string soyisim, string cinsiyet, string telefon)
        {
            var filteredPhonebooks = PhonebookList.Where(x => Compare(id, x.Id) &&  
              Compare(isim, x.İsim) && Compare(soyisim, x.Soyisim) && Compare(cinsiyet, x.Cinsiyet) && Compare(telefon, x.Telefon));
            return Ok(filteredPhonebooks);
        }
        [HttpPut]
        public IActionResult UpdatePhonebook([FromBody] PhonebookModel phonebook)
        {
            if (ModelState.IsValid)
            {
                var upToUpdate = PhonebookList.FirstOrDefault(x => x.Id == phonebook.Id);
                if (upToUpdate != null)
                {
                    PhonebookList.Remove(upToUpdate);
                    PhonebookList.Add(phonebook);
                    return Created($"api/phonebooks/{phonebook.Id}", phonebook);
                }
                return BadRequest("Kayıt bulunamadı!");
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult AddPhonebook([FromBody] PhonebookModel phonebook)
        {
            if (ModelState.IsValid)
            {
                PhonebookList.Add(phonebook);
                return Created($"api/phonebooks/{phonebook.Id}", phonebook);
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult DeletePhonebook([FromQuery] int id)
        {
            var upToDelete = PhonebookList.FirstOrDefault(x => x.Id == id);
            if (upToDelete != null)
            {
                PhonebookList.Remove(upToDelete);
                return Ok();
            }
            return NotFound("Kayıt bulunamadı!");
        }

    }
}
