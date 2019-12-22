using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    public class PromocjasController : ControllerBase
    {
        private s16372Context _context;
        public PromocjasController(s16372Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPromotions()
        {
            return Ok(_context.Promocja.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetPromotion(int id)
        {
            var promotion = _context.Promocja.FirstOrDefault(e => e.IdPromocja == id);
            if (promotion == null)
            {
                return NotFound();
            }
            return Ok(promotion);
        }
        [HttpPost]
        public IActionResult Create(Promocja newPromotion)
        {
            _context.Promocja.Add(newPromotion);
            _context.SaveChanges();
            return StatusCode(201, newPromotion);
        }
        [HttpPut("{idPromocji:int}")]
        public IActionResult Update(int idPromocji, Promocja updatePromotion)
        {
            var exist = _context.Promocja.FirstOrDefault(e => e.IdPromocja == idPromocji);
            if (exist == null)
            {
                return NotFound();
            }
            _context.Promocja.Attach(updatePromotion);
            _context.Entry(updatePromotion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatePromotion);
        }
        [HttpDelete("{idPromocji:int}")]
        public IActionResult Delete(int idPromocji)
        {
            var existed = _context.Promocja.FirstOrDefault(e => e.IdPromocja == idPromocji);
            if (existed == null)
            {
                return NotFound();
            }
            _context.Promocja.Remove(existed);
            _context.SaveChanges();

            return Ok();
        }
    }
}
