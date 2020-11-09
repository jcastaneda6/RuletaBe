using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaBe.Models
{
    public class JUGADOR
    {
        [Key]
        public int ID_JUGADOR { get; set; }
        public string NOMBRE { get; set; }
        public Double APUESTA { get; set; }
        public int NUMERO { get; set; }
    }
}
