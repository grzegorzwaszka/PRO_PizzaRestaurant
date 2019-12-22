using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    public class ProduktsController : ControllerBase
    {
        private s16372Context _context;
        public ProduktsController(s16372Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetProdukts()
        {
            return Ok(_context.Produkt.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetProdukt(int id)
        {
            var produkt = _context.Produkt.FirstOrDefault(e => e.IdProdukt== id);
            if (produkt == null)
            {
                return NotFound();
            }
            return Ok(produkt);
        }
        [HttpPost]
        public IActionResult Create(Produkt newProdukt)
        {
            _context.Produkt.Add(newProdukt);
            _context.SaveChanges();
            return StatusCode(201, newProdukt);
        }
        [HttpPut("{idProduktu:int}")]
        public IActionResult Update(int idProduktu, Produkt updatedProdukt)
        {
            var exist = _context.Produkt.FirstOrDefault(e => e.IdProdukt == idProduktu);
            if (exist == null)
            {
                return NotFound();
            }
            _context.Produkt.Attach(updatedProdukt);
            _context.Entry(updatedProdukt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedProdukt);
        }
        [HttpDelete("{idProduktu:int}")]
        public IActionResult Delete(int idProduktu)
        {
            var existed = _context.Produkt.FirstOrDefault(e => e.IdProdukt == idProduktu);
            if (existed == null)
            {
                return NotFound();
            }
            _context.Produkt.Remove(existed);
            _context.SaveChanges();

            return Ok();
        }
    }
}
