using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaBe.Models
{
    public class JUGADORES_PARTIDAS
    {
        [Key]
        public int ID_JUGADORES_PARTIDAS { get; set; }
        public int ID_JUGADOR { get; set; }
        public int ID_PARTIDA { get; set; }
    }
}
