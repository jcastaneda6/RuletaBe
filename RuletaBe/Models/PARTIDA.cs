using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaBe.Models
{
    public class PARTIDA
    {
        [Key]
        public int ID_PARTIDA { get; set; }
        public int ID_RULETA { get; set; }
        /// <summary>
        /// ID JUGADOR GANADOR
        /// </summary>
        public int ID_JUGADOR { get; set; }

    }
}
