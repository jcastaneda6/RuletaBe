using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaBe.Models
{
    public class ESTADOS
    {
        [Key]
        public int ID_ESTADO { get; set; }
        public string ESTADO { get; set; }
    }
}
