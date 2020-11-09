using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuletaBe.Context;
using RuletaBe.Models;

namespace RuletaBe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuletaController : Controller
    {
        private readonly AppDbContext context;
        public RuletaController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.RULETA.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{ID}", Name = "GetRuleta")]
        public ActionResult Get(int id)
        {
            try
            {
                var ruleta = context.RULETA.FirstOrDefault(g => g.ID_RULETA == id);
                return Ok(ruleta);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] RULETA ruleta)
        {
            try
            {
                context.RULETA.Add(ruleta);
                context.SaveChanges();
                return CreatedAtRoute("GetRuleta", new { id = ruleta.ID_RULETA }, ruleta);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RULETA ruleta)
        {
            try
            {
                if (ruleta.ID_RULETA == id)
                {
                    context.Entry(ruleta).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetRuleta", new { id = ruleta.ID_RULETA }, ruleta);
                }
                else
                {
                    return BadRequest("No se encontro la ruleta " + id);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var ruleta = context.RULETA.FirstOrDefault(g => g.ID_RULETA == id);
                if (ruleta != null)
                {
                    context.RULETA.Remove(ruleta);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest("No se elimino la ruleta" + id);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
