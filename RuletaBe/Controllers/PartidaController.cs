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
    public class PartidaController : Controller
    {
        private readonly AppDbContext context;
        public PartidaController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.PARTIDA.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{ID}", Name = "GetPartida")]
        public ActionResult Get(int id)
        {
            try
            {
                var ruleta = context.PARTIDA.FirstOrDefault(g => g.ID_PARTIDA == id);
                return Ok(ruleta);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] PARTIDA partida)
        {
            try
            {
                context.PARTIDA.Add(partida);
                context.SaveChanges();
                return CreatedAtRoute("GetPartida", new { id = partida.ID_PARTIDA }, partida);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PARTIDA partida)
        {
            try
            {
                if (partida.ID_PARTIDA == id)
                {
                    context.Entry(partida).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPartida", new { id = partida.ID_PARTIDA }, partida);
                }
                else
                {
                    return BadRequest("No se encontro la partida " + id);
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
                var ruleta = context.PARTIDA.FirstOrDefault(g => g.ID_PARTIDA == id);
                if (ruleta != null)
                {
                    context.PARTIDA.Remove(ruleta);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest("No se elimino la partida " + id);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
