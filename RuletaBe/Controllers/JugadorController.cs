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
    public class JugadorController : Controller
    {
        private readonly AppDbContext context;
        public JugadorController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.JUGADOR.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{ID}", Name = "GetJugador")]
        public ActionResult Get(int id)
        {
            try
            {
                var ruleta = context.JUGADOR.FirstOrDefault(g => g.ID_JUGADOR == id);
                return Ok(ruleta);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] JUGADOR ruleta)
        {
            try
            {
                context.JUGADOR.Add(ruleta);
                context.SaveChanges();
                return CreatedAtRoute("GetJugador", new { id = ruleta.ID_JUGADOR }, ruleta);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] JUGADOR ruleta)
        {
            try
            {
                if (ruleta.ID_JUGADOR == id)
                {
                    context.Entry(ruleta).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetJugador", new { id = ruleta.ID_JUGADOR }, ruleta);
                }
                else
                {
                    return BadRequest("No se encontro el jugador " + id);
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
                var ruleta = context.JUGADOR.FirstOrDefault(g => g.ID_JUGADOR == id);
                if (ruleta != null)
                {
                    context.JUGADOR.Remove(ruleta);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest("No se elimino el jugador" + id);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
