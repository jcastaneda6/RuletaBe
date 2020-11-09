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
    public class EstadoController : Controller
    {
        private readonly AppDbContext context;
        public EstadoController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.ESTADOS.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{ID}", Name = "GetEstado")]
        public ActionResult Get(int id)
        {
            try
            {
                var ruleta = context.ESTADOS.FirstOrDefault(g => g.ID_ESTADO == id);
                return Ok(ruleta);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] ESTADOS ruleta)
        {
            try
            {
                context.ESTADOS.Add(ruleta);
                context.SaveChanges();
                return CreatedAtRoute("GetEstado", new { id = ruleta.ID_ESTADO }, ruleta);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ESTADOS ruleta)
        {
            try
            {
                if (ruleta.ID_ESTADO == id)
                {
                    context.Entry(ruleta).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetEstado", new { id = ruleta.ID_ESTADO }, ruleta);
                }
                else
                {
                    return BadRequest("No se encontro el estado " + id);
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
                var ruleta = context.ESTADOS.FirstOrDefault(g => g.ID_ESTADO == id);
                if (ruleta != null)
                {
                    context.ESTADOS.Remove(ruleta);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest("No se elimino el estado" + id);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
