using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaBe.Models
{
    public class RULETA
    {
        [Key]
        public int ID_RULETA { get; set; }
        public DateTime FECHA { get; set; }
        public int ID_ESTADO { get; set; }
    }
}
