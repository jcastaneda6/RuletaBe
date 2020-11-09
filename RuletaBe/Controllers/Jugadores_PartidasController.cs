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
    public class Jugadores_PartidasController : Controller
    {
        private readonly AppDbContext context;
        public Jugadores_PartidasController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.JUGADORES_PARTIDAS.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{ID}", Name = "GetJugadoresPartidas")]
        public ActionResult Get(int id)
        {
            try
            {
                var ruleta = context.JUGADORES_PARTIDAS.FirstOrDefault(g => g.ID_JUGADORES_PARTIDAS == id);
                return Ok(ruleta);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] JUGADORES_PARTIDAS ruleta)
        {
            try
            {
                context.JUGADORES_PARTIDAS.Add(ruleta);
                context.SaveChanges();
                return CreatedAtRoute("GetJugadoresPartidas", new { id = ruleta.ID_JUGADORES_PARTIDAS }, ruleta);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] JUGADORES_PARTIDAS ruleta)
        {
            try
            {
                if (ruleta.ID_JUGADORES_PARTIDAS == id)
                {
                    context.Entry(ruleta).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetJugadoresPartidas", new { id = ruleta.ID_JUGADORES_PARTIDAS }, ruleta);
                }
                else
                {
                    return BadRequest("No se encontro el jugador-partida " + id);
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
                var ruleta = context.JUGADORES_PARTIDAS.FirstOrDefault(g => g.ID_JUGADORES_PARTIDAS == id);
                if (ruleta != null)
                {
                    context.JUGADORES_PARTIDAS.Remove(ruleta);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest("No se elimino el jugador-partida" + id);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
