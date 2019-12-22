using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlientsController : ControllerBase
    {
        private s16372Context _context;
        public KlientsController(s16372Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetKlients()
        {
            return Ok(_context.Klient.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetKlient(int id)
        {
            var klient = _context.Klient.FirstOrDefault(e => e.IdKlienta == id);
            if(klient == null)
            {
                return NotFound();
            }
            return Ok(klient);
        }
        [HttpPost]
        public IActionResult Create(Klient newKlient)
        {
            _context.Klient.Add(newKlient);
            _context.SaveChanges();
            return StatusCode(201, newKlient);
        }
        [HttpPut("{idKlienta:int}")]
        public IActionResult Update(int idKlienta, Klient updatedKlient)
        {
            var exist = _context.Klient.FirstOrDefault(e => e.IdKlienta == idKlienta);
            if(exist == null)
            {
                return NotFound();
            }
            _context.Klient.Attach(updatedKlient);
            _context.Entry(updatedKlient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedKlient);
        }
        [HttpDelete("{idKlienta:int}")]
        public IActionResult Delete(int idKlienta)
        {
            var existed = _context.Klient.FirstOrDefault(e => e.IdKlienta == idKlienta);
            if(existed == null)
            {
                return NotFound();
            }
            _context.Klient.Remove(existed);
            _context.SaveChanges();

            return Ok();
        }
    }
}